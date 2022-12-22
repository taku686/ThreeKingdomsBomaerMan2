using System.Collections.Generic;
using Common.Data;
using DG.Tweening;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UniRx;
using UnityEngine.UI;
using State = StateMachine<UI.Title.TitlePresenter>.State;

namespace UI.Title
{
    public partial class TitlePresenter
    {
        public class BattleReadyState : State
        {
            private readonly Dictionary<int, GameObject> _gridDictionary = new Dictionary<int, GameObject>();
            private bool _isInitialize;

            protected override void OnEnter(State prevState)
            {
                Initialize();
                SetupEvent();
            }

            protected override void OnUpdate()
            {
                SceneTransition();
            }

            private void Initialize()
            {
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

                Owner._photonNetworkManager.JoinedRoom
                    .Subscribe(OnJoinedRoom)
                    .AddTo(Owner.gameObject);
                Owner._photonNetworkManager.LeftRoom.Subscribe(OnLeftRoom)
                    .AddTo(Owner.gameObject);
                _isInitialize = true;
            }

            private void OnClickBackButton()
            {
                Owner._uiAnimation.OnClickScaleColorAnimation(Owner.battleReadyView.BackButton.gameObject)
                    .OnComplete(() =>
                    {
                        if (!PhotonNetwork.InRoom)
                        {
                            return;
                        }

                        Owner._photonNetworkManager.LeftRoom.OnNext(PhotonNetwork.LocalPlayer.ActorNumber);
                        PhotonNetwork.LeaveRoom();
                        Owner.DisableTitleGameObject();
                        Owner.mainView.MainGameObject.SetActive(true);
                        Owner._stateMachine.Dispatch((int)Event.Main);
                    })
                    .SetLink(Owner.gameObject);
            }

            private void OnJoinedRoom(Photon.Realtime.Player[] players)
            {
                GridAllDestroy();
                foreach (var player in players)
                {
                    var index = player.ActorNumber;
                    var grid = Instantiate(Owner.battleReadyView.BattleReadyGrid.gameObject,
                        Owner.battleReadyView.GridParent);
                    var battleReadyGrid = grid.GetComponent<BattleReadyGrid>();
                    _gridDictionary[index] = grid;
                    var characterData = Owner._photonNetworkManager.CurrentRoomCharacterList[index];
                    battleReadyGrid.characterImage.sprite =
                        Owner._characterDataManager.GetCharacterSprite(characterData.ID);
                    battleReadyGrid.backGroundImage.sprite = Owner._characterDataManager.GetCharacterColor(
                        (int)GameSettingData.GetCharacterColor(characterData.CharaColor));
                    battleReadyGrid.nameText.text = characterData.Name;
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

                Owner._stateMachine.Dispatch((int)Event.SceneTransition);
            }

            private void OnClickSceneTransition()
            {
                if (!PhotonNetwork.IsMasterClient)
                {
                    return;
                }

                Owner._stateMachine.Dispatch((int)Event.SceneTransition);
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