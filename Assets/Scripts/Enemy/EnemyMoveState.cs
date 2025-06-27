using Pathfinding;
using UnityEngine;
using State = StateMachine<Enemy.EnemyCore>.State;

namespace Enemy
{
    public partial class EnemyCore
    {
        public class EnemyMoveState : State
        {
            private Seeker _Seeker => Owner._seeker;
            private AILerp _AILerp => Owner._aiLerp;
            private Transform _Target => Owner._target;
            private StateMachine<EnemyCore> _StateMachine => Owner._stateMachine;

            protected override void OnEnter(State prevState)
            {
                Debug.Log("移動開始");
                Initialize();
            }

            private void Initialize()
            {
                Move();
            }

            protected override void OnUpdate()
            {
                if (_AILerp == null)
                {
                    return;
                }

                if (_AILerp.reachedEndOfPath)
                {
                    Debug.Log("行き止まり");
                    _StateMachine.Dispatch((int)EnemyState.PutBomb);
                }

                if (_AILerp.reachedDestination)
                {
                    Debug.Log("目的地に到達");
                    _StateMachine.Dispatch((int)EnemyState.PutBomb);
                }
            }


            private void Move()
            {
                if (_Seeker == null || _Target == null)
                {
                    return;
                }

                Debug.Log("パスセット");
                _Seeker.StartPath(Owner.transform.position, _Target.position, OnPathComplete);
            }

            private void OnPathComplete(Path path)
            {
                Debug.Log("Yay, we got a path back. Did it have an error? " + path.error);
            }
        }
    }
}