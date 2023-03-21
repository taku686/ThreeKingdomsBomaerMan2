using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Common
{
    public class UIAnimation
    {
        private const float Duration = 0.1f;

        public Sequence ClickScaleColor(GameObject target)
        {
            Sequence preSequence = DOTween.Sequence();
            Sequence postSequence = DOTween.Sequence();
            var rect = target.GetComponent<RectTransform>();
            var images = target.GetComponentsInChildren<Image>();
            var texts = target.GetComponentsInChildren<TextMeshProUGUI>();
            preSequence.Append(
                rect.DOScale(0.9f, 0.1f));
            foreach (var image in images)
            {
                preSequence.Join(
                    image.DOColor(Color.gray, Duration));
            }

            foreach (var text in texts)
            {
                preSequence.Join(
                    text.DOColor(Color.gray, Duration));
            }

            postSequence.Append(
                rect.DOScale(1f, 0.1f));
            foreach (var image in images)
            {
                postSequence.Join(
                    image.DOColor(image.color, Duration));
            }

            foreach (var text in texts)
            {
                postSequence.Join(
                    text.DOColor(text.color, Duration));
            }

            return preSequence.Append(postSequence);
        }

        public Sequence ClickScale(GameObject target)
        {
            Sequence preSequence = DOTween.Sequence();
            Sequence postSequence = DOTween.Sequence();
            var rect = target.GetComponent<RectTransform>();
            preSequence.Append(
                rect.DOScale(0.9f, 0.1f));
            postSequence.Append(
                rect.DOScale(1f, 0.1f));
            return preSequence.Append(postSequence);
        }
        
        public async UniTask Open(Transform target, float duration)
        {
            await target.DOScale(1f, duration).SetEase(Ease.OutBounce)
                .WithCancellation(target.GetCancellationTokenOnDestroy());
        }

        public async UniTask Close(Transform target, float duration)
        {
            await target.DOScale(0f, duration).SetEase(Ease.OutQuad)
                .WithCancellation(target.GetCancellationTokenOnDestroy());
        }
    }
}