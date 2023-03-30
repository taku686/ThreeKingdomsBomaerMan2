using System.Collections.Generic;
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
        [SerializeField] private GameObject loginBonusObjet;
        [SerializeField] private Button characterSelectButton;
        [SerializeField] private Button battleReadyButton;
        [SerializeField] private Button settingButton;
        [SerializeField] private Button shopButton;
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private TextMeshProUGUI diamondText;
        public GameObject LoginBonusObjet => loginBonusObjet;
        public Button SettingButton => settingButton;
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
        public TextMeshProUGUI CoinText => coinText;
        public TextMeshProUGUI DiamondText => diamondText;
        public GameObject ShopGameObject => shopGameObject;
    }
}