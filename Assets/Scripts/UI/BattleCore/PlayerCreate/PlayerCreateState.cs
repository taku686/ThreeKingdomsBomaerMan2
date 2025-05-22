using System.Collections.Generic;
using Bomb;
using Common.Data;
using Cysharp.Threading.Tasks;
using Enemy;
using Manager.BattleManager.Camera;
using Manager.DataManager;
using Manager.NetworkManager;
using Photon.Pun;
using Player.Common;
using Repository;
using Skill;
using UI.Battle;
using Unity.Mathematics;
using UnityEngine;
using UniRx;

namespace Manager.BattleManager
{
    public partial class BattleCore
    {
        public class PlayerCreateState : StateMachine<BattleCore>.State
        {
            private PhotonNetworkManager _PhotonNetworkManager => Owner._photonNetworkManager;
            private PlayerGeneratorUseCase _PlayerGeneratorUseCase => Owner._playerGeneratorUseCase;
            private MapManager _MapManager => Owner.mapManager;
            private CameraManager _CameraManager => Owner.cameraManager;
            private StateMachine<BattleCore> _StateMachineClone => Owner._stateMachine;
            private BombProvider _BombProvider => Owner._bombProvider;
            private AnimatorControllerRepository _AnimatorControllerRepository => Owner.animatorControllerRepository;
            private EffectActivateUseCase _EffectActivateUseCase => Owner.effectActivator;
            private ApplyStatusSkillUseCase _ApplyStatusSkillUseCase => Owner._applyStatusSkillUseCase;
            private List<PlayerStatusUI> _PlayerStatusUiList => Owner._playerStatusUiList;
            private CharacterMasterDataRepository _CharacterMasterDataRepository => Owner._characterMasterDataRepository;
            private WeaponMasterDataRepository _WeaponMasterDataRepository => Owner._weaponMasterDataRepository;
            private CharacterCreateUseCase _CharacterCreateUseCase => Owner._characterCreateUseCase;
            private ActiveSkillManager _ActiveSkillManager => Owner._activeSkillManager;
            private PassiveSkillManager _PassiveSkillManager => Owner._passiveSkillManager;
            private SkillActivationConditionsUseCase _SkillActivationConditionsUseCase => Owner._skillActivationConditionsUseCase;

            private PhotonView _photonView;

            private static readonly Vector3 ColliderCenter = new(0, 0.6f, 0);
            private static readonly Vector3 ColliderSize = new(0.4f, 0.6f, 0.4f);
            private const float MaxRate = 1f;
            private const int PlayerNotification = 1;

            protected override void OnEnter(StateMachine<BattleCore>.State prevState)
            {
                OnInitialize();
            }

            protected override void OnExit(StateMachine<BattleCore>.State nextState)
            {
                _PhotonNetworkManager.DisposePlayerGenerateCompleteSubject();
            }

            private void OnInitialize()
            {
                _PhotonNetworkManager.CreatePlayerGenerateCompleteSubject();
                GenerateCPU();
                GeneratePlayer();
                PlayerGenerateCompleteSubscribe();
                PhotonNetwork.LocalPlayer.SetPlayerGenerate(PlayerNotification);
            }

            private void GeneratePlayer()
            {
                var index = PhotonNetwork.LocalPlayer.ActorNumber;
                var playerKey = PhotonNetworkManager.GetPlayerKey(index, 0);
                var characterData = _PhotonNetworkManager.GetCharacterData(playerKey);
                var weaponData = _PhotonNetworkManager.GetWeaponData(playerKey);
                var playerCore = _PlayerGeneratorUseCase.InstantiatePlayerCore(spawnPointIndex: index, false);
                _photonView = playerCore.GetComponent<PhotonView>();
                var playerObj = SetUpPlayerObj(playerCore, characterData, weaponData, false);
                var weaponObj = SetupWeaponObj(playerObj, weaponData, false);
                var playerObjPhotonView = playerObj.GetComponent<PhotonView>();
                var weaponObjPhotonView = weaponObj.GetComponent<PhotonView>();
                var instantiationId = _photonView.InstantiationId;
                //バトル時にチーム情報をinstantiationIdで管理するため、Keyを変えてセットし直す
                _PhotonNetworkManager.SetTeamMembersInfo(instantiationId, playerObjPhotonView.InstantiationId, weaponObjPhotonView.InstantiationId);
            }

