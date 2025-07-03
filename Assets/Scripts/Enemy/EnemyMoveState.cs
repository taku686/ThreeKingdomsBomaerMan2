using Common.Data;
using Pathfinding;
using Photon.Pun;
using UnityEngine;
using State = StateMachine<Enemy.EnemyCore>.State;

namespace Enemy
{
    public partial class EnemyCore
    {
        public class EnemyMoveState : State
        {
            private Seeker _Seeker => Owner._seeker;
            private AIPath _AIPath => Owner._aiPath;
            private StateMachine<EnemyCore> _StateMachine => Owner._stateMachine;

            private Transform _PlayerTransform => Owner.transform;
            private const float WanderingRadius = 5f;
            private const float WanderInterval = 3f; // How often to choose a new wander point
            private const float StoppingDistance = 1f; // How close to get to the wander point before choosing a new one

            private float _nextWanderTime;
            private Vector3 _currentWanderTarget;

            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            private void Initialize()
            {
                if (_AIPath != null)
                {
                    _AIPath.maxSpeed = 3f; // 適宜調整
                    _AIPath.endReachedDistance = StoppingDistance;
                }

                _nextWanderTime = Time.time + Random.Range(0f, WanderInterval);
                ChooseNewWanderPoint();
            }

            protected override void OnUpdate()
            {
                /*if (_AIPath == null)
                {
                    return;
                }

                if (_AIPath.reachedEndOfPath)
                {
                    Debug.Log("行き止まり");
                    _StateMachine.Dispatch((int)EnemyState.PutBomb);
                }

                if (_AIPath.reachedDestination)
                {
                    Debug.Log("目的地に到達");
                    _StateMachine.Dispatch((int)EnemyState.PutBomb);
                }*/
                if (Time.time >= _nextWanderTime)
                {
                    if (_AIPath.reachedEndOfPath)
                    {
                        ChooseNewWanderPoint();
                    }
                    else if (Vector3.Distance(_PlayerTransform.position, _currentWanderTarget) < StoppingDistance)
                    {
                        ChooseNewWanderPoint();
                    }
                }

                // AIPath を使用していない場合の簡易的な移動処理
                if (_AIPath == null && _Seeker.IsDone() && Vector3.Distance(_PlayerTransform.position, _currentWanderTarget) > StoppingDistance)
                {
                    var moveDirection = (_currentWanderTarget - _PlayerTransform.position).normalized;
                    _PlayerTransform.position += moveDirection * 3f * Time.deltaTime; // 適宜速度調整
                }
            }


            /*private void Move()
            {
                if (_Seeker == null || _Target == null)
                {
                    return;
                }

                Debug.Log("パスセット");
                _Seeker.StartPath(Owner.transform.position, _Target.position, OnPathComplete);
            }*/

            private void ChooseNewWanderPoint()
            {
                var target = FindTarget();
                var randomCircle = Random.insideUnitCircle * WanderingRadius;
                var wanderPoint = target + new Vector3(randomCircle.x, 0f, randomCircle.y);

                // 地形や障害物を考慮して到達可能なポイントを探す (A* Pathfinding Projectの機能を利用)
                if (_Seeker != null)
                {
                    _Seeker.StartPath(_PlayerTransform.position, wanderPoint, OnPathComplete);
                }
                else
                {
                    _currentWanderTarget = wanderPoint;
                    _nextWanderTime = Time.time + WanderInterval;
                }
            }

            private Vector3 FindTarget()
            {
                //todo review later
                var candidateTargets = GameObject.FindGameObjectsWithTag(GameCommonData.PlayerTag);
                var targetCount = candidateTargets.Length;
                if (targetCount == 0)
                {
                    return _PlayerTransform.position; // No targets found
                }

                var targetIndex = Random.Range(0, targetCount);
                var target = candidateTargets[targetIndex];
                var photonView = target.GetComponent<PhotonView>();
                var photonTransformView = target.GetComponent<PhotonTransformView>();
                if (photonTransformView == null || Owner.IsMine(photonView.InstantiationId))
                {
                    return _PlayerTransform.position; // Skip if the target is not valid
                }

                return target.transform.position; // Return the position of the chosen target
            }

            private void OnPathComplete(Path p)
            {
                switch (p.error)
                {
                    case false when _AIPath != null:
                        _AIPath.SetPath(p);
                        _AIPath.canMove = true;
                        _nextWanderTime = Time.time + WanderInterval;
                        break;
                    case false when _AIPath == null:
                        _currentWanderTarget = p.vectorPath[^1]; // パスの最後の点を目指す
                        _nextWanderTime = Time.time + WanderInterval;
                        break;
                }
            }
        }
    }
}