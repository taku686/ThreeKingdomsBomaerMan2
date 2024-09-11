using Common.Data;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Title
{
    public class CharacterDetailView : ViewBase
    {
        [SerializeField] private Button backButton;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private Button selectButton;
        [SerializeField] private RectTransform leftArrowRect;
        [SerializeField] private RectTransform rightArrowRect;
        [SerializeField] private Button leftArrowButton;
        [SerializeField] private Button rightArrowButton;
        [SerializeField] private StatusView statusView;
        [SerializeField] private SkillsView skillsView;
        [SerializeField] private Button upgradeButton;
        [SerializeField] private TextMeshProUGUI upgradeText;
        [SerializeField] private TextMeshProUGUI upgradeInfoText;
        [SerializeField] private GameObject upgradeInfoGameObject;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private PurchaseErrorView purchaseErrorView;
        [SerializeField] private VirtualCurrencyAddPopup virtualCurrencyAddPopup;
        [SerializeField] private Button inventoryButton;
        [Inject] private StatusSkillUseCase statusSkillUseCase;
        private bool isInitialized;
        private const float MoveAmount = 50;
        public VirtualCurrencyAddPopup VirtualCurrencyAddPopup => virtualCurrencyAddPopup;
        public PurchaseErrorView PurchaseErrorView => purchaseErrorView;
        public Button UpgradeButton => upgradeButton;
        public Button BackButton => backButton;
        public Button SelectButton => selectButton;
        public Button LeftArrowButton => leftArrowButton;
        public Button RightArrowButton => rightArrowButton;
        public Button InventoryButton => inventoryButton;

        public void ApplyViewModel(ViewModel viewModel)
        {
            var characterData = viewModel.CharacterData;
            var currentLevelData = viewModel.CurrentLevelMasterData;
            var nextLevelData = viewModel.NextLevelMasterData;
            var skillsViewModel = viewModel.SkillsViewModel;
            var weaponMasterData = viewModel.WeaponMasterData;
            SetStatusView(characterData, weaponMasterData);
            ApplySkillsViewModel(skillsViewModel);
            SetLevelView(currentLevelData, nextLevelData);
            purchaseErrorView.gameObject.SetActive(false);
            virtualCurrencyAddPopup.gameObject.SetActive(false);
            InitializeArrowAnimation();
        }

        private void SetStatusView
        (
            CharacterData characterData,
            WeaponMasterData weaponMasterData
        )
        {
            nameText.text = characterData.Name;
            var statusSkillId = weaponMasterData.StatusSkillMasterData.Id;
            statusView.HpText.text =
                GetFixedStatus(characterData, statusSkillId, StatusType.Hp);
            statusView.DamageText.text =
                GetFixedStatus(characterData, statusSkillId, StatusType.Attack);
            statusView.SpeedText.text =
                GetFixedStatus(characterData, statusSkillId, StatusType.Speed);
            statusView.BombLimitText.text =
                GetFixedStatus(characterData, statusSkillId, StatusType.BombLimit);
            statusView.FireRangeText.text =
                GetFixedStatus(characterData, statusSkillId, StatusType.FireRange);
        }

        private void ApplySkillsViewModel(SkillsView.ViewModel viewModel)
        {
            skillsView.ApplyViewModel(viewModel);
        }

        private void SetLevelView(LevelMasterData currentLevelMasterData, LevelMasterData nextLevelMasterData)
        {
            if (currentLevelMasterData.Level < GameCommonData.MaxCharacterLevel)
            {
                upgradeButton.gameObject.SetActive(true);
                upgradeInfoGameObject.gameObject.SetActive(true);
                levelText.text = "LV <#94aed0><size=170%>" + currentLevelMasterData.Level;
                upgradeInfoText.text = $"Lv{nextLevelMasterData.Level} Upgrade";
                upgradeText.text = nextLevelMasterData.NeedCoin.ToString("D");
            }
            else
            {
                levelText.text = "LV <#94aed0><size=170%>" + currentLevelMasterData.Level;
                upgradeButton.gameObject.SetActive(false);
                upgradeInfoGameObject.gameObject.SetActive(false);
            }
        }

        private string GetFixedStatus
        (
            CharacterData characterData,
            int skillId,
            StatusType statusType
        )
        {
            var fixedValue = statusSkillUseCase.ApplyLevelStatus(characterData.Id, statusType);
            var statusAddValue = statusSkillUseCase.ApplyStatusSkill(characterData.Id, skillId, statusType);
            var increaseValue = statusAddValue - fixedValue;
            if (increaseValue == 0)
            {
                return statusAddValue.ToString();
            }

            return statusAddValue + $"<#ff0000>+{increaseValue}<size=170%>";
        }

        private void InitializeArrowAnimation()
        {
            if (isInitialized)
            {
                return;
            }

            isInitialized = true;
            var leftArrowTransform = leftArrowRect;
            var rightArrowTransform = rightArrowRect;
            var leftPosition = leftArrowTransform.anchoredPosition3D;
            var rightPosition = rightArrowTransform.anchoredPosition3D;
            leftArrowTransform
                .DOLocalMove(new Vector3(leftPosition.x + MoveAmount, leftPosition.y, leftPosition.z), 1f)
                .SetLoops(-1, LoopType.Yoyo)
                .SetLink(leftArrowTransform.gameObject);
            rightArrowTransform
                .DOLocalMove(new Vector3(rightPosition.x - MoveAmount, rightPosition.y, rightPosition.z), 1f)
                .SetLoops(-1, LoopType.Yoyo)
                .SetLink(rightArrowTransform.gameObject);
        }


        public class ViewModel
        {
            public CharacterData CharacterData { get; }
            public LevelMasterData CurrentLevelMasterData { get; }
            public LevelMasterData NextLevelMasterData { get; }
            public SkillsView.ViewModel SkillsViewModel { get; }
            public WeaponMasterData WeaponMasterData { get; }

            public ViewModel
            (
                CharacterData characterData,
                LevelMasterData currentLevelMasterData,
                LevelMasterData nextLevelMasterData,
                SkillsView.ViewModel skillsViewModel,
                WeaponMasterData weaponMasterData
            )
            {
                CharacterData = characterData;
                CurrentLevelMasterData = currentLevelMasterData;
                NextLevelMasterData = nextLevelMasterData;
                SkillsViewModel = skillsViewModel;
                WeaponMasterData = weaponMasterData;
            }
        }
    }
}