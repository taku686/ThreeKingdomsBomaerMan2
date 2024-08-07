using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class Setting : ViewBase
    {
        [SerializeField] private Button accountRegisterButton;
        [SerializeField] private GameObject signUpGameObject;
        [SerializeField] private GameObject signInGameObject;
        [SerializeField] private TMP_InputField signUpEmailInputField;
        [SerializeField] private TMP_InputField signUpUserNameInputField;
        [SerializeField] private TMP_InputField signUpPasswordInputField;
        [SerializeField] private Button signUpButton;
        [SerializeField] private Button alreadySignInButton;
        [SerializeField] private TMP_InputField signInUserNameInputField;
        [SerializeField] private TMP_InputField signInPasswordInputField;
        [SerializeField] private Button signInButton;
        [SerializeField] private Button backToSignUpButton;
        [SerializeField] private Button settingCloseButton;
        [SerializeField] private Button signUpCloseButton;
        [SerializeField] private Button signInCloseButton;

        public Button AccountRegisterButton => accountRegisterButton;
        public GameObject SignUpGameObject => signUpGameObject;
        public GameObject SignInGameObject => signInGameObject;

        public TMP_InputField SignUpEmailInputField => signUpEmailInputField;

        public TMP_InputField SignUpUserNameInputField => signUpUserNameInputField;

        public TMP_InputField SignUpPasswordInputField => signUpPasswordInputField;

        public Button SignUpButton => signUpButton;

        public Button AlreadySignInButton => alreadySignInButton;

        public TMP_InputField SignInUserNameInputField => signInUserNameInputField;

        public TMP_InputField SignInPasswordInputField => signInPasswordInputField;
        
        public Button SignInButton => signInButton;

        public Button BackToSignUpButton => backToSignUpButton;

        public Button SettingCloseButton => settingCloseButton;

        public Button SignUpCloseButton => signUpCloseButton;

        public Button SignInCloseButton => signInCloseButton;
    }
}