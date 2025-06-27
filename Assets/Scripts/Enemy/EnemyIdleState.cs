using Common.Data;
using Pathfinding;
using Photon.Pun;
using UnityEngine;
using UnityEngine.TextCore.Text;
using State = StateMachine<Enemy.EnemyCore>.State;

namespace Enemy
{
    public partial class EnemyCore
    {
        public class EnemyIdleState : State
        {
            private StateMachine<EnemyCore> _StateMachine => Owner._stateMachine;
            private bool _isDecideTarget;

            protected override void OnEnter(State prevState)
            {
                _isDecideTarget = false;
            }

            protected override void OnUpdate()
            {
                if (DecideTarget())
                {
                    _StateMachine.Dispatch((int)EnemyState.Move);
                }
            }


            private bool DecideTarget()
            {
                if (_isDecideTarget)
                {
                    return true;
                }

                var targets = GameObject.FindGameObjectsWithTag(GameCommonData.PlayerTag);
                if (targets == null)
                {
                    return false;
                }

                Debug.Log("ターゲット発見");

                for (var index = 0; index < targets.Length; index++)
                {
                    var t = targets[index];
                    var targetIndex = Random.Range(0, targets.Length);
                    var target = targets[targetIndex];
                    var photonView = target.GetComponent<PhotonView>();
                    var photonTransformView = target.GetComponent<PhotonTransformView>();
                    if (photonTransformView == null || Owner.IsMine(photonView.InstantiationId))
                    {
                        continue;
                    }

                    Owner._target = target.transform;
                    return true;
                }

                return false;
            }
        }
    }
}