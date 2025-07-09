using System;
using System.Threading;
using AttributeAttack;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.DataManager;
using Repository;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Skill.RainArrow
{
    public class RainArrowBase : AttackSkillBase, IAttackBehaviour
    {
        private GameObject _effectClone;
        private readonly SkillEffectRepository _skillEffectRepository;
        private readonly SkillMasterDataRepository _skillMasterDataRepository;
        private const float WaitDurationForStart = 0.1f;
        private const float WaitDurationForEnd = 0.1f;

        [Inject]
        public RainArrowBase
        (
            SkillEffectRepository skillEffectRepository,
            SkillMasterDataRepository skillMasterDataRepository
        )
        {
            _skillEffectRepository = skillEffectRepository;
            _skillMasterDataRepository = skillMasterDataRepository;
        }


        public virtual void Attack()
        {
        }

        protected void RainArrow
        (
            AbnormalCondition abnormalCondition,
            int skillId,
            Transform playerTransform
        )
        {
            var skillData = _skillMasterDataRepository.GetSkillData(skillId);
            var range = skillData.Range;

            Observable
                .Timer(TimeSpan.FromSeconds(WaitDurationForStart))
                .Subscribe(_ =>
                {
                    ActivateEffect(playerTransform, abnormalCondition, skillId, range);
                    SetupCollider(playerTransform, skillId);
                });
        }

        protected virtual void ActivateEffect
        (
            Transform playerTransform,
            AbnormalCondition abnormalCondition,
            int skillId,
            float range
        )
        {
            var effect = _skillEffectRepository.GetRainArrowEffect(abnormalCondition);
            _effectClone = Object.Instantiate(effect).gameObject;
            SetupParticleSystem(_effectClone);
            var playerPosition = playerTransform.position;
            var spawnPosition = new Vector3(playerPosition.x, playerPosition.y, playerPosition.z);
            spawnPosition += playerTransform.forward * 8;
            var effectTransform = _effectClone.transform;
            effectTransform.position = spawnPosition;
        }

        private void SetupCollider
        (
            Component playerTransform,
            int skillId
        )
        {
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

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}