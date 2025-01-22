using System;
using DamageNumbersPro;
using UI.BattleCore;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Manager.BattleManager
{
    public class BattleResultView : BattleViewBase
    {
        [SerializeField] private Button _claimButton;
        [SerializeField] private Button _claimAdButton;
        [SerializeField] private DamageNumberGUI _rankText;
        private const int RankTextScale = 5;
        private const float RankTextPositionX = 0.0f;
        private const float RankTextPositionY = -18.6f;

        public void ApplyView(int rank)
        {
            _rankText.number = rank;
            _rankText.SetScale(RankTextScale);
            _rankText.SetAnchoredPosition(_rankText.transform.parent, new Vector2(RankTextPositionX, RankTextPositionY));
            _rankText.UpdateText();
        }

        public IObservable<Unit> _ClaimButtonObservable => _claimButton.OnClickAsObservable();
    }
}