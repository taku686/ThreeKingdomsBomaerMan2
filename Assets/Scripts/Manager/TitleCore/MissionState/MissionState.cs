using System.Collections.Generic;
using Assets.Scripts.Common.Data;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager.DataManager;
using Manager.NetworkManager;
using ModestTree;
using UI.Common;
using UnityEngine;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class MissionState : State
        {
            private const string CanGet = "Get";
            private const string InProgress = "In Progress";
            private const string ProgressBarText = " <#b3bedb>/ 100";
            private MissionDataManager _missionDataManager;
            private UserDataManager _userDataManager;
            private CatalogDataManager _catalogDataManager;
            private PlayFabShopManager _playFabShopManager;
            private MainView _mainView;
            private MissionView _missionView;
            private CommonView _commonView;
            private UIAnimation _uiAnimation;
            private Sprite _coinSprite;
            private Sprite _gemSprite;
            private readonly Dictionary<int, MissionGrid> _missionGrids = new();
            private bool _inProgress;

            protected override void OnEnter(State prevState)
            {
                Initialize().Forget();
            }

            protected override void OnExit(State nextState)
            {
                DestroyMissionGrids();
            }


            private async UniTask Initialize()
            {
                _missionDataManager = Owner._missionDataManager;
                _userDataManager = Owner._userDataManager;
                _catalogDataManager = Owner._catalogDataManager;
                _playFabShopManager = Owner._playFabShopManager;
                _mainView = Owner.mainView;
                _missionView = Owner.missionView;
                _commonView = Owner.commonView;
                _uiAnimation = Owner._uiAnimation;
                await GenerateMissionGrid();
                InitializeButton();
                Owner.DisableTitleGameObject();
                OpenMissionPanel().Forget();
            }

            private void InitializeButton()
            {
                _missionView.backButton.onClick.RemoveAllListeners();
                _missionView.backButton.onClick.AddListener(OnClickBack);
            }

            private async UniTask OpenMissionPanel()
            {
                var panel = _mainView.MissionGameObject.transform;
                panel.localScale = Vector3.zero;
                panel.gameObject.SetActive(true);
                await _uiAnimation.Open(panel, GameCommonData.OpenDuration);
            }

            private async UniTask GenerateMissionGrid()
            {
                DestroyMissionGrids();
                var coinSprite = await Resources.LoadAsync<Sprite>(GameCommonData.VirtualCurrencySpritePath + "coin");
                _coinSprite = (Sprite)coinSprite;
                var gemSprite = await Resources.LoadAsync<Sprite>(GameCommonData.VirtualCurrencySpritePath + "gem");
                _gemSprite = (Sprite)gemSprite;
                var missionProgressDatum = _userDataManager.GetMissionProgressDatum();
                foreach (var data in missionProgressDatum)
                {
                    var missionData = _missionDataManager.GetMissionData(data.Key);
                    var rewardData = _catalogDataManager.GetAddVirtualCurrencyItemData(missionData.rewardId);
                    var missionGrid = Instantiate(_missionView.missionGrid, _missionView.gridParent);
                    var progressValue =
                        (int)(data.Value / (float)missionData.count * GameCommonData.MaxMissionProgress);
                    _missionGrids[missionData.index] = missionGrid;
                    missionGrid.progressSlider.maxValue = GameCommonData.MaxMissionProgress;
                    missionGrid.progressSlider.value = progressValue;
                    missionGrid.progressText.text = progressValue + ProgressBarText;
                    missionGrid.missionText.text = missionData.explanation;
                    missionGrid.buttonText.text =
                        progressValue >= GameCommonData.MaxMissionProgress ? CanGet : InProgress;
                    missionGrid.getButton.enabled = progressValue >= GameCommonData.MaxMissionProgress;
                    missionGrid.getButton.onClick.AddListener(() =>
                        OnClickGetMissionReward(missionData, missionGrid.getButton.gameObject));
                    if (rewardData == null)
                    {
                        continue;
                    }

                    missionGrid.rewardText.text = rewardData.price.ToString("D");
                    missionGrid.rewardImage.sprite = rewardData.vc == GameCommonData.CoinKey ? _coinSprite : _gemSprite;
                }
            }

            private void OnClickGetMissionReward(MissionData missionData, GameObject button)
            {
                if (_inProgress)
                {
                    return;
                }

                _inProgress = true;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var errorText = _commonView.purchaseErrorView.errorInfoText;
                    var result = await _playFabShopManager.TryPurchaseItem(missionData.rewardId,
                        GameCommonData.CoinKey, 0, errorText);
                    await RemoveMission(missionData.index);
                    await AddMission();
                    _inProgress = false;
                })).SetLink(button);
            }

            private void OnClickBack()
            {
                var button = _missionView.backButton.gameObject;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var missionView = _mainView.MissionGameObject.transform;
                    await _uiAnimation.Close(missionView, GameCommonData.CloseDuration);
                    Owner._stateMachine.Dispatch((int)Event.Main);
                })).SetLink(button);
            }

            private async UniTask RemoveMission(int missionId)
            {
                if (!_missionGrids.ContainsKey(missionId))
                {
                    return;
                }

                Destroy(_missionGrids[missionId].gameObject);
                _missionGrids.Remove(missionId);
                await _userDataManager.RemoveMissionData(missionId);
            }

            private async UniTask AddMission()
            {
                await _userDataManager.AddMissionData();
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