using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class SceneTransitionView : MonoBehaviour
    {
        [SerializeField] private Slider loadingBar;
        [SerializeField] private TextMeshProUGUI loadingText;
        [SerializeField] private RectTransform iconRectTransform;

        public RectTransform IconRectTransform => iconRectTransform;

        public TextMeshProUGUI LoadingText => loadingText;

        public Slider LoadingBar => loadingBar;
    }
}