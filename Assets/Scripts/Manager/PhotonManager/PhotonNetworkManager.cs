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
        [Inject] private CharacterMasterDataRepository characterMasterDataRepository;
        [Inject] private UserDataRepository userDataRepository;
        [Inject] private LevelMasterDataRepository levelMasterDataRepository;
        private readonly Subject<Photon.Realtime.Player[]> joinedRoomSubject = new();
        private readonly Subject<int> leftRoomSubject = new();
        private readonly Subject<Unit> playerGenerateCompleteSubject = new();
        private readonly Dictionary<int, UserData> currentRoomUserDatum = new();
        private readonly Dictionary<int, LevelMasterData> currentRoomCharacterLevelDatum = new();
        private int playerCount;

        public Dictionary<int, UserData> CurrentRoomUserDatum => currentRoomUserDatum;

        public Dictionary<int, LevelMasterData> CurrentRoomCharacterLevelDatum => currentRoomCharacterLevelDatum;
        public Subject<int> LeftRoomSubject => leftRoomSubject;
        public IObservable<Photon.Realtime.Player[]> JoinedRoomSubject => joinedRoomSubject;
        public IObservable<Unit> PlayerGenerateCompleteSubject => playerGenerateCompleteSubject;

        private void Awake()
        {
            CurrentRoomUserDatum.Clear();
            PhotonNetwork.UseRpcMonoBehaviourCache = true;
            PhotonNetwork.AutomaticallySyncScene = true;
            playerCount = 0;
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
            var characterId = characterMasterDataRepository.GetUserEquippedCharacterData().Id;
            var characterLevel = userDataRepository.GetCurrentLevelData(characterId).Level;
            PhotonNetwork.LocalPlayer.SetCharacterData(characterId);
            PhotonNetwork.LocalPlayer.SetCharacterLevel(characterLevel);
            PhotonNetwork.LocalPlayer.SetPlayerIndex(index);
        }

        public override void OnLeftRoom()
        {
            currentRoomUserDatum.Clear();
            currentRoomCharacterLevelDatum.Clear();
            PhotonNetwork.Disconnect();
        }

        public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
        {
            leftRoomSubject.OnNext(otherPlayer.GetPlayerIndex());
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
                    playerCount++;
                    CheckPlayerGenerateComplete(playerCount);
                }
            }
        }

        private void SetupPlayerInfo(Photon.Realtime.Player[] players)
        {
            foreach (var player in players)
            {
                currentRoomUserDatum[player.ActorNumber] = userDataRepository.GetUserData();
                currentRoomCharacterLevelDatum[player.ActorNumber] =
                    levelMasterDataRepository.GetLevelMasterData(player.GetCharacterLevel());
            }

            joinedRoomSubject.OnNext(players);
        }

        //todo debug機能後で消す
        private void OnGUI()
        {
            GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
        }

        public int GetPlayerNumber(int index)
        {
            var count = 0;
            foreach (var player in currentRoomUserDatum.OrderBy(x => x.Key))
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

        public UserData GetUserData(int playerId)
        {
            if (!currentRoomUserDatum.TryGetValue(playerId, out var value))
            {
                Debug.LogError("キャラクター情報がありません");
                return null;
            }


            return value;
        }

        public LevelMasterData GetCharacterLevelData(int playerId)
        {
            if (!currentRoomCharacterLevelDatum.ContainsKey(playerId))
            {
                Debug.LogError("キャラクター情報がありません");
                return null;
            }


            return currentRoomCharacterLevelDatum[playerId];
        }

        private void CheckPlayerGenerateComplete(int count)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount > count)
            {
                return;
            }

            playerCount = 0;
            playerGenerateCompleteSubject.OnNext(Unit.Default);
        }

        private void OnDestroy()
        {
            joinedRoomSubject.Dispose();
            leftRoomSubject.Dispose();
        }
    }
}