using System;
using AttributeAttack;
using Common.Data;
using Cysharp.Threading.Tasks;
using Repository;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Skill.CrushImpact
{
    public class CrushImpactBase : AttackSkillBase, IAttackBehaviour
    {
        private readonly SkillEffectRepository _skillEffectRepository;
        private const float DelayTime = 0.8f;
        private const float ColliderEnableDuration = 0.9f;

        [Inject]
        public CrushImpactBase
        (
            SkillEffectRepository skillEffectRepository
        )
        {
            _skillEffectRepository = skillEffectRepository;
        }

        public virtual void Attack()
        {
        }

        protected void CrushImpact
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
                .Where(info => info.StateInfo.IsName(GameCommonData.ImpactKey))
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
            var effect = _skillEffectRepository.GetCrushImpactEffect(abnormalCondition);
            var spawnPosition = playerTransform.position;
            var effectClone = Object.Instantiate(effect, spawnPosition, Quaternion.identity);
            var effectTransform = effectClone.transform;
            var effectObj = effectClone.gameObject;
            FixTransform(effectTransform, playerTransform);
            SetupCollider(effectObj, playerTransform, skillId);
        }

        private static void FixTransform(Transform effectTransform, Transform playerTransform)
        {
            effectTransform.localEulerAngles = new Vector3(-90, 0, 0);
            effectTransform.localScale *= 0.8f;
            effectTransform.localPosition += playerTransform.forward * 2f;
        }

        private void SetupCollider(GameObject effectClone, Transform playerTransform, int skillId)
        {
            var effectCollider = effectClone.GetComponent<Collider>();
            effectCollider.isTrigger = true;
            var player = playerTransform.gameObject;

            effectCollider.OnTriggerEnterAsObservable()
                .Where(collider => IsObstaclesTag(collider.gameObject))
                .Subscribe(collider => HitPlayer(player, collider.gameObject, skillId))
                .AddTo(effectClone);

            DisableCollider(effectCollider).Forget();
        }

        private static async UniTask DisableCollider(Collider collider)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(ColliderEnableDuration));
            collider.enabled = false;
        }

        public void Dispose()
        {
        }
    }
}