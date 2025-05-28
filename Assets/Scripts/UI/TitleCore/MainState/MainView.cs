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
        [SerializeField] private GameObject _missionCautionGameObject;
        [SerializeField] private Button _userInfoButton;
        [SerializeField] private Button _teamEditButton;
        [SerializeField] private Button _inventoryButton;
        [SerializeField] private GameObject _inventoryCautionGameObject;
        [SerializeField] private GameObject backgroundEffect;
        [SerializeField] private SimpleUserInfoView _simpleUserInfoView;

        public GameObject _LoginBonusGameObjet => loginBonusGameObjet;
        public Button _SettingButton => settingButton;
        public Button _MissionButton => missionButton;
        public Button _BattleReadyButton => battleReadyButton;
        public Button _CharacterSelectButton => characterSelectButton;
        public Button _ShopButton => shopButton;
        public Button _UserInfoButton => _userInfoButton;
        public Button _TeamEditButton => _teamEditButton;
        public Button _InventoryButton => _inventoryButton;

        public void SetBackgroundEffect(bool isActive)
        {
            backgroundEffect.SetActive(isActive);
        }

        public void ApplyViewModel(ViewModel viewModel)
        {
            _inventoryCautionGameObject.SetActive(viewModel._IsInventoryCautionActive);
            _missionCautionGameObject.SetActive(viewModel._IsMissionCautionActive);
        }

        public void ApplySimpleUserInfoView(SimpleUserInfoView.ViewModel viewModel)
        {
            _simpleUserInfoView.ApplyViewModel(viewModel);
        }

        public class ViewModel
        {
            public bool _IsInventoryCautionActive { get; }
            public bool _IsMissionCautionActive { get; }

            public ViewModel
            (
                bool isInventoryCautionActive,
                bool isMissionCautionActive
            )
            {
                _IsInventoryCautionActive = isInventoryCautionActive;
                _IsMissionCautionActive = isMissionCautionActive;
            }
        }
    }
}