using System.Threading;
using Common;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using PlayFab;
using PlayFab.ClientModels;
using UniRx;
using UnityEngine;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class SettingState : StateMachine<TitleCore>.State
        {
            private PopupGenerateUseCase _PopupGenerateUseCase => Owner._popupGenerateUseCase;
            private UserDataRepository _UserDataRepository => Owner._userDataRepository;
            private StateMachine<TitleCore> _StateMachine => Owner._stateMachine;
            private SettingPopup _settingPopup;
            private CancellationTokenSource _cts;

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize();
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
                Cancel();
            }

            private void Initialize()
            {
            }

            private void Subscribe()
            {
                if (_settingPopup == null)
                {
                    return;
                }

                _settingPopup._OnClickButton
                    .Subscribe(_ => { _StateMachine.Dispatch((int)State.Main); })
                    .AddTo(_cts.Token);
            }

            private SettingPopup.ViewModel GetViewModel()
            {
                var settingData = _UserDataRepository.GetSettingData();
                return new SettingPopup.ViewModel
                (
                    "",
                    "",
                    settingData
                );
            }

            private void Cancel()
            {
                _cts.Cancel();
                _cts.Dispose();
                _cts = null;
            }
        }
    }
}