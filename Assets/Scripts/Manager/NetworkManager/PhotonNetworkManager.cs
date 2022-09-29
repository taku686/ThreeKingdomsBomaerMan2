using System;
using System.Collections.Generic;
using Common.Data;
using Cysharp.Threading.Tasks;
using ExitGames.Client.Photon;
using Manager.BattleManager;
using Photon.Pun;
using Photon.Realtime;
using UI.Title;
using UniRx;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Manager.NetworkManager
{
    public class PhotonNetworkManager : MonoBehaviourPunCallbacks
    {
        [Inject] private TitleModel _titleModel;

        // [Inject] private PlayerManager _playerManager;
        private readonly Subject<int> _joinedRoom = new Subject<int>();
        private readonly Subject<int> _leftRoom = new Subject<int>();
        private Tuple<int, CharacterData> _currentPlayerData;
        private readonly Dictionary<int, CharacterData> _currentCharacterList = new Dictionary<int, CharacterData>();
        private bool _isJoining;
        public Dictionary<int, CharacterData> CurrentCharacterList => _currentCharacterList;

        public Tuple<int, CharacterData> CurrentPlayerData => _currentPlayerData;

        public Subject<int> LeftRoom => _leftRoom;

        public IObservable<int> JoinedRoom => _joinedRoom;

        private void Awake()
        {
            CurrentCharacterList.Clear();
            _currentPlayerData = new Tuple<int, CharacterData>(0, null);
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
            PhotonNetwork.JoinOrCreateRoom("ROOM", new RoomOptions(), TypedLobby.Default);
        }

        public override void OnJoinedRoom()
        {
            _isJoining = true;
            PhotonNetwork.LocalPlayer.SetCharacterData(_titleModel.GetUserEquipCharacterData().ID);
            PhotonNetwork.LocalPlayer.SetPlayerIndex(PhotonNetwork.CurrentRoom.PlayerCount);
        }

        public override void OnLeftRoom()
        {
            _leftRoom.OnNext(_currentPlayerData.Item1);
            _currentCharacterList.Clear();
            _currentPlayerData = new Tuple<int, CharacterData>(0, null);
            PhotonNetwork.Disconnect();
        }

        public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
        {
            /*_isJoining = true;
            newPlayer.SetCharacterData(_titleModel.GetUserEquipCharacterData().ID);*/
        }

        public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, Hashtable changedProps)
        {
            OnChangeCharacterProperty(targetPlayer, changedProps);
        }

        private void OnChangeCharacterProperty(Photon.Realtime.Player targetPlayer, Hashtable changedProps)
        {
           
            /*if (_isJoining)
            {
                int playerIndex = 0;
                if (!_currentCharacterList.ContainsKey(GetPlayerIndex(PhotonNetwork.CurrentRoom.PlayerCount)))
                {
                    _currentCharacterList.Add(GetPlayerIndex(PhotonNetwork.CurrentRoom.PlayerCount),
                        _titleModel.GetCharacterData(targetPlayer.GetCharacterId()));
                    if (targetPlayer.IsLocal)
                    {
                        int index = GetPlayerIndex(PhotonNetwork.CurrentRoom.PlayerCount);
                        var characterData = _titleModel.GetCharacterData(targetPlayer.GetCharacterId());
                        _currentPlayerData = new Tuple<int, CharacterData>(index, characterData);
                        playerIndex = GetPlayerIndex(PhotonNetwork.CurrentRoom.PlayerCount);
                    }
                }
                else
                {
                    bool isSet = false;
                    for (int i = 1; i < 5; i++)
                    {
                        if (!isSet && !_currentCharacterList.ContainsKey(GetPlayerIndex(i)))
                        {
                            _currentCharacterList.Add(GetPlayerIndex(i),
                                _titleModel.GetCharacterData(targetPlayer.GetCharacterId()));

                            if (targetPlayer.IsLocal)
                            {
                                int index = GetPlayerIndex(i);
                                var characterData = _titleModel.GetCharacterData(targetPlayer.GetCharacterId());
                                _currentPlayerData = new Tuple<int, CharacterData>(index, characterData);
                            }

                            playerIndex = GetPlayerIndex(i);
                            isSet = true;
                        }
                    }
                }

                _joinedRoom.OnNext(playerIndex);
                _isJoining = false;
            }
            */
        }

        private void OnGUI()
        {
            GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
        }

        private int GetPlayerIndex(int index)
        {
            return index switch
            {
                1 => (int)PlayerIndex.Player1,
                2 => (int)PlayerIndex.Player2,
                3 => (int)PlayerIndex.Player3,
                4 => (int)PlayerIndex.Player4,
                _ => -1
            };
        }
    }
}