using System;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager.NetworkManager;
using TitleCore.LoginBonusState;
using UI.Common;
using UnityEngine;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class LoginBonusState : StateMachine<TitleCore>.State
        {
            private UIAnimation uiAnimation;
            private LoginBonusView View => (LoginBonusView)Owner.GetView(State.LoginBonus);
            private MainView MainView => (MainView)Owner.GetView(State.Main);
            private UserDataRepository userDataRepository;
            private PlayFabShopManager playaFabShopManager;
            private GameObject focusObj;
            private const int Day4 = 3;
            private const int Day7 = 6;

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize().Forget();
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
                Destroy(focusObj);
            }

            private async UniTask Initialize()
            {
                uiAnimation = Owner._uiAnimation;
                userDataRepository = Owner._userDataRepository;
                playaFabShopManager = Owner._playFabShopManager;
                InitializeButton();
                await InitializeUIContent();
                SetupLoginImage();
                Owner.SwitchUiObject(State.LoginBonus, true).Forget();
            }

            private void InitializeButton()
            {
                var buttons = View.buttons;
                for (int i = 0; i < buttons.Length; i++)
                {
                    var index = i;
                    if (userDataRepository.GetLoginBonusStatus(index) != LoginBonusStatus.CanReceive)
                    {
                        continue;
                    }

                    buttons[i].onClick.RemoveAllListeners();
                    buttons[i].onClick.AddListener(() => OnClickRewardButton(index));
                }

                View.closeButton.onClick.RemoveAllListeners();
                View.rewardGetView.okButton.onClick.RemoveAllListeners();
                View.closeButton.onClick.AddListener(OnClickClosePanel);
                View.rewardGetView.okButton.onClick.AddListener(OnClickCloseRewardView);
            }

            private async UniTask InitializeUIContent()
            {
                View.purchaseErrorView.gameObject.SetActive(false);
                View.rewardGetView.gameObject.SetActive(false);
                await Owner.SetCoinText();
                await Owner.SetGemText();
            }


            private void SetupLoginImage()
            {
                var userData = userDataRepository.GetUserData();
                foreach (var login in userData.LoginBonus)
                {
                    if (GameCommonData.GetLoginBonusStatus(login.Value) != LoginBonusStatus.Received)
                    {
                        continue;
                    }

                    View.clearImages[login.Key].gameObject.SetActive(true);
                }

                var dayOfWeek = DateTime.Today.DayOfWeek;
                switch (dayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        GenerateFocusObj(1);
                        break;
                    case DayOfWeek.Monday:
                        GenerateFocusObj(2);
                        break;
                    case DayOfWeek.Tuesday:
                        GenerateFocusObj(3);
                        break;
                    case DayOfWeek.Wednesday:
                        GenerateFocusObj(4);
                        break;
                    case DayOfWeek.Thursday:
                        GenerateFocusObj(5);
                        break;
                    case DayOfWeek.Friday:
                        GenerateFocusObj(6);
                        break;
                    case DayOfWeek.Saturday:
                        GenerateFocusObj(0);
                        break;
                }
            }

            private void GenerateFocusObj(int index)
            {
                var parent = View.buttons[index].transform;
                focusObj = Instantiate(View.focusObj, parent);
            }

            private void OnClickRewardButton(int index)
            {
                var button = View.buttons[index].gameObject;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    //todo　購入処理
                    if (index is Day4 or Day7)
                    {
                        var day = index + 1;
                        var errorText = View.purchaseErrorView.errorInfoText;
                        var rewardView = View.rewardGetView;
                        var rewardViewObj = View.rewardGetView.gameObject;
                        var itemGetResult = await playaFabShopManager.TryPurchaseGacha(
                            GameCommonData.LoginBonusItemKey + day, GameCommonData.CoinKey, 0,
                            GameCommonData.GachaShopKey, rewardView, errorText);
                        if (!itemGetResult)
                        {
                            return;
                        }

                        rewardViewObj.transform.localScale = Vector3.zero;
                        rewardViewObj.SetActive(true);
                        await uiAnimation.Open(rewardViewObj.transform, GameCommonData.OpenDuration)
                            .AttachExternalCancellation(rewardViewObj.GetCancellationTokenOnDestroy());
                    }
                    else
                    {
                        var day = index + 1;
                        var errorText = View.purchaseErrorView.errorInfoText;
                        var rewardView = View.rewardGetView;
                        var rewardViewObj = View.rewardGetView.gameObject;
                        var itemGetResult =
                            await playaFabShopManager.TryPurchaseLoginBonusItem(day, GameCommonData.CoinKey, 0,
                                rewardView, errorText);
                        if (!itemGetResult)
                        {
                            return;
                        }

                        rewardViewObj.transform.localScale = Vector3.zero;
                        rewardViewObj.SetActive(true);
                        await uiAnimation.Open(rewardViewObj.transform, GameCommonData.OpenDuration)
                            .AttachExternalCancellation(rewardViewObj.GetCancellationTokenOnDestroy());
                    }

                    var result = await userDataRepository.SetLoginBonus(index, LoginBonusStatus.Received);
                    if (!result)
                    {
                        return;
                    }

                    await Owner.SetCoinText();
                    await Owner.SetGemText();
                    SetupLoginImage();
                })).SetLink(button);
            }

            private void OnClickClosePanel()
            {
                var button = View.closeButton.gameObject;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var panel = MainView.LoginBonusGameObjet.transform;
                    await uiAnimation.Close(panel, GameCommonData.CloseDuration)
                        .AttachExternalCancellation(panel.GetCancellationTokenOnDestroy());
                    panel.gameObject.SetActive(false);
                    Owner._stateMachine.Dispatch((int)State.Main);
                })).SetLink(button);
            }

            private void OnClickCloseRewardView()
            {
                var button = View.rewardGetView.okButton.gameObject;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var panel = View.rewardGetView.transform;
                    await uiAnimation.Close(panel, GameCommonData.CloseDuration)
                        .AttachExternalCancellation(panel.GetCancellationTokenOnDestroy());
                    ;
                    panel.gameObject.SetActive(false);
                })).SetLink(button);
            }
        }
    }
}