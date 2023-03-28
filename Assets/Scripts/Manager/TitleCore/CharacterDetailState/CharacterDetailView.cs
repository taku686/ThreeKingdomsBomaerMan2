using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class CharacterDetailView : MonoBehaviour
    {
        [SerializeField] private Button backButton;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private Button selectButton;
        [SerializeField] private RectTransform leftArrowRect;
        [SerializeField] private RectTransform rightArrowRect;
        [SerializeField] private Button leftArrowButton;
        [SerializeField] private Button rightArrowButton;
        [SerializeField] private CharacterStatusView characterStatusView;
        [SerializeField] private SkillsView skillsView;
        [SerializeField] private Button upgradeButton;
        [SerializeField] private TextMeshProUGUI upgradeText;
        [SerializeField] private TextMeshProUGUI upgradeInfoText;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private PurchaseErrorView purchaseErrorView;
        [SerializeField] private VirtualCurrencyAddPopup virtualCurrencyAddPopup;

        public VirtualCurrencyAddPopup VirtualCurrencyAddPopup => virtualCurrencyAddPopup;
        public PurchaseErrorView PurchaseErrorView => purchaseErrorView;
        public Button UpgradeButton => upgradeButton;
        public TextMeshProUGUI UpgradeText => upgradeText;
        public TextMeshProUGUI UpgradeInfoText => upgradeInfoText;
        public TextMeshProUGUI LevelText => levelText;
        public SkillsView SkillsView => skillsView;
        public CharacterStatusView CharacterStatusView => characterStatusView;
        public Button BackButton => backButton;
        public TextMeshProUGUI NameText => nameText;
        public Button SelectButton => selectButton;
        public RectTransform LeftArrowRect => leftArrowRect;
        public RectTransform RightArrowRect => rightArrowRect;
        public Button LeftArrowButton => leftArrowButton;
        public Button RightArrowButton => rightArrowButton;
    }
}