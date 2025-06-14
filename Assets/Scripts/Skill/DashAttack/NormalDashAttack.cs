using AttributeAttack;
using Common.Data;
using Player.Common;
using UnityEngine;
using Zenject;

namespace Skill.DashAttack
{
    public class NormalDashAttack : IAttackBehaviour
    {
        private readonly Animator _animator;
        private readonly PlayerDash _playerDash;
        private const float DashForce = 6f;

        [Inject]
        public NormalDashAttack
        (
            Animator animator,
            PlayerDash playerDash
        )
        {
            _animator = animator;
            _playerDash = playerDash;
        }

        public void Attack()
        {
            _playerDash.Dash(DashForce);
            _animator.SetTrigger(GameCommonData.DashAttackHashKey);
        }

        public void Dispose()
        {
        }

        public class Factory : PlaceholderFactory<Animator, PlayerDash, NormalDashAttack>
        {
        }
    }
}