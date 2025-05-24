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
using UseCase.Battle;

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
            private EffectActivateUseCase _EffectActivateUseCase => Owner.effectActivator;
            private List<PlayerStatusUI> _PlayerStatusUiList => Owner._playerStatusUiList;
            private CharacterMasterDataRepository _CharacterMasterDataRepository => Owner._characterMasterDataRepository;
            private WeaponMasterDataRepository _WeaponMasterDataRepository => Owner._weaponMasterDataRepository;
            private CharacterCreateUseCase _CharacterCreateUseCase => Owner._characterCreateUseCase;
            private ActiveSkillManager _ActiveSkillManager => Owner._activeSkillManager;
            private PassiveSkillManager _PassiveSkillManager => Owner._passiveSkillManager;
            private SkillActivationConditionsUseCase _SkillActivationConditionsUseCase => Owner._skillActivationConditionsUseCase;
            private SetupAnimatorUseCase _SetupAnimatorUseCase => Owner._setupAnimatorUseCase;
            private TranslateStatusInBattleUseCase.Factory _TranslateStatusInBattleUseCaseFactory => Owner._translateStatusInBattleUseCaseFactory;

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

            private void GeneratePlayer()
            {
                var index = PhotonNetwork.LocalPlayer.ActorNumber;
                var playerKey = PhotonNetworkManager.GetPlayerKey(index, 0);
                var characterData = _PhotonNetworkManager.GetCharacterData(playerKey);
                var weaponData = _PhotonNetworkManager.GetWeaponData(playerKey);
                var playerCore = _PlayerGeneratorUseCase.InstantiatePlayerCore(spawnPointIndex: index, false);
                _photonView = playerCore.GetComponent<PhotonView>();
                var playerObj = _PlayerGeneratorUseCase.InstantiatePlayerObj(characterData, playerCore.transform, weaponData.Id, false);
                var weaponObjs = _CharacterCreateUseCase.CreateWeapon(playerObj, weaponData, true);
                var playerObjPhotonView = playerObj.GetComponent<PhotonView>();
                var weaponInstantiationIds = new List<int>();
                foreach (var weaponObj in weaponObjs)
                {
                    var weaponObjPhotonView = weaponObj.GetComponent<PhotonView>();
                    weaponInstantiationIds.Add(weaponObjPhotonView.InstantiationId);
                }

                var instantiationId = _photonView.InstantiationId;
                _PhotonNetworkManager.SetTeamMembersInfo(instantiationId, playerObjPhotonView.InstantiationId, weaponInstantiationIds.ToArray());
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
                    var characterData = _CharacterMasterDataRepository.GetCharacterData(candidateCharacterId);
                    var weaponData = _WeaponMasterDataRepository.GetWeaponData(candidateWeaponId);
                    var cpuCore = _PlayerGeneratorUseCase.InstantiatePlayerCore(cpuActorNr, true);
                    var cpuCorePhotonView = cpuCore.GetComponent<PhotonView>();
                    var instantiationId = cpuCorePhotonView.InstantiationId;
                    var playerKey = PhotonNetworkManager.GetPlayerKey(instantiationId, 0);
                    var cpuObj = _PlayerGeneratorUseCase.InstantiatePlayerObj(characterData, cpuCore.transform, weaponData.Id, true);
                    var cpuObjPhotonView = cpuObj.GetComponent<PhotonView>();
                    var weaponObjs = _CharacterCreateUseCase.CreateWeapon(cpuObj, weaponData, true, true);
                    foreach (var weaponObj in weaponObjs)
                    {
                        var weaponObjPhotonView = weaponObj.GetComponent<PhotonView>();
                        var weaponInstantiationId = weaponObjPhotonView.InstantiationId;
                        var weaponCoreInfo = new KeyValuePair<int, int>(instantiationId, weaponInstantiationId);
                        PhotonNetwork.LocalPlayer.SetWeaponCoreInfo(weaponCoreInfo);
                    }

                    var characterDic = new Dictionary<int, int> { { playerKey, candidateCharacterId } };
                    var weaponDic = new Dictionary<int, int> { { playerKey, candidateWeaponId } };
                    var levelDic = new Dictionary<int, int> { { playerKey, GameCommonData.MaxCharacterLevel } };
                    var cpuCoreInfo = new KeyValuePair<int, int>(instantiationId, cpuObjPhotonView.InstantiationId);

                    PhotonNetwork.LocalPlayer.SetCharacterId(characterDic);
                    PhotonNetwork.LocalPlayer.SetWeaponId(weaponDic);
                    PhotonNetwork.LocalPlayer.SetCharacterLevel(levelDic);
                    PhotonNetwork.LocalPlayer.SetPlayerCoreInfo(cpuCoreInfo);
                    PhotonNetwork.LocalPlayer.SetPlayerIndex(masterActorNr);
                }
            }

            private void CommonInitializationProcess
            (
                GameObject playerCore,
                out string hpKey,
                out PlayerStatusInfo playerStatusInfo,
                out PhotonView photonView,
                out PlayerMove playerMove
            )
            {
                photonView = playerCore.GetComponent<PhotonView>();
                var instantiationId = photonView.InstantiationId;
                var creatorNr = photonView.CreatorActorNr;
                var characterDatum = GetCharacterDatum(instantiationId);
                var weaponDatum = GetWeaponDatum(instantiationId);
                var levelDatum = GetLevelDatum(instantiationId);
                var characterData = characterDatum[0];
                var weaponData = weaponDatum[0];
                var levelData = levelDatum[0];
                var weaponType = weaponData.WeaponType;

                var playerPutBomb = playerCore.AddComponent<PutBomb>();
                SetPlayerUI(playerCore, instantiationId, out hpKey);
                playerMove = playerCore.AddComponent<PlayerMove>();
                _SetupAnimatorUseCase.SetAnimatorController(playerCore, weaponType);
                GenerateEffectActivator(playerCore, instantiationId);
                var translateStatusInBattleUseCase = _TranslateStatusInBattleUseCaseFactory.Create(characterData, weaponData, levelData);
                translateStatusInBattleUseCase.InitializeStatus();
                playerPutBomb.Initialize(_BombProvider, _MapManager, translateStatusInBattleUseCase);
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
                    out var photonView,
                    out var playerMove
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
                    _TranslateStatusInBattleUseCaseFactory,
                    _PhotonNetworkManager,
                    _ActiveSkillManager,
                    _PassiveSkillManager,
                    _SkillActivationConditionsUseCase,
                    _PlayerGeneratorUseCase,
                    _CharacterCreateUseCase,
                    _SetupAnimatorUseCase,
                    playerMove,
                    hpKey
                );
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

            private static void AddBoxCollider(GameObject player)
            {
                var collider = player.AddComponent<BoxCollider>();
                collider.isTrigger = false;
                collider.center = ColliderCenter;
                collider.size = ColliderSize;
            }

            private static void AddRigidbody(GameObject player)
            {
                var rigid = player.AddComponent<Rigidbody>();
                rigid.useGravity = false;
                rigid.constraints = RigidbodyConstraints.FreezeAll;
            }

            private static bool IsCpu(int creatorNr)
            {
                return creatorNr == 0;
            }

            private bool IsMine(PhotonView photonView)
            {
                return _photonView.InstantiationId == photonView.InstantiationId;
            }
        }
    }
}