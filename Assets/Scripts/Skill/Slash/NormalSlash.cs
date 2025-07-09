using AttributeAttack;
using UnityEngine;
using Zenject;

namespace Skill.Attack
{
    public class NormalSlash : IAttackBehaviour
    {
        private readonly Animator _animator;

        [Inject]
        public NormalSlash(Animator animator)
        {
            _animator = animator;
        }

        public void Attack()
        {
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }

        public class Factory : PlaceholderFactory<Animator, NormalSlash>
        {
        }
    }
}