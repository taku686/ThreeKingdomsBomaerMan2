using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class LoginView : ViewBase
    {
        [SerializeField] private Button _loginButton;
        public Button _LoginButton => _loginButton;
    }
}