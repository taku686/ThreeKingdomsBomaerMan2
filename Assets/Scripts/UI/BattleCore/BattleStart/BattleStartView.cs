using System;
using UI.BattleCore;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Manager.BattleManager
{
    public class BattleStartView : BattleViewBase
    {
        [SerializeField] private Animator battleStartAnimator;
        private ObservableStateMachineTrigger _observableStateMachineTrigger;

        public void Initialize()
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }

            _observableStateMachineTrigger = battleStartAnimator.GetBehaviour<ObservableStateMachineTrigger>();
        }

        public IObservable<Unit> _Exit => _observableStateMachineTrigger
            .OnStateExitAsObservable()
            .AsUnitObservable();
    }
}