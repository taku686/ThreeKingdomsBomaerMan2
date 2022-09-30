using System.Collections.Generic;
using Common.Data;
using DG.Tweening;
using Manager.NetworkManager;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
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

            private void Initialize()
            {
                InitializeButton();
                InitializeSubscribe();
            }

            private void SetupEvent()
            {
                Owner.DisableTitleGameObject();
                Owner.mainView.BattleReadyGameObject.SetActive(true);
                Owner.photonNetworkManager.OnStartConnectNetwork();
            }

            private void InitializeButton()
            {
                Owner.battleReadyView.BackButton.onClick.RemoveAllListeners();
                Owner.battleReadyView.BackButton.onClick.AddListener(OnClickBackButton);
            }

            private void InitializeSubscribe()
            {
                if (_isInitialize)
                {
                    return;
                }

                Owner.photonNetworkManager.JoinedRoom
                    .Subscribe(OnJoinedRoom)
                    .AddTo(Owner.gameObject);
                Owner.photonNetworkManager.LeftRoom.Subscribe(OnLeftRoom)
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

                        Owner.photonNetworkManager.LeftRoom.OnNext(PhotonNetwork.LocalPlayer.ActorNumber);
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
                    var grid = Instantiate(Owner.battleReadyView.Grid, Owner.battleReadyView.GridParent);
                    _gridDictionary[index] = grid;
                    var images = grid.GetComponentsInChildren<Image>();
                    var names = grid.GetComponentsInChildren<TextMeshProUGUI>();
                    var characterData = Owner.photonNetworkManager.CurrentRoomCharacterList[index];
                    foreach (var image in images)
                    {
                        if (image.CompareTag("CharacterImage"))
                        {
                            image.sprite = Owner._titleModel.GetCharacterSprite(characterData.ID);
                        }

                        if (image.CompareTag("BackGround"))
                        {
                            image.sprite = Owner._titleModel.GetCharacterColor((int)characterData.CharaColor);
                        }
                    }

                    foreach (var name in names)
                    {
                        if (name.CompareTag("Name"))
                        {
                            name.text = characterData.Name;
                        }
                    }
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

                Debug.Log("削除");
                Destroy(grid);
                _gridDictionary.Remove(index);
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