            private void GenerateCPU()
            {
                if (!PhotonNetwork.LocalPlayer.IsMasterClient)
                {
                    return;
                }

                var generateAmount = PhotonNetwork.CurrentRoom.MaxPlayers - PhotonNetwork.CurrentRoom.PlayerCount;
                for (var i = 1; i <= generateAmount; i++)
                {
                    //CPUのチームメンバーを3人してもいいが、現段階では1人に設定する
                    var masterActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                    var cpuActorNr = PhotonNetwork.CurrentRoom.PlayerCount + i;
                    var candidateCharacterId = _CharacterMasterDataRepository.GetRandomCharacterId();
                    var candidateWeaponId = _WeaponMasterDataRepository.GetWeaponRandomWeaponId();
                    var cpuCharacterData = _CharacterMasterDataRepository.GetCharacterData(candidateCharacterId);
                    var cpuWeaponData = _WeaponMasterDataRepository.GetWeaponData(candidateWeaponId);
                    var cpuCore = _PlayerGeneratorUseCase.InstantiatePlayerCore(cpuActorNr, true);
                    var cpuCorePhotonView = cpuCore.GetComponent<PhotonView>();
                    var cpuObj = SetUpPlayerObj(cpuCore, cpuCharacterData, cpuWeaponData, true);
                    var weaponObj = SetupWeaponObj(cpuObj, cpuWeaponData, true);
                    var cpuObjPhotonView = cpuObj.GetComponent<PhotonView>();
                    var weaponObjPhotonView = weaponObj.GetComponent<PhotonView>();
                    var instantiationId = cpuCorePhotonView.InstantiationId;
                    var weaponInstantiationId = weaponObjPhotonView.InstantiationId;
                    var playerKey = PhotonNetworkManager.GetPlayerKey(instantiationId, 0);
                    var characterDic = new Dictionary<int, int> { { playerKey, candidateCharacterId } };
                    var weaponDic = new Dictionary<int, int> { { playerKey, candidateWeaponId } };
                    var levelDic = new Dictionary<int, int> { { playerKey, GameCommonData.MaxCharacterLevel } };
                    var cpuCoreInfo = new KeyValuePair<int, int>(instantiationId, cpuObjPhotonView.InstantiationId);
                    var weaponCoreInfo = new KeyValuePair<int, int>(instantiationId, weaponInstantiationId);
                    PhotonNetwork.LocalPlayer.SetCharacterId(characterDic);
                    PhotonNetwork.LocalPlayer.SetWeaponId(weaponDic);
                    PhotonNetwork.LocalPlayer.SetCharacterLevel(levelDic);
                    PhotonNetwork.LocalPlayer.SetPlayerCoreInfo(cpuCoreInfo);
                    PhotonNetwork.LocalPlayer.SetWeaponViewInfo(weaponCoreInfo);
                    PhotonNetwork.LocalPlayer.SetPlayerIndex(masterActorNr);
                }
            }

            private void PlayerGenerateCompleteSubscribe()
            {
                _PhotonNetworkManager._PlayerGenerateCompleteSubject.Subscribe(_ =>
                {
                    var players = GameObject.FindGameObjectsWithTag(GameCommonData.PlayerTag);
                    foreach (var player in players)
                    {
                        InitializePlayerComponent(player);
                    }

                    _StateMachineClone.Dispatch((int)State.BattleStart);
                }).AddTo(Owner.GetCancellationTokenOnDestroy());
            }

            private void SetUpPlayerCore(GameObject playerCore)
            {
                _PlayerGeneratorUseCase.SetupPlayerCore(playerCore);
                playerCore.layer = LayerMask.NameToLayer(GameCommonData.PlayerLayer);
            }

            private GameObject SetUpPlayerObj(GameObject playerCore, CharacterData characterData, WeaponMasterData weaponData, bool isCpu)
            {
                var playerObj = _PlayerGeneratorUseCase.InstantiatePlayerObj(characterData, playerCore.transform, isCpu);
                return playerObj;
            }

