using System;
using System.Collections.Generic;
using Common.Data;
using ExitGames.Client.Photon;
using Manager.DataManager;
using Photon.Pun;
using Photon.Realtime;
using Repository;
using UniRx;
using Unity.Entities;
using UnityEngine;
using Zenject;

namespace Manager.NetworkManager
{
    public class PhotonNetworkManager : MonoBehaviourPunCallbacks
    {
        [Inject] private CharacterMasterDataRepository _characterMasterDataRepository;
        [Inject] private UserDataRepository _userDataRepository;
        [Inject] private LevelMasterDataRepository _levelMasterDataRepository;
        [Inject] private WeaponMasterDataRepository _weaponMasterDataRepository;
        [Inject] private SkillMasterDataRepository _skillMasterDataRepository;
        private Subject<Photon.Realtime.Player[]> _joinedRoomSubject = new();
        private Subject<int> _leftRoomSubject = new();
        private readonly Subject<Unit> _playerGenerateCompleteSubject = new();
        private readonly Subject<(int, SkillMasterData)> _activateSkillSubject = new();
        private readonly Dictionary<int, CharacterData> _currentRoomCharacterDatum = new();
        private readonly Dictionary<int, WeaponMasterData> _currentRoomWeaponDatum = new();
        private readonly Dictionary<int, LevelMasterData> _currentRoomLevelDatum = new();
        private int _playerCount;
        public bool _isTitle;

        public Subject<int> _LeftRoomSubject => _leftRoomSubject;
        public IObservable<Photon.Realtime.Player[]> _JoinedRoomSubject => _joinedRoomSubject;
        public IObservable<Unit> _PlayerGenerateCompleteSubject => _playerGenerateCompleteSubject;
        public IObservable<(int, SkillMasterData)> _ActivateSkillSubject => _activateSkillSubject;

        private void Awake()
        {
            _currentRoomCharacterDatum.Clear();
            _currentRoomLevelDatum.Clear();
            _currentRoomWeaponDatum.Clear();
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
            var characterId = _characterMasterDataRepository.GetUserEquippedCharacterData().Id;
            var characterLevel = _userDataRepository.GetCurrentLevelData(characterId).Level;
            var weaponId = _userDataRepository.GetEquippedWeaponData(characterId).Id;
            PhotonNetwork.LocalPlayer.SetCharacterData(characterId);
            PhotonNetwork.LocalPlayer.SetCharacterLevel(characterLevel);
            PhotonNetwork.LocalPlayer.SetWeaponData(weaponId);
            PhotonNetwork.LocalPlayer.SetPlayerIndex(index); //indexを参照にデータを取得するため最後に値を入れないといけない
        }

        public override void OnLeftRoom()
        {
            _currentRoomCharacterDatum.Clear();
            _currentRoomLevelDatum.Clear();
            _currentRoomWeaponDatum.Clear();
            PhotonNetwork.Disconnect();
        }

        public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
        {
            if (!_isTitle)
            {
                return;
            }

            _leftRoomSubject.OnNext(otherPlayer.GetPlayerIndex());
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

                if ((string)prop.Key == PlayerPropertiesExtensions.SkillDataKey)
                {
                    var skillId = targetPlayer.GetSkillId();
                    var skillData = _skillMasterDataRepository.GetSkillData(skillId);
                    _activateSkillSubject.OnNext((targetPlayer.ActorNumber, skillData));
                }
            }
        }

        private void SetupPlayerInfo(Photon.Realtime.Player[] players)
        {
            foreach (var player in players)
            {
                _currentRoomCharacterDatum[player.ActorNumber] = _characterMasterDataRepository.GetCharacterData(player.GetCharacterId());
                _currentRoomLevelDatum[player.ActorNumber] = _levelMasterDataRepository.GetLevelMasterData(player.GetCharacterLevel());
                _currentRoomWeaponDatum[player.ActorNumber] = _weaponMasterDataRepository.GetWeaponData(player.GetWeaponId());
            }

            _joinedRoomSubject.OnNext(players);
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

        public WeaponMasterData GetWeaponData(int playerId)
        {
            if (!_currentRoomWeaponDatum.TryGetValue(playerId, out var value))
            {
                Debug.LogError("キャラクター情報がありません");
                return null;
            }

            return value;
        }

        public LevelMasterData GetLevelMasterData(int playerId)
        {
            if (!_currentRoomLevelDatum.TryGetValue(playerId, out var data))
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

            _playerCount = 0;
            _playerGenerateCompleteSubject.OnNext(Unit.Default);
        }

        public void DisposedSubject()
        {
            _joinedRoomSubject.Dispose();
            _leftRoomSubject.Dispose();
        }

        public void CreateSubject()
        {
            _joinedRoomSubject = new Subject<Photon.Realtime.Player[]>();
            _leftRoomSubject = new Subject<int>();
        }

        private void OnDestroy()
        {
            _joinedRoomSubject.Dispose();
            _leftRoomSubject.Dispose();
        }
    }
}