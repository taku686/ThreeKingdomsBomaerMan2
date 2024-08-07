using System;
using Assets.Scripts.Common.PlayFab;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager.NetworkManager;
using UI.Common;
using UnityEngine;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class LoginBonusState : StateMachine<TitleCore>.State
        {
            private UIAnimation _uiAnimation;
            private LoginBonus loginBonus;
            private Main main;
            private UserDataManager _userDataManager;
            private PlayFabLoginManager _playFabLoginManager;
            private PlayFabShopManager _playaFabShopManager;
            private GameObject _focusObj;
            private const int Day4 = 3;
            private const int Day7 = 6;

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize().Forget();
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
                Destroy(_focusObj);
            }

            private async UniTask Initialize()
            {
                _uiAnimation = Owner.uiAnimation;
                loginBonus = Owner.loginBonus;
                main = Owner.main;
                _userDataManager = Owner.userDataManager;
                _playFabLoginManager = Owner.playFabLoginManager;
                _playaFabShopManager = Owner.playFabShopManager;
                InitializeButton();
                await InitializeUIContent();
                SetupLoginImage();
                Owner.SwitchUiObject(State.LoginBonus, true);
            }

            private void InitializeButton()
            {
                var buttons = loginBonus.buttons;
                for (int i = 0; i < buttons.Length; i++)
                {
                    var index = i;
                    if (_userDataManager.GetLoginBonusStatus(index) != LoginBonusStatus.CanReceive)
                    {
                        continue;
                    }

                    buttons[i].onClick.RemoveAllListeners();
                    buttons[i].onClick.AddListener(() => OnClickRewardButton(index));
                }

                loginBonus.closeButton.onClick.RemoveAllListeners();
                loginBonus.rewardGetView.okButton.onClick.RemoveAllListeners();
                loginBonus.closeButton.onClick.AddListener(OnClickClosePanel);
                loginBonus.rewardGetView.okButton.onClick.AddListener(OnClickCloseRewardView);
            }

            private async UniTask InitializeUIContent()
            {
                loginBonus.purchaseErrorView.gameObject.SetActive(false);
                loginBonus.rewardGetView.gameObject.SetActive(false);
                await Owner.SetCoinText();
                await Owner.SetGemText();
            }


            private void SetupLoginImage()
            {
                var userData = _userDataManager.GetUserData();
                foreach (var login in userData.LoginBonus)
                {
                    if (GameCommonData.GetLoginBonusStatus(login.Value) != LoginBonusStatus.Received)
                    {
                        continue;
                    }

                    loginBonus.clearImages[login.Key].gameObject.SetActive(true);
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
                var parent = loginBonus.buttons[index].transform;
                _focusObj = Instantiate(loginBonus.focusObj, parent);
            }

            private void OnClickRewardButton(int index)
            {
                var button = loginBonus.buttons[index].gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    //todo　購入処理
                    if (index is Day4 or Day7)
                    {
                        var day = index + 1;
                        var errorText = loginBonus.purchaseErrorView.errorInfoText;
                        var rewardView = loginBonus.rewardGetView;
                        var rewardViewObj = loginBonus.rewardGetView.gameObject;
                        var itemGetResult = await _playaFabShopManager.TryPurchaseGacha(
                            GameCommonData.LoginBonusItemKey + day, GameCommonData.CoinKey, 0,
                            GameCommonData.GachaShopKey, rewardView, errorText);
                        if (!itemGetResult)
                        {
                            return;
                        }

                        rewardViewObj.transform.localScale = Vector3.zero;
                        rewardViewObj.SetActive(true);
                        await _uiAnimation.Open(rewardViewObj.transform, GameCommonData.OpenDuration)
                            .AttachExternalCancellation(rewardViewObj.GetCancellationTokenOnDestroy());
                    }
                    else
                    {
                        var day = index + 1;
                        var errorText = loginBonus.purchaseErrorView.errorInfoText;
                        var rewardView = loginBonus.rewardGetView;
                        var rewardViewObj = loginBonus.rewardGetView.gameObject;
                        var itemGetResult =
                            await _playaFabShopManager.TryPurchaseLoginBonusItem(day, GameCommonData.CoinKey, 0,
                                rewardView, errorText);
                        if (!itemGetResult)
                        {
                            return;
                        }

                        rewardViewObj.transform.localScale = Vector3.zero;
                        rewardViewObj.SetActive(true);
                        await _uiAnimation.Open(rewardViewObj.transform, GameCommonData.OpenDuration)
                            .AttachExternalCancellation(rewardViewObj.GetCancellationTokenOnDestroy());
                    }

                    var result = await _userDataManager.SetLoginBonus(index, LoginBonusStatus.Received);
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
                var button = loginBonus.closeButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var panel = main.LoginBonusGameObjet.transform;
                    await _uiAnimation.Close(panel, GameCommonData.CloseDuration)
                        .AttachExternalCancellation(panel.GetCancellationTokenOnDestroy());
                    panel.gameObject.SetActive(false);
                    Owner.stateMachine.Dispatch((int)State.Main);
                })).SetLink(button);
            }

            private void OnClickCloseRewardView()
            {
                var button = loginBonus.rewardGetView.okButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var panel = loginBonus.rewardGetView.transform;
                    await _uiAnimation.Close(panel, GameCommonData.CloseDuration)
                        .AttachExternalCancellation(panel.GetCancellationTokenOnDestroy());;
                    panel.gameObject.SetActive(false);
                })).SetLink(button);
            }
        }
    }
}