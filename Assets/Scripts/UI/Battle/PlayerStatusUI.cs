using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace UI.Battle
{
    public class PlayerStatusUI : MonoBehaviour
    {
        [SerializeField] private RectTransform greenGauge;
        [SerializeField] private RectTransform redGauge;
        private const float GreenGaugeMoveDuration = 0.3f;
        private const float RedGaugeMoveDuration = 0.5f;

        public void Initialize(ReadOnlyReactiveProperty<int> hpValue, int maxHp)
        {
            hpValue.Subscribe(hp =>
            {
                Debug.Log(hp);
                var hpRate = hp / (float)maxHp;
                OnDamage(hpRate).Forget();
            }).AddTo(gameObject);
        }

        private async UniTask OnDamage(float hpRate)
        {
            var endPosX = -greenGauge.rect.width * (1 - hpRate);
            var endPos = new Vector3(endPosX, 0, 0);
            await greenGauge.DOLocalMove(endPos, GreenGaugeMoveDuration).SetLink(greenGauge.gameObject)
                .WithCancellation(greenGauge.gameObject.GetCancellationTokenOnDestroy());
            await redGauge.DOLocalMove(endPos, RedGaugeMoveDuration).SetLink(redGauge.gameObject)
                .WithCancellation(greenGauge.gameObject.GetCancellationTokenOnDestroy());
        }
    }
}