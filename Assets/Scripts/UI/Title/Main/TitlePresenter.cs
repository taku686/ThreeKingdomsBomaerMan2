using System.Threading;
using Cysharp.Threading.Tasks;
using UI.Title.MainTitle;
using UniRx;
using UnityEngine;
using Zenject;

namespace UI.Title.Main
{
    public partial class TitlePresenter : MonoBehaviour
    {
        [Inject] private TitleModel _titleModel;
        [SerializeField] private MainView mainView;
        [SerializeField] private CharacterSelectView characterSelectView;
        [SerializeField] private Transform characterCreatePosition;


        private GameObject _character;
        private StateMachine<TitlePresenter> _stateMachine;
        private CancellationToken _token;
        private ReactiveProperty<int> _currentCharacterId = new ReactiveProperty<int>(0);

        private enum Event
        {
            Main,
            CharacterSelect,
            CharacterDetail,
            Shop,
            ReadyBattle,
            SelectBattleMode
        }

        private void Start()
        {
            Initialize().Forget();
        }


        private async UniTask Initialize()
        {
            _token = this.GetCancellationTokenOnDestroy();
            await _titleModel.Initialize(_token);
            InitializeState();
            InitializeButton();
            _currentCharacterId.Subscribe(CreateCharacter).AddTo(this);
            _currentCharacterId.Value = _titleModel.UserData.currentCharacterID;
        }

        private void InitializeState()
        {
            _stateMachine = new StateMachine<Main.TitlePresenter>(this);
            _stateMachine.Start<MainState>();
            _stateMachine.AddAnyTransition<MainState>((int)Event.Main);
            _stateMachine.AddTransition<MainState, CharacterSelectState>((int)Event.CharacterSelect);
            _stateMachine.AddTransition<CharacterSelectState, CharacterDetailState>((int)Event.CharacterDetail);
        }

        private void InitializeButton()
        {
            mainView.CharacterSelectButton.onClick.AddListener(() =>
                _stateMachine.Dispatch((int)Event.CharacterSelect));
            characterSelectView.BackButton.onClick.AddListener(() => _stateMachine.Dispatch((int)Event.Main));
        }

        private void DisableTitleGameObject()
        {
            mainView.MainGameObject.SetActive(false);
            mainView.CharacterListGameObject.SetActive(false);
            mainView.CharacterDetailGameObject.SetActive(false);
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