using System;
using System.Collections;
using System.Collections.Generic;
using Common.Data;
using Manager.DataManager;
using Photon.Pun;
using Photon.Realtime;
using Player.Common;
using Repository;
using Skill;
using UniRx;
using UnityEngine;
using Zenject;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace Manager.NetworkManager
{
    public class PhotonNetworkManager : MonoBehaviourPunCallbacks
    {
        [Inject] private CharacterMasterDataRepository _characterMasterDataRepository;
        [Inject] private UserDataRepository _userDataRepository;
        [Inject] private LevelMasterDataRepository _levelMasterDataRepository;
        [Inject] private WeaponMasterDataRepository _weaponMasterDataRepository;
        [Inject] private SkillMasterDataRepository _skillMasterDataRepository;
        [Inject] private OnDamageFacade _onDamageFacade;
        private Subject<Photon.Realtime.Player[]> _joinedRoomSubject = new();
        private Subject<Unit> _playerGenerateCompleteSubject = new();
        private readonly Subject<(int, SkillMasterData)> _activateSkillSubject = new();
        private readonly Dictionary<int, CharacterData> _currentRoomCharacterDatum = new();
        private readonly Dictionary<int, WeaponMasterData> _currentRoomWeaponDatum = new();
        private readonly Dictionary<int, LevelMasterData> _currentRoomLevelDatum = new();
        private int _playerCount;
        public bool _isTitle;

        private const int MinPlayerCount = 1;
        public Subject<int> _LeftRoomSubject { get; private set; } = new();
        public IObservable<Photon.Realtime.Player[]> _JoinedRoomSubject => _joinedRoomSubject;
        public IObservable<Unit> _PlayerGenerateCompleteObservable => _playerGenerateCompleteSubject;
        public IObservable<(int, SkillMasterData)> _ActivateSkillObservable => _activateSkillSubject;


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

        public void SetTeamMembersInfo(int playerIndex)
        {
            var characterIds = _userDataRepository.GetTeamMembers();
            var characterDic = new Dictionary<int, int>();
            var weaponDic = new Dictionary<int, int>();
            var levelDic = new Dictionary<int, int>();

            foreach (var (teamNumber, characterId) in characterIds)
            {
                if (characterId == GameCommonData.InvalidNumber)
                {
                    continue; // キャラクターが選択されていない場合はスキップ
                }

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

            _LeftRoomSubject.OnNext(otherPlayer.GetPlayerIndex());
        }

        public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, Hashtable changedProps)
        {
            foreach (var prop in changedProps)
            {
                CheckPlayerGenerateComplete(prop);
                SetupPlayerInfo(prop);
                HitAttack(targetPlayer, prop);
                ActivateSkill(targetPlayer, prop);
            }
        }


        private void HitAttack(Photon.Realtime.Player targetPlayer, DictionaryEntry prop)
        {
            if ((string)prop.Key != PlayerPropertiesExtensions.HitAttackDataKey)
            {
                return;
            }

            var dic = targetPlayer.GetHitAttack();
            if (dic == null)
            {
                return;
            }

            var players = GameObject.FindGameObjectsWithTag(GameCommonData.PlayerTag);

            foreach (var player in players)
            {
                var playerConditionInfo = player.GetComponent<PlayerConditionInfo>();
                if (playerConditionInfo == null)
                {
                    continue;
                }

                foreach (var keyValue in dic)
                {
                    if (playerConditionInfo.GetPlayerIndex() != keyValue.Key) continue;
                    var skillData = _skillMasterDataRepository.GetSkillData(keyValue.Value);
                    _onDamageFacade.OnNextAbnormalConditionSubject(playerConditionInfo, skillData);
                }
            }
        }

        private void ActivateSkill(Photon.Realtime.Player targetPlayer, DictionaryEntry prop)
        {
            if ((string)prop.Key != PlayerPropertiesExtensions.SkillDataKey)
            {
                return;
            }

            var dic = targetPlayer.GetSkillId();
            if (dic == null)
            {
                return;
            }

            var players = GameObject.FindGameObjectsWithTag(GameCommonData.PlayerTag);

            foreach (var player in players)
            {
                var playerConditionInfo = player.GetComponent<PlayerConditionInfo>();
                if (playerConditionInfo == null)
                {
                    continue;
                }

                foreach (var keyValue in dic)
                {
                    if (playerConditionInfo.GetPlayerIndex() != keyValue.Key) continue;
                    var skillData = _skillMasterDataRepository.GetSkillData(keyValue.Value);
                    _activateSkillSubject.OnNext((playerConditionInfo.GetPlayerIndex(), skillData));
                }
            }
        }

        private void SetupPlayerInfo(DictionaryEntry prop)
        {
            if ((string)prop.Key != PlayerPropertiesExtensions.PlayerIndexKey)
            {
                return;
            }

            var players = PhotonNetwork.PlayerList;
            foreach (var player in players)
            {
                var characterDic = player.GetCharacterId();
                var weaponDic = player.GetWeaponId();
                var levelDic = player.GetCharacterLevel();

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
            }

            _joinedRoomSubject.OnNext(players);
        }

        #region GetData

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

        #endregion

        public bool CanChangeCharacter()
        {
            var teamMembers = _userDataRepository.GetTeamMembers();
            var teamMemberCount = 0;
            foreach (var (_, characterId) in teamMembers)
            {
                if (characterId != GameCommonData.InvalidNumber)
                {
                    teamMemberCount++;
                }
            }

            return teamMemberCount != MinPlayerCount;
        }

        private void CheckPlayerGenerateComplete(DictionaryEntry prop)
        {
            if ((string)prop.Key != PlayerPropertiesExtensions.PlayerGenerateKey)
            {
                return;
            }

            _playerCount++;
            if (PhotonNetwork.CurrentRoom.PlayerCount > _playerCount)
            {
                return;
            }

            _playerCount = 0;
            _playerGenerateCompleteSubject.OnNext(Unit.Default);
        }

        public void DisposedRoomSubject()
        {
            _joinedRoomSubject.Dispose();
            _LeftRoomSubject.Dispose();
        }

        public void CreateRoomSubject()
        {
            _joinedRoomSubject = new Subject<Photon.Realtime.Player[]>();
            _LeftRoomSubject = new Subject<int>();
        }

        public static bool IsCpu(int creatorNr)
        {
            return creatorNr == 0;
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
            _LeftRoomSubject.Dispose();
        }
    }
}