using System.Threading;
using Cysharp.Threading.Tasks;
using Manager.NetworkManager;
using Photon.Pun;
using Photon.Realtime;
using UI.Title;
using UnityEngine;
using Zenject;

namespace Manager.BattleManager
{
    public partial class BattleManager : MonoBehaviourPunCallbacks
    {
        [Inject] private PhotonNetworkManager _networkManager;
        [Inject] private CharacterDataModel _characterDataModel;
        [Inject] private PlayerManager _playerManager;
        private StateMachine<BattleManager> _stateMachine;
        [SerializeField] private bool isTest;

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
        async void Start()
        {
          
            if (isTest)
            {
                var token = this.GetCancellationTokenOnDestroy();
                await OnInitialize(token).AttachExternalCancellation(token);
                PhotonNetwork.ConnectUsingSettings();
                return;
            }

            InitializeState();
        }

        private async UniTask OnInitialize(CancellationToken token)
        {
            await _characterDataModel.Initialize(token).AttachExternalCancellation(token);
        }

        private void InitializeState()
        {
            _stateMachine = new StateMachine<BattleManager>(this);
            _stateMachine.Start<PlayerCreateState>();
            _stateMachine.AddTransition<EndSceneTransitionState, PlayerCreateState>((int)Event.PlayerCreate);
        }

        #region //ToDo 後で消す

        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            PhotonNetwork.CreateRoom(null, new RoomOptions()
            {
                MaxPlayers = 4,
                IsOpen = true,
                IsVisible = true,
                EmptyRoomTtl = 0
            }, TypedLobby.Default);
        }

        public override void OnJoinedRoom()
        {
            InitializeState();
        }

        #endregion
    }
}