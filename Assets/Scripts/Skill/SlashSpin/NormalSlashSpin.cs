using AttributeAttack;
using Common.Data;
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
            _animator.SetTrigger(GameCommonData.SlashSpinHashKey);
        }

        public void Dispose()
        {
        }

        public class Factory : PlaceholderFactory<Animator, NormalSlashSpin>
        {
        }
    }
}