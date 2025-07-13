using System;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Facade.Skill
{
    public class SkillAnimationFacade : IDisposable
    {
        private Animator _animator;
        private ObservableStateMachineTrigger _observableStateMachineTrigger;

        public void Initialize
        (
            Animator animator,
            ObservableStateMachineTrigger observableStateMachineTrigger
        )
        {
            _animator = animator;
            _observableStateMachineTrigger = observableStateMachineTrigger;
        }

        public void PlayBack(SkillMasterData skillMasterData)
        {
            if (skillMasterData._SkillActionTypeEnum == SkillActionType.None)
            {
                return;
            }

            _animator.SetTrigger(GameCommonData.GetAnimatorHashKey(skillMasterData._SkillActionTypeEnum));
        }

        public void AnimationSubscribe
        (
            SkillMasterData skillMasterData,
            CancellationTokenSource cts,
            Action action
        )
        {
            _observableStateMachineTrigger
                .OnStateExitAsObservable()
                .Where(stateInfo => IsAnimationState(skillMasterData, stateInfo))
                .Take(1)
                .Subscribe(_ => action?.Invoke())
                .AddTo(cts.Token);
        }

        private static bool IsAnimationState
        (
            SkillMasterData skillMasterData,
            ObservableStateMachineTrigger.OnStateInfo stateInfo
        )
        {
            var stateName = "";
            switch (skillMasterData._SkillActionTypeEnum)
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
                    stateName = GameCommonData.MagicShotKey;
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
                    stateName = GameCommonData.SlashSpinKey;
                    break;
                case SkillActionType.ThrowEdge:
                    break;
                case SkillActionType.RainArrow:
                    stateName = GameCommonData.RainArrowKey;
                    break;
                case SkillActionType.ImpactRock:
                    stateName = GameCommonData.ImpactRockKey;
                    break;
                case SkillActionType.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return stateInfo.StateInfo.IsName(stateName);
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}