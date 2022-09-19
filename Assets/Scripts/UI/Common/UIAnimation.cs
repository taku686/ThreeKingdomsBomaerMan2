using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace UI.Common
{
    public class UIAnimation
    {
        public Sequence OnClickAnimation(RectTransform target)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(
                target.DOScale(1.1f, 0.5f).SetEase(Ease.OutElastic));

            return sequence;
        }
    }
}