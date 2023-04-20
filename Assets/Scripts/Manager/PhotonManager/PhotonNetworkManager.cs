using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;
using ExitGames.Client.Photon;
using Manager.DataManager;
using Photon.Pun;
using Photon.Realtime;
using UniRx;
using UnityEngine;
using Zenject;

namespace Manager.NetworkManager
{
    public class PhotonNetworkManager : MonoBehaviourPunCallbacks
    {
        [Inject] private CharacterDataManager _characterDataManager;
        [Inject] private UserDataManager _userDataManager;
        [Inject] private CharacterLevelDataManager _characterLevelDataManager;
        private readonly Subject<Photon.Realtime.Player[]> _joinedRoom = new();
        private readonly Subject<int> _leftRoom = new();
        private readonly Dictionary<int, GameObject> _playerObjectDictionary = new();
        private readonly Dictionary<int, CharacterData> _currentRoomCharacterDatum = new();
        private readonly Dictionary<int, CharacterLevelData> _currentRoomCharacterLevelDatum = new();
        private readonly Subject<Unit> _playerGenerateComplete = new();
        private int _playerCount;
        public Dictionary<int, CharacterData> CurrentRoomCharacterDatum => _currentRoomCharacterDatum;
        public Dictionary<int, CharacterLevelData> CurrentRoomCharacterLevelDatum => _currentRoomCharacterLevelDatum;
        public Dictionary<int, GameObject> PlayerObjectDictionary => _playerObjectDictionary;
        public Subject<int> LeftRoom => _leftRoom;
        public IObservable<Photon.Realtime.Player[]> JoinedRoom => _joinedRoom;
        public IObservable<Unit> PlayerGenerateComplete => _playerGenerateComplete;

        private void Awake()
        {
            CurrentRoomCharacterDatum.Clear();
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
            var characterId = _characterDataManager.GetUserEquipCharacterData().Id;
            var characterLevel = _userDataManager.GetCurrentLevelData(characterId).Level;
            PhotonNetwork.LocalPlayer.SetCharacterData(characterId);
            PhotonNetwork.LocalPlayer.SetCharacterLevel(characterLevel);
            PhotonNetwork.LocalPlayer.SetPlayerIndex(index);
        }

        public override void OnLeftRoom()
        {
            _currentRoomCharacterDatum.Clear();
            _currentRoomCharacterLevelDatum.Clear();
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
                /*if (player.IsLocal)
                {
                    _currentRoomCharacterList[player.ActorNumber] =
                        _characterDataManager.GetCharacterData(_characterDataManager.GetUserEquipCharacterData().ID);
                }
                else
                {
                    _currentRoomCharacterList[player.ActorNumber] =
                        _characterDataManager.GetCharacterData(player.GetCharacterId());
                }*/
                _currentRoomCharacterDatum[player.ActorNumber] =
                    _characterDataManager.GetCharacterData(player.GetCharacterId());
                _currentRoomCharacterLevelDatum[player.ActorNumber] =
                    _characterLevelDataManager.GetCharacterLevelData(player.GetCharacterLevel());
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
            foreach (var player in _currentRoomCharacterDatum.OrderBy(x => x.Key))
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
            if (!_currentRoomCharacterDatum.TryGetValue(playerId, out var value))
            {
                Debug.LogError("キャラクター情報がありません");
                return null;
            }


            return value;
        }

        public CharacterLevelData GetCharacterLevelData(int playerId)
        {
            if (!_currentRoomCharacterLevelDatum.ContainsKey(playerId))
            {
                Debug.LogError("キャラクター情報がありません");
                return null;
            }


            return _currentRoomCharacterLevelDatum[playerId];
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

            _playerCount = 0;
            _playerGenerateComplete.OnNext(Unit.Default);
        }
    }
}