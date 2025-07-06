using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Common
{
    public class StampUiAnimation : MonoBehaviour
    {
        [SerializeField] private Image _backgroundImage; // スタンプの背景画像（省略可能）
        public float _pressScale = 0.8f; // 押された時のスケール
        public float _pressDuration = 0.1f; // 押し込む時間
        public float _releaseScale = 1.05f; // 離す時のスケール（省略可能）
        public float _releaseDuration = 0.1f; // 離す時間（省略可能）
        public float _fadeDuration = 0.1f; // フェードイン時間

        private RectTransform _rectTransform;
        private Image _image;
        private Color _originalColor;

        public void ImageActivate(bool isActive)
        {
            if (isActive)
            {
                return;
            }

            var backgroundColor = _backgroundImage.color;
            backgroundColor.a = 0;
            _backgroundImage.color = backgroundColor;
            _rectTransform = GetComponent<RectTransform>();
            _image = GetComponent<Image>();
            if (_image != null)
            {
                _originalColor = _image.color;
                var transparentColor = _originalColor;
                transparentColor.a = 0f;
                _image.color = transparentColor;
            }
            else
            {
                Debug.LogError("Imageコンポーネントが見つかりません。");
                enabled = false;
            }
        }

        public void PlayStamp(Action onCompleteAction = null)
        {
            if (_rectTransform == null || _image == null) return;

            // 初期状態からのフェードイン
            _image.DOFade(_originalColor.a, _fadeDuration)
                .OnComplete(() =>
                {
                    // 押し込むアニメーション
                    _rectTransform.DOScale(_pressScale, _pressDuration)
                        .SetEase(Ease.OutQuad)
                        .OnComplete(() =>
                        {
                            // 離すアニメーション (任意)
                            if (_releaseScale > 0 && _releaseDuration > 0)
                            {
                                _rectTransform.DOScale(_releaseScale, _releaseDuration)
                                    .SetEase(Ease.OutQuad)
                                    .OnComplete(() =>
                                    {
                                        _rectTransform.DOScale(1f, _releaseDuration * 0.5f)
                                            .SetEase(Ease.OutBack)
                                            .OnComplete(() =>
                                            {
                                                var backgroundColor = _backgroundImage.color;
                                                backgroundColor.a = 1;
                                                _backgroundImage.color = backgroundColor;
                                                onCompleteAction?.Invoke();
                                            });
                                    });
                            }
                            else
                            {
                                _rectTransform.DOScale(1f, _pressDuration * 0.5f)
                                    .SetEase(Ease.OutQuad);
                            }
                        });
                });
        }
    }
}