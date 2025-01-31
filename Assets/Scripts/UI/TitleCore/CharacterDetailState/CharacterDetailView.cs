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
        [SerializeField] private GameObject[] _teamTextObjects;
        [SerializeField] private Image _typeImage;
        [SerializeField] private Image _typeIcon;
        [SerializeField] private TextMeshProUGUI _passiveSkillName;
        [SerializeField] private TextMeshProUGUI _passiveSkillExplanation;
        [Inject] private ApplyStatusSkillUseCase _applyStatusSkillUseCase;
        private bool _isInitialized;
        private const float MoveAmount = 50;
        public VirtualCurrencyAddPopup _VirtualCurrencyAddPopup => virtualCurrencyAddPopup;
        public PurchaseErrorView _PurchaseErrorView => purchaseErrorView;
        public Button _UpgradeButton => upgradeButton;
        public Button _BackButton => backButton;
        public Button _SelectButton => selectButton;
        public Button _LeftArrowButton => leftArrowButton;
        public Button _RightArrowButton => rightArrowButton;
        public Button _InventoryButton => inventoryButton;

        public void ApplyViewModel(ViewModel viewModel)
        {
            var characterData = viewModel._CharacterData;
            var currentLevelData = viewModel._CurrentLevelMasterData;
            var nextLevelData = viewModel._NextLevelMasterData;
            var skillsViewModel = viewModel._SkillsViewModel;
            var weaponMasterData = viewModel._WeaponMasterData;
            SetStatusView(characterData, weaponMasterData);
            ApplySkillsViewModel(skillsViewModel);
            SetLevelView(currentLevelData, nextLevelData);
            purchaseErrorView.gameObject.SetActive(false);
            virtualCurrencyAddPopup.gameObject.SetActive(false);
            _typeImage.color = viewModel._TypeColor;
            _typeIcon.sprite = viewModel._TypeSprite;
            _passiveSkillName.text = viewModel._PassiveSkillMasterData.Name;
            _passiveSkillExplanation.text = viewModel._PassiveSkillMasterData.Explanation;
            foreach (var teamText in _teamTextObjects)
            {
                teamText.SetActive(false);
            }

            _teamTextObjects[characterData.Team].SetActive(true);
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
            statusView.HpText.text = GetFixedStatus(characterData, statusSkillId, StatusType.Hp);
            statusView.DamageText.text = GetFixedStatus(characterData, statusSkillId, StatusType.Attack);
            statusView.SpeedText.text = GetFixedStatus(characterData, statusSkillId, StatusType.Speed);
            statusView.BombLimitText.text = GetFixedStatus(characterData, statusSkillId, StatusType.BombLimit);
            statusView.FireRangeText.text = GetFixedStatus(characterData, statusSkillId, StatusType.FireRange);
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
            var fixedValue = _applyStatusSkillUseCase.ApplyLevelStatus(characterData.Id, statusType);
            var statusAddValue = _applyStatusSkillUseCase.ApplyStatusSkill(characterData.Id, skillId, statusType);
            var increaseValue = statusAddValue - fixedValue;
            if (increaseValue == 0)
            {
                return statusAddValue.ToString();
            }

            return statusAddValue + $"<#ff0000>+{increaseValue}<size=170%>";
        }

        private void InitializeArrowAnimation()
        {
            if (_isInitialized)
            {
                return;
            }

            _isInitialized = true;
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
            public CharacterData _CharacterData { get; }
            public LevelMasterData _CurrentLevelMasterData { get; }
            public LevelMasterData _NextLevelMasterData { get; }
            public SkillsView.ViewModel _SkillsViewModel { get; }
            public WeaponMasterData _WeaponMasterData { get; }
            public Sprite _TypeSprite { get; }
            public Color _TypeColor { get; }
            public SkillMasterData _PassiveSkillMasterData { get; }

            public ViewModel
            (
                CharacterData characterData,
                LevelMasterData currentLevelMasterData,
                LevelMasterData nextLevelMasterData,
                SkillsView.ViewModel skillsViewModel,
                WeaponMasterData weaponMasterData,
                Sprite typeSprite,
                Color typeColor,
                SkillMasterData passiveSkillMasterData
            )
            {
                _CharacterData = characterData;
                _CurrentLevelMasterData = currentLevelMasterData;
                _NextLevelMasterData = nextLevelMasterData;
                _SkillsViewModel = skillsViewModel;
                _WeaponMasterData = weaponMasterData;
                _TypeSprite = typeSprite;
                _TypeColor = typeColor;
                _PassiveSkillMasterData = passiveSkillMasterData;
            }
        }
    }
}