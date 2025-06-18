using System;
using AttributeAttack;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager.DataManager;
using Repository;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Skill.Attack.FlyingSlash
{
    public class FlyingSlashBase : AttackSkillBase, IAttackBehaviour
    {
        private readonly SkillEffectRepository _skillEffectRepository;
        private readonly SkillMasterDataRepository _skillMasterDataRepository;
        private const float DelayTime = 0.1f;
        private const float EffectHeight = 0.5f;
        private const float EffectScale = 0.3f;
        private const float EffectDuration = 0.5f;
        private const float WaitDuration = 0.1f;

        [Inject]
        public FlyingSlashBase
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

        protected void FlyingSlash(
            AbnormalCondition abnormalCondition,
            Animator animator,
            int skillId,
            Transform playerTransform
        )
        {
            var observableStateMachineTrigger = animator.GetBehaviour<ObservableStateMachineTrigger>();
            observableStateMachineTrigger
                .OnStateEnterAsObservable()
                .Where(info => info.StateInfo.IsName(GameCommonData.SlashKey))
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
            var skillMasterData = _skillMasterDataRepository.GetSkillData(skillId);
            var range = skillMasterData.Range;
            var effect = _skillEffectRepository.GetFlyingSlashEffect(abnormalCondition);
            var playerPosition = playerTransform.position;
            var spawnPosition = new Vector3(playerPosition.x, playerPosition.y + EffectHeight, playerPosition.z);
            var spawnRotation = new Vector3(0, playerTransform.eulerAngles.y + 180, 0);
            var effectClone = Object.Instantiate(effect, spawnPosition, Quaternion.Euler(spawnRotation));
            effectClone.transform.position -= effectClone.transform.forward * 2;
            effectClone.transform.localScale *= EffectScale;
            var endPos = spawnPosition + playerTransform.forward * range;

            var particle = effectClone.GetComponent<ParticleSystem>();
            effectClone.transform.DOMove(endPos, EffectDuration)
                .SetEase(Ease.Linear)
                .OnComplete(() => particle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear))
                .SetLink(effectClone.gameObject);

            var boxCollider = effectClone.GetComponent<BoxCollider>();
            boxCollider.isTrigger = true;

            boxCollider.OnTriggerEnterAsObservable()
                .Where(collider => IsObstaclesTag(collider.gameObject))
                .SelectMany(collider => HitEffectAsync(particle, collider.gameObject, playerTransform.gameObject, skillId).ToObservable())
                .Subscribe()
                .AddTo(effectClone);
        }

        private static async UniTask HitEffectAsync
        (
            ParticleSystem particle,
            GameObject collider,
            GameObject player,
            int skillId
        )
        {
            await UniTask.Delay(TimeSpan.FromSeconds(WaitDuration));
            particle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            if (!collider.CompareTag(GameCommonData.PlayerTag))
            {
                return;
            }

            HitPlayer(player, collider, skillId);
        }


        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}