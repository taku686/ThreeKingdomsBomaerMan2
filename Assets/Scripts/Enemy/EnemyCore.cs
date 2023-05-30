using System;
using Pathfinding;
using UnityEngine;

namespace Enemy
{
    public partial class EnemyCore : MonoBehaviour
    {
        private StateMachine<EnemyCore> _stateMachine;
        private Seeker _seeker;

        private enum EnemyState
        {
            Idle,
            Move,
            Escape,
            Skill1,
            Skill2,
            SetBomb,
            Dead
        }

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            _seeker = GetComponent<Seeker>();
            InitializeState();
        }

        private void InitializeState()
        {
            _stateMachine = new StateMachine<EnemyCore>(this);
            _stateMachine.Start<EnemyIdleState>();
            _stateMachine.AddAnyTransition<EnemyIdleState>((int)EnemyState.Idle);
            _stateMachine.AddAnyTransition<EnemyDeadState>((int)EnemyState.Dead);
            _stateMachine.AddTransition<EnemyIdleState, EnemyMoveState>((int)EnemyState.Move);
        }
    }
}