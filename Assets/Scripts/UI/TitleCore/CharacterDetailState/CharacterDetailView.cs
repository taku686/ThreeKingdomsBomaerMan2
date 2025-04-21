using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Common.Data;
using DG.Tweening;
using TMPro;
using UniRx;
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
        [SerializeField] private Image _levelIcon;
        [Inject] private ApplyStatusSkillUseCase _applyStatusSkillUseCase;
        private bool _isInitialized;
        private readonly Dictionary<int, (bool, string)> _statusTextDictionary = new();
        private const float MoveAmount = 50;
        public VirtualCurrencyAddPopup _VirtualCurrencyAddPopup => virtualCurrencyAddPopup;
        public PurchaseErrorView _PurchaseErrorView => purchaseErrorView;
        public Button _UpgradeButton => upgradeButton;
        public Button _BackButton => backButton;
        public Button _SelectButton => selectButton;
        public Button _LeftArrowButton => leftArrowButton;
        public Button _RightArrowButton => rightArrowButton;
        public Button _InventoryButton => inventoryButton;

        public IObservable<Button> _OnClickNormalSkillButtonAsObservable => skillsView._OnClickNormalSkillButtonAsObservable;
        public IObservable<Button> _OnClickSpecialSkillButtonAsObservable => skillsView._OnClickSpecialSkillButtonAsObservable;

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
            _passiveSkillExplanation.text = TranslateExplanation(viewModel._PassiveSkillMasterData);
            foreach (var teamText in _teamTextObjects)
            {
                teamText.SetActive(false);
            }

            _teamTextObjects[characterData.Team].SetActive(true);
            InitializeArrowAnimation();
        }

        private static string TranslateExplanation(SkillMasterData skillMasterData)
        {
            var explanation = skillMasterData.Explanation;
            explanation = explanation.Replace("hppl", skillMasterData.HpPlu.ToString(CultureInfo.InvariantCulture));
            explanation = explanation.Replace("atkpl", skillMasterData.AttackPlu.ToString(CultureInfo.InvariantCulture));
            explanation = explanation.Replace("defpl", skillMasterData.DefensePlu.ToString(CultureInfo.InvariantCulture));
            explanation = explanation.Replace("spdpl", skillMasterData.SpeedPlu.ToString(CultureInfo.InvariantCulture));
            explanation = explanation.Replace("respl", skillMasterData.ResistancePlu.ToString(CultureInfo.InvariantCulture));
            explanation = explanation.Replace("bompl", skillMasterData.BombPlu.ToString(CultureInfo.InvariantCulture));
            explanation = explanation.Replace("firpl", skillMasterData.FirePlu.ToString(CultureInfo.InvariantCulture));
            explanation = explanation.Replace("dmgpl", skillMasterData.DamagePlu.ToString(CultureInfo.InvariantCulture));
            explanation = explanation.Replace("coipl", skillMasterData.CoinPlu.ToString(CultureInfo.InvariantCulture));
            explanation = explanation.Replace("gempl", skillMasterData.GemPlu.ToString(CultureInfo.InvariantCulture));
            explanation = explanation.Replace("skpl", skillMasterData.SkillPlu.ToString(CultureInfo.InvariantCulture));
            explanation = explanation.Replace("hpml", skillMasterData.HpMul.ToString(CultureInfo.InvariantCulture));
            explanation = explanation.Replace("atkml", skillMasterData.AttackMul.ToString(CultureInfo.InvariantCulture));
            explanation = explanation.Replace("defml", skillMasterData.DefenseMul.ToString(CultureInfo.InvariantCulture));
            explanation = explanation.Replace("spdml", skillMasterData.SpeedMul.ToString(CultureInfo.InvariantCulture));
            explanation = explanation.Replace("resml", skillMasterData.ResistanceMul.ToString(CultureInfo.InvariantCulture));
            explanation = explanation.Replace("bomml", skillMasterData.BombMul.ToString(CultureInfo.InvariantCulture));
            explanation = explanation.Replace("firml", skillMasterData.FireMul.ToString(CultureInfo.InvariantCulture));
            explanation = explanation.Replace("dmgml", skillMasterData.DamageMul.ToString(CultureInfo.InvariantCulture));
            explanation = explanation.Replace("coiml", skillMasterData.CoinMul.ToString(CultureInfo.InvariantCulture));
            explanation = explanation.Replace("gemml", skillMasterData.GemMul.ToString(CultureInfo.InvariantCulture));
            explanation = explanation.Replace("skml", skillMasterData.SkillMul.ToString(CultureInfo.InvariantCulture));
            explanation = explanation.Replace("ran", skillMasterData.Range.ToString(CultureInfo.InvariantCulture));
            explanation = explanation.Replace("inv", skillMasterData.Interval.ToString(CultureInfo.InvariantCulture));
            explanation = explanation.Replace("et", skillMasterData.EffectTime.ToString(CultureInfo.InvariantCulture));

            return explanation;
        }

        private void SetStatusView
        (
            CharacterData characterData,
            WeaponMasterData weaponMasterData
        )
        {
            nameText.text = characterData.Name;
            _statusTextDictionary.Clear();
            var statusSkillDatum = weaponMasterData.StatusSkillMasterDatum;
            foreach (var statusSkillData in statusSkillDatum)
            {
                var skillId = statusSkillData.Id;
                GetFixedStatuesText(characterData, skillId, StatusType.Hp);
                GetFixedStatuesText(characterData, skillId, StatusType.Attack);
                GetFixedStatuesText(characterData, skillId, StatusType.Speed);
                GetFixedStatuesText(characterData, skillId, StatusType.BombLimit);
                GetFixedStatuesText(characterData, skillId, StatusType.FireRange);
                GetFixedStatuesText(characterData, skillId, StatusType.Defense);
                GetFixedStatuesText(characterData, skillId, StatusType.Resistance);
            }

            statusView._HpText.text = _statusTextDictionary.First(x => x.Key == (int)StatusType.Hp).Value.Item2;
            statusView._AttackText.text = _statusTextDictionary.First(x => x.Key == (int)StatusType.Attack).Value.Item2;
            statusView._SpeedText.text = _statusTextDictionary.First(x => x.Key == (int)StatusType.Speed).Value.Item2;
            statusView._BombLimitText.text = _statusTextDictionary.First(x => x.Key == (int)StatusType.BombLimit).Value.Item2;
            statusView._FireRangeText.text = _statusTextDictionary.First(x => x.Key == (int)StatusType.FireRange).Value.Item2;
            statusView._DefenseText.text = _statusTextDictionary.First(x => x.Key == (int)StatusType.Defense).Value.Item2;
            statusView._ResistanceText.text = _statusTextDictionary.First(x => x.Key == (int)StatusType.Resistance).Value.Item2;
        }

        private void ApplySkillsViewModel(SkillsView.ViewModel viewModel)
        {
            skillsView.ApplyViewModel(viewModel);
        }

        private void SetLevelView(LevelMasterData currentLevelMasterData, LevelMasterData nextLevelMasterData)
        {
            if (currentLevelMasterData.Level < GameCommonData.MaxCharacterLevel)
            {
                upgradeButton.interactable = true;
                levelText.text = "LV <#94aed0><size=170%>" + currentLevelMasterData.Level;
                upgradeInfoText.text = $"Lv{nextLevelMasterData.Level} Upgrade";
                upgradeText.text = nextLevelMasterData.NeedCoin.ToString("D");
                _levelIcon.color = Color.white;
            }
            else
            {
                levelText.text = "LV <#94aed0><size=170%>" + currentLevelMasterData.Level;
                upgradeButton.interactable = false;
                upgradeText.text = "MAX LV";
                upgradeInfoText.text = "MAX LV";
                _levelIcon.color = new Color(1, 1, 1, 0.5f);
            }
        }

        private void GetFixedStatuesText
        (
            CharacterData characterData,
            int skillId,
            StatusType statusType
        )
        {
            if (_statusTextDictionary.TryGetValue((int)statusType, out var statusText))
            {
                if (statusText.Item1)
                {
                    return;
                }
            }

            var appliedLevelValue = _applyStatusSkillUseCase.ApplyLevelStatus(characterData.Id, statusType);
            var appliedStatusSkillValue = _applyStatusSkillUseCase.ApplyStatusSkill(characterData.Id, skillId, statusType);
            var increaseValue = appliedStatusSkillValue - appliedLevelValue;
            if (increaseValue is 0)
            {
                _statusTextDictionary[(int)statusType] = (false, appliedStatusSkillValue.ToString());
                return;
            }

            _statusTextDictionary[(int)statusType] = (true, appliedStatusSkillValue + $"<#ff0000> +{increaseValue}<size=170%>");
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