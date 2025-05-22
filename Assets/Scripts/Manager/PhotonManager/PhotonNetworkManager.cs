using System;
using System.Collections.Generic;
using Common.Data;
using ExitGames.Client.Photon;
using Manager.DataManager;
using Photon.Pun;
using Photon.Realtime;
using Repository;
using Skill;
using UniRx;
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
        [Inject] private SkillActivationConditionsUseCase _skillActivationConditionsUseCase;
        private Subject<Photon.Realtime.Player[]> _joinedRoomSubject = new();
        private Subject<int> _leftRoomSubject = new();
        private Subject<Unit> _playerGenerateCompleteSubject = new();
        private readonly Subject<(int, SkillMasterData)> _activateSkillSubject = new();
        private readonly Dictionary<int, CharacterData> _currentRoomCharacterDatum = new();
        private readonly Dictionary<int, WeaponMasterData> _currentRoomWeaponDatum = new();
        private readonly Dictionary<int, LevelMasterData> _currentRoomLevelDatum = new();
        private readonly Dictionary<int, int> _playerCoreInfos = new();
        private readonly Dictionary<int, int> _weaponViewInfos = new();
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
                EmptyRoomTtl = 0,
                PublishUserId = true,
                CleanupCacheOnLeave = true,
            }, TypedLobby.Default);
        }

        public override void OnJoinedRoom()
        {
            var actorNumber = PhotonNetwork.LocalPlayer.ActorNumber;
            SetTeamMembersInfo(actorNumber);
        }

        public void SetTeamMembersInfo(int playerIndex, int playerObjInstantiationId = 0, int weaponInstantiationId = 0)
        {
            var characterIds = _userDataRepository.GetTeamMembers();
            var characterDic = new Dictionary<int, int>();
            var weaponDic = new Dictionary<int, int>();
            var levelDic = new Dictionary<int, int>();
            var playerCoreInfo = new KeyValuePair<int, int>(playerIndex, playerObjInstantiationId);
            var weaponViewInfo = new KeyValuePair<int, int>(playerIndex, weaponInstantiationId);
            foreach (var (teamNumber, characterId) in characterIds)
            {
                var playerKey = GetPlayerKey(playerIndex, teamNumber);
                var characterLevel = _userDataRepository.GetCurrentLevelData(characterId).Level;
                var weaponId = _userDataRepository.GetEquippedWeaponData(characterId).Id;
                characterDic[playerKey] = characterId;
                weaponDic[playerKey] = weaponId;
                levelDic[playerKey] = characterLevel;
            }

            PhotonNetwork.LocalPlayer.SetCharacterId(characterDic);
            PhotonNetwork.LocalPlayer.SetCharacterLevel(levelDic);
            PhotonNetwork.LocalPlayer.SetWeaponId(weaponDic);
            PhotonNetwork.LocalPlayer.SetPlayerCoreInfo(playerCoreInfo);
            PhotonNetwork.LocalPlayer.SetWeaponViewInfo(weaponViewInfo);
            PhotonNetwork.LocalPlayer.SetPlayerIndex(playerIndex); //indexを参照にデータを取得するため最後に値を入れないといけない
        }

        public static int GetPlayerKey(int instantiationId, int teamNumber)
        {
            return instantiationId * 10 + teamNumber;
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
                    var dic = targetPlayer.GetSkillId();
                    if (dic == null)
                    {
                        return;
                    }

                    var players = GameObject.FindGameObjectsWithTag(GameCommonData.PlayerTag);

                    foreach (var player in players)
                    {
                        var playerStatusInfo = player.GetComponent<PlayerStatusInfo>();
                        if (playerStatusInfo == null)
                        {
                            continue;
                        }

                        foreach (var keyValue in dic)
                        {
                            if (playerStatusInfo.GetPlayerIndex() != keyValue.Key) continue;
                            var skillData = _skillMasterDataRepository.GetSkillData(keyValue.Value);
                            _activateSkillSubject.OnNext((playerStatusInfo.GetPlayerIndex(), skillData));
                            _skillActivationConditionsUseCase.OnNextAbnormalConditionSubject(playerStatusInfo, skillData).Forget();
                        }
                    }
                }
            }
        }

        private void SetupPlayerInfo(Photon.Realtime.Player[] players)
        {
            foreach (var player in players)
            {
                var characterDic = player.GetCharacterId();
                var weaponDic = player.GetWeaponId();
                var levelDic = player.GetCharacterLevel();
                var playerCoreInfo = player.GetPlayerCoreInfo();
                var weaponViewInfo = player.GetWeaponViewInfo();
                foreach (var character in characterDic)
                {
                    _currentRoomCharacterDatum[character.Key] = _characterMasterDataRepository.GetCharacterData(character.Value);
                }

                foreach (var weapon in weaponDic)
                {
                    _currentRoomWeaponDatum[weapon.Key] = _weaponMasterDataRepository.GetWeaponData(weapon.Value);
                }

                foreach (var level in levelDic)
                {
                    _currentRoomLevelDatum[level.Key] = _levelMasterDataRepository.GetLevelMasterData(level.Value);
                }

                _playerCoreInfos[playerCoreInfo.Key] = playerCoreInfo.Value;
                _weaponViewInfos[weaponViewInfo.Key] = weaponViewInfo.Value;
            }

            _joinedRoomSubject.OnNext(players);
        }

        public CharacterData GetCharacterData(int playerId)
        {
            return _currentRoomCharacterDatum.GetValueOrDefault(playerId);
        }

        public WeaponMasterData GetWeaponData(int playerId)
        {
            return _currentRoomWeaponDatum.GetValueOrDefault(playerId);
        }

        public LevelMasterData GetLevelMasterData(int playerId)
        {
            return _currentRoomLevelDatum.GetValueOrDefault(playerId);
        }

        public int GetPlayerCoreInfo(int playerCoreInstantiationId)
        {
            return _playerCoreInfos.GetValueOrDefault(playerCoreInstantiationId);
        }

        public int GetWeaponViewInfo(int playerCoreInstantiationId)
        {
            return _weaponViewInfos.GetValueOrDefault(playerCoreInstantiationId);
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

        public void DisposedRoomSubject()
        {
            _joinedRoomSubject.Dispose();
            _leftRoomSubject.Dispose();
        }

        public void CreateRoomSubject()
        {
            _joinedRoomSubject = new Subject<Photon.Realtime.Player[]>();
            _leftRoomSubject = new Subject<int>();
        }

        public void CreatePlayerGenerateCompleteSubject()
        {
            _playerGenerateCompleteSubject = new Subject<Unit>();
        }

        public void DisposePlayerGenerateCompleteSubject()
        {
            _playerGenerateCompleteSubject.Dispose();
        }

        private void OnDestroy()
        {
            _playerGenerateCompleteSubject.Dispose();
            _currentRoomCharacterDatum.Clear();
            _activateSkillSubject.Dispose();
            _joinedRoomSubject.Dispose();
            _leftRoomSubject.Dispose();
        }
    }
}