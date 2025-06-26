using System;
using MoreMountains.Feedbacks;
using UI.BattleCore;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Manager.BattleManager
{
    public class BattleStartView : BattleViewBase
    {
        [SerializeField] private Animator battleStartAnimator;
        [SerializeField] private MMF_Player _battleStartFeedback;
        private ObservableStateMachineTrigger _observableStateMachineTrigger;

        public void Initialize()
        {
            _observableStateMachineTrigger = battleStartAnimator.GetBehaviour<ObservableStateMachineTrigger>();
        }

        public void PlayBattleStartFeedback()
        {
            _battleStartFeedback.PlayFeedbacks();
        }

        public IObservable<Unit> _Exit => _observableStateMachineTrigger
            .OnStateExitAsObservable()
            .AsUnitObservable();
    }
}