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
using UnityEngine.UI;
using UseCase;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class MissionState : StateMachine<TitleCore>.State
        {
            private MissionMasterDataRepository _MissionMasterDataRepository => Owner._missionMasterDataRepository;
            private UserDataRepository _UserDataRepository => Owner._userDataRepository;
            private CharacterMasterDataRepository _CharacterMasterDataRepository => Owner._characterMasterDataRepository;
            private WeaponMasterDataRepository _WeaponMasterDataRepository => Owner._weaponMasterDataRepository;
            private MissionView _View => (MissionView)Owner.GetView(State.Mission);
            private MissionSpriteDataRepository _MissionSpriteDataRepository => Owner._missionSpriteDataRepository;
            private PopupGenerateUseCase _PopupGenerateUseCase => Owner._popupGenerateUseCase;
            private RewardDataRepository _RewardDataRepository => Owner._rewardDataRepository;
            private GetRewardUseCase _GetRewardUseCase => Owner._getRewardUseCase;

            private readonly Dictionary<int, MissionGrid> _missionGrids = new();
            private bool _isProgress;
            private CancellationToken _token;


            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize();
            }

            private void Initialize()
            {
                Owner.SwitchUiObject(State.Mission, true, () =>
                {
                    _token = _View.GetCancellationTokenOnDestroy();
                    GenerateMissionGrid();
                    Subscribe();
                    InitializeVirtualCurrencyText().Forget();
                }).Forget();
            }

            private async UniTask InitializeVirtualCurrencyText()
            {
                await Owner.SetGemText();
                await Owner.SetCoinText();
            }

            private void Subscribe()
            {
                _View.backButton.OnClickAsObservable()
                    .Take(1)
                    .SelectMany(_ => OnClickBack().ToObservable())
                    .Subscribe()
                    .AddTo(_token);
            }

            private void GenerateMissionGrid()
            {
                DestroyMissionGrids();
                var missionDatum = _UserDataRepository.GetMissionDatum()
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
                    MissionGridSubscribe(masterData, grid.getButton);
                }
            }

            private void MissionGridSubscribe(MissionMasterData missionMasterData, Button button)
            {
                button.OnClickAsObservable()
                    .Select(_ => GetRewardViewModel(missionMasterData))
                    .SelectMany(viewModel => _PopupGenerateUseCase.GenerateRewardPopup(viewModel))
                    .SelectMany(_ => GetRewardAsync(missionMasterData).ToObservable())
                    .Subscribe(_ => { stateMachine.Dispatch((int)State.Reward, (int)State.Mission); })
                    .AddTo(button.gameObject);
            }

            private async UniTask GetRewardAsync(MissionMasterData missionMasterData)
            {
                var rewardResults = _RewardDataRepository.SetMissionReward(missionMasterData);
                await _GetRewardUseCase.InAsTask(rewardResults);
                await _UserDataRepository.RemoveMissionData(missionMasterData.Index);
                await _UserDataRepository.AddMissionData();
            }

            private RewardPopup.ViewModel GetRewardViewModel(MissionMasterData masterData)
            {
                var rewardAmount = masterData.RewardAmount;
                var rewardType = (GameCommonData.RewardType)masterData.RewardId;
                var rewardSprite = _MissionSpriteDataRepository.GetRewardSprite(rewardType);
                return new RewardPopup.ViewModel("", "", rewardSprite, rewardAmount);
            }

            private async UniTask OnClickBack()
            {
                Owner._stateMachine.Dispatch((int)State.Main);
                var button = _View.backButton.gameObject;
                await Owner._uiAnimation.ClickScaleColor(button).ToUniTask(cancellationToken: _token);
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