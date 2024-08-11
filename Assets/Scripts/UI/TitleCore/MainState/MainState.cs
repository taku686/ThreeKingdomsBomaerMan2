using Assets.Scripts.Common.PlayFab;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Repository;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class MainState : StateMachine<TitleCore>.State
        {
            private PlayFabLoginManager PlayFabLoginManager => Owner.playFabLoginManager;
            private MainView View => (MainView)Owner.GetView(State.Main);
            private CharacterCreateUseCase CharacterCreateUseCase => Owner.characterCreateUseCase;
            private UserDataRepository UserDataRepository => Owner.userDataRepository;

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize().Forget();
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
                View.SetBackgroundEffect(false);
            }


            protected override void OnUpdate()
            {
            }

            private async UniTaskVoid Initialize()
            {
                var characterId = UserDataRepository.GetEquippedCharacterId();
                CharacterCreateUseCase.CreateCharacter(characterId);
                View.SetBackgroundEffect(true);
                InitializeButton();
                Owner.SwitchUiObject(State.Main, true).Forget();
                await InitializeText();
            }


            private void InitializeButton()
            {
                View.CharacterSelectButton.onClick.RemoveAllListeners();
                View.BattleReadyButton.onClick.RemoveAllListeners();
                View.SettingButton.onClick.RemoveAllListeners();
                View.ShopButton.onClick.RemoveAllListeners();
                View.MissionButton.onClick.RemoveAllListeners();
                View.CharacterSelectButton.onClick.AddListener(OnClickCharacterSelect);
                View.BattleReadyButton.onClick.AddListener(OnClickBattleReady);
                View.SettingButton.onClick.AddListener(OnClickSetting);
                View.ShopButton.onClick.AddListener(OnClickShop);
                View.MissionButton.onClick.AddListener(OnClickMission);
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
                if (!PlayFabLoginManager.haveLoginBonus)
                {
                    return;
                }

                PlayFabLoginManager.haveLoginBonus = false;
                Owner.stateMachine.Dispatch((int)State.LoginBonus);
            }


            private void OnClickCharacterSelect()
            {
                Owner.uiAnimation.ClickScaleColor(View.CharacterSelectButton.gameObject)
                    .OnComplete(() => { Owner.stateMachine.Dispatch((int)State.CharacterSelect); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickBattleReady()
            {
                Owner.uiAnimation.ClickScaleColor(View.BattleReadyButton.gameObject)
                    .OnComplete(() => { Owner.stateMachine.Dispatch((int)State.BattleReady); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickSetting()
            {
                Owner.uiAnimation.ClickScaleColor(View.SettingButton.gameObject)
                    .OnComplete(() => { Owner.stateMachine.Dispatch((int)State.Setting); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickShop()
            {
                Owner.uiAnimation.ClickScaleColor(View.ShopButton.gameObject)
                    .OnComplete(() => { Owner.stateMachine.Dispatch((int)State.Shop); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickMission()
            {
                Owner.uiAnimation.ClickScaleColor(View.MissionButton.gameObject)
                    .OnComplete(() => { Owner.stateMachine.Dispatch((int)State.Mission); })
                    .SetLink(Owner.gameObject);
            }
        }
    }
}