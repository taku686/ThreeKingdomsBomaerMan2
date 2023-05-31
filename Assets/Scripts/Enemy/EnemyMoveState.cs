using Pathfinding;
using UnityEngine;
using State = StateMachine<Enemy.EnemyCore>.State;

namespace Enemy
{
    public partial class EnemyCore
    {
        public class EnemyMoveState : State
        {
            private Seeker _seeker;
            private AILerp _aiLerp;
            private Transform _target;
            private StateMachine<EnemyCore> _stateMachine;
            protected override void OnEnter(State prevState)
            {
                Debug.Log("移動開始");
                Initialize();
            }

            protected override void OnUpdate()
            {
                if (_aiLerp == null)
                {
                    return;
                }

                if (_aiLerp.reachedEndOfPath)
                {
                    Debug.Log("行き止まり");
                    _stateMachine.Dispatch((int)EnemyState.PutBomb);
                }
            }

            private void Initialize()
            {
                _seeker = Owner._seeker;
                _aiLerp = Owner._aiLerp;
                _target = Owner._target;
                _stateMachine = Owner._stateMachine;
                Move();
            }

            private void Move()
            {
                if (_seeker == null || _target == null)
                {
                    return;
                }


                Debug.Log("パスセット");
                _seeker.StartPath(Owner.transform.position, _target.position, OnPathComplete);
            }

            private void OnPathComplete(Path path)
            {
                Debug.Log("Yay, we got a path back. Did it have an error? " + path.error);
            }
        }
    }
}