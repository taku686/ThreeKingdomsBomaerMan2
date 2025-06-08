using System;
using Common.Data;
using UniRx;
using UniRx.Triggers;
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
            var normalSkill = viewModel._NormalSkillMasterData;
            var specialSkill = viewModel._SpecialSkillMasterData;
            var weaponSkill = viewModel._WeaponSkillMasterData;
            var levelMasterData = viewModel._LevelMasterData;

            _normalSkillButtonView.InitializeSkillButton(normalSkill, levelMasterData);
            _specialSkillButtonView.InitializeSkillButton(specialSkill, levelMasterData);
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

        private void ActivateBombButton(bool isActive)
        {
            bombButton.interactable = isActive;
            _bombDisableImage.gameObject.SetActive(!isActive);
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

        public IObservable<Unit> OnClickWeaponSkillButtonAsObservable()
        {
            return _weaponSkillButtonView.OnClickSkillButtonAsObservable();
        }

        public IObservable<Unit> OnClickNormalSkillButtonAsObservable()
        {
            return _normalSkillButtonView.OnClickSkillButtonAsObservable();
        }

        public IObservable<Unit> OnClickSpecialSkillButtonAsObservable()
        {
            return _specialSkillButtonView.OnClickSkillButtonAsObservable();
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

        public IObservable<(bool, float)> OnTouchWeaponSkillButtonAsObservable()
        {
            return _weaponSkillButtonView.OnTouchSkillButtonAsObservable();
        }

        public IObservable<(bool, float)> OnTouchNormalSkillButtonAsObservable()
        {
            return _weaponSkillButtonView.OnTouchSkillButtonAsObservable();
        }

        public IObservable<(bool, float)> OnTouchSpecialSkillButtonAsObservable()
        {
            return _weaponSkillButtonView.OnTouchSkillButtonAsObservable();
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