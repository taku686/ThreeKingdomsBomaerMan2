using System;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager.NetworkManager;
using TitleCore.LoginBonusState;
using UI.Common;
using UI.TitleCore.LoginBonusState;
using UniRx;
using UnityEngine;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class LoginBonusState : StateMachine<TitleCore>.State
        {
            private UIAnimation _UIAnimation => Owner._uiAnimation;
            private MainView _MainView => (MainView)Owner.GetView(State.Main);
            private UserDataRepository _UserDataRepository => Owner._userDataRepository;
            private PlayFabShopManager _PlayaFabShopManager => Owner._playFabShopManager;
            private LoginBonusFacade _LoginBonusFacade => Owner._loginBonusFacade;
            private PopupGenerateUseCase _PopupGenerateUseCase => Owner._popupGenerateUseCase;
            private StateMachine<TitleCore> _StateMachine => Owner._stateMachine;
            private LoginBonusPopup _popup;
            private CancellationTokenSource _cts;
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
                Owner.Cancel(_cts);
            }

            private async UniTask Initialize()
            {
                _cts = new CancellationTokenSource();
                _popup = await _PopupGenerateUseCase.GenerateLoginBonusPopup();
                Subscribe();
                InitializeButton();
                SetupLoginImage();
            }

            private void Subscribe()
            {
                _popup
                    ._OnClickButton
                    .SelectMany(_ => _LoginBonusFacade.ReceiveBonus().ToObservable())
                    .Subscribe(_ => { _StateMachine.Dispatch((int)State.Main, (int)State.LoginBonus); })
                    .AddTo(_cts.Token);
            }

            private void InitializeButton()
            {
                var buttons = _popup._buttons;
            }

            private void SetupLoginImage()
            {
                var userData = _UserDataRepository.GetUserData();
                foreach (var login in userData.LoginBonus)
                {
                    if (GameCommonData.GetLoginBonusStatus(login.Value) != LoginBonusStatus.Received)
                    {
                        continue;
                    }

                    _popup._clearImages[login.Key].gameObject.SetActive(true);
                }
            }

            private void GenerateFocusObj(int index)
            {
                var parent = _popup._buttons[index].transform;
                _focusObj = Instantiate(_popup._focusObj, parent);
            }

            private void OnClickRewardButton(int index)
            {
                var button = _popup._buttons[index].gameObject;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    //todo　購入処理
                    if (index is Day4 or Day7)
                    {
                        var day = index + 1;
                        /*var errorText = _View.purchaseErrorView.errorInfoText;
                        var rewardView = _View._rewardPopup;
                        var rewardViewObj = _View._rewardPopup.gameObject;*/
                        var itemGetResult = await _PlayaFabShopManager.TryPurchaseGacha
                        (
                            GameCommonData.LoginBonusItemKey + day,
                            GameCommonData.CoinKey,
                            0,
                            GameCommonData.GachaShopKey,
                            null
                        );
                        if (!itemGetResult)
                        {
                            return;
                        }

                        /*rewardViewObj.transform.localScale = Vector3.zero;
                        rewardViewObj.SetActive(true);
                        await _UIAnimation.Open(rewardViewObj.transform, GameCommonData.OpenDuration)
                            .AttachExternalCancellation(rewardViewObj.GetCancellationTokenOnDestroy());*/
                    }
                    else
                    {
                        /*var day = index + 1;
                        var errorText = _View.purchaseErrorView.errorInfoText;
                        var rewardView = _View._rewardPopup;
                        var rewardViewObj = _View._rewardPopup.gameObject;
                        var itemGetResult = await _PlayaFabShopManager.TryPurchaseLoginBonusItem(day, GameCommonData.CoinKey, 0, rewardView, errorText);
                        if (!itemGetResult)
                        {
                            return;
                        }

                        rewardViewObj.transform.localScale = Vector3.zero;
                        rewardViewObj.SetActive(true);
                        await _UIAnimation.Open(rewardViewObj.transform, GameCommonData.OpenDuration).AttachExternalCancellation(rewardViewObj.GetCancellationTokenOnDestroy());*/
                    }

                    await Owner.SetCoinText();
                    await Owner.SetGemText();
                    SetupLoginImage();
                })).SetLink(button);
            }

            /*private void OnClickCloseRewardView()
            {
                var button = View._rewardPopup.okButton.gameObject;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var panel = View._rewardPopup.transform;
                    await uiAnimation.Close(panel, GameCommonData.CloseDuration)
                        .AttachExternalCancellation(panel.GetCancellationTokenOnDestroy());
                    ;
                    panel.gameObject.SetActive(false);
                })).SetLink(button);
            }*/
        }
    }
}