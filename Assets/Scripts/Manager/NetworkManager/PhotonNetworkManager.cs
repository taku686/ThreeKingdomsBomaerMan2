using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;
using ExitGames.Client.Photon;
using ModestTree;
using Photon.Pun;
using Photon.Realtime;
using UI.Title;
using UniRx;
using UnityEngine;
using Zenject;

namespace Manager.NetworkManager
{
    public class PhotonNetworkManager : MonoBehaviourPunCallbacks
    {
        [Inject] private CharacterDataModel _characterDataModel;
        private readonly Subject<Photon.Realtime.Player[]> _joinedRoom = new Subject<Photon.Realtime.Player[]>();
        private readonly Subject<int> _leftRoom = new Subject<int>();
        private readonly Dictionary<int, GameObject> _playerObjectDictionary = new Dictionary<int, GameObject>();

        private readonly Dictionary<int, CharacterData>
            _currentRoomCharacterList = new Dictionary<int, CharacterData>();

        private readonly Subject<Unit> _playerGenerateComplete = new Subject<Unit>();
        private int _playerCount;


        public Dictionary<int, CharacterData> CurrentRoomCharacterList => _currentRoomCharacterList;
        public Dictionary<int, GameObject> PlayerObjectDictionary => _playerObjectDictionary;
        public Subject<int> LeftRoom => _leftRoom;
        public IObservable<Photon.Realtime.Player[]> JoinedRoom => _joinedRoom;
        public IObservable<Unit> PlayerGenerateComplete => _playerGenerateComplete;

        private void Awake()
        {
            CurrentRoomCharacterList.Clear();
            PhotonNetwork.UseRpcMonoBehaviourCache = true;
            PhotonNetwork.AutomaticallySyncScene = true;
            _playerCount = 0;
        }

        public void OnStartConnectNetwork()
        {
            if (!PhotonNetwork.IsConnected)
            {
                PhotonNetwork.ConnectUsingSettings();
            }
        }

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
            var index = PhotonNetwork.LocalPlayer.ActorNumber;
            PhotonNetwork.LocalPlayer.SetCharacterData(_characterDataModel.GetUserEquipCharacterData().ID);
            PhotonNetwork.LocalPlayer.SetPlayerIndex(index);
        }

        public override void OnLeftRoom()
        {
            _currentRoomCharacterList.Clear();
            PhotonNetwork.Disconnect();
        }

        public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
        {
            _leftRoom.OnNext(otherPlayer.GetPlayerIndex());
        }

        public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, Hashtable changedProps)
        {
            foreach (var prop in changedProps)
            {
                if ((string)prop.Key == PlayerPropertiesExtensions.PlayerIndexKey)
                {
                    SetupPlayerInfo(PhotonNetwork.PlayerList);
                }

                if ((string)prop.Key == PlayerPropertiesExtensions.PlayerGenerateKey)
                {
                    _playerCount++;
                    CheckPlayerGenerateComplete(_playerCount);
                }
            }
        }

        private void SetupPlayerInfo(Photon.Realtime.Player[] players)
        {
            foreach (var player in players)
            {
                if (player.IsLocal)
                {
                    _currentRoomCharacterList[player.ActorNumber] =
                        _characterDataModel.GetCharacterData(_characterDataModel.GetUserEquipCharacterData().ID);
                }
                else
                {
                    _currentRoomCharacterList[player.ActorNumber] =
                        _characterDataModel.GetCharacterData(player.GetCharacterId());
                }
            }

            _joinedRoom.OnNext(players);
        }

        private void OnGUI()
        {
            GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
        }

        public int GetPlayerNumber(int index)
        {
            var count = 0;
            foreach (var player in _currentRoomCharacterList.OrderBy(x => x.Key))
            {
                count++;
                if (player.Key == index)
                {
                    return count switch
                    {
                        1 => (int)PlayerIndex.Player1,
                        2 => (int)PlayerIndex.Player2,
                        3 => (int)PlayerIndex.Player3,
                        4 => (int)PlayerIndex.Player4,
                        _ => -1
                    };
                }
            }

            return -1;
        }

        public CharacterData GetCharacterData(int playerId)
        {
            if (!_currentRoomCharacterList.TryGetValue(playerId, out var value))
            {
                Debug.LogError("キャラクター情報がありません");
                return null;
            }


            return value;
        }

        public void SetPlayerObjDictionary(int playerId, GameObject playerObj)
        {
            _playerObjectDictionary[playerId] = playerObj;
        }

        private void CheckPlayerGenerateComplete(int playerCount)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount > playerCount)
            {
                return;
            }

            _playerGenerateComplete.OnNext(Unit.Default);
        }
    }
}