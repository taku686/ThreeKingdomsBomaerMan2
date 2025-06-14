using AttributeAttack;
using Common.Data;
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
            _animator.SetTrigger(GameCommonData.SlashHashKey);
        }

        public void Attack(AbnormalCondition attribute)
        {
            throw new System.NotImplementedException();
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