            private GameObject SetupWeaponObj(GameObject playerObj, WeaponMasterData weaponData, bool isCpu)
            {
                var weaponObj = _CharacterCreateUseCase.InstantiateWeapon(playerObj, weaponData, true, isCpu);
                return weaponObj;
            }

            private void FixedPlayerObjTransform(PhotonView photonView, GameObject playerCore)
            {
                SetUpPlayerCore(playerCore);
                var playerObjInstantiationId = _PhotonNetworkManager.GetPlayerCoreInfo(photonView.InstantiationId);
                var players = GameObject.FindGameObjectsWithTag(GameCommonData.PlayerTag);
                foreach (var player in players)
                {
                    var photonViewPlayer = player.GetComponent<PhotonView>();
                    if (photonViewPlayer == null)
                    {
                        continue;
                    }

                    if (photonViewPlayer.InstantiationId != playerObjInstantiationId)
                    {
                        continue;
                    }

                    player.transform.SetParent(playerCore.transform);
                    player.transform.localPosition = Vector3.zero;
                    player.transform.localRotation = quaternion.identity;
                }
            }

            private void FixedWeaponObjTransform(PhotonView photonView, GameObject playerCore, WeaponMasterData weaponData)
            {
                var weaponInstantiateId = _PhotonNetworkManager.GetWeaponViewInfo(photonView.InstantiationId);
                var weapons = GameObject.FindGameObjectsWithTag(GameCommonData.WeaponTag);
                foreach (var weapon in weapons)
                {
                    var photonViewWeapon = weapon.GetComponent<PhotonView>();
                    if (photonViewWeapon == null)
                    {
                        continue;
                    }

                    if (photonViewWeapon.InstantiationId != weaponInstantiateId)
                    {
                        continue;
                    }

                    _CharacterCreateUseCase.FixedWeaponTransform(playerCore, weapon, weaponData);
                }
            }

            private void CommonInitializationProcess
            (
                GameObject playerCore,
                out string hpKey,
                out PlayerStatusInfo playerStatusInfo,
                out TranslateStatusInBattleUseCase playerStatusManager,
                out PhotonView photonView
            )
            {
                photonView = playerCore.GetComponent<PhotonView>();
                var instantiationId = photonView.InstantiationId;
                var creatorNr = photonView.CreatorActorNr;
                var characterDatum = GetCharacterDatum(instantiationId);
                var weaponDatum = GetWeaponDatum(instantiationId);
                var levelDatum = GetLevelDatum(instantiationId);
                var leaderCharacterData = characterDatum[0];
                var leaderWeaponData = weaponDatum[0];
                var leaderLevelData = levelDatum[0];
                var weaponType = leaderWeaponData.WeaponType;

                FixedPlayerObjTransform(photonView, playerCore);
                FixedWeaponObjTransform(photonView, playerCore, leaderWeaponData);

                var playerPutBomb = playerCore.AddComponent<PutBomb>();
                SetPlayerUI(playerCore, instantiationId, out hpKey);
                SetAnimatorController(playerCore, weaponType);
                GenerateEffectActivator(playerCore, instantiationId);
                playerStatusManager = InitializeStatus(leaderCharacterData, leaderWeaponData, leaderLevelData, IsMine(photonView));
                playerPutBomb.Initialize(_BombProvider, playerStatusManager, _MapManager);
                playerStatusInfo = playerCore.AddComponent<PlayerStatusInfo>();
                playerStatusInfo.SetPlayerIndex(instantiationId);
                AddBoxCollider(playerCore);
                AddRigidbody(playerCore);


                if (IsCpu(creatorNr))
                {
                    var enemyCore = playerCore.AddComponent<EnemyCore>();
                    enemyCore.enabled = PhotonNetwork.IsMasterClient;
                }
            }

            #region GetDatum

            private CharacterData[] GetCharacterDatum(int playerIndex)
            {
                var characterDatum = new List<CharacterData>();
                for (var i = 0; i < GameCommonData.MaxTeamMember; i++)
                {
                    var playerKey = PhotonNetworkManager.GetPlayerKey(playerIndex, i);
                    var characterData = _PhotonNetworkManager.GetCharacterData(playerKey);
                    if (characterData == null)
                    {
                        continue;
                    }

                    characterDatum.Add(characterData);
                }

                return characterDatum.ToArray();
            }

            private WeaponMasterData[] GetWeaponDatum(int playerIndex)
            {
                var weaponMasterDatum = new List<WeaponMasterData>();
                for (var i = 0; i < GameCommonData.MaxTeamMember; i++)
                {
                    var playerKey = PhotonNetworkManager.GetPlayerKey(playerIndex, i);
                    var weaponData = _PhotonNetworkManager.GetWeaponData(playerKey);
                    if (weaponData == null)
                    {
                        continue;
                    }

                    weaponMasterDatum.Add(weaponData);
                }

                return weaponMasterDatum.ToArray();
            }

            private LevelMasterData[] GetLevelDatum(int playerIndex)
            {
                var levelMasterDatum = new List<LevelMasterData>();
                for (var i = 0; i < GameCommonData.MaxTeamMember; i++)
                {
                    var playerKey = PhotonNetworkManager.GetPlayerKey(playerIndex, i);
                    var levelMasterData = _PhotonNetworkManager.GetLevelMasterData(playerKey);
                    if (levelMasterData == null)
                    {
                        continue;
                    }

                    levelMasterDatum.Add(levelMasterData);
                }

                return levelMasterDatum.ToArray();
            }

            #endregion

            private static bool IsCpu(int creatorNr)
            {
                return creatorNr == 0;
            }

            private bool IsMine(PhotonView photonView)
            {
                return _photonView.InstantiationId == photonView.InstantiationId;
            }

            private void InitializePlayerComponent(GameObject player)
            {
                var playerTransformView = player.GetComponent<PhotonTransformView>();
                if (playerTransformView == null)
                {
                    return;
                }

                CommonInitializationProcess
                (
                    player,
                    out var hpKey,
                    out var playerStatusInfo,
                    out var playerStatusManager,
                    out var photonView
                );

                if (!IsMine(photonView))
                {
                    return;
                }

                _CameraManager.Initialize(player.transform);
                var playerCore = player.AddComponent<PlayerCore>();
                Owner.SetPlayerCore(playerCore);
                Owner.SetPlayerStatusInfo(playerStatusInfo);
                playerCore.Initialize
                (
                    playerStatusManager,
                    _PhotonNetworkManager,
                    _ActiveSkillManager,
                    _PassiveSkillManager,
                    _SkillActivationConditionsUseCase,
                    _PlayerGeneratorUseCase,
                    _CharacterCreateUseCase,
                    hpKey
                );
            }

            private TranslateStatusInBattleUseCase InitializeStatus(CharacterData characterData, WeaponMasterData weaponData, LevelMasterData levelData, bool isMine)
            {
                var statusSkillDatum = weaponData.StatusSkillMasterDatum;
                var characterId = characterData.Id;
                var hp = 0;
                var attack = 0;
                var speed = 0;
                var bombLimit = 0;
                var fireRange = 0;
                var defense = 0;
                var resistance = 0;

                foreach (var statusSkillData in statusSkillDatum)
                {
                    var skillId = statusSkillData.Id;
                    hp = _ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Hp, levelData);
                    speed = _ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Speed, levelData);
                    attack = _ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Attack, levelData);
                    fireRange = _ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.FireRange, levelData);
                    bombLimit = _ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.BombLimit, levelData);
                    defense = _ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Defense, levelData);
                    resistance = _ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Resistance, levelData);
                }

                var playerStatusForBattleUseCase = new TranslateStatusInBattleUseCase
                (
                    hp,
                    speed,
                    bombLimit,
                    attack,
                    fireRange,
                    defense,
                    resistance,
                    isMine
                );

                return playerStatusForBattleUseCase;
            }

            private void GenerateEffectActivator(GameObject playerObj, int playerId)
            {
                var effectActivator = Instantiate(_EffectActivateUseCase, playerObj.transform);
                effectActivator.transform.localPosition = new Vector3(0, 0, 0);
                effectActivator.transform.localRotation = quaternion.identity;
                var activateSkillSubject = _PhotonNetworkManager._ActivateSkillSubject;
                effectActivator.Initialize(activateSkillSubject, playerId);
            }

            private void SetPlayerUI(GameObject player, int playerId, out string hpKey)
            {
                var playerUI = Instantiate(Owner.playerUI, Owner.playerUIParent);
                var playerBillBoardUI = playerUI.GetComponentInChildren<PlayerUIBillBoard>();
                playerBillBoardUI.Initialize(player.transform);
                hpKey = playerId + "Hp";
                SynchronizedValue.Instance.Create(hpKey, MaxRate);
                var playerStatusUI = playerUI.GetComponent<PlayerStatusUI>();
                playerStatusUI.Initialize(SynchronizedValue.Instance.GetFloatValue(hpKey));
                _PlayerStatusUiList.Add(playerStatusUI);
            }

            private void SetAnimatorController(GameObject player, WeaponType weaponType)
            {
                var animator = player.GetComponentInChildren<Animator>();
                var photonAnimatorView = player.GetComponentInChildren<PhotonAnimatorView>();
                animator.runtimeAnimatorController = _AnimatorControllerRepository.GetAnimatorController(weaponType);
                photonAnimatorView.SetParameterSynchronized
                (
                    GameCommonData.SpeedhParameterName,
                    PhotonAnimatorView.ParameterType.Float,
                    PhotonAnimatorView.SynchronizeType.Continuous
                );
                photonAnimatorView.SetParameterSynchronized
                (
                    GameCommonData.SpeedvParameterName,
                    PhotonAnimatorView.ParameterType.Float,
                    PhotonAnimatorView.SynchronizeType.Continuous
                );
                photonAnimatorView.SetParameterSynchronized
                (
                    GameCommonData.NormalParameterName,
                    PhotonAnimatorView.ParameterType.Trigger,
                    PhotonAnimatorView.SynchronizeType.Discrete
                );
                photonAnimatorView.SetParameterSynchronized
                (
                    GameCommonData.SpecialParameterName,
                    PhotonAnimatorView.ParameterType.Trigger,
                    PhotonAnimatorView.SynchronizeType.Discrete
                );
                photonAnimatorView.SetParameterSynchronized
                (
                    GameCommonData.KickParameterName,
                    PhotonAnimatorView.ParameterType.Trigger,
                    PhotonAnimatorView.SynchronizeType.Discrete
                );
                photonAnimatorView.SetParameterSynchronized
                (
                    GameCommonData.JumpParameterName,
                    PhotonAnimatorView.ParameterType.Trigger,
                    PhotonAnimatorView.SynchronizeType.Discrete
                );
                photonAnimatorView.SetParameterSynchronized
                (
                    GameCommonData.DashParameterName,
                    PhotonAnimatorView.ParameterType.Trigger,
                    PhotonAnimatorView.SynchronizeType.Discrete
                );
                photonAnimatorView.SetParameterSynchronized
                (
                    GameCommonData.BuffParameterName,
                    PhotonAnimatorView.ParameterType.Trigger,
                    PhotonAnimatorView.SynchronizeType.Discrete
                );
                photonAnimatorView.SetParameterSynchronized
                (
                    GameCommonData.DeadParameterName,
                    PhotonAnimatorView.ParameterType.Trigger,
                    PhotonAnimatorView.SynchronizeType.Discrete
                );
                photonAnimatorView.SetParameterSynchronized
                (
                    GameCommonData.SlashParameterName,
                    PhotonAnimatorView.ParameterType.Trigger,
                    PhotonAnimatorView.SynchronizeType.Discrete
                );
            }

            private void AddBoxCollider(GameObject player)
            {
                var collider = player.AddComponent<BoxCollider>();
                collider.isTrigger = false;
                collider.center = ColliderCenter;
                collider.size = ColliderSize;
            }

            private void AddRigidbody(GameObject player)
            {
                var rigid = player.AddComponent<Rigidbody>();
                rigid.useGravity = false;
                rigid.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }
}