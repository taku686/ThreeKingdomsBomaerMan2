using UI.Common;
using UnityEngine;
using Zenject;

public class LoadingImage : MonoBehaviour
{
    [Inject] private UIAnimation _uiAnimation;
    [SerializeField] private RectTransform circleImageRect;

    private void Start()
    {
        _uiAnimation.RepeatRotation(circleImageRect);
    }
}