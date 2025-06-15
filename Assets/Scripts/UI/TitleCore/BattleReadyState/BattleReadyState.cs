using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager;
using Manager.NetworkManager;
using MoreMountains.Tools;
using UnityEngine;
using Photon.Pun;
using UniRx;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class BattleReadyState : StateMachine<TitleCore>.State
        {
            private BattleReadyView _View => (BattleReadyView)Owner.GetView(State.BattleReady);
            private PhotonNetworkManager _PhotonNetworkManager => Owner._photonNetworkManager;
            private MainManager _MainManager => Owner._mainManager;
            private readonly Dictionary<int, GameObject> _gridDictionary = new();
            private bool _isInitialize;
            private CancellationTokenSource _cts;


            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize();
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
                _PhotonNetworkManager.DisposedRoomSubject();
                GridAllDestroy();
                Cancel();
            }

            protected override void OnUpdate()
            {
                SceneTransition();
            }

            private void Initialize()
            {
                _PhotonNetworkManager._isTitle = true;
                _isInitialize = false;
                _cts = new CancellationTokenSource();
                _PhotonNetworkManager.CreateRoomSubject();
                InitializeButton();
                InitializeSubscribe();
                SetupEvent();
            }

            private void SetupEvent()
            {
                _PhotonNetworkManager.OnStartConnectNetwork();
            }

            private void InitializeButton()
            {
                _View._BattleStartButton
                    .OnClickAsObservable()
                    .Take(1)
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._BattleStartButton).ToObservable())
                    .Subscribe(_ => { OnClickSceneTransition(); })
                    .AddTo(_cts.Token);

                _View._BackButton
                    .OnClickAsObservable()
                    .Take(1)
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._BackButton).ToObservable())
                    .Subscribe(_ => { OnClickBackButton(); })
                    .AddTo(_cts.Token);
            }

            private void InitializeSubscribe()
            {
                _PhotonNetworkManager._JoinedRoomSubject
                    .Subscribe(OnJoinedRoom)
                    .AddTo(_cts.Token);

                _PhotonNetworkManager._LeftRoomSubject
                    .Subscribe(OnLeftRoom)
                    .AddTo(_cts.Token);
            }

            private void OnClickBackButton()
            {
                if (!PhotonNetwork.InRoom)
                {
                    return;
                }

                _PhotonNetworkManager._LeftRoomSubject.OnNext(PhotonNetwork.LocalPlayer.ActorNumber);
                PhotonNetwork.LeaveRoom();
                Owner._stateMachine.Dispatch((int)State.Main);
            }

            private void OnJoinedRoom(Photon.Realtime.Player[] players)
            {
                if (!_PhotonNetworkManager._isTitle)
                {
                    return;
                }

                GridAllDestroy();
                foreach (var player in players)
                {
                    var index = player.ActorNumber;
                    var playerKey = PhotonNetworkManager.GetPlayerKey(index, 0);
                    CreateGrid(playerKey);
                }

                if (_isInitialize)
                {
                    return;
                }

                _View._BattleStartButton.interactable = PhotonNetwork.IsMasterClient;
                Owner.SwitchUiObject(State.BattleReady, false).Forget();
                _isInitialize = true;
            }

            private void CreateGrid(int playerKey)
            {
                var characterData = _PhotonNetworkManager.GetCharacterData(playerKey);
                var levelData = _PhotonNetworkManager.GetLevelMasterData(playerKey);
                var grid = Instantiate(_View._BattleReadyGrid.gameObject, _View._GridParent);
                var battleReadyGrid = grid.GetComponent<BattleReadyGrid>();
                _gridDictionary[playerKey] = grid;
                battleReadyGrid.characterImage.sprite = characterData.SelfPortraitSprite;
                battleReadyGrid.backGroundImage.sprite = characterData.ColorSprite;
                battleReadyGrid.nameText.text = characterData.Name;
                battleReadyGrid.levelText.text = GameCommonData.LevelText + levelData.Level;
            }

            private void OnLeftRoom(int index)
            {
                if (!_gridDictionary.TryGetValue(index, out var grid))
                {
                    return;
                }

                if (index == PhotonNetwork.LocalPlayer.ActorNumber)
                {
                    return;
                }

                Destroy(grid);
                _gridDictionary.Remove(index);
                _View._BattleStartButton.interactable = PhotonNetwork.IsMasterClient;
            }

            private void SceneTransition()
            {
                if
                (
                    !PhotonNetwork.IsMasterClient ||
                    PhotonNetwork.CurrentRoom.PlayerCount < PhotonNetwork.CurrentRoom.MaxPlayers
                )
                {
                    return;
                }

                PhotonNetwork.CurrentRoom.IsOpen = false;
                PhotonNetwork.CurrentRoom.IsVisible = false;
                MMSceneLoadingManager.LoadScene(GameCommonData.BattleScene);
            }

            private void OnClickSceneTransition()
            {
                if (!PhotonNetwork.IsMasterClient)
                {
                    return;
                }

                PhotonNetwork.CurrentRoom.IsOpen = false;
                PhotonNetwork.CurrentRoom.IsVisible = false;
                MMSceneLoadingManager.LoadScene(GameCommonData.BattleScene);
                Owner.SetActiveBlockPanel(false);
            }


            private void GridAllDestroy()
            {
                foreach (var grid in _gridDictionary)
                {
                    Destroy(grid.Value);
                }

                _gridDictionary.Clear();
            }

            private void Cancel()
            {
                if (_cts == null)
                {
                    return;
                }

                _cts.Cancel();
                _cts.Dispose();
                _cts = null;
            }
        }
    }
}