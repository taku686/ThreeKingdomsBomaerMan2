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

        public GameObject LoginBonusGameObjet => loginBonusGameObjet;
        public Button SettingButton => settingButton;
        public Button MissionButton => missionButton;
        public Button BattleReadyButton => battleReadyButton;
        public Button CharacterSelectButton => characterSelectButton;
        public Button ShopButton => shopButton;

        public void SetBackgroundEffect(bool isActive)
        {
            backgroundEffect.SetActive(isActive);
        }
    }
}