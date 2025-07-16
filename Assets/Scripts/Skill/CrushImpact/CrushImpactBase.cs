using System;
using System.Threading;
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
        private GameObject _effectClone;
        private Collider _effectCollider;
        private readonly SkillEffectRepository _skillEffectRepository;
        private const float WaitDurationForStart = 0.85f;
        private const float WaitDurationForEnd = 1.75f;

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
            int skillId,
            Transform playerTransform
        )
        {
            _cts = new CancellationTokenSource();

            Observable
                .Timer(TimeSpan.FromSeconds(WaitDurationForStart))
                .Subscribe(_ =>
                {
                    ActivateEffect(playerTransform, abnormalCondition, skillId);
                    SetupCollider(_effectClone, playerTransform, skillId);
                })
                .AddTo(_cts.Token);

            Observable
                .Timer(TimeSpan.FromSeconds(WaitDurationForEnd))
                .Subscribe(_ =>
                {
                    _effectCollider.enabled = false;
                    Cancel();
                })
                .AddTo(_cts.Token);
        }

        protected void ActivateEffect
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
            _effectClone = effectClone.gameObject;
            FixTransform(effectTransform, playerTransform);
            SetupParticleSystem(_effectClone);
        }

        private static void FixTransform(Transform effectTransform, Transform playerTransform)
        {
            effectTransform.localEulerAngles = new Vector3(-90, 0, 0);
            effectTransform.localScale *= 0.8f;
            effectTransform.localPosition += playerTransform.forward * 2f;
        }

        private void SetupCollider(GameObject effectClone, Transform playerTransform, int skillId)
        {
            _effectCollider = effectClone.GetComponent<Collider>();
            _effectCollider.isTrigger = true;
            var player = playerTransform.gameObject;

            _effectCollider.OnTriggerEnterAsObservable()
                .Where(collider => IsObstaclesTag(collider.gameObject))
                .Subscribe(collider => HitPlayer(player, collider.gameObject, skillId))
                .AddTo(effectClone);
        }

        public void Dispose()
        {
        }
    }
}