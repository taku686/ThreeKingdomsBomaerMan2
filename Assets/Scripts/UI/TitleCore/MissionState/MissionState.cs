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
            private PlayFabVirtualCurrencyManager _PlayFabVirtualCurrencyManager => Owner._playFabVirtualCurrencyManager;

            private readonly Dictionary<int, MissionGrid> _missionGrids = new();
            private bool _isProgress;
            private CancellationToken _token;


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
                missionDatum = missionDatum
                    .OrderBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);
                foreach (var (index, missionData) in missionDatum)
                {
                    var masterData = _MissionMasterDataRepository.GetMissionData(index);
                    var actionId = (GameCommonData.MissionActionId)masterData.Action;
                    var rewardId = masterData.RewardId;
                    var characterId = missionData._characterId;
                    var weaponId = missionData._weaponId;
                    var characterData = _CharacterMasterDataRepository.GetCharacterData(characterId);
                    var weaponData = _WeaponMasterDataRepository.GetWeaponData(weaponId);
                    var missionSprite = _MissionSpriteDataRepository.GetActionSprite(actionId);
                    var rewardSprite = _MissionSpriteDataRepository.GetRewardSprite((GameCommonData.RewardType)rewardId);
                    var grid = _View.GenerateGrid(missionData, masterData, characterData, weaponData, missionSprite, rewardSprite);
                    _missionGrids[masterData.Index] = grid;
                    grid.getButton.onClick.AddListener(() => OnClickGetMissionReward(masterData, grid.getButton.gameObject));
                }
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
                    var rewardId = missionMasterData.RewardId;
                    var rewardAmount = missionMasterData.RewardAmount;
                    var result = await GetRewardAsync(rewardId, rewardAmount);

                    if (result)
                    {
                        var rewardSprite = _MissionSpriteDataRepository.GetRewardSprite((GameCommonData.RewardType)missionMasterData.RewardId);
                        await Owner.SetRewardUI(rewardAmount, rewardSprite);
                        await RemoveMission(missionMasterData.Index);
                        await AddMission();
                        await Owner.SetGemText();
                        await Owner.SetCoinText();
                    }
                    else
                    {
                        errorText.text = "報酬の取得に失敗しました";
                        _CommonView.purchaseErrorView.gameObject.SetActive(true);
                    }

                    _isProgress = false;
                })).SetLink(button);
            }

            private async UniTask<bool> GetRewardAsync(int rewardId, int rewardAmount)
            {
                if (rewardId == (int)GameCommonData.RewardType.Coin)
                {
                    return await _PlayFabVirtualCurrencyManager.AddVirtualCurrency(GameCommonData.CoinKey, rewardAmount);
                }

                if (rewardId == (int)GameCommonData.RewardType.Gem)
                {
                    return await _PlayFabVirtualCurrencyManager.AddVirtualCurrency(GameCommonData.GemKey, rewardAmount);
                }

                if (rewardId == (int)GameCommonData.RewardType.Weapon)
                {
                    const int free = 0;
                    var result = await _PlayFabShopManager.AddRandomWeaponAsync(rewardAmount, free);
                    return result.Item1;
                }

                if (rewardId == (int)GameCommonData.RewardType.Character)
                {
                    return await _PlayFabShopManager.TryPurchaseRandomCharacters(rewardAmount);
                }

                return false;
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