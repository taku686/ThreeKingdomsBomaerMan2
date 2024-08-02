using Assets.Scripts.Common.PlayFab;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class MainState : StateMachine<TitleCore>.State
        {
            private PlayFabLoginManager playFabLoginManager;
            private MainView mainView;

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize().Forget();
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
                mainView.SetBackgroundEffect(false);
            }


            protected override void OnUpdate()
            {
                //   TransitionLoginBonus();
            }

            private async UniTaskVoid Initialize()
            {
                playFabLoginManager = Owner.playFabLoginManager;
                mainView = Owner.mainView;
                Owner.CreateCharacter(Owner.userDataManager.GetUserData().EquipCharacterId);
                mainView.SetBackgroundEffect(true);
                InitializeButton();
                Owner.SwitchUiObject(State.Main, true).Forget();
                await InitializeText();
            }


            private void InitializeButton()
            {
                Owner.mainView.CharacterSelectButton.onClick.RemoveAllListeners();
                Owner.mainView.BattleReadyButton.onClick.RemoveAllListeners();
                Owner.mainView.SettingButton.onClick.RemoveAllListeners();
                Owner.mainView.ShopButton.onClick.RemoveAllListeners();
                mainView.MissionButton.onClick.RemoveAllListeners();
                Owner.mainView.CharacterSelectButton.onClick.AddListener(OnClickCharacterSelect);
                Owner.mainView.BattleReadyButton.onClick.AddListener(OnClickBattleReady);
                Owner.mainView.SettingButton.onClick.AddListener(OnClickSetting);
                Owner.mainView.ShopButton.onClick.AddListener(OnClickShop);
                mainView.MissionButton.onClick.AddListener(OnClickMission);
            }

            private async UniTask InitializeText()
            {
                await Owner.SetCoinText();
                await Owner.SetGemText();
                await Owner.SetTicketText();
                Owner.commonView.virtualCurrencyView.gameObject.SetActive(true);
            }

            //todo 後で使う
            private void TransitionLoginBonus()
            {
                if (!playFabLoginManager.haveLoginBonus)
                {
                    return;
                }

                playFabLoginManager.haveLoginBonus = false;
                Owner.stateMachine.Dispatch((int)State.LoginBonus);
            }


            private void OnClickCharacterSelect()
            {
                Owner.uiAnimation.ClickScaleColor(Owner.mainView.CharacterSelectButton.gameObject)
                    .OnComplete(() => { Owner.stateMachine.Dispatch((int)State.CharacterSelect); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickBattleReady()
            {
                Owner.uiAnimation.ClickScaleColor(Owner.mainView.BattleReadyButton.gameObject)
                    .OnComplete(() => { Owner.stateMachine.Dispatch((int)State.ReadyBattle); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickSetting()
            {
                Owner.uiAnimation.ClickScaleColor(Owner.mainView.SettingButton.gameObject)
                    .OnComplete(() => { Owner.stateMachine.Dispatch((int)State.Setting); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickShop()
            {
                Owner.uiAnimation.ClickScaleColor(Owner.mainView.ShopButton.gameObject)
                    .OnComplete(() => { Owner.stateMachine.Dispatch((int)State.Shop); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickMission()
            {
                Owner.uiAnimation.ClickScaleColor(mainView.MissionButton.gameObject)
                    .OnComplete(() => { Owner.stateMachine.Dispatch((int)State.Mission); })
                    .SetLink(Owner.gameObject);
            }
        }
    }
}