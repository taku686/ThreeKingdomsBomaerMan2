using AttributeAttack;
using UnityEngine;
using Zenject;

namespace Skill.SlashSpin
{
    public class NormalSlashSpin : IAttackBehaviour
    {
        private readonly Animator _animator;

        [Inject]
        public NormalSlashSpin(Animator animator)
        {
            _animator = animator;
        }

        public void Attack()
        {
        }

        public void Dispose()
        {
        }

        public class Factory : PlaceholderFactory<Animator, NormalSlashSpin>
        {
        }
    }
}