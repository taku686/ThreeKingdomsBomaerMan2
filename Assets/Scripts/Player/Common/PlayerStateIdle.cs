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
                playerMove = Owner._playerMove;
            }

            private void InitialiseIdleState()
            {
                if (isSetup)
                {
                    return;
                }

                playerTransform = Owner.transform;
                Owner._inputManager.OnClickNormalSkill(OnClickNormalSkill, Owner.GetCancellationTokenOnDestroy());
                Owner._inputManager.OnClickSpecialSkill(OnClickSpecialSkill, Owner.GetCancellationTokenOnDestroy());
                isSetup = true;
            }

            private void InitializeCancellationToken()
            {
                cancellationTokenSource ??= new CancellationTokenSource();
            }

            private void InitializeButton()
            {
                Owner._inputManager.BombButton.OnClickAsObservable()
                    .Where(_ => Owner._translateStatusForBattleUseCase.CanPutBomb())
                    .Throttle(TimeSpan.FromSeconds(GameCommonData.InputBombInterval))
                    .Subscribe(
                        _ =>
                        {
                            var playerId = PhotonView.ViewID;
                            var explosionTime =
                                PhotonNetwork.ServerTimestamp + GameCommonData.ThreeMilliSecondsBeforeExplosion;
                            var damageAmount = Owner._translateStatusForBattleUseCase._Attack;
                            var fireRange = Owner._translateStatusForBattleUseCase._FireRange;
                            var boxCollider = Owner._boxCollider;
                            Owner._putBomb.SetBomb
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
                Owner._stateMachine.Dispatch((int)PLayerState.NormalSkill);
            }

            private void OnClickSpecialSkill()
            {
                Owner._stateMachine.Dispatch((int)PLayerState.SpecialSkill);
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