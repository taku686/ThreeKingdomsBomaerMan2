using System.Collections.Generic;
using System.Threading;
using Assets.Scripts.Common.Data;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager.DataManager;
using Manager.NetworkManager;
using ModestTree;
using UI.Common;
using UniRx;
using UnityEngine;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class MissionState : StateMachine<TitleCore>.State
        {
            private const string CanGet = "Get";
            private const string InProgress = "In Progress";
            private const string ProgressBarText = " <#b3bedb>/ 100";
            private MissionDataManager missionDataManager;
            private UserDataManager userDataManager;
            private CatalogDataManager catalogDataManager;
            private PlayFabShopManager playFabShopManager;
            private MainView mainView;
            private MissionView missionView;
            private CommonView commonView;
            private UIAnimation uiAnimation;
            private Sprite coinSprite;
            private Sprite gemSprite;
            private readonly Dictionary<int, MissionGrid> missionGrids = new();
            private bool isProgress;
            private CancellationToken token;

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize().Forget();
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
            }


            private async UniTask Initialize()
            {
                missionDataManager = Owner.missionDataManager;
                userDataManager = Owner.userDataManager;
                catalogDataManager = Owner.catalogDataManager;
                playFabShopManager = Owner.playFabShopManager;
                mainView = Owner.mainView;
                missionView = Owner.missionView;
                commonView = Owner.commonView;
                uiAnimation = Owner.uiAnimation;
                token = missionView.GetCancellationTokenOnDestroy();
                await GenerateMissionGrid();
                InitializeButton();
                Owner.SwitchUiObject(State.Mission, true);
            }

            private void InitializeButton()
            {
                missionView.backButton.onClick.RemoveAllListeners();
                missionView.backButton.OnClickAsObservable()
                    .Take(1)
                    .SelectMany(_ => OnClickBack().ToObservable())
                    .Subscribe()
                    .AddTo(token);
            }

            private async UniTask GenerateMissionGrid()
            {
                DestroyMissionGrids();
                var coinSprite = await Resources.LoadAsync<Sprite>(GameCommonData.VirtualCurrencySpritePath + "coin");
                this.coinSprite = (Sprite)coinSprite;
                var gemSprite = await Resources.LoadAsync<Sprite>(GameCommonData.VirtualCurrencySpritePath + "gem");
                this.gemSprite = (Sprite)gemSprite;
                var missionProgressDatum = userDataManager.GetMissionProgressDatum();
                foreach (var data in missionProgressDatum)
                {
                    var missionData = missionDataManager.GetMissionData(data.Key);
                    var rewardData = catalogDataManager.GetAddVirtualCurrencyItemData(missionData.rewardId);
                    var missionGrid = Instantiate(missionView.missionGrid, missionView.gridParent);
                    var progressValue =
                        (int)(data.Value / (float)missionData.count * GameCommonData.MaxMissionProgress);
                    progressValue = progressValue >= GameCommonData.MaxMissionProgress
                        ? GameCommonData.MaxMissionProgress
                        : progressValue;
                    missionGrids[missionData.index] = missionGrid;
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
                    missionGrid.rewardImage.sprite = rewardData.vc == GameCommonData.CoinKey ? this.coinSprite : this.gemSprite;
                }
            }

            private void OnClickGetMissionReward(MissionData missionData, GameObject button)
            {
                if (isProgress)
                {
                    return;
                }

                isProgress = true;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var errorText = commonView.purchaseErrorView.errorInfoText;
                    var rewardData = catalogDataManager.GetAddVirtualCurrencyItemData(missionData.rewardId);
                    await playFabShopManager.TryPurchaseItem(missionData.rewardId, GameCommonData.CoinKey, 0,
                        errorText);
                    if (rewardData == null)
                    {
                        isProgress = false;
                        return;
                    }

                    var rewardSprite = rewardData.vc == GameCommonData.CoinKey ? coinSprite : gemSprite;
                    await Owner.SetRewardUI(rewardData.price, rewardSprite);
                    await RemoveMission(missionData.index);
                    await AddMission();
                    await Owner.SetGemText();
                    await Owner.SetCoinText();
                    isProgress = false;
                })).SetLink(button);
            }

            private async UniTask OnClickBack()
            {
                Owner.stateMachine.Dispatch((int)State.Main);
                var button = missionView.backButton.gameObject;
                await Owner.uiAnimation.ClickScaleColor(button).ToUniTask(cancellationToken: token);
            }

            private async UniTask RemoveMission(int missionId)
            {
                if (!missionGrids.ContainsKey(missionId))
                {
                    return;
                }

                Destroy(missionGrids[missionId].gameObject);
                missionGrids.Remove(missionId);
                await userDataManager.RemoveMissionData(missionId);
            }

            private async UniTask AddMission()
            {
                await userDataManager.AddMissionData();
                await GenerateMissionGrid();
            }

            private void DestroyMissionGrids()
            {
                foreach (var missionGrid in missionGrids)
                {
                    Destroy(missionGrid.Value.gameObject);
                }

                missionGrids.Clear();
            }
        }
    }
}