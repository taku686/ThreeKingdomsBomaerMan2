using System.Threading;
using Common.Data;
using Facade.Skill;
using Manager.NetworkManager;
using UniRx.Triggers;
using UnityEngine;
using State = StateMachine<Player.Common.PlayerCore>.State;

namespace Player.Common
{
    public partial class PlayerCore
    {
        public class PlayerSkillStateBase : State
        {
            private ObservableStateMachineTrigger _ObservableStateMachineTrigger => Owner._observableStateMachineTrigger;
            protected PhotonNetworkManager _PhotonNetworkManager => Owner._photonNetworkManager;
            protected PlayerConditionInfo _PlayerConditionInfo => Owner._playerConditionInfo;
            private StateMachine<PlayerCore> _StateMachine => Owner._stateMachine;
            private Animator _Animator => Owner._animator;
            protected SkillAnimationFacade _SkillAnimationFacade => Owner._skillAnimationFacade;
            private CancellationTokenSource _cts;
            protected SkillMasterData _skillMasterData;

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
                if (_skillMasterData._SkillActionTypeEnum == SkillActionType.None)
                {
                    _StateMachine.Dispatch((int)PlayerState.Idle);
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
                    () => { _StateMachine.Dispatch((int)PlayerState.Idle); }
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