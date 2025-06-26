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

namespace Skill.SlashSpin
{
    public class SlashSpinBase : AttackSkillBase, IAttackBehaviour
    {
        private bool _isSpawnEffect;
        private GameObject _effectClone;
        private readonly SkillEffectRepository _skillEffectRepository;
        private readonly SkillMasterDataRepository _skillMasterDataRepository;
        private const float EffectHeight = 0.5f;
        private const float WaitDurationForStart = 1f;
        private const float WaitDurationForEnd = 1.5f;


        [Inject]
        public SlashSpinBase
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

        protected void SlashSpin
        (
            AbnormalCondition abnormalCondition,
            int skillId,
            Transform playerTransform
        )
        {
            _Cts = new CancellationTokenSource();
            var rigid = playerTransform.GetComponent<Rigidbody>();
            var skillData = _skillMasterDataRepository.GetSkillData(skillId);
            var range = skillData.Range;

            Observable
                .EveryFixedUpdate()
                .Where(_ => _Cts is { IsCancellationRequested: false })
                .SelectMany(_ => UniTask.Delay(TimeSpan.FromSeconds(WaitDurationForStart), DelayType.DeltaTime, PlayerLoopTiming.FixedUpdate).ToObservable())
                .Subscribe(_ =>
                {
                    const float moveDuration = WaitDurationForEnd - WaitDurationForStart;
                    rigid.velocity = playerTransform.forward * (range / moveDuration);
                    ActivateEffect(playerTransform, abnormalCondition, skillId);
                })
                .AddTo(_Cts.Token);

            Observable.Timer(TimeSpan.FromSeconds(WaitDurationForEnd))
                .Subscribe(_ =>
                {
                    rigid.velocity = Vector3.zero;
                    var particleSystems = _effectClone?.GetComponentsInChildren<ParticleSystem>();
                    if (particleSystems != null)
                    {
                        foreach (var particleSystem in particleSystems)
                        {
                            particleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                        }
                    }

                    Object.Destroy(_effectClone);
                    Cancel();
                })
                .AddTo(_Cts.Token);
        }

        protected virtual void ActivateEffect
        (
            Transform playerTransform,
            AbnormalCondition abnormalCondition,
            int skillId
        )
        {
            if (_isSpawnEffect)
            {
                return;
            }

            _isSpawnEffect = true;
            var effect = _skillEffectRepository.GetSlashSpinEffect(abnormalCondition);
            _effectClone = Object.Instantiate(effect, playerTransform).gameObject;
            _effectClone.transform.localPosition = new Vector3(0, EffectHeight, 0);
            _effectClone.transform.localEulerAngles = new Vector3(0, 90, 0);
            var effectCollider = _effectClone.GetComponent<Collider>();
            effectCollider.isTrigger = true;
            var player = playerTransform.gameObject;

            effectCollider.OnTriggerEnterAsObservable()
                .Where(collider => IsObstaclesTag(collider.gameObject))
                .Subscribe(collider => HitPlayer(player, collider.gameObject, skillId))
                .AddTo(_effectClone);
        }

        public void Dispose()
        {
        }
    }
}