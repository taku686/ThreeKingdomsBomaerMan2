using Bomb;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.BattleManager.Camera;
using Manager.BattleManager.Environment;
using Manager.NetworkManager;
using MoreMountains.Tools;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Manager.BattleManager
{
    public partial class BattleCore : MonoBehaviourPunCallbacks
    {
        [Inject] private PhotonNetworkManager _networkManager;
        [Inject] private PlayerGenerator _playerGenerator;
        [Inject] private BombProvider _bombProvider;
        [Inject] private UserDataManager _userDataManager;
        [Inject] private MissionManager _missionManager;
        [SerializeField] private Transform playerUIParent;
        [SerializeField] private GameObject playerUI;
        [SerializeField] private CameraManager cameraManager;
        [SerializeField] private StageManager stageManager;
        [SerializeField] private MapManager mapManager;
        private StateMachine<BattleCore> _stateMachine;

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

        private void Update()
        {
            _stateMachine.Update();
        }

        private void InitializeState()
        {
            _stateMachine = new StateMachine<BattleCore>(this);
            _stateMachine.Start<EndSceneTransitionState>();
            _stateMachine.AddTransition<EndSceneTransitionState, PlayerCreateState>((int)Event.PlayerCreate);
            _stateMachine.AddTransition<PlayerCreateState, BattleStartState>((int)Event.BattleStart);
        }

        private void InitializeComponent()
        {
            gameObject.AddComponent<SynchronizedValue>();
        }

        private void CheckMission(int actionId)
        {
            switch (actionId)
            {
                case GameCommonData.LevelUpActionId:
                    _missionManager.CheckMission(GameCommonData.LevelUpActionId);
                    break;
                case GameCommonData.BattleCountActionId:
                    _missionManager.CheckMission(GameCommonData.BattleCountActionId);
                    break;
                case GameCommonData.CharacterBattleActionId:
                    var characterId = _userDataManager.GetEquippedCharacterData().Id;
                    _missionManager.CheckMission(GameCommonData.CharacterBattleActionId, characterId);
                    break;
            }
        }


        //todo デバッグ用後で消す
        public void OnClickExit()
        {
            SynchronizedValue.Instance.Destroy();
            PhotonNetwork.Disconnect();
            MMSceneLoadingManager.LoadScene(GameCommonData.TitleScene);
        }

        //todo デバッグ用後で消す
        public void OnReborn()
        {
            var players = GameObject.FindGameObjectsWithTag(GameCommonData.PlayerTag);
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