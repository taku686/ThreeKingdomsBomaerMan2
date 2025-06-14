using System;
using AttributeAttack;
using Common.Data;
using Repository;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Skill.DashAttack
{
    public class DashAttackBase : AttackSkillBase, IAttackBehaviour
    {
        private readonly SkillEffectRepository _skillEffectRepository;
        private const float DelayTime = 0.1f;

        [Inject]
        public DashAttackBase
        (
            SkillEffectRepository skillEffectRepository
        )
        {
            _skillEffectRepository = skillEffectRepository;
        }

        public virtual void Attack()
        {
        }

        protected void DashAttack
        (
            AbnormalCondition abnormalCondition,
            Animator animator,
            int skillId,
            Transform playerTransform
        )
        {
            var observableStateMachineTrigger = animator.GetBehaviour<ObservableStateMachineTrigger>();
            observableStateMachineTrigger
                .OnStateEnterAsObservable()
                .Where(info => info.StateInfo.IsName(GameCommonData.DashAttackKey))
                .Take(1)
                .Delay(TimeSpan.FromSeconds(DelayTime))
                .Subscribe(_ => { ActivateEffect(playerTransform, abnormalCondition, skillId); })
                .AddTo(playerTransform);
        }

        protected virtual void ActivateEffect
        (
            Transform playerTransform,
            AbnormalCondition abnormalCondition,
            int skillId
        )
        {
            var effect = _skillEffectRepository.GetDashAttackEffect(abnormalCondition);
            var effectClone = Object.Instantiate(effect, playerTransform);
            effectClone.transform.localPosition = new Vector3(0.3f, 0.5f, 3f);
            effectClone.transform.localEulerAngles = new Vector3(0, 90, 0);
            var boxCollider = effectClone.GetComponent<BoxCollider>();
            boxCollider.isTrigger = true;
            var player = playerTransform.gameObject;

            boxCollider.OnTriggerEnterAsObservable()
                .Where(collider => IsObstaclesTag(collider.gameObject))
                .Subscribe(collider => HitPlayer(player, collider.gameObject, skillId))
                .AddTo(effectClone);
        }

        public void Dispose()
        {
        }
    }
}