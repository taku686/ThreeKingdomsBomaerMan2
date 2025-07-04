using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Pathfinding;
using Photon.Pun;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using State = StateMachine<Enemy.EnemyCore>.State;

namespace Enemy
{
    public partial class EnemyCore
    {
        public class EnemyMoveState : State
        {
            private AIDestinationSetter _AIDestinationSetter => Owner._aiDestinationSetter;
            private FollowerEntity _FollowerEntity => Owner._followerEntity;
            private StateMachine<EnemyCore> _StateMachine => Owner._stateMachine;
            private Rigidbody _Rigidbody => Owner._rigidbody;
            private Transform _PlayerTransform => Owner.transform;
            private const float MinDistance = 5f;
            private const float StoppingDistance = 3f; // How close to get to the wander point before choosing a new one
            private const int TryCount = 5;
            private Vector3 _currentTarget;
            private CancellationTokenSource _cts;

            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            protected override void OnExit(State nextState)
            {
                Cancel(_cts);
            }

            private void Initialize()
            {
                Subscribe();
                _FollowerEntity.isStopped = false;
                _Rigidbody.isKinematic = true; // Disable physics interactions
                if (_FollowerEntity != null)
                {
                    _FollowerEntity.maxSpeed = 3f; // 適宜調整
                    _FollowerEntity.stopDistance = StoppingDistance;
                }

                ChooseNewWanderPoint();
            }

            private void Subscribe()
            {
                _cts = new CancellationTokenSource();

                _PlayerTransform
                    .OnCollisionEnterAsObservable()
                    .Where(collision => collision.gameObject.CompareTag(GameCommonData.WallTag))
                    .Subscribe(_ => ChooseNewWanderPoint())
                    .AddTo(_cts.Token);
            }

            protected override void OnUpdate()
            {
                if (_FollowerEntity.reachedDestination)
                {
                    ChooseNewWanderPoint();
                }
            }

            private void ChooseNewWanderPoint()
            {
                var target = FindTarget();
                _AIDestinationSetter.target = target; // Clear the current target
            }

            private Transform FindTarget()
            {
                var findCount = 0;
                var candidateTargets = new List<GameObject>();
                var players = GameObject.FindGameObjectsWithTag(GameCommonData.PlayerTag);
                var props = GameObject.FindGameObjectsWithTag(GameCommonData.PropsTag);
                candidateTargets.AddRange(players);
                candidateTargets.AddRange(props);

                while (true)
                {
                    var targetCount = candidateTargets.Count;
                    if (targetCount == 0)
                    {
                        return _PlayerTransform; // No targets found
                    }

                    var targetIndex = Random.Range(0, targetCount);
                    var target = candidateTargets[targetIndex];
                    var photonView = target.GetComponent<PhotonView>();

                    if (photonView != null)
                    {
                        if (Owner.IsMine(photonView.InstantiationId))
                        {
                            continue;
                        }
                    }

                    if
                    (
                        Vector3.Distance(_PlayerTransform.position, target.transform.position) <= MinDistance
                        && findCount < TryCount
                    )
                    {
                        findCount++;
                        continue; // Ensure the target is within the wandering radius
                    }

                    return target.transform; // Return the position of the chosen target
                }
            }
        }
    }
}