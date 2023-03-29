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

            protected override void OnEnter(State prevState)
            {
                Owner.DisableTitleGameObject();
                Initialize();
                InitializeButton();
                SetupLoginImage();
                OpenLoginBonusPanel().Forget();
            }

            protected override void OnExit(State nextState)
            {
                Destroy(_focusObj);
            }

            private void Initialize()
            {
                _uiAnimation = Owner._uiAnimation;
                _loginBonusView = Owner.loginBonusView;
                _mainView = Owner.mainView;
                _userDataManager = Owner._userDataManager;
                _playFabLoginManager = Owner._playFabLoginManager;
                _playaFabShopManager = Owner._playFabShopManager;
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
                _loginBonusView.closeButton.onClick.AddListener(OnClickClosePanel);
            }

            private async UniTask OpenLoginBonusPanel()
            {
                var panel = Owner.mainView.LoginBonusObjet.transform;
                panel.localScale = Vector3.zero;
                panel.gameObject.SetActive(true);
                await _uiAnimation.Open(panel, GameCommonData.OpenDuration);
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
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    //todo　購入処理

                    var result = await _userDataManager.SetLoginBonus(index, LoginBonusStatus.Received);
                    if (!result)
                    {
                        return;
                    }

                    SetupLoginImage();
                })).SetLink(button);
            }

            private void OnClickClosePanel()
            {
                var button = _loginBonusView.closeButton.gameObject;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var panel = _mainView.LoginBonusObjet.transform;
                    await _uiAnimation.Close(panel, GameCommonData.CloseDuration);
                    panel.gameObject.SetActive(false);
                    Owner._stateMachine.Dispatch((int)Event.Main);
                })).SetLink(button);
            }
        }
    }
}