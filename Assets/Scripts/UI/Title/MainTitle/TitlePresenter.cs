using UnityEngine;
using Zenject;

namespace UI.Title.MainTitle
{
    public partial class TitlePresenter : MonoBehaviour
    {
        [Inject] private TitleModel _titleModel;
        [SerializeField] private TitleView _titleView;

        private StateMachine<TitlePresenter> _stateMachine;

        private enum TitleState
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
        }

        private void InitializeState()
        {
            _stateMachine = new StateMachine<TitlePresenter>(this);
            _stateMachine.Start<MainState>();
        }
    }
}