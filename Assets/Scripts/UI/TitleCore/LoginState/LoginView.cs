using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class LoginView : ViewBase
    {
        [SerializeField] private Button loginButton;
        public Button _LoginButton => loginButton;
    }
}