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

namespace Skill.DashAttack
{
    public class DashAttackBase : AttackSkillBase, IAttackBehaviour
    {
        private GameObject _effectClone;
        private readonly SkillEffectRepository _skillEffectRepository;
        private readonly SkillMasterDataRepository _skillMasterDataRepository;
        private const float WaitDurationForStart = 0.34f;
        private const float WaitDurationForEnd = 0.55f;

        [Inject]
        public DashAttackBase
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

        protected void DashAttack
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
                })
                .AddTo(_Cts.Token);

            Observable.Timer(TimeSpan.FromSeconds(WaitDurationForStart))
                .Subscribe(_ => { ActivateEffect(playerTransform, abnormalCondition, skillId); })
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
            var effect = _skillEffectRepository.GetDashAttackEffect(abnormalCondition);
            _effectClone = Object.Instantiate(effect, playerTransform).gameObject;
            _effectClone.transform.localPosition = new Vector3(0.3f, 0.5f, 3f);
            _effectClone.transform.localEulerAngles = new Vector3(0, 90, 0);
            var boxCollider = _effectClone.GetComponent<BoxCollider>();
            boxCollider.isTrigger = true;
            var player = playerTransform.gameObject;

            boxCollider.OnTriggerEnterAsObservable()
                .Where(collider => IsObstaclesTag(collider.gameObject))
                .Subscribe(collider => HitPlayer(player, collider.gameObject, skillId))
                .AddTo(_effectClone);
        }

        public void Dispose()
        {
        }
    }
}