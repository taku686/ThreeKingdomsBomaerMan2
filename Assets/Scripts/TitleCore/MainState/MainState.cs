using Assets.Scripts.Common.PlayFab;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class MainState : State
        {
            private PlayFabLoginManager _playFabLoginManager;
            private MainView _mainView;

            protected override void OnEnter(State prevState)
            {
                Initialize().Forget();
            }


            protected override void OnUpdate()
            {
                TransitionLoginBonus();
            }

            private async UniTaskVoid Initialize()
            {
                _playFabLoginManager = Owner._playFabLoginManager;
                _mainView = Owner.mainView;
                Owner.DisableTitleGameObject();
                Owner.CreateCharacter(Owner._userDataManager.GetUserData().EquipCharacterId);
                InitializeButton();
                _mainView.MainGameObject.SetActive(true);
                await InitializeText();
            }


            private void InitializeButton()
            {
                Owner.mainView.CharacterSelectButton.onClick.RemoveAllListeners();
                Owner.mainView.BattleReadyButton.onClick.RemoveAllListeners();
                Owner.mainView.SettingButton.onClick.RemoveAllListeners();
                Owner.mainView.ShopButton.onClick.RemoveAllListeners();
                _mainView.MissionButton.onClick.RemoveAllListeners();
                Owner.mainView.CharacterSelectButton.onClick.AddListener(OnClickCharacterSelect);
                Owner.mainView.BattleReadyButton.onClick.AddListener(OnClickBattleReady);
                Owner.mainView.SettingButton.onClick.AddListener(OnClickSetting);
                Owner.mainView.ShopButton.onClick.AddListener(OnClickShop);
                _mainView.MissionButton.onClick.AddListener(OnClickMission);
            }

            private async UniTask InitializeText()
            {
                await Owner.SetCoinText();
                await Owner.SetGemText();
                Owner.commonView.virtualCurrencyView.gameObject.SetActive(true);
            }

            private void TransitionLoginBonus()
            {
                if (!_playFabLoginManager.haveLoginBonus)
                {
                    return;
                }

                _playFabLoginManager.haveLoginBonus = false;
                Owner._stateMachine.Dispatch((int)Event.LoginBonus);
            }


            private void OnClickCharacterSelect()
            {
                Owner._uiAnimation.ClickScaleColor(Owner.mainView.CharacterSelectButton.gameObject)
                    .OnComplete(() => { Owner._stateMachine.Dispatch((int)Event.CharacterSelect); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickBattleReady()
            {
                Owner._uiAnimation.ClickScaleColor(Owner.mainView.BattleReadyButton.gameObject)
                    .OnComplete(() => { Owner._stateMachine.Dispatch((int)Event.ReadyBattle); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickSetting()
            {
                Owner._uiAnimation.ClickScaleColor(Owner.mainView.SettingButton.gameObject)
                    .OnComplete(() => { Owner._stateMachine.Dispatch((int)Event.Setting); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickShop()
            {
                Owner._uiAnimation.ClickScaleColor(Owner.mainView.ShopButton.gameObject)
                    .OnComplete(() => { Owner._stateMachine.Dispatch((int)Event.Shop); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickMission()
            {
                Owner._uiAnimation.ClickScaleColor(_mainView.MissionButton.gameObject)
                    .OnComplete(() => { Owner._stateMachine.Dispatch((int)Event.Mission); })
                    .SetLink(Owner.gameObject);
            }
        }
    }
}