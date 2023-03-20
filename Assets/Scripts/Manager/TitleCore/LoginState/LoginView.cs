using TMPro;
using UI.Title.LoginState;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class LoginView : MonoBehaviour
    {
        [SerializeField] private GameObject errorGameObject;
        [SerializeField] private Button retryButton;
        [SerializeField] private Button startButton;
        [SerializeField] private TextMeshProUGUI loadingBarText;
        [SerializeField] private DisplayNameView displayNameView;

        public DisplayNameView DisplayNameView => displayNameView;
        public TextMeshProUGUI LoadingBarText => loadingBarText;
        public GameObject ErrorGameObject => errorGameObject;
        public Button RetryButton => retryButton;
        public Button StartButton => startButton;
    }
}