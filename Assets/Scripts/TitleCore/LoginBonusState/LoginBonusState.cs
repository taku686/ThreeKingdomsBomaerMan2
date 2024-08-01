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
        public class LoginBonusState : State
        {
            private UIAnimation _uiAnimation;
            private LoginBonusView _loginBonusView;
            private MainView _mainView;
            private UserDataManager _userDataManager;
            private PlayFabLoginManager _playFabLoginManager;
            private PlayFabShopManager _playaFabShopManager;
            private GameObject _focusObj;
            private const int Day4 = 3;
            private const int Day7 = 6;

            protected override void OnEnter(State prevState)
            {
                Initialize().Forget();
            }

            protected override void OnExit(State nextState)
            {
                Destroy(_focusObj);
            }

            private async UniTask Initialize()
            {
                _uiAnimation = Owner.uiAnimation;
                _loginBonusView = Owner.loginBonusView;
                _mainView = Owner.mainView;
                _userDataManager = Owner.userDataManager;
                _playFabLoginManager = Owner.playFabLoginManager;
                _playaFabShopManager = Owner.playFabShopManager;
                InitializeButton();
                await InitializeUIContent();
                SetupLoginImage();
                Owner.SwitchUiObject(TitleCoreEvent.LoginBonus, true);
            }

            private void InitializeButton()
            {
                var buttons = _loginBonusView.buttons;
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

                _loginBonusView.closeButton.onClick.RemoveAllListeners();
                _loginBonusView.rewardGetView.okButton.onClick.RemoveAllListeners();
                _loginBonusView.closeButton.onClick.AddListener(OnClickClosePanel);
                _loginBonusView.rewardGetView.okButton.onClick.AddListener(OnClickCloseRewardView);
            }

            private async UniTask InitializeUIContent()
            {
                _loginBonusView.purchaseErrorView.gameObject.SetActive(false);
                _loginBonusView.rewardGetView.gameObject.SetActive(false);
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

                    _loginBonusView.clearImages[login.Key].gameObject.SetActive(true);
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
                var parent = _loginBonusView.buttons[index].transform;
                _focusObj = Instantiate(_loginBonusView.focusObj, parent);
            }

            private void OnClickRewardButton(int index)
            {
                var button = _loginBonusView.buttons[index].gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    //todo　購入処理
                    if (index is Day4 or Day7)
                    {
                        var day = index + 1;
                        var errorText = _loginBonusView.purchaseErrorView.errorInfoText;
                        var rewardView = _loginBonusView.rewardGetView;
                        var rewardViewObj = _loginBonusView.rewardGetView.gameObject;
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
                        var errorText = _loginBonusView.purchaseErrorView.errorInfoText;
                        var rewardView = _loginBonusView.rewardGetView;
                        var rewardViewObj = _loginBonusView.rewardGetView.gameObject;
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
                var button = _loginBonusView.closeButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var panel = _mainView.LoginBonusGameObjet.transform;
                    await _uiAnimation.Close(panel, GameCommonData.CloseDuration)
                        .AttachExternalCancellation(panel.GetCancellationTokenOnDestroy());
                    panel.gameObject.SetActive(false);
                    Owner.stateMachine.Dispatch((int)TitleCoreEvent.Main);
                })).SetLink(button);
            }

            private void OnClickCloseRewardView()
            {
                var button = _loginBonusView.rewardGetView.okButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var panel = _loginBonusView.rewardGetView.transform;
                    await _uiAnimation.Close(panel, GameCommonData.CloseDuration)
                        .AttachExternalCancellation(panel.GetCancellationTokenOnDestroy());;
                    panel.gameObject.SetActive(false);
                })).SetLink(button);
            }
        }
    }
}