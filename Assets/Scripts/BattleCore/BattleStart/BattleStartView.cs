using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Manager.BattleManager
{
    public class BattleStartView : MonoBehaviour
    {
        [SerializeField] private Animator battleStartAnimator;
        private ObservableStateMachineTrigger observableStateMachineTrigger;

        public void Initialize()
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
            observableStateMachineTrigger = battleStartAnimator.GetBehaviour<ObservableStateMachineTrigger>();
        }

        public IObservable<Unit> Exit => observableStateMachineTrigger
            .OnStateExitAsObservable()
            .AsUnitObservable();
    }
}