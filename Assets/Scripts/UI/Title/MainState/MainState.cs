using DG.Tweening;
using State = StateMachine<UI.Title.TitlePresenter>.State;

namespace UI.Title
{
    public partial class TitlePresenter
    {
        public class MainState : State
        {
            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            protected override void OnExit(State nextState)
            {
            }

            private void Initialize()
            {
                Owner.DisableTitleGameObject();
                Owner.CreateCharacter(Owner._userManager.equipCharacterId.Value);
                InitializeButton();
                InitializeText();
                Owner.mainView.MainGameObject.SetActive(true);
            }

            private void InitializeButton()
            {
                Owner.mainView.CharacterSelectButton.onClick.RemoveAllListeners();
                Owner.mainView.BattleReadyButton.onClick.RemoveAllListeners();
                Owner.mainView.SettingButton.onClick.RemoveAllListeners();
                Owner.mainView.ShopButton.onClick.RemoveAllListeners();
                Owner.mainView.CharacterSelectButton.onClick.AddListener(OnClickCharacterSelect);
                Owner.mainView.BattleReadyButton.onClick.AddListener(OnClickBattleReady);
                Owner.mainView.SettingButton.onClick.AddListener(OnClickSetting);
                Owner.mainView.ShopButton.onClick.AddListener(OnClickShop);
            }

            private void InitializeText()
            {
                Owner.mainView.CoinText.text = Owner._userManager.GetUser().Coin.ToString("D");
                Owner.mainView.DiamondText.text = Owner._userManager.GetUser().Gem.ToString("D");
            }


            private void OnClickCharacterSelect()
            {
                Owner._uiAnimation.OnClickScaleColorAnimation(Owner.mainView.CharacterSelectButton.gameObject)
                    .OnComplete(() => { Owner._stateMachine.Dispatch((int)Event.CharacterSelect); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickBattleReady()
            {
                Owner._uiAnimation.OnClickScaleColorAnimation(Owner.mainView.BattleReadyButton.gameObject)
                    .OnComplete(() => { Owner._stateMachine.Dispatch((int)Event.ReadyBattle); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickSetting()
            {
                Owner._uiAnimation.OnClickScaleColorAnimation(Owner.mainView.SettingButton.gameObject)
                    .OnComplete(() => { Owner._stateMachine.Dispatch((int)Event.Setting); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickShop()
            {
                Owner._uiAnimation.OnClickScaleColorAnimation(Owner.mainView.ShopButton.gameObject)
                    .OnComplete(() => { Owner._stateMachine.Dispatch((int)Event.Shop); })
                    .SetLink(Owner.gameObject);
            }
        }
    }
}