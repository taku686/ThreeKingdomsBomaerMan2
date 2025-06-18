using AttributeAttack;
using Common.Data;
using UnityEngine;
using Zenject;

namespace Skill.MagicShot
{
    public class NormalMagicShot : IAttackBehaviour
    {
        private readonly Animator _animator;

        [Inject]
        public NormalMagicShot(Animator animator)
        {
            _animator = animator;
        }

        public void Attack()
        {
            _animator.SetTrigger(GameCommonData.MagicShotHashKey);
        }

        public void Dispose()
        {
        }
        
        public class Factory : PlaceholderFactory<Animator, NormalMagicShot>
        {
        }
    }
}