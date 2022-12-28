using Bomb;
using Common.Data;
using Manager.NetworkManager;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Manager.BattleManager
{
    public partial class BattleBase : MonoBehaviourPunCallbacks
    {
        [Inject] private PhotonNetworkManager _networkManager;

        //   [Inject] private CharacterDataManager _characterDataManager;
        [Inject] private PlayerGenerator _playerGenerator;

        //[Inject] private UserManager _userManager;
        [Inject] private BombProvider _bombProvider;
        [SerializeField] private Transform playerUIParent;
        [SerializeField] private GameObject playerUI;
        private StateMachine<BattleBase> _stateMachine;
        private SynchronizedValue _synchronizedValue;

        private enum Event
        {
            EndSceneTransition,
            PlayerCreate,
            Staging,
            CountDown,
            BattleStart,
            InBattle,
            BattleEnd,
            Result,
            StartSceneTransition
        }

        // Start is called before the first frame update
        void Start()
        {
            InitializeState();
            InitializeComponent();
        }

        /*private async UniTask OnInitialize(CancellationToken token)
        {
            await _characterDataManager.Initialize(_userManager, token).AttachExternalCancellation(token);
        }*/

        private void InitializeState()
        {
            _stateMachine = new StateMachine<BattleBase>(this);
            _stateMachine.Start<PlayerCreateState>();
            _stateMachine.AddTransition<EndSceneTransitionState, PlayerCreateState>((int)Event.PlayerCreate);
        }

        private void InitializeComponent()
        {
            _synchronizedValue = gameObject.AddComponent<SynchronizedValue>();
        }


        //todo デバッグ用後で消す
        public void OnClickExit()
        {
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene((int)SceneIndex.Title);
        }

        //todo デバッグ用後で消す
        public void OnReborn()
        {
            var players = GameObject.FindGameObjectsWithTag(GameSettingData.PlayerTag);
            foreach (var player in players)
            {
                var view = player.GetComponent<PhotonView>();
                if (!view.IsMine)
                {
                    return;
                }

                player.transform.position = new Vector3(0, 0.5f, 0);
            }
        }
    }
}