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
            private PlayFabLoginManager _PlayFabLoginManager => Owner._playFabLoginManager;
            private MainView _View => (MainView)Owner.GetView(State.Main);
            private CharacterCreateUseCase _CharacterCreateUseCase => Owner._characterCreateUseCase;
            private UserDataRepository _UserDataRepository => Owner._userDataRepository;

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize().Forget();
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
                _View.SetBackgroundEffect(false);
            }


            protected override void OnUpdate()
            {
            }

            private async UniTaskVoid Initialize()
            {
                var characterId = _UserDataRepository.GetEquippedCharacterId();
                _CharacterCreateUseCase.CreateCharacter(characterId);
                _View.SetBackgroundEffect(true);
                InitializeButton();
                Owner.SwitchUiObject(State.Main, true).Forget();
                await InitializeText();
            }


            private void InitializeButton()
            {
                _View.CharacterSelectButton.onClick.RemoveAllListeners();
                _View.BattleReadyButton.onClick.RemoveAllListeners();
                _View.SettingButton.onClick.RemoveAllListeners();
                _View.ShopButton.onClick.RemoveAllListeners();
                _View.MissionButton.onClick.RemoveAllListeners();
                _View.CharacterSelectButton.onClick.AddListener(OnClickCharacterSelect);
                _View.BattleReadyButton.onClick.AddListener(OnClickBattleReady);
                _View.SettingButton.onClick.AddListener(OnClickSetting);
                _View.ShopButton.onClick.AddListener(OnClickShop);
                _View.MissionButton.onClick.AddListener(OnClickMission);
            }

            private async UniTask InitializeText()
            {
                await Owner.SetCoinText();
                await Owner.SetGemText();
                await Owner.SetTicketText();
                Owner._commonView.virtualCurrencyView.gameObject.SetActive(true);
            }

            //todo 後で使う
            private void TransitionLoginBonus()
            {
                if (!_PlayFabLoginManager._haveLoginBonus)
                {
                    return;
                }

                _PlayFabLoginManager._haveLoginBonus = false;
                Owner._stateMachine.Dispatch((int)State.LoginBonus);
            }


            private void OnClickCharacterSelect()
            {
                Owner._uiAnimation.ClickScaleColor(_View.CharacterSelectButton.gameObject)
                    .OnComplete(() => { Owner._stateMachine.Dispatch((int)State.CharacterSelect); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickBattleReady()
            {
                Owner._uiAnimation.ClickScaleColor(_View.BattleReadyButton.gameObject)
                    .OnComplete(() => { Owner._stateMachine.Dispatch((int)State.BattleReady); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickSetting()
            {
                Owner._uiAnimation.ClickScaleColor(_View.SettingButton.gameObject)
                    .OnComplete(() => { Owner._stateMachine.Dispatch((int)State.Setting); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickShop()
            {
                Owner._uiAnimation.ClickScaleColor(_View.ShopButton.gameObject)
                    .OnComplete(() => { Owner._stateMachine.Dispatch((int)State.Shop); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickMission()
            {
                Owner._uiAnimation.ClickScaleColor(_View.MissionButton.gameObject)
                    .OnComplete(() => { Owner._stateMachine.Dispatch((int)State.Mission); })
                    .SetLink(Owner.gameObject);
            }
        }
    }
}