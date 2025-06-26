using System;
using System.Threading;
using AttributeAttack;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager.DataManager;
using Repository;
using UniRx;
using UniRx.Triggers;
using Unity.Mathematics;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Skill.MagicShot
{
    public class MagicShotBase : AttackSkillBase, IAttackBehaviour
    {
        private readonly SkillEffectRepository _skillEffectRepository;
        private readonly SkillMasterDataRepository _skillMasterDataRepository;
        private const float EffectInstantiateDelayTime = 0.4f;
        private const float EffectHeight = 0.5f;
        private const float EffectScale = 0.4f;
        private const float EffectLifeTime = 1f;
        private const float WaitDuration = 0.1f;
        private const int ShotCount = 1;

        [Inject]
        public MagicShotBase
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

        protected void MagicShot
        (
            AbnormalCondition abnormalCondition,
            int skillId,
            Transform playerTransform
        )
        {
            _Cts = new CancellationTokenSource();
            Observable.Timer(TimeSpan.FromSeconds(EffectInstantiateDelayTime))
                .Subscribe(_ => { ActivateEffect(playerTransform, abnormalCondition, skillId); })
                .AddTo(_Cts.Token);
        }

        protected void ActivateEffect
        (
            Transform playerTransform,
            AbnormalCondition abnormalCondition,
            int skillId
        )
        {
            for (var i = 0; i < ShotCount; i++)
            {
                var effectClone = InstantiateEffect(abnormalCondition, playerTransform);
                MoveEffect(playerTransform, effectClone, skillId);
                var particle = effectClone.GetComponent<ParticleSystem>();
                SetUpCollider(effectClone, particle, playerTransform, skillId);
            }
        }

        private GameObject InstantiateEffect(AbnormalCondition abnormalCondition, Transform playerTransform)
        {
            var effect = _skillEffectRepository.GetMagicShotEffect(abnormalCondition);
            var spawnPosition = GetSpawnPosition(playerTransform);
            var effectClone = Object.Instantiate(effect, spawnPosition, quaternion.identity);
            effectClone.transform.position += playerTransform.forward;
            effectClone.transform.localScale *= EffectScale;

            return effectClone.gameObject;
        }

        private void MoveEffect(Transform playerTransform, GameObject effectClone, int skillId)
        {
            var skillMasterData = _skillMasterDataRepository.GetSkillData(skillId);
            var range = skillMasterData.Range;
            var spawnPosition = GetSpawnPosition(playerTransform);
            var endPos = spawnPosition + playerTransform.forward * range;
            var particle = effectClone.GetComponent<ParticleSystem>();
            effectClone.transform.DOMove(endPos, EffectLifeTime)
                .SetEase(Ease.Linear)
                .OnComplete(() => { DestroyEffect(particle.gameObject); })
                .SetLink(effectClone.gameObject);
        }

        private void SetUpCollider(GameObject effectClone, ParticleSystem particle, Transform playerTransform, int skillId)
        {
            var effectCollider = effectClone.GetComponent<Collider>();
            effectCollider.isTrigger = true;
            effectCollider.OnTriggerEnterAsObservable()
                .Where(collider => IsObstaclesTag(collider.gameObject))
                .Delay(TimeSpan.FromSeconds(WaitDuration))
                .Subscribe(collider => { HitEffect(particle, collider.gameObject, playerTransform.gameObject, skillId); })
                .AddTo(effectClone);
        }

        private void HitEffect
        (
            ParticleSystem particle,
            GameObject hitObject,
            GameObject player,
            int skillId
        )
        {
            if (!hitObject.CompareTag(GameCommonData.PlayerTag))
            {
                DestroyEffect(particle.gameObject);
                return;
            }

            DestroyEffect(particle.gameObject);
            HitPlayer(player, hitObject, skillId);
        }

        private void DestroyEffect(GameObject effectClone)
        {
            if (effectClone == null)
            {
                return;
            }

            var particle = effectClone.GetComponent<ParticleSystem>();
            particle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            Object.Destroy(effectClone);
            Cancel();
        }

        private static Vector3 GetSpawnPosition(Transform playerTransform)
        {
            var playerPosition = playerTransform.position;
            return new Vector3(playerPosition.x, playerPosition.y + EffectHeight, playerPosition.z);
        }

        public void Dispose()
        {
        }
    }
}