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
            private StateMachine<PlayerCore> _StateMachine => Owner._stateMachine;
            private IObservable<Unit> _OnClickNormalSkill => Owner._NormalSkillSubject;
            private IObservable<Unit> _OnClickSpecialSkill => Owner._SpecialSkillSubject;
            private IObservable<Unit> _OnClickDash => Owner._DashSkillSubject;
            private IObservable<Unit> _OnClickBomb => Owner._BombSkillSubject;
            private IObservable<int> _OnClickCharacterChange => Owner._TeamMemberReactiveProperty;


            private Transform _playerTransform;
            private bool _isSetup;
            private CancellationTokenSource _cancellationTokenSource;

            protected override void OnEnter(State prevState)
            {
                base.OnEnter(prevState);
                InitializeCancellationToken();
                InitialiseIdleState();
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

                _OnClickNormalSkill
                    .Subscribe(_ => { OnClickNormalSkill(); })
                    .AddTo(Owner.GetCancellationTokenOnDestroy());

                _OnClickSpecialSkill
                    .Subscribe(_ => { OnClickSpecialSkill(); })
                    .AddTo(Owner.GetCancellationTokenOnDestroy());

                _OnClickDash
                    .Subscribe(_ => { OnClickDash(); })
                    .AddTo(Owner.GetCancellationTokenOnDestroy());

                _OnClickCharacterChange
                    .Throttle(TimeSpan.FromSeconds(GameCommonData.CharacterChangeInterval))
                    .Subscribe(_ => { })
                    .AddTo(Owner.GetCancellationTokenOnDestroy());

                _OnClickBomb
                    .Where(_ => Owner._translateStatusInBattleUseCase.CanPutBomb())
                    .Throttle(TimeSpan.FromSeconds(GameCommonData.InputBombInterval))
                    .Subscribe(_ =>
                    {
                        var playerId = _PhotonView.ViewID;
                        var explosionTime = PhotonNetwork.ServerTimestamp + GameCommonData.ThreeMilliSecondsBeforeExplosion;
                        var damageAmount = Owner._translateStatusInBattleUseCase._Attack;
                        var fireRange = Owner._translateStatusInBattleUseCase._FireRange;
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
                    }).AddTo(Owner.GetCancellationTokenOnDestroy());

                _isSetup = true;
            }

            private void InitializeCancellationToken()
            {
                _cancellationTokenSource ??= new CancellationTokenSource();
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