using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.NetworkManager;
using Photon.Pun;
using Skill;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using State = StateMachine<Player.Common.PlayerCore>.State;

namespace Player.Common
{
    public partial class PlayerCore
    {
        public class PlayerSkillStateBase : State
        {
            private DC.Scanner.TargetScanner _TargetScanner => Owner._targetScanner;
            protected ActiveSkillManager _ActiveSkillManager => Owner._activeSkillManager;
            private ObservableStateMachineTrigger _ObservableStateMachineTrigger => Owner._observableStateMachineTrigger;
            protected PhotonView _PhotonView => Owner.photonView;
            protected PhotonNetworkManager _PhotonNetworkManager => Owner._photonNetworkManager;

            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            protected virtual void Initialize()
            {
                SetupTargetScanner();
                PlayBackAnimation();
            }

            private void SetupTargetScanner()
            {
                //todo 後で範囲、角度などを調整する
                _TargetScanner.TargetLayer = LayerMask.GetMask(GameCommonData.EnemyLayer);
                _TargetScanner._CenterTransform = Owner.transform;
                _TargetScanner.ViewRadius = 1.5f;
                _TargetScanner.ViewAngle = 180f;
            }

            private void PlayBackAnimation()
            {
                _ObservableStateMachineTrigger
                    .OnStateExitAsObservable()
                    .Take(1)
                    .Subscribe(_ => { Owner._stateMachine.Dispatch((int)PLayerState.Idle); })
                    .AddTo(Owner.GetCancellationTokenOnDestroy());
            }
        }
    }
}