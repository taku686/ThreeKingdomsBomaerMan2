using System;
using System.Threading;
using Character;
using Common.Data;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using Skill;
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
            private PlayerStatusInfo _PlayerStatusInfo => Owner._PlayerStatusInfo;
            private AbnormalConditionEffectUseCase _AbnormalConditionEffectUseCase => Owner._abnormalConditionEffectUseCase;
            private IObservable<Unit> _OnClickWeaponSkill => Owner._WeaponSkillSubject;
            private IObservable<Unit> _OnClickNormalSkill => Owner._NormalSkillSubject;
            private IObservable<Unit> _OnClickSpecialSkill => Owner._SpecialSkillSubject;
            private IObservable<Unit> _OnClickDash => Owner._DashSkillSubject;
            private IObservable<Unit> _OnClickBomb => Owner._BombSkillSubject;
            private IObservable<int> _OnClickCharacterChange => Owner._TeamMemberReactiveProperty;


            private Transform _playerTransform;
            private CancellationTokenSource _cts;
            private const int WaitDurationBeforeExplosion = 3000;
            private const int WaitDurationBeforeExplosionInBurning = 1000;

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
                    .Subscribe(_ => { _StateMachine.Dispatch((int)PlayerState.WeaponSkill); })
                    .AddTo(_cts.Token);

                _OnClickNormalSkill
                    .Subscribe(_ => { _StateMachine.Dispatch((int)PlayerState.NormalSkill); })
                    .AddTo(_cts.Token);

                _OnClickSpecialSkill
                    .Subscribe(_ => { _StateMachine.Dispatch((int)PlayerState.SpecialSkill); })
                    .AddTo(_cts.Token);

                _OnClickDash
                    .Subscribe(_ => { _StateMachine.Dispatch((int)PlayerState.Dash); })
                    .AddTo(_cts.Token);

                _OnClickCharacterChange
                    .Throttle(TimeSpan.FromSeconds(GameCommonData.CharacterChangeInterval))
                    .Subscribe(_ => { })
                    .AddTo(_cts.Token);

                _OnClickBomb
                    .Where(_ => Owner._translateStatusInBattleUseCase.CanPutBomb())
                    .Where(_ => _AbnormalConditionEffectUseCase._CanPutBombReactiveProperty.Value)
                    .Throttle(TimeSpan.FromSeconds(GameCommonData.InputBombInterval))
                    .Subscribe(_ =>
                    {
                        var instantiationId = _PhotonView.InstantiationId;
                        var waitDuration = _AbnormalConditionEffectUseCase._IsBurning ? WaitDurationBeforeExplosionInBurning : WaitDurationBeforeExplosion;
                        var explosionTime = PhotonNetwork.ServerTimestamp + waitDuration;
                        var damageAmount = (int)TranslateStatusInBattleUseCase.Translate(StatusType.Attack, _PlayerStatusInfo._Attack.Value);
                        var fireRange = (int)TranslateStatusInBattleUseCase.Translate(StatusType.FireRange, _PlayerStatusInfo._FireRange.Value);
                        var boxCollider = Owner._boxCollider;
                        Owner._putBomb.SetBomb
                        (
                            boxCollider,
                            _PhotonView,
                            _playerTransform,
                            (int)BombType.Attribute,
                            damageAmount,
                            fireRange,
                            explosionTime,
                            instantiationId,
                            393,
                            AbnormalCondition.Paralysis
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