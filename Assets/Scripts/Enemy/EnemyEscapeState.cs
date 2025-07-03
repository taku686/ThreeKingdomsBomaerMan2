using Pathfinding;
using UnityEngine;
using State = StateMachine<Enemy.EnemyCore>.State;

namespace Enemy
{
    public partial class EnemyCore
    {
        public class EnemyEscapeState : State
        {
            private Seeker _seeker;
            private AIPath _aiPath;
            private Transform _target;
            private MapManager _mapManager;
            private StateMachine<EnemyCore> _stateMachine;
            private const int SearchLength = 1000;
            private const int Spread = 100;
            private const float AimStrength = 0;

            protected override void OnEnter(State prevState)
            {
                Debug.Log("逃走開始");
                Initialize();
            }

            protected override void OnUpdate()
            {
                if (_aiPath == null)
                {
                    return;
                }

                if (_aiPath.reachedEndOfPath)
                {
                    Debug.Log("行き止まり");
                    _stateMachine.Dispatch((int)EnemyState.Move);
                }

                if (_aiPath.reachedDestination)
                {
                    Debug.Log("目的地に到達");
                    _stateMachine.Dispatch((int)EnemyState.Move);
                }
            }

            private void Initialize()
            {
                _seeker = Owner._seeker;
                _aiPath = Owner._aiPath;
                _target = Owner._target;
                _stateMachine = Owner._stateMachine;
                _mapManager = Owner.mapManager;
                Escape();
            }

            private Vector3 GetDestination()
            {
                var position = Owner.transform.position;
                var nearestNoneArea = _mapManager.GetNearestNoneArea(position);
                var destination = new Vector3(nearestNoneArea.Item1, position.y, nearestNoneArea.Item2);
                return destination;
            }

            private void Escape()
            {
                if (_seeker == null || _target == null)
                {
                    return;
                }

                var startPos = Owner.transform.position;
                var endPos = GetDestination();
                _seeker.StartPath(startPos, endPos, OnPathComplete);

                Debug.Log("パスセット");
            }

            private void OnPathComplete(Path path)
            {
                Debug.Log("Yay, we got a path back. Did it have an error? " + path.error);
            }
        }
    }
}