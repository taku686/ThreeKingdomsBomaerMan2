using System.Threading;
using Common.Data;
using Facade.Skill;
using Manager.NetworkManager;
using Player.Common;
using UniRx.Triggers;
using UnityEngine;
using State = StateMachine<Enemy.EnemyCore>.State;

namespace Enemy
{
    public partial class EnemyCore
    {
        public class EnemySkillStateBase : State
        {
            
            protected PhotonNetworkManager _PhotonNetworkManager => Owner._photonNetworkManager;
            protected PlayerConditionInfo _PlayerConditionInfo => Owner._playerConditionInfo;
            private StateMachine<EnemyCore> _StateMachine => Owner._stateMachine;
            private Animator _Animator => Owner._animator;
            private ObservableStateMachineTrigger _ObservableStateMachineTrigger => Owner._observableStateMachineTrigger;
            private SkillAnimationFacade _SkillAnimationFacade => Owner._skillAnimationFacade;
            private CancellationTokenSource _cts;
            protected SkillMasterData _SkillMasterData;

            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            protected override void OnExit(State nextState)
            {
                Cancel();
            }

            protected override void OnUpdate()
            {
                if (_SkillMasterData._SkillActionTypeEnum == SkillActionType.None)
                {
                    _StateMachine.Dispatch((int)EnemyState.Idle);
                }
            }

            protected virtual void Initialize()
            {
                _cts = new CancellationTokenSource();
                _SkillAnimationFacade.Initialize(_Animator, _ObservableStateMachineTrigger);
            }

            protected void SetupAnimation(SkillMasterData skillMasterData)
            {
                _SkillAnimationFacade.PlayBack(skillMasterData);

                _SkillAnimationFacade.AnimationSubscribe
                (
                    skillMasterData,
                    _cts,
                    () => { _StateMachine.Dispatch((int)EnemyState.Idle); }
                );
            }

            private void Cancel()
            {
                if (_cts == null)
                {
                    return;
                }

                _cts.Cancel();
                _cts.Dispose();
                _cts = null;
            }
        }
    }
}