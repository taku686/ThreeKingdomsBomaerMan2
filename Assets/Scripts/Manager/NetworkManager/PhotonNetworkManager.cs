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
        private readonly Subject<Photon.Realtime.Player[]> _joinedRoom = new Subject<Photon.Realtime.Player[]>();
        private readonly Subject<int> _leftRoom = new Subject<int>();

        private readonly Dictionary<int, CharacterData>
            _currentRoomCharacterList = new Dictionary<int, CharacterData>();

        private bool _isJoining;
        public Dictionary<int, CharacterData> CurrentRoomCharacterList => _currentRoomCharacterList;


        public Subject<int> LeftRoom => _leftRoom;

        public IObservable<Photon.Realtime.Player[]> JoinedRoom => _joinedRoom;

        private void Awake()
        {
            CurrentRoomCharacterList.Clear();
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
            Debug.Log("部屋生成");
            PhotonNetwork.CreateRoom(null, new RoomOptions()
            {
            }, TypedLobby.Default);
        }

        public override void OnJoinedRoom()
        {
            var index = PhotonNetwork.LocalPlayer.ActorNumber;
            PhotonNetwork.LocalPlayer.SetCharacterData(_titleModel.GetUserEquipCharacterData().ID);
            PhotonNetwork.LocalPlayer.SetPlayerIndex(index);
         
        }

        public override void OnLeftRoom()
        {
            _currentRoomCharacterList.Clear();
            PhotonNetwork.Disconnect();
        }

        public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
        {
          //  SetupPlayerInfo(PhotonNetwork.PlayerList);
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
            }
        }

        private void SetupPlayerInfo(Photon.Realtime.Player[] players)
        {
            foreach (var player in players)
            {
                if (player.IsLocal)
                {
                    _currentRoomCharacterList[player.ActorNumber] =
                        _titleModel.GetCharacterData(_titleModel.GetUserEquipCharacterData().ID);
                }
                else
                {
                    _currentRoomCharacterList[player.ActorNumber] =
                        _titleModel.GetCharacterData(player.GetCharacterId());
                }
            }

            _joinedRoom.OnNext(players);
        }

        private void OnGUI()
        {
            GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
        }

        private int GetPlayerNumber(int index)
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