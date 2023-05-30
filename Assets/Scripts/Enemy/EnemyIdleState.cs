using Common.Data;
using Pathfinding;
using UnityEngine;
using State = StateMachine<Enemy.EnemyCore>.State;

namespace Enemy
{
    public partial class EnemyCore
    {
        public class EnemyIdleState : State
        {
            private Seeker _seeker;

            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            private void Initialize()
            {
                _seeker = Owner._seeker;
                DecideTarget();
            }


            private void DecideTarget()
            {
                var targets = GameObject.FindGameObjectsWithTag(GameCommonData.PlayerTag);
                var targetIndex = Random.Range(0, targets.Length);
                var target = targets[targetIndex];
                _seeker.StartPath(Owner.transform.position, target.transform.position);
            }
        }
    }
}