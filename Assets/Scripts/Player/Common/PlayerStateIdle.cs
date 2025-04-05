using System;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager;
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
            private PhotonView _PhotonView => Owner.photonView;
            private PlayerMove _PlayerMove => Owner._playerMove;
            private InputManager _InputManager => Owner._inputManager;
            private StateMachine<PlayerCore> _StateMachine => Owner._stateMachine;
            private Transform _playerTransform;
            private bool _isSetup;
            private CancellationTokenSource _cancellationTokenSource;

            protected override void OnEnter(State prevState)
            {
                base.OnEnter(prevState);
                InitializeCancellationToken();
                InitialiseIdleState();
                InitializeButton();
            }

            protected override void OnExit(State nextState)
            {
                base.OnExit(nextState);
                Cancel();
            }

            protected override void OnUpdate()
            {
                if (_PlayerMove == null)
                {
                    return;
                }

                var direction = new Vector3(UltimateJoystick.GetHorizontalAxis(GameCommonData.JoystickName), 0, UltimateJoystick.GetVerticalAxis(GameCommonData.JoystickName));
                _PlayerMove.Run(direction);
            }

            private void InitialiseIdleState()
            {
                if (_isSetup)
                {
                    return;
                }

                _playerTransform = Owner.transform;
                _InputManager.OnClickNormalSkill(OnClickNormalSkill, Owner.GetCancellationTokenOnDestroy());
                _InputManager.OnClickSpecialSkill(OnClickSpecialSkill, Owner.GetCancellationTokenOnDestroy());
                _InputManager.OnClickDash(OnClickDash, Owner.GetCancellationTokenOnDestroy());
                _isSetup = true;
            }

            private void InitializeCancellationToken()
            {
                _cancellationTokenSource ??= new CancellationTokenSource();
            }

            private void InitializeButton()
            {
                _InputManager.BombButton.OnClickAsObservable()
                    .Where(_ => Owner._translateStatusForBattleUseCase.CanPutBomb())
                    .Throttle(TimeSpan.FromSeconds(GameCommonData.InputBombInterval))
                    .Subscribe(
                        _ =>
                        {
                            var playerId = _PhotonView.ViewID;
                            var explosionTime = PhotonNetwork.ServerTimestamp + GameCommonData.ThreeMilliSecondsBeforeExplosion;
                            var damageAmount = Owner._translateStatusForBattleUseCase._Attack;
                            var fireRange = Owner._translateStatusForBattleUseCase._FireRange;
                            var boxCollider = Owner._boxCollider;
                            Owner._putBomb.SetBomb
                            (
                                boxCollider,
                                _PhotonView,
                                _playerTransform,
                                (int)BombType.Normal,
                                damageAmount,
                                fireRange,
                                explosionTime,
                                playerId
                            );
                        }).AddTo(_cancellationTokenSource.Token);
            }

            private void OnClickNormalSkill()
            {
                _StateMachine.Dispatch((int)PLayerState.NormalSkill);
            }

            private void OnClickSpecialSkill()
            {
                _StateMachine.Dispatch((int)PLayerState.SpecialSkill);
            }

            private void OnClickDash()
            {
                _StateMachine.Dispatch((int)PLayerState.Dash);
            }

            private void Cancel()
            {
                _cancellationTokenSource?.Cancel();
                _cancellationTokenSource?.Dispose();
                _cancellationTokenSource = null;
            }
        }
    }
}