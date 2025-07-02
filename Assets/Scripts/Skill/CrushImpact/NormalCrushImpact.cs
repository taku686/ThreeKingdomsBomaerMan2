using AttributeAttack;
using Common.Data;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Skill.CrushImpact
{
    public class NormalCrushImpact : IAttackBehaviour
    {
        private readonly Transform _playerTransform;

        //private const float AnimationTime = 0.983f;
        private const float AnimationTime = 0.5f;

        [Inject]
        public NormalCrushImpact
        (
            Transform playerTransform
        )
        {
            _playerTransform = playerTransform;
        }

        public void Attack()
        {
            _playerTransform.GetComponentInChildren<WeaponObject>();
            var startValue = _playerTransform.position;
            var endValue = _playerTransform.position + new Vector3(0, 3f, 0);
            var sequence = DOTween.Sequence();

            sequence
                .Append(_playerTransform
                    .DOMove(endValue, AnimationTime / 2)
                    .SetEase(Ease.OutCubic))
                .Append(_playerTransform
                    .DOMove(startValue, AnimationTime / 2)
                    .SetEase(Ease.InCubic))
                .SetLink(_playerTransform.gameObject);
        }

        public void Dispose()
        {
        }

        public class Factory : PlaceholderFactory<Transform, NormalCrushImpact>
        {
        }
    }
}