using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Manager.BattleManager
{
    public class BattleResultView : MonoBehaviour
    {
        [SerializeField] private Button okButton;
        [SerializeField] private Button adButton;
        
        public IObservable<Unit> OkButtonObservable => okButton.OnClickAsObservable();
    }
}