using System.Collections.Generic;
using Common.Data;
using DG.Tweening;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UniRx;
using UnityEngine.UI;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class BattleReadyState : State
        {
            private readonly Dictionary<int, GameObject> _gridDictionary = new();
            private bool _isInitialize;
            private UserDataManager _userDataManager;

            protected override void OnEnter(State prevState)
            {
                Initialize();
                SetupEvent();
            }

            protected override void OnExit(State nextState)
            {
                Owner.commonView.virtualCurrencyView.gameObject.SetActive(true);
            }

            protected override void OnUpdate()
            {
                SceneTransition();
            }

            private void Initialize()
            {
                _userDataManager = Owner._userDataManager;
                Owner.commonView.virtualCurrencyView.gameObject.SetActive(false);
                InitializeButton();
                InitializeSubscribe();
            }

            private void SetupEvent()
            {
                Owner.DisableTitleGameObject();
                Owner.mainView.BattleReadyGameObject.SetActive(true);
                Owner._photonNetworkManager.OnStartConnectNetwork();
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
                if (_isInitialize)
                {
                    return;
                }

                Owner._photonNetworkManager.JoinedRoom.Subscribe(OnJoinedRoom).AddTo(Owner.gameObject);
                Owner._photonNetworkManager.LeftRoom.Subscribe(OnLeftRoom).AddTo(Owner.gameObject);
                _isInitialize = true;
            }

            private void OnClickBackButton()
            {
                Owner._uiAnimation.ClickScaleColor(Owner.battleReadyView.BackButton.gameObject).OnComplete(() =>
                {
                    if (!PhotonNetwork.InRoom)
                    {
                        return;
                    }

                    Owner._photonNetworkManager.LeftRoom.OnNext(PhotonNetwork.LocalPlayer.ActorNumber);
                    PhotonNetwork.LeaveRoom();
                    Owner.DisableTitleGameObject();
                    Owner.mainView.MainGameObject.SetActive(true);
                    Owner._stateMachine.Dispatch((int)TitleCoreEvent.Main);
                }).SetLink(Owner.gameObject);
            }

            private void OnJoinedRoom(Photon.Realtime.Player[] players)
            {
                GridAllDestroy();
                foreach (var player in players)
                {
                    var index = player.ActorNumber;
                    var characterData = Owner._photonNetworkManager.CurrentRoomCharacterDatum[index];
                    var levelData = Owner._photonNetworkManager.GetCharacterLevelData(index);
                    var grid = Instantiate(Owner.battleReadyView.BattleReadyGrid.gameObject,
                        Owner.battleReadyView.GridParent);
                    var battleReadyGrid = grid.GetComponent<BattleReadyGrid>();
                    _gridDictionary[index] = grid;
                    battleReadyGrid.characterImage.sprite = characterData.SelfPortraitSprite;
                    battleReadyGrid.backGroundImage.sprite = characterData.ColorSprite;
                    battleReadyGrid.nameText.text = characterData.Name;
                    battleReadyGrid.levelText.text = GameCommonData.LevelText + levelData.Level;
                }
            }

            private void OnLeftRoom(int index)
            {
                if (!_gridDictionary.TryGetValue(index, out var grid))
                {
                    return;
                }

                if (index == PhotonNetwork.LocalPlayer.ActorNumber)
                {
                    GridAllDestroy();
                    return;
                }

                Destroy(grid);
                _gridDictionary.Remove(index);
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
                Owner._stateMachine.Dispatch((int)TitleCoreEvent.SceneTransition);
            }

            private void OnClickSceneTransition()
            {
                if (!PhotonNetwork.IsMasterClient)
                {
                    return;
                }

                PhotonNetwork.CurrentRoom.IsOpen = false;
                PhotonNetwork.CurrentRoom.IsVisible = false;
                Owner._stateMachine.Dispatch((int)TitleCoreEvent.SceneTransition);
            }


            private void GridAllDestroy()
            {
                foreach (var grid in _gridDictionary)
                {
                    Destroy(grid.Value);
                }

                _gridDictionary.Clear();
            }
        }
    }
}