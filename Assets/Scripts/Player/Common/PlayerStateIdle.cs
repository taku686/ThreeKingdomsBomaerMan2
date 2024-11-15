using System;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using UniRx;
using UnityEngine;
using State = StateMachine<Player.Common.PlayerCore>.State;

namespace Player.Common
{
    public partial class PlayerCore
    {
        public class PlayerIdleState : State
        {
            private PhotonView PhotonView => Owner.photonView;
            private Transform playerTransform;
            private bool isSetup;
            private PlayerMove playerMove;
            private CancellationTokenSource cancellationTokenSource;

            protected override void OnEnter(State prevState)
            {
                base.OnEnter(prevState);
                InitializeComponent();
                InitializeCancellationToken();
                InitialiseIdleState();
                InitializeButton();
            }

            protected override void OnExit(State nextState)
            {
                base.OnExit(nextState);
                Cancel();
                playerMove = null;
            }

            protected override void OnUpdate()
            {
                if (playerMove == null)
                {
                    return;
                }

                var direction = new Vector3(UltimateJoystick.GetHorizontalAxis(GameCommonData.JoystickName), 0,
                    UltimateJoystick.GetVerticalAxis(GameCommonData.JoystickName));
                playerMove.Move(direction);
            }

            private void InitializeComponent()
            {
                playerMove = Owner.playerMove;
            }

            private void InitialiseIdleState()
            {
                if (isSetup)
                {
                    return;
                }

                playerTransform = Owner.transform;
                Owner.inputManager.OnClickNormalSkill(OnClickNormalSkill, Owner.GetCancellationTokenOnDestroy());
                Owner.inputManager.OnClickSpecialSkill(OnClickSpecialSkill, Owner.GetCancellationTokenOnDestroy());
                isSetup = true;
            }

            private void InitializeCancellationToken()
            {
                cancellationTokenSource ??= new CancellationTokenSource();
            }

            private void InitializeButton()
            {
                Owner.inputManager.BombButton.OnClickAsObservable()
                    .Where(_ => Owner.translateStatusForBattleUseCase.CanPutBomb())
                    .Throttle(TimeSpan.FromSeconds(GameCommonData.InputBombInterval))
                    .Subscribe(
                        _ =>
                        {
                            var playerId = PhotonView.ViewID;
                            var explosionTime =
                                PhotonNetwork.ServerTimestamp + GameCommonData.ThreeMilliSecondsBeforeExplosion;
                            var damageAmount = Owner.translateStatusForBattleUseCase.Attack;
                            var fireRange = Owner.translateStatusForBattleUseCase.FireRange;
                            var boxCollider = Owner.boxCollider;
                            Owner.putBomb.SetBomb
                            (
                                boxCollider,
                                PhotonView,
                                playerTransform,
                                (int)BombType.Normal,
                                damageAmount,
                                fireRange,
                                explosionTime,
                                playerId
                            );
                        }).AddTo(cancellationTokenSource.Token);
            }

            private void OnClickNormalSkill()
            {
                Owner.stateMachine.Dispatch((int)PLayerState.NormalSkill);
            }

            private void OnClickSpecialSkill()
            {
                Owner.stateMachine.Dispatch((int)PLayerState.SpecialSkill);
            }

            private void Cancel()
            {
                cancellationTokenSource?.Cancel();
                cancellationTokenSource?.Dispose();
                cancellationTokenSource = null;
            }
        }
    }
}