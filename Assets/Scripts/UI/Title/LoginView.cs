using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class LoginView : MonoBehaviour
    {
     //   [SerializeField] private Button startButton;
        [SerializeField] private Slider loadingBar;

        public Slider LoadingBar => loadingBar;
    }
}