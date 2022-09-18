using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Zenject;

namespace UI.Title.MainTitle
{
    public partial class TitlePresenter : MonoBehaviour
    {
        [Inject] private TitleModel _titleModel;

        [SerializeField] private TitleView _titleView;
        [SerializeField] private Transform characterCreatePosition;

        private GameObject _character;
        private StateMachine<TitlePresenter> _stateMachine;
        private CancellationToken _token;
        private ReactiveProperty<int> _currentCharacterId = new ReactiveProperty<int>(0);

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
            _token = this.GetCancellationTokenOnDestroy();
            _titleModel.Initialize(_token);
            InitializeState();
            InitializeButton();
            _currentCharacterId.Subscribe(CreateCharacter).AddTo(this);
            _currentCharacterId.Value = _titleModel.UserData.currentCharacterID;
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

        private void CreateCharacter(int id)
        {
            _titleModel.UserData.currentCharacterID = id;
            Destroy(_character);
            _character = Instantiate(_titleModel.GetCharacterData(id).CharaObj, characterCreatePosition.position,
                characterCreatePosition.rotation, characterCreatePosition);
        }
    }
}