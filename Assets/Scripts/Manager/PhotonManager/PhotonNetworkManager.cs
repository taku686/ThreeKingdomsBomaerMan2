using System;
using System.Collections.Generic;
using Common.Data;
using ExitGames.Client.Photon;
using Manager.DataManager;
using Photon.Pun;
using Photon.Realtime;
using Repository;
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
        [Inject] private WeaponMasterDataRepository weaponMasterDataRepository;
        [Inject] private SkillMasterDataRepository skillMasterDataRepository;
        private readonly Subject<Photon.Realtime.Player[]> joinedRoomSubject = new();
        private readonly Subject<int> leftRoomSubject = new();
        private readonly Subject<Unit> playerGenerateCompleteSubject = new();
        private readonly Subject<(int, SkillMasterData)> activateSkillSubject = new();
        private readonly Dictionary<int, CharacterData> currentRoomCharacterDatum = new();
        private readonly Dictionary<int, WeaponMasterData> currentRoomWeaponDatum = new();
        private readonly Dictionary<int, LevelMasterData> currentRoomLevelDatum = new();
        private int playerCount;

        public Subject<int> LeftRoomSubject => leftRoomSubject;
        public IObservable<Photon.Realtime.Player[]> JoinedRoomSubject => joinedRoomSubject;
        public IObservable<Unit> PlayerGenerateCompleteSubject => playerGenerateCompleteSubject;
        public IObservable<(int, SkillMasterData)> ActivateSkillSubject => activateSkillSubject;

        private void Awake()
        {
            currentRoomCharacterDatum.Clear();
            currentRoomLevelDatum.Clear();
            currentRoomWeaponDatum.Clear();
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
            PhotonNetwork.CreateRoom(null, new RoomOptions
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
            var weaponId = userDataRepository.GetEquippedWeaponData(characterId).Id;
            PhotonNetwork.LocalPlayer.SetCharacterData(characterId);
            PhotonNetwork.LocalPlayer.SetCharacterLevel(characterLevel);
            PhotonNetwork.LocalPlayer.SetWeaponData(weaponId);
            PhotonNetwork.LocalPlayer.SetPlayerIndex(index); //indexを参照にデータを取得するため最後に値を入れないといけない
        }

        public override void OnLeftRoom()
        {
            currentRoomCharacterDatum.Clear();
            currentRoomLevelDatum.Clear();
            currentRoomWeaponDatum.Clear();
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

                if ((string)prop.Key == PlayerPropertiesExtensions.SkillDataKey)
                {
                    var skillId = targetPlayer.GetSkillId();
                    var skillData = skillMasterDataRepository.GetSkillData(skillId);
                    activateSkillSubject.OnNext((targetPlayer.ActorNumber, skillData));
                }
            }
        }

        private void SetupPlayerInfo(Photon.Realtime.Player[] players)
        {
            foreach (var player in players)
            {
                currentRoomCharacterDatum[player.ActorNumber] =
                    characterMasterDataRepository.GetCharacterData(player.GetCharacterId());
                currentRoomLevelDatum[player.ActorNumber] =
                    levelMasterDataRepository.GetLevelMasterData(player.GetCharacterLevel());
                currentRoomWeaponDatum[player.ActorNumber] =
                    weaponMasterDataRepository.GetWeaponData(player.GetWeaponId());
            }

            joinedRoomSubject.OnNext(players);
        }

        public CharacterData GetCharacterData(int playerId)
        {
            if (!currentRoomCharacterDatum.TryGetValue(playerId, out var value))
            {
                Debug.LogError("キャラクター情報がありません");
                return null;
            }

            return value;
        }

        public WeaponMasterData GetWeaponData(int playerId)
        {
            if (!currentRoomWeaponDatum.TryGetValue(playerId, out var value))
            {
                Debug.LogError("キャラクター情報がありません");
                return null;
            }

            return value;
        }

        public LevelMasterData GetLevelMasterData(int playerId)
        {
            if (!currentRoomLevelDatum.TryGetValue(playerId, out var data))
            {
                Debug.LogError("キャラクター情報がありません");
                return null;
            }

            return data;
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