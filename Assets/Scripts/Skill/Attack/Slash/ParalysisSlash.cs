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
    public class ParalysisSlash : SlashBase
    {
        private readonly Animator _animator;
        private readonly Transform _playerTransform;
        private readonly IAttackBehaviour _attackBehaviour;

        [Inject]
        public ParalysisSlash
        (
            Animator animator,
            Transform playerTransform,
            IAttackBehaviour attackBehaviour,
            SkillEffectRepository skillEffectRepository
        ) : base(skillEffectRepository)
        {
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
                .Delay(TimeSpan.FromSeconds(0.1f))
                .Subscribe(_ =>
                {
                    var effect = _SkillEffectRepository.GetSkillEffect(AbnormalCondition.Paralysis);
                    var playerPosition = _playerTransform.position;
                    var spawnPosition = new Vector3(playerPosition.x, 0.5f, playerPosition.z);
                    var effectClone = Object.Instantiate(effect, spawnPosition, _playerTransform.rotation);
                })
                .AddTo(_playerTransform);
            Debug.Log("Paralysis Slash Attack");
        }

        public override void Dispose()
        {
        }

        public class Factory : PlaceholderFactory<Animator, Transform, IAttackBehaviour, ParalysisSlash>
        {
        }
    }
}