using System;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.NetworkManager;
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
            protected PhotonNetworkManager _PhotonNetworkManager => Owner._photonNetworkManager;
            private StateMachine<PlayerCore> _StateMachine => Owner._stateMachine;
            private CancellationTokenSource _cts;
            protected SkillMasterData _SkillMasterData;

            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            protected override void OnExit(State nextState)
            {
                Cancel();
            }

            protected override void OnUpdate()
            {
                if (_SkillMasterData._SkillActionTypeEnum == SkillActionType.None)
                {
                    _StateMachine.Dispatch((int)PLayerState.Idle);
                }
            }

            protected virtual void Initialize()
            {
                _cts = new CancellationTokenSource();
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
                    .Where(IsAnimationState)
                    .Take(1)
                    .Subscribe(_ =>
                    {
                        Debug.Log("Skill Animation Ended");
                        _StateMachine.Dispatch((int)PLayerState.Idle);
                    })
                    .AddTo(_cts.Token);
            }

            private bool IsAnimationState(ObservableStateMachineTrigger.OnStateInfo stateInfo)
            {
                var stateName = "";
                switch (_SkillMasterData._SkillActionTypeEnum)
                {
                    case SkillActionType.Heal:
                        break;
                    case SkillActionType.ContinuousHeal:
                        break;
                    case SkillActionType.Barrier:
                        break;
                    case SkillActionType.PerfectBarrier:
                        break;
                    case SkillActionType.Reborn:
                        break;
                    case SkillActionType.SlowTime:
                        break;
                    case SkillActionType.ProhibitedSkill:
                        break;
                    case SkillActionType.Jump:
                        break;
                    case SkillActionType.WallThrough:
                        break;
                    case SkillActionType.WallDestruction:
                        break;
                    case SkillActionType.Teleport:
                        break;
                    case SkillActionType.Kick:
                        break;
                    case SkillActionType.Transparent:
                        break;
                    case SkillActionType.Clairvoyance:
                        break;
                    case SkillActionType.LinerArrangement:
                        break;
                    case SkillActionType.CircleArrangement:
                        break;
                    case SkillActionType.ArrowArrangement:
                        break;
                    case SkillActionType.Meteor:
                        break;
                    case SkillActionType.BombDestruction:
                        break;
                    case SkillActionType.BombBlowOff:
                        break;
                    case SkillActionType.EnemyBlowOff:
                        break;
                    case SkillActionType.BlastReflection:
                        break;
                    case SkillActionType.SkillBarrier:
                        break;
                    case SkillActionType.RewardCoin:
                        break;
                    case SkillActionType.RewardGem:
                        break;
                    case SkillActionType.PenetrationBomb:
                        break;
                    case SkillActionType.DiffusionBomb:
                        break;
                    case SkillActionType.FullPowerBomb:
                        break;
                    case SkillActionType.ParalysisBomb:
                        break;
                    case SkillActionType.ConfusionBomb:
                        break;
                    case SkillActionType.PoisonBomb:
                        break;
                    case SkillActionType.IceBomb:
                        break;
                    case SkillActionType.GoldenBomb:
                        break;
                    case SkillActionType.ChaseBomb:
                        break;
                    case SkillActionType.RotateBomb:
                        break;
                    case SkillActionType.GenerateWall:
                        break;
                    case SkillActionType.CantMoveTrap:
                        break;
                    case SkillActionType.PoisonTrap:
                        break;
                    case SkillActionType.GenerateBombAlly:
                        break;
                    case SkillActionType.BombDestructionShot:
                        break;
                    case SkillActionType.BombBlowOffShot:
                        break;
                    case SkillActionType.EnemyBlowOffShot:
                        break;
                    case SkillActionType.AllBuff:
                        stateName = GameCommonData.BuffKey;
                        break;
                    case SkillActionType.HpBuff:
                        stateName = GameCommonData.BuffKey;
                        break;
                    case SkillActionType.AttackBuff:
                        stateName = GameCommonData.BuffKey;
                        break;
                    case SkillActionType.SpeedBuff:
                        stateName = GameCommonData.BuffKey;
                        break;
                    case SkillActionType.BombLimitBuff:
                        stateName = GameCommonData.BuffKey;
                        break;
                    case SkillActionType.FireRangeBuff:
                        stateName = GameCommonData.BuffKey;
                        break;
                    case SkillActionType.AllDebuff:
                        break;
                    case SkillActionType.HpDebuff:
                        break;
                    case SkillActionType.AttackDebuff:
                        break;
                    case SkillActionType.SpeedDebuff:
                        break;
                    case SkillActionType.BombLimitDebuff:
                        break;
                    case SkillActionType.FireRangeDebuff:
                        break;
                    case SkillActionType.RandomDebuff:
                        break;
                    case SkillActionType.FastMove:
                        break;
                    case SkillActionType.BombThrough:
                        break;
                    case SkillActionType.BlackHole:
                        break;
                    case SkillActionType.Summon:
                        break;
                    case SkillActionType.GodPower:
                        stateName = GameCommonData.BuffKey;
                        break;
                    case SkillActionType.ResistanceBuff:
                        stateName = GameCommonData.BuffKey;
                        break;
                    case SkillActionType.DefenseBuff:
                        stateName = GameCommonData.BuffKey;
                        break;
                    case SkillActionType.Slash:
                        stateName = GameCommonData.SlashKey;
                        break;
                    case SkillActionType.Shot:
                        break;
                    case SkillActionType.Resistance:
                        break;
                    case SkillActionType.Bomb:
                        break;
                    case SkillActionType.Dash:
                        stateName = GameCommonData.DashKey;
                        break;
                    case SkillActionType.DashAttack:
                        stateName = GameCommonData.DashAttackKey;
                        break;
                    case SkillActionType.FlyingSlash:
                        stateName = GameCommonData.SlashKey;
                        break;
                    case SkillActionType.Impact:
                        stateName = GameCommonData.ImpactKey;
                        break;
                    case SkillActionType.JumpSmash:
                        break;
                    case SkillActionType.SlashSpin:
                        break;
                    case SkillActionType.ThrowEdge:
                        break;
                    case SkillActionType.None:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                return stateInfo.StateInfo.IsName(stateName);
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