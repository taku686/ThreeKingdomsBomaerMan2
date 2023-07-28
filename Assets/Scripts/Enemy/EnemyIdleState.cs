using Common.Data;
using Pathfinding;
using UnityEngine;
using UnityEngine.TextCore.Text;
using State = StateMachine<Enemy.EnemyCore>.State;

namespace Enemy
{
    public partial class EnemyCore
    {
        public class EnemyIdleState : State
        {
            private StateMachine<EnemyCore> _stateMachine;
            private bool _isDecideTarget;

            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            protected override void OnUpdate()
            {
                DecideTarget();
                if (_isDecideTarget)
                {
                    _isDecideTarget = false;
                    _stateMachine.Dispatch((int)EnemyState.Move);
                }
            }

            private void Initialize()
            {
                _stateMachine = Owner._stateMachine;
            }


            private void DecideTarget()
            {
                if (_isDecideTarget)
                {
                    return;
                }

                var targets = GameObject.FindGameObjectsWithTag(GameCommonData.PlayerTag);
                if (targets == null)
                {
                    return;
                }

                Debug.Log("ターゲット発見");
                var targetIndex = Random.Range(0, targets.Length);
                var target = targets[targetIndex];
                Owner._target = target.transform;
                _isDecideTarget = true;
            }
        }
    }
}