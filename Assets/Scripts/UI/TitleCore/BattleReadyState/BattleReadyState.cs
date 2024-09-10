using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
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
            private readonly Dictionary<int, GameObject> gridDictionary = new();
            private bool isInitialize;
            private CancellationTokenSource cts;
            private BattleReadyView View => (BattleReadyView)Owner.GetView(State.BattleReady);

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize();
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
                Cancel();
            }

            protected override void OnUpdate()
            {
                SceneTransition();
            }

            private void Initialize()
            {
                isInitialize = false;
                SetupCancellationToken();
                InitializeButton();
                InitializeSubscribe();
                SetupEvent();
            }

            private void SetupEvent()
            {
                Owner.photonNetworkManager.OnStartConnectNetwork();
            }

            private void InitializeButton()
            {
                View.BackButton.onClick.RemoveAllListeners();
                View.BattleStartButton.onClick.RemoveAllListeners();
                View.BackButton.onClick.AddListener(OnClickBackButton);
                View.BattleStartButton.onClick.AddListener(OnClickSceneTransition);
            }

            private void InitializeSubscribe()
            {
                Owner.photonNetworkManager.JoinedRoomSubject.Subscribe(OnJoinedRoom).AddTo(cts.Token);
                Owner.photonNetworkManager.LeftRoomSubject.Subscribe(OnLeftRoom).AddTo(cts.Token);
            }

            private void OnClickBackButton()
            {
                Owner.uiAnimation.ClickScaleColor(View.BackButton.gameObject).OnComplete(() =>
                {
                    if (!PhotonNetwork.InRoom)
                    {
                        return;
                    }

                    Owner.photonNetworkManager.LeftRoomSubject.OnNext(PhotonNetwork.LocalPlayer.ActorNumber);
                    PhotonNetwork.LeaveRoom();
                    Owner.stateMachine.Dispatch((int)State.Main);
                }).SetLink(Owner.gameObject);
            }

            private void OnJoinedRoom(Photon.Realtime.Player[] players)
            {
                GridAllDestroy();
                foreach (var player in players)
                {
                    var index = player.ActorNumber;
                    CreateGrid(index);
                }

                if (isInitialize)
                {
                    return;
                }

                Owner.SwitchUiObject(State.BattleReady, false).Forget();
                isInitialize = true;
            }

            private void CreateGrid(int index)
            {
                var characterData = Owner.photonNetworkManager.GetCharacterData(index);
                var levelData = Owner.photonNetworkManager.GetLevelMasterData(index);
                var grid = Instantiate(View.BattleReadyGrid.gameObject, View.GridParent);
                var battleReadyGrid = grid.GetComponent<BattleReadyGrid>();
                gridDictionary[index] = grid;
                battleReadyGrid.characterImage.sprite = characterData.SelfPortraitSprite;
                battleReadyGrid.backGroundImage.sprite = characterData.ColorSprite;
                battleReadyGrid.nameText.text = characterData.Name;
                battleReadyGrid.levelText.text = GameCommonData.LevelText + levelData.Level;
            }

            private void OnLeftRoom(int index)
            {
                if (!gridDictionary.TryGetValue(index, out var grid))
                {
                    return;
                }

                if (index == PhotonNetwork.LocalPlayer.ActorNumber)
                {
                    return;
                }

                Destroy(grid);
                gridDictionary.Remove(index);
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
            }


            private void GridAllDestroy()
            {
                foreach (var grid in gridDictionary)
                {
                    Destroy(grid.Value);
                }

                gridDictionary.Clear();
            }

            private void SetupCancellationToken()
            {
                cts = new CancellationTokenSource();
            }

            private void Cancel()
            {
                if (cts == null)
                {
                    return;
                }

                cts.Cancel();
                cts.Dispose();
                cts = null;
            }
        }
    }
}