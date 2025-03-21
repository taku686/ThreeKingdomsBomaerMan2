using System.Collections.Generic;
using System.Threading;
using Assets.Scripts.Common.Data;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager.DataManager;
using Manager.NetworkManager;
using Repository;
using UniRx;
using UnityEngine;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class MissionState : StateMachine<TitleCore>.State
        {
            private const string CanGet = "Get";
            private const string InProgress = "In Progress";
            private const string ProgressBarText = " <#b3bedb>/ ";
            private MissionDataRepository _missionDataRepository;
            private UserDataRepository _userDataRepository;
            private CatalogDataRepository _catalogDataRepository;
            private PlayFabShopManager _playFabShopManager;
            private CharacterMasterDataRepository _CharacterMasterDataRepository => Owner._characterMasterDataRepository;
            private WeaponMasterDataRepository _WeaponMasterDataRepository => Owner._weaponMasterDataRepository;
            private MissionView _View => (MissionView)Owner.GetView(State.Mission);
            private CommonView _commonView;
            private Sprite _coinSprite;
            private Sprite _gemSprite;
            private readonly Dictionary<int, MissionGrid> _missionGrids = new();
            private bool _isProgress;
            private CancellationToken _token;

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize().Forget();
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
            }


            private async UniTask Initialize()
            {
                _missionDataRepository = Owner._missionDataRepository;
                _userDataRepository = Owner._userDataRepository;
                _catalogDataRepository = Owner._catalogDataRepository;
                _playFabShopManager = Owner._playFabShopManager;
                _commonView = Owner._commonView;
                _token = _View.GetCancellationTokenOnDestroy();
                await GenerateMissionGrid();
                InitializeButton();
                Owner.SwitchUiObject(State.Mission, true).Forget();
            }

            private void InitializeButton()
            {
                _View.backButton.onClick.RemoveAllListeners();
                _View.backButton.OnClickAsObservable()
                    .Take(1)
                    .SelectMany(_ => OnClickBack().ToObservable())
                    .Subscribe()
                    .AddTo(_token);
            }

            private async UniTask GenerateMissionGrid()
            {
                DestroyMissionGrids();
                _coinSprite = (Sprite)await Resources.LoadAsync<Sprite>(GameCommonData.VirtualCurrencySpritePath + "coin");
                _gemSprite = (Sprite)await Resources.LoadAsync<Sprite>(GameCommonData.VirtualCurrencySpritePath + "gem");
                var missionProgressDatum = _userDataRepository.GetMissionProgressDatum();
                foreach (var data in missionProgressDatum)
                {
                    var missionData = _missionDataRepository.GetMissionData(data.Key);
                    var actionCount = missionData.ActionCount;
                    var rewardData = _catalogDataRepository.GetAddVirtualCurrencyItemData(missionData.RewardId);
                    var missionGrid = Instantiate(_View.missionGrid, _View.gridParent);
                    var progressValue = data.Value;
                    progressValue = progressValue >= actionCount ? actionCount : progressValue;
                    _missionGrids[missionData.Index] = missionGrid;
                    missionGrid.progressSlider.maxValue = actionCount;
                    missionGrid.progressSlider.value = progressValue;
                    missionGrid.progressText.text = progressValue + ProgressBarText + actionCount;
                    missionGrid.missionText.text = GetExplanationText(missionData);
                    missionGrid.buttonText.text = progressValue >= actionCount ? CanGet : InProgress;
                    missionGrid.getButton.enabled = progressValue >= actionCount;
                    missionGrid.getButton.onClick.AddListener(() => OnClickGetMissionReward(missionData, missionGrid.getButton.gameObject));
                    if (rewardData == null)
                    {
                        continue;
                    }

                    missionGrid.rewardText.text = rewardData.price.ToString("D");
                    missionGrid.rewardImage.sprite = rewardData.vc == GameCommonData.CoinKey ? _coinSprite : _gemSprite;
                }
            }

            private string GetExplanationText(MissionMasterData missionData)
            {
                var actionCount = missionData.ActionCount;
                var actionId = missionData.Action;
                var characterId = missionData.CharacterId;
                var characterName = _CharacterMasterDataRepository.GetCharacterData(characterId).Name;
                var weaponId = missionData.WeaponId;
                var weaponName = _WeaponMasterDataRepository.GetWeaponData(weaponId).Name;
                var explanation = missionData.Explanation.Replace("n", actionCount.ToString());
                if (GameCommonData.IsMissionsUsingCharacter(actionId))
                {
                    explanation = explanation.Replace("x", characterName);
                }

                if (GameCommonData.IsMissionsUsingWeapon(actionId))
                {
                    explanation = explanation.Replace("x", weaponName);
                }

                return explanation;
            }

            private void OnClickGetMissionReward(MissionMasterData missionMasterData, GameObject button)
            {
                if (_isProgress)
                {
                    return;
                }

                _isProgress = true;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var errorText = _commonView.purchaseErrorView.errorInfoText;
                    var rewardData = _catalogDataRepository.GetAddVirtualCurrencyItemData(missionMasterData.RewardId);
                    await _playFabShopManager.TryPurchaseItem(missionMasterData.RewardId, GameCommonData.CoinKey, 0, errorText);
                    if (rewardData == null)
                    {
                        _isProgress = false;
                        return;
                    }

                    var rewardSprite = rewardData.vc == GameCommonData.CoinKey ? _coinSprite : _gemSprite;
                    await Owner.SetRewardUI(rewardData.price, rewardSprite);
                    await RemoveMission(missionMasterData.Index);
                    await AddMission();
                    await Owner.SetGemText();
                    await Owner.SetCoinText();
                    _isProgress = false;
                })).SetLink(button);
            }

            private async UniTask OnClickBack()
            {
                Owner._stateMachine.Dispatch((int)State.Main);
                var button = _View.backButton.gameObject;
                await Owner._uiAnimation.ClickScaleColor(button).ToUniTask(cancellationToken: _token);
            }

            private async UniTask RemoveMission(int missionId)
            {
                if (!_missionGrids.ContainsKey(missionId))
                {
                    return;
                }

                Destroy(_missionGrids[missionId].gameObject);
                _missionGrids.Remove(missionId);
                await _userDataRepository.RemoveMissionData(missionId);
            }

            private async UniTask AddMission()
            {
                await _userDataRepository.AddMissionData();
                await GenerateMissionGrid();
            }

            private void DestroyMissionGrids()
            {
                foreach (var missionGrid in _missionGrids)
                {
                    Destroy(missionGrid.Value.gameObject);
                }

                _missionGrids.Clear();
            }
        }
    }
}