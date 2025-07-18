using System;
using Common.Data;
using UI.BattleCore.InBattle;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Common
{
    public class InputView : MonoBehaviour
    {
        public Button bombButton;
        [SerializeField] private Image _bombDisableImage;
        [SerializeField] private SkillButtonView _weaponSkillButtonView;
        [SerializeField] private SkillButtonView _normalSkillButtonView;
        [SerializeField] private SkillButtonView _specialSkillButtonView;
        [SerializeField] private SkillButtonView _jumpSkillButtonView;
        [SerializeField] private SkillButtonView _changeCharacterButtonView;

        public void ApplyViewModel(ViewModel viewModel)
        {
            //todo : review later
            var normalSkill = viewModel._NormalSkillMasterData;
            var specialSkill = viewModel._SpecialSkillMasterData;
            var weaponSkill = viewModel._WeaponSkillMasterData;
            var levelMasterData = viewModel._LevelMasterData;

            _normalSkillButtonView.InitializeSkillButton(weaponSkill, levelMasterData);
            _specialSkillButtonView.InitializeSkillButton(weaponSkill, levelMasterData);
            _jumpSkillButtonView.InitializeSkillButton(null, null);
            _changeCharacterButtonView.InitializeSkillButton(null, null);

            if (weaponSkill == null)
            {
                _weaponSkillButtonView.ActivateButton(false);
            }
            else
            {
                _weaponSkillButtonView.InitializeSkillButton(weaponSkill, levelMasterData);
            }

            ActivateBombButton(true);
            _changeCharacterButtonView.ActivateButton(viewModel._CanChangeCharacter);
        }

        public void ActivateBombButton(bool isActive)
        {
            bombButton.interactable = isActive;
            _bombDisableImage.gameObject.SetActive(!isActive);
        }

        public void ActivateWeaponSkillButton(bool isActive)
        {
            _weaponSkillButtonView.ActivateButton(isActive);
        }

        public void ActivateNormalSkillButton(bool isActive)
        {
            _normalSkillButtonView.ActivateButton(isActive);
        }

        public void ActivateSpecialSkillButton(bool isActive)
        {
            _specialSkillButtonView.ActivateButton(isActive);
        }

        public void ActivateJumpSkillButton(bool isActive)
        {
            _jumpSkillButtonView.ActivateButton(isActive);
        }

        public void ActivateChangeCharacterButton(bool isActive)
        {
            _changeCharacterButtonView.ActivateButton(isActive);
        }

        public void UpdateTimer()
        {
            _weaponSkillButtonView.UpdateTimer();
            _normalSkillButtonView.UpdateTimer();
            _specialSkillButtonView.UpdateTimer();
            _jumpSkillButtonView.UpdateTimer();
            _changeCharacterButtonView.UpdateTimer();
        }

        #region OnClick

        public IObservable<Unit> OnClickBombButtonAsObservable()
        {
            return bombButton
                .OnClickAsObservable()
                .Select(_ => Unit.Default);
        }

        public IObservable<Unit> OnClickCharacterChangeButtonAsObservable()
        {
            return _changeCharacterButtonView.OnClickSkillButtonAsObservable();
        }

        public IObservable<Unit> OnClickDashButtonAsObservable()
        {
            return _jumpSkillButtonView.OnClickSkillButtonAsObservable();
        }

        #endregion

        #region OnTouch

        public IObservable<SkillIndicatorViewBase.SkillIndicatorInfo> OnTouchWeaponSkillButtonAsObservable()
        {
            return _weaponSkillButtonView.OnTouchSkillButtonAsObservable();
        }

        public IObservable<SkillIndicatorViewBase.SkillIndicatorInfo> OnTouchNormalSkillButtonAsObservable()
        {
            return _normalSkillButtonView.OnTouchSkillButtonAsObservable();
        }

        public IObservable<SkillIndicatorViewBase.SkillIndicatorInfo> OnTouchSpecialSkillButtonAsObservable()
        {
            return _specialSkillButtonView.OnTouchSkillButtonAsObservable();
        }

        #endregion

        public class ViewModel
        {
            public SkillMasterData _NormalSkillMasterData { get; }
            public SkillMasterData _SpecialSkillMasterData { get; }
            public SkillMasterData _WeaponSkillMasterData { get; }
            public LevelMasterData _LevelMasterData { get; }
            public bool _CanChangeCharacter { get; }

            public ViewModel
            (
                SkillMasterData normalSkillMasterData,
                SkillMasterData specialSkillMasterData,
                SkillMasterData weaponSkillMasterData,
                LevelMasterData levelMasterData,
                bool canChangeCharacter
            )
            {
                _NormalSkillMasterData = normalSkillMasterData;
                _SpecialSkillMasterData = specialSkillMasterData;
                _WeaponSkillMasterData = weaponSkillMasterData;
                _LevelMasterData = levelMasterData;
                _CanChangeCharacter = canChangeCharacter;
            }
        }
    }
}