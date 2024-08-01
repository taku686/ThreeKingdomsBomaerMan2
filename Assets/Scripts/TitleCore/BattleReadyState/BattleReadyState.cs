using System.Collections.Generic;
using Common.Data;
using DG.Tweening;
using UnityEngine;
using Photon.Pun;
using UniRx;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class BattleReadyState : State
        {
            private readonly Dictionary<int, GameObject> gridDictionary = new();
            private bool isInitialize;
            private UserDataManager userDataManager;

            protected override void OnEnter(State prevState)
            {
                Initialize();
            }


            protected override void OnUpdate()
            {
                SceneTransition();
            }

            private void Initialize()
            {
                userDataManager = Owner.userDataManager;
                InitializeButton();
                InitializeSubscribe();
                SetupEvent();
                Owner.SwitchUiObject(TitleCoreEvent.ReadyBattle, false);
            }

            private void SetupEvent()
            {
                Owner.photonNetworkManager.OnStartConnectNetwork();
            }

            private void InitializeButton()
            {
                Owner.battleReadyView.BackButton.onClick.RemoveAllListeners();
                Owner.battleReadyView.BattleStartButton.onClick.RemoveAllListeners();
                Owner.battleReadyView.BackButton.onClick.AddListener(OnClickBackButton);
                Owner.battleReadyView.BattleStartButton.onClick.AddListener(OnClickSceneTransition);
            }

            private void InitializeSubscribe()
            {
                if (isInitialize)
                {
                    return;
                }

                Owner.photonNetworkManager.JoinedRoom.Subscribe(OnJoinedRoom).AddTo(Owner.gameObject);
                Owner.photonNetworkManager.LeftRoom.Subscribe(OnLeftRoom).AddTo(Owner.gameObject);
                isInitialize = true;
            }

            private void OnClickBackButton()
            {
                Owner.uiAnimation.ClickScaleColor(Owner.battleReadyView.BackButton.gameObject).OnComplete(() =>
                {
                    if (!PhotonNetwork.InRoom)
                    {
                        return;
                    }

                    Owner.photonNetworkManager.LeftRoom.OnNext(PhotonNetwork.LocalPlayer.ActorNumber);
                    PhotonNetwork.LeaveRoom();
                    Owner.DisableTitleGameObject();
                    Owner.mainView.MainGameObject.SetActive(true);
                    Owner.stateMachine.Dispatch((int)TitleCoreEvent.Main);
                }).SetLink(Owner.gameObject);
            }

            private void OnJoinedRoom(Photon.Realtime.Player[] players)
            {
                GridAllDestroy();
                foreach (var player in players)
                {
                    var index = player.ActorNumber;
                    var characterData = Owner.photonNetworkManager.CurrentRoomCharacterDatum[index];
                    var levelData = Owner.photonNetworkManager.GetCharacterLevelData(index);
                    var grid = Instantiate(Owner.battleReadyView.BattleReadyGrid.gameObject,
                        Owner.battleReadyView.GridParent);
                    var battleReadyGrid = grid.GetComponent<BattleReadyGrid>();
                    gridDictionary[index] = grid;
                    battleReadyGrid.characterImage.sprite = characterData.SelfPortraitSprite;
                    battleReadyGrid.backGroundImage.sprite = characterData.ColorSprite;
                    battleReadyGrid.nameText.text = characterData.Name;
                    battleReadyGrid.levelText.text = GameCommonData.LevelText + levelData.Level;
                }
            }

            private void OnLeftRoom(int index)
            {
                if (!gridDictionary.TryGetValue(index, out var grid))
                {
                    return;
                }

                if (index == PhotonNetwork.LocalPlayer.ActorNumber)
                {
                    GridAllDestroy();
                    return;
                }

                Destroy(grid);
                gridDictionary.Remove(index);
            }

            private void SceneTransition()
            {
                if (!PhotonNetwork.IsMasterClient ||
                    PhotonNetwork.CurrentRoom.PlayerCount < PhotonNetwork.CurrentRoom.MaxPlayers)
                {
                    return;
                }

                PhotonNetwork.CurrentRoom.IsOpen = false;
                PhotonNetwork.CurrentRoom.IsVisible = false;
                Owner.stateMachine.Dispatch((int)TitleCoreEvent.SceneTransition);
            }

            private void OnClickSceneTransition()
            {
                if (!PhotonNetwork.IsMasterClient)
                {
                    return;
                }

                PhotonNetwork.CurrentRoom.IsOpen = false;
                PhotonNetwork.CurrentRoom.IsVisible = false;
                Owner.stateMachine.Dispatch((int)TitleCoreEvent.SceneTransition);
            }


            private void GridAllDestroy()
            {
                foreach (var grid in gridDictionary)
                {
                    Destroy(grid.Value);
                }

                gridDictionary.Clear();
            }
        }
    }
}