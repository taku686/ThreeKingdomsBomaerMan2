using System;
using AttributeAttack;
using Common.Data;
using Repository;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Skill.Attack
{
    public class SlashBase : AttackSkillBase, IAttackBehaviour
    {
        private GameObject _effectClone;
        private readonly SkillEffectRepository _skillEffectRepository;
        private const float DelayTime = 0.1f;
        private const float WaitDurationForEnd = 1.5f;
        private const float EffectHeight = 0.5f;

        [Inject]
        public SlashBase
        (
            SkillEffectRepository skillEffectRepository
        )
        {
            _skillEffectRepository = skillEffectRepository;
        }

        public virtual void Attack()
        {
        }

        protected void Slash
        (
            AbnormalCondition abnormalCondition,
            int skillId,
            Transform playerTransform
        )
        {
            Observable
                .Timer(TimeSpan.FromSeconds(DelayTime))
                .Subscribe(_ => { ActivateEffect(playerTransform, abnormalCondition, skillId); })
                .AddTo(playerTransform);

            Observable
                .Timer(TimeSpan.FromSeconds(WaitDurationForEnd))
                .Subscribe(_ => { Object.Destroy(_effectClone); })
                .AddTo(playerTransform);
        }

        protected virtual void ActivateEffect
        (
            Transform playerTransform,
            AbnormalCondition abnormalCondition,
            int skillId
        )
        {
            var effect = _skillEffectRepository.GetSlashEffect(abnormalCondition);
            _effectClone = Object.Instantiate(effect, playerTransform).gameObject;
            var spawnPosition = new Vector3(0, EffectHeight, 0);
            var spawnRotation = new Vector3(180, 34.3f, 0);
            _effectClone.transform.localPosition = spawnPosition;
            _effectClone.transform.localEulerAngles = spawnRotation;
            var colliders = _effectClone.GetComponents<SphereCollider>();
            var player = playerTransform.gameObject;

            foreach (var sphereCollider in colliders)
            {
                sphereCollider.OnTriggerEnterAsObservable()
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