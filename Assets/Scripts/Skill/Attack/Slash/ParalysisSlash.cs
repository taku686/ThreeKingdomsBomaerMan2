using System;
using AttributeAttack;
using Common.Data;
using Repository;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;
using TargetScanner = DC.Scanner.TargetScanner;

namespace Skill.Attack
{
    public class ParalysisSlash : SlashBase
    {
        private readonly int _skillId;
        private readonly TargetScanner _targetScanner;
        private readonly Animator _animator;
        private readonly Transform _playerTransform;
        private readonly IAttackBehaviour _attackBehaviour;
        private const float DelayTime = 0.1f;
        private const float EffectHeight = 0.5f;

        [Inject]
        public ParalysisSlash
        (
            int skillId,
            TargetScanner targetScanner,
            Animator animator,
            Transform playerTransform,
            IAttackBehaviour attackBehaviour,
            SkillEffectRepository skillEffectRepository
        ) : base(skillEffectRepository)
        {
            _skillId = skillId;
            _targetScanner = targetScanner;
            _animator = animator;
            _playerTransform = playerTransform;
            _attackBehaviour = attackBehaviour;
        }

        public override void Attack()
        {
            _attackBehaviour.Attack();
            var observableStateMachineTrigger = _animator.GetBehaviour<ObservableStateMachineTrigger>();
            observableStateMachineTrigger
                .OnStateEnterAsObservable()
                .Where(info => info.StateInfo.IsName(GameCommonData.SlashKey))
                .Take(1)
                .Delay(TimeSpan.FromSeconds(DelayTime))
                .Subscribe(_ =>
                {
                    ActivateEffect();
                    HitPlayer(_targetScanner, _skillId);
                })
                .AddTo(_playerTransform);
        }

        private void ActivateEffect()
        {
            var effect = _SkillEffectRepository.GetSkillEffect(AbnormalCondition.Paralysis);
            var playerPosition = _playerTransform.position;
            var spawnPosition = new Vector3(playerPosition.x, EffectHeight, playerPosition.z);
            var effectClone = Object.Instantiate(effect, spawnPosition, _playerTransform.rotation);
        }

        public override void Dispose()
        {
        }

        public class Factory : PlaceholderFactory<int, TargetScanner, Animator, Transform, IAttackBehaviour, ParalysisSlash>
        {
        }
    }
}