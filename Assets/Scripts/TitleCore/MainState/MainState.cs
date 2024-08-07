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
            private Main main;

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize().Forget();
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
                main.SetBackgroundEffect(false);
            }


            protected override void OnUpdate()
            {
                //   TransitionLoginBonus();
            }

            private async UniTaskVoid Initialize()
            {
                playFabLoginManager = Owner.playFabLoginManager;
                main = Owner.main;
                Owner.CreateCharacter(Owner.userDataManager.GetUserData().EquippedCharacterId);
                main.SetBackgroundEffect(true);
                InitializeButton();
                Owner.SwitchUiObject(State.Main, true).Forget();
                await InitializeText();
            }


            private void InitializeButton()
            {
                Owner.main.CharacterSelectButton.onClick.RemoveAllListeners();
                Owner.main.BattleReadyButton.onClick.RemoveAllListeners();
                Owner.main.SettingButton.onClick.RemoveAllListeners();
                Owner.main.ShopButton.onClick.RemoveAllListeners();
                main.MissionButton.onClick.RemoveAllListeners();
                Owner.main.CharacterSelectButton.onClick.AddListener(OnClickCharacterSelect);
                Owner.main.BattleReadyButton.onClick.AddListener(OnClickBattleReady);
                Owner.main.SettingButton.onClick.AddListener(OnClickSetting);
                Owner.main.ShopButton.onClick.AddListener(OnClickShop);
                main.MissionButton.onClick.AddListener(OnClickMission);
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
                Owner.uiAnimation.ClickScaleColor(Owner.main.CharacterSelectButton.gameObject)
                    .OnComplete(() => { Owner.stateMachine.Dispatch((int)State.CharacterSelect); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickBattleReady()
            {
                Owner.uiAnimation.ClickScaleColor(Owner.main.BattleReadyButton.gameObject)
                    .OnComplete(() => { Owner.stateMachine.Dispatch((int)State.BattleReady); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickSetting()
            {
                Owner.uiAnimation.ClickScaleColor(Owner.main.SettingButton.gameObject)
                    .OnComplete(() => { Owner.stateMachine.Dispatch((int)State.Setting); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickShop()
            {
                Owner.uiAnimation.ClickScaleColor(Owner.main.ShopButton.gameObject)
                    .OnComplete(() => { Owner.stateMachine.Dispatch((int)State.Shop); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickMission()
            {
                Owner.uiAnimation.ClickScaleColor(main.MissionButton.gameObject)
                    .OnComplete(() => { Owner.stateMachine.Dispatch((int)State.Mission); })
                    .SetLink(Owner.gameObject);
            }
        }
    }
}