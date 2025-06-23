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
            private PhotonView _PhotonView => Owner.photonView;
            private PlayerMove _PlayerMove => Owner._playerMove;
            private StateMachine<PlayerCore> _StateMachine => Owner._stateMachine;
            private IObservable<Unit> _OnClickWeaponSkill => Owner._WeaponSkillSubject;
            private IObservable<Unit> _OnClickNormalSkill => Owner._NormalSkillSubject;
            private IObservable<Unit> _OnClickSpecialSkill => Owner._SpecialSkillSubject;
            private IObservable<Unit> _OnClickDash => Owner._DashSkillSubject;
            private IObservable<Unit> _OnClickBomb => Owner._BombSkillSubject;
            private IObservable<int> _OnClickCharacterChange => Owner._TeamMemberReactiveProperty;
            private PlayerStatusInfo _PlayerStatusInfo => Owner._playerStatusInfo;


            private Transform _playerTransform;
            private CancellationTokenSource _cts;

            protected override void OnEnter(State prevState)
            {
                _playerTransform = Owner.transform;
                _cts = new CancellationTokenSource();
                Subscribe();
            }

            protected override void OnExit(State nextState)
            
            {
                _PlayerMove.Stop();
                Cancel();
            }

            private void Subscribe()
            {
                Observable
                    .EveryFixedUpdate()
                    .Where(_ => _PlayerMove != null)
                    .Subscribe(_ =>
                    {
                        var direction = new Vector3(UltimateJoystick.GetHorizontalAxis(GameCommonData.JoystickName), 0, UltimateJoystick.GetVerticalAxis(GameCommonData.JoystickName));
                        _PlayerMove.Run(direction);
                    })
                    .AddTo(_cts.Token);

                _OnClickWeaponSkill
                    .Subscribe(_ => { _StateMachine.Dispatch((int)PLayerState.WeaponSkill); })
                    .AddTo(_cts.Token);

                _OnClickNormalSkill
                    .Subscribe(_ => { _StateMachine.Dispatch((int)PLayerState.NormalSkill); })
                    .AddTo(_cts.Token);

                _OnClickSpecialSkill
                    .Subscribe(_ => { _StateMachine.Dispatch((int)PLayerState.SpecialSkill); })
                    .AddTo(_cts.Token);

                _OnClickDash
                    .Subscribe(_ => { _StateMachine.Dispatch((int)PLayerState.Dash); })
                    .AddTo(_cts.Token);

                _OnClickCharacterChange
                    .Throttle(TimeSpan.FromSeconds(GameCommonData.CharacterChangeInterval))
                    .Subscribe(_ => { })
                    .AddTo(_cts.Token);

                _OnClickBomb
                    .Where(_ => Owner._translateStatusInBattleUseCase.CanPutBomb())
                    .Throttle(TimeSpan.FromSeconds(GameCommonData.InputBombInterval))
                    .Subscribe(_ =>
                    {
                        var playerId = _PhotonView.ViewID;
                        var explosionTime = PhotonNetwork.ServerTimestamp + GameCommonData.ThreeMilliSecondsBeforeExplosion;
                        var damageAmount = _PlayerStatusInfo._Attack.Value;
                        var fireRange = _PlayerStatusInfo._FireRange.Value;
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
                    }).AddTo(_cts.Token);
            }

            private void Cancel()
            {
                if (_cts == null)
                {
                    return;
                }

                _cts.Cancel();
                _cts.Dispose();
                _cts = null;
            }
        }
    }
}