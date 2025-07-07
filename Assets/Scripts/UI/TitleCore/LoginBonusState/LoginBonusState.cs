using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.NetworkManager;
using TitleCore.LoginBonusState;
using UI.TitleCore.LoginBonusState;
using UniRx;
using UnityEngine;
using StampUiAnimation = UI.Common.StampUiAnimation;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class LoginBonusState : StateMachine<TitleCore>.State
        {
            private LoginBonusFacade _LoginBonusFacade => Owner._loginBonusFacade;
            private PopupGenerateUseCase _PopupGenerateUseCase => Owner._popupGenerateUseCase;
            private LoginBonusViewModelUseCase _LoginBonusViewModelUseCase => Owner._loginBonusViewModelUseCase;
            private StateMachine<TitleCore> _StateMachine => Owner._stateMachine;

            private LoginBonusPopup _popup;
            private CancellationTokenSource _cts;


            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize().Forget();
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
                Owner.Cancel(_cts);
            }

            private async UniTask Initialize()
            {
                _cts = new CancellationTokenSource();
                var viewModel = _LoginBonusViewModelUseCase.InAsTask();
                _popup = await _PopupGenerateUseCase.GenerateLoginBonusPopup(viewModel);
                Subscribe();
                InitializeButton();
            }

            private void Subscribe()
            {
                _popup
                    ._OnClickButton
                    .Subscribe(_ => { _StateMachine.Dispatch((int)State.Main, (int)State.LoginBonus); })
                    .AddTo(_cts.Token);
            }

            private void InitializeButton()
            {
                var buttons = _popup._buttons;
                var data = _LoginBonusFacade._Data;
                var day = data._consecutiveDays;
                var rewardData = _LoginBonusFacade._LoginBonusConfig._rewards[day];
                var button = buttons[data._consecutiveDays];
                var stampAnimation = button.GetComponentInChildren<StampUiAnimation>();
                Debug.Log("Day: " + day + ", Reward Type: " + rewardData._rewardType);
                Debug.Log("Today Received: " + data._todayReceived);
                button
                    .OnClickAsObservable()
                    .Where(_ => !data._todayReceived)
                    .Take(1)
                    .SelectMany(_ => _LoginBonusFacade.ReceiveBonus().ToObservable())
                    .Subscribe(_ => { stampAnimation.PlayStamp(() => TransitionScene(rewardData._rewardType)); })
                    .AddTo(_cts.Token);
            }

            private void TransitionScene(GameCommonData.RewardType rewardType)
            {
                if (rewardType is GameCommonData.RewardType.Coin or GameCommonData.RewardType.Gem)
                {
                    return;
                }

                _StateMachine.Dispatch((int)State.Reward, (int)State.LoginBonus);
            }
        }
    }
}