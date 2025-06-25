using AttributeAttack;
using Common.Data;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Skill.CrushImpact
{
    public class NormalCrushImpact : IAttackBehaviour
    {
        private readonly Animator _animator;
        private readonly Transform _playerTransform;
        private const float AnimationTime = 0.983f;

        [Inject]
        public NormalCrushImpact
        (
            Animator animator,
            Transform playerTransform
        )
        {
            _animator = animator;
            _playerTransform = playerTransform;
        }

        public void Attack()
        {
            _playerTransform.GetComponentInChildren<WeaponObject>();
            _playerTransform.DOJump(_playerTransform.position, 3f, 1, AnimationTime)
                .SetEase(Ease.InOutQuad)
                .SetLink(_playerTransform.gameObject);
        }

        public void Dispose()
        {
        }

        public class Factory : PlaceholderFactory<Animator, Transform, NormalCrushImpact>
        {
        }
    }
}