using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class MainView : ViewBase
    {
        [SerializeField] private GameObject loginBonusGameObjet;
        [SerializeField] private Button characterSelectButton;
        [SerializeField] private Button battleReadyButton;
        [SerializeField] private Button settingButton;
        [SerializeField] private Button shopButton;
        [SerializeField] private Button missionButton;
        [SerializeField] private GameObject backgroundEffect;

        public GameObject _LoginBonusGameObjet => loginBonusGameObjet;
        public Button _SettingButton => settingButton;
        public Button _MissionButton => missionButton;
        public Button _BattleReadyButton => battleReadyButton;
        public Button _CharacterSelectButton => characterSelectButton;
        public Button _ShopButton => shopButton;

        public void SetBackgroundEffect(bool isActive)
        {
            backgroundEffect.SetActive(isActive);
        }
    }
}