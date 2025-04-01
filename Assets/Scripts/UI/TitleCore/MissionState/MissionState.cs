using System.Collections.Generic;
using System.Linq;
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
            private MissionMasterDataRepository _MissionMasterDataRepository => Owner._missionMasterDataRepository;
            private UserDataRepository _UserDataRepository => Owner._userDataRepository;
            private CatalogDataRepository _CatalogDataRepository => Owner._catalogDataRepository;
            private PlayFabShopManager _PlayFabShopManager => Owner._playFabShopManager;
            private CharacterMasterDataRepository _CharacterMasterDataRepository => Owner._characterMasterDataRepository;
            private WeaponMasterDataRepository _WeaponMasterDataRepository => Owner._weaponMasterDataRepository;
            private MissionView _View => (MissionView)Owner.GetView(State.Mission);
            private CommonView _CommonView => Owner._commonView;
            private MissionSpriteDataRepository _MissionSpriteDataRepository => Owner._missionSpriteDataRepository;

            private readonly Dictionary<int, MissionGrid> _missionGrids = new();
            private bool _isProgress;
            private CancellationToken _token;

            private const string CanGet = "Get";
            private const string InProgress = "In Progress";
            private const string ProgressBarText = " <#b3bedb>/ ";

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize();
            }

            private void Initialize()
            {
                _token = _View.GetCancellationTokenOnDestroy();
                GenerateMissionGrid();
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

            private void GenerateMissionGrid()
            {
                DestroyMissionGrids();
                var missionDatum = _UserDataRepository.GetMissionDatum();
                missionDatum = missionDatum.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                foreach (var (index, missionData) in missionDatum)
                {
                    var masterData = _MissionMasterDataRepository.GetMissionData(index);
                    var actionId = (GameCommonData.MissionActionId)masterData.Action;
                    var actionCount = masterData.ActionCount;
                    var rewardId = masterData.RewardId;
                    var missionGrid = Instantiate(_View.missionGrid, _View.gridParent);
                    var progress = missionData._progress;
                    progress = progress >= actionCount ? actionCount : progress;
                    _missionGrids[masterData.Index] = missionGrid;
                    missionGrid.missionImage.sprite = _MissionSpriteDataRepository.GetActionSprite(actionId);
                    missionGrid.progressSlider.maxValue = actionCount;
                    missionGrid.progressSlider.value = progress;
                    missionGrid.progressText.text = progress + ProgressBarText + actionCount;
                    missionGrid.missionText.text = GetExplanationText(missionData, masterData);
                    missionGrid.buttonText.text = progress >= actionCount ? CanGet : InProgress;
                    missionGrid.getButton.enabled = progress >= actionCount;
                    missionGrid.getButton.onClick.AddListener(() => OnClickGetMissionReward(masterData, missionGrid.getButton.gameObject));
                    missionGrid.rewardText.text = masterData.RewardAmount.ToString("D");
                    missionGrid.rewardImage.sprite = _MissionSpriteDataRepository.GetRewardSprite((GameCommonData.RewardType)rewardId);
                }
            }

            private string GetExplanationText(UserData.MissionData missionData, MissionMasterData masterData)
            {
                var actionCount = masterData.ActionCount;
                var actionId = masterData.Action;
                var explanation = masterData.Explanation.Replace("n", actionCount.ToString());
                if (GameCommonData.IsMissionsUsingCharacter(actionId))
                {
                    var characterId = missionData._characterId;
                    var characterName = _CharacterMasterDataRepository.GetCharacterData(characterId).Name;
                    explanation = explanation.Replace("x", characterName);
                }

                if (GameCommonData.IsMissionsUsingWeapon(actionId))
                {
                    var weaponId = missionData._weaponId;
                    var weaponName = _WeaponMasterDataRepository.GetWeaponData(weaponId).Name;
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
                    var errorText = _CommonView.purchaseErrorView.errorInfoText;
                    var rewardName = missionMasterData.RewardId.ToString();
                    var rewardData = _CatalogDataRepository.GetAddVirtualCurrencyItemData(rewardName);
                    await _PlayFabShopManager.TryPurchaseItem(rewardName, GameCommonData.CoinKey, 0, errorText);
                    if (rewardData == null)
                    {
                        _isProgress = false;
                        return;
                    }

                    var rewardSprite = _MissionSpriteDataRepository.GetRewardSprite((GameCommonData.RewardType)missionMasterData.RewardId);
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
                if (!_missionGrids.TryGetValue(missionId, out var grid))
                {
                    return;
                }

                Destroy(grid.gameObject);
                _missionGrids.Remove(missionId);
                await _UserDataRepository.RemoveMissionData(missionId);
            }

            private async UniTask AddMission()
            {
                await _UserDataRepository.AddMissionData();
                GenerateMissionGrid();
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