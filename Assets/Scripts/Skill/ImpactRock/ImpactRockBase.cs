using System;
using AttributeAttack;
using Common.Data;
using MoreMountains.Tools;
using Repository;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Skill.ImpactRock
{
    public class ImpactRockBase : AttackSkillBase, IAttackBehaviour
    {
        private GameObject _effectClone;
        private readonly SkillEffectRepository _skillEffectRepository;
        private const float DelayTime = 0.47f;

        [Inject]
        public ImpactRockBase
        (
            SkillEffectRepository skillEffectRepository
        )
        {
            _skillEffectRepository = skillEffectRepository;
        }

        public virtual void Attack()
        {
        }

        protected void ImpactRock
        (
            AbnormalCondition abnormalCondition,
            int skillId,
            Transform playerTransform
        )
        {
            Observable
                .Timer(TimeSpan.FromSeconds(DelayTime))
                .Subscribe(_ =>
                {
                    ActivateEffect(playerTransform, abnormalCondition, skillId);
                    SetupCollider(playerTransform, skillId);
                })
                .AddTo(playerTransform);
        }

        protected virtual void ActivateEffect
        (
            Transform playerTransform,
            AbnormalCondition abnormalCondition,
            int skillId
        )
        {
            var effect = _skillEffectRepository.GetImpactRockEffect(abnormalCondition);
            var playerPosition = playerTransform.position;
            var spawnPosition = new Vector3(playerPosition.x, playerPosition.y, playerPosition.z);
            var spawnRotation = new Vector3(0, playerTransform.eulerAngles.y, 0);
            _effectClone = Object.Instantiate(effect, spawnPosition, Quaternion.Euler(spawnRotation)).gameObject;
            SetupParticleSystem(_effectClone);
        }

        private void SetupCollider
        (
            Component playerTransform,
            int skillId
        )
        {
            var colliders = _effectClone.GetComponentsInChildren<Collider>();
            var player = playerTransform.gameObject;

            foreach (var effectCollider in colliders)
            {
                effectCollider.OnTriggerEnterAsObservable()
                    .Where(collider => IsObstaclesTag(collider.gameObject))
                    .Subscribe(collider => HitPlayer(player, collider.gameObject, skillId))
                    .AddTo(_effectClone);
            }
        }

        public virtual void Dispose()
        {
        }
    }
}