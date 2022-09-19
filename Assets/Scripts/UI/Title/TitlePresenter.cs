using System.Threading;
using Cysharp.Threading.Tasks;
using UI.Common;
using UniRx;
using UnityEngine;
using Zenject;

namespace UI.Title
{
    public partial class TitlePresenter : MonoBehaviour
    {
        [Inject] private TitleModel _titleModel;
        [Inject] private UIAnimation _uiAnimation;
        [SerializeField] private MainView mainView;
        [SerializeField] private CharacterSelectView characterSelectView;
        [SerializeField] private CharacterDetailView characterDetailView;
        [SerializeField] private Transform characterCreatePosition;


        private GameObject _character;
        private StateMachine<Title.TitlePresenter> _stateMachine;
        private CancellationToken _token;
        private int _currentCharacterId;

        private enum Event
        {
            Main,
            CharacterSelect,
            CharacterSelectBack,
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
            _titleModel.UserData.currentCharacterID.Subscribe(CreateCharacter).AddTo(this);
        }

        private void InitializeState()
        {
            _stateMachine = new StateMachine<Title.TitlePresenter>(this);
            _stateMachine.Start<MainState>();
            _stateMachine.AddAnyTransition<MainState>((int)Event.Main);
            _stateMachine.AddTransition<MainState, CharacterSelectState>((int)Event.CharacterSelect);
            _stateMachine.AddTransition<CharacterSelectState, CharacterDetailState>((int)Event.CharacterDetail);
            _stateMachine.AddTransition<CharacterDetailState, CharacterSelectState>((int)Event.CharacterSelectBack);
        }

       

        private void DisableTitleGameObject()
        {
            mainView.MainGameObject.SetActive(false);
            mainView.CharacterListGameObject.SetActive(false);
            mainView.CharacterDetailGameObject.SetActive(false);
        }

        private void CreateCharacter(int id)
        {
            _titleModel.UserData.currentCharacterID.Value = id;
            var preCharacter = _character;
            Destroy(preCharacter);
            _character = Instantiate(_titleModel.GetCharacterData(id).CharaObj, characterCreatePosition.position,
                characterCreatePosition.rotation, characterCreatePosition);
        }
    }
}