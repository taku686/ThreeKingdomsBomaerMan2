using UnityEngine;
using Zenject;

namespace UI.Title.MainTitle
{
    public partial class TitlePresenter : MonoBehaviour
    {
        [Inject] private TitleModel _titleModel;
        [SerializeField] private TitleView _titleView;

        private StateMachine<TitlePresenter> _stateMachine;

        private enum Event
        {
            Main,
            CharacterSelect,
            Shop,
            ReadyBattle,
            SelectBattleMode
        }

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            InitializeState();
            InitializeButton();
        }

        private void InitializeState()
        {
            _stateMachine = new StateMachine<TitlePresenter>(this);
            _stateMachine.Start<MainState>();
            _stateMachine.AddAnyTransition<MainState>((int)Event.Main);
            _stateMachine.AddTransition<MainState, CharacterSelectState>((int)Event.CharacterSelect);
        }

        private void InitializeButton()
        {
            _titleView.CharacterButton.onClick.AddListener(() => _stateMachine.Dispatch((int)Event.CharacterSelect));
            _titleView.BackButton.onClick.AddListener(() => _stateMachine.Dispatch((int)Event.Main));
        }

        private void DisableTitleGameObject()
        {
            _titleView.LobbyGameObject.SetActive(false);
            _titleView.CharacterListGameObject.SetActive(false);
            _titleView.CharacterDetailGameObject.SetActive(false);
        }
    }
}