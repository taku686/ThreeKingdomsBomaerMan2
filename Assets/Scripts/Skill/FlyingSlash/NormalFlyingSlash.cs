using AttributeAttack;
using Common.Data;
using UnityEngine;
using Zenject;

namespace Skill.Attack.FlyingSlash
{
    public class NormalFlyingSlash : IAttackBehaviour
    {
        private readonly Animator _animator;

        [Inject]
        public NormalFlyingSlash(Animator animator)
        {
            _animator = animator;
        }

        public void Attack()
        {
            _animator.SetTrigger(GameCommonData.SlashHashKey);
        }

        public void Dispose()
        {
        }

        public class Factory : PlaceholderFactory<Animator, NormalFlyingSlash>
        {
        }
    }
}