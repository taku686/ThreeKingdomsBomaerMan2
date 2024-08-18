using System.Collections.Generic;
using UI.Title.LoginState;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class LoginView : ViewBase
    {
        [SerializeField] private GameObject errorGameObject;
        [SerializeField] private Button retryButton;
        [SerializeField] private Button loginButton;
        [SerializeField] private DisplayNameView displayNameView;
        
        public DisplayNameView DisplayNameView => displayNameView;
        public GameObject ErrorGameObject => errorGameObject;
        public Button RetryButton => retryButton;
        public Button LoginButton => loginButton;
    }
}