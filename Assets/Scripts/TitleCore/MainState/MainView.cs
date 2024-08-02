using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class MainView : MonoBehaviour
    {
        [SerializeField] private GameObject mainGameObject;
        [SerializeField] private GameObject characterListGameObject;
        [SerializeField] private GameObject battleReadyGameObject;
        [SerializeField] private GameObject characterDetailGameObject;
        [SerializeField] private GameObject sceneTransitionGameObject;
        [SerializeField] private GameObject loginGameObject;
        [SerializeField] private GameObject settingGameObject;
        [SerializeField] private GameObject shopGameObject;
        [SerializeField] private GameObject loginBonusGameObjet;
        [SerializeField] private GameObject missionGameObject;
        [SerializeField] private GameObject commonGameObject;
        [SerializeField] private Button characterSelectButton;
        [SerializeField] private Button battleReadyButton;
        [SerializeField] private Button settingButton;
        [SerializeField] private Button shopButton;
        [SerializeField] private Button missionButton;
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private TextMeshProUGUI diamondText;
        [SerializeField] private GameObject backgroundEffect;
        public GameObject CommonGameObject => commonGameObject;
        public GameObject LoginBonusGameObjet => loginBonusGameObjet;
        public Button SettingButton => settingButton;
        public Button MissionButton => missionButton;
        public Button BattleReadyButton => battleReadyButton;
        public Button CharacterSelectButton => characterSelectButton;
        public Button ShopButton => shopButton;
        public GameObject MainGameObject => mainGameObject;
        public GameObject CharacterListGameObject => characterListGameObject;
        public GameObject CharacterDetailGameObject => characterDetailGameObject;
        public GameObject BattleReadyGameObject => battleReadyGameObject;
        public GameObject SceneTransitionGameObject => sceneTransitionGameObject;
        public GameObject LoginGameObject => loginGameObject;
        public GameObject SettingGameObject => settingGameObject;
        public GameObject MissionGameObject => missionGameObject;
        public TextMeshProUGUI CoinText => coinText;
        public TextMeshProUGUI DiamondText => diamondText;
        public GameObject ShopGameObject => shopGameObject;
        public void SetBackgroundEffect(bool isActive)
        {
            backgroundEffect.SetActive(isActive);
        }
    }
}