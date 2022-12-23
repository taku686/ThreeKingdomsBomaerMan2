using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace UI.Battle
{
    public class PlayerStatusUI : MonoBehaviour
    {
        [SerializeField] private RectTransform _greenGauge;
        [SerializeField] private RectTransform _redGauge;
        private const float GreenGaugeMoveDuration = 0.3f;
        private const float RedGaugeMoveDuration = 0.5f;

        public async UniTask OnDamage(float hpRate)
        {
            var endPosX = -_greenGauge.rect.width * (1 - hpRate);
            var endPos = new Vector3(endPosX, 0, 0);
            await _greenGauge.DOLocalMove(endPos, GreenGaugeMoveDuration).SetLink(_greenGauge.gameObject)
                .WithCancellation(_greenGauge.gameObject.GetCancellationTokenOnDestroy());
            await _redGauge.DOLocalMove(endPos, RedGaugeMoveDuration).SetLink(_redGauge.gameObject)
                .WithCancellation(_greenGauge.gameObject.GetCancellationTokenOnDestroy());
        }
    }
}