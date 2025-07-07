using System.Collections.Generic;
using Bomb;
using Common.Data;
using Cysharp.Threading.Tasks;
using Enemy;
using Facade.Skill;
using Manager.BattleManager.Camera;
using Manager.DataManager;
using Manager.NetworkManager;
using Photon.Pun;
using Player.Common;
using Repository;
using Skill;
using UI.Battle;
using UI.BattleCore.InBattle;
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
            //Manager
            private PhotonNetworkManager _PhotonNetworkManager => Owner._photonNetworkManager;
            private MapManager _MapManager => Owner.mapManager;
            private CameraManager _CameraManager => Owner.cameraManager;
            private ActiveSkillManager _ActiveSkillManager => Owner._activeSkillManager;
            private PassiveSkillManager _PassiveSkillManager => Owner._passiveSkillManager;

            //UseCase
            private PlayerGeneratorUseCase _PlayerGeneratorUseCase => Owner._playerGeneratorUseCase;
            private SkillEffectActivateUseCase _SkillEffectActivateUseCase => Owner._skillEffectActivateUseCase;
            private CharacterCreateUseCase _CharacterCreateUseCase => Owner._characterCreateUseCase;
            private OnDamageFacade _OnDamageFacade => Owner._onDamageFacade;
            private SetupAnimatorUseCase _SetupAnimatorUseCase => Owner._setupAnimatorUseCase;

            //Repository
            private CharacterMasterDataRepository _CharacterMasterDataRepository => Owner._characterMasterDataRepository;
            private WeaponMasterDataRepository _WeaponMasterDataRepository => Owner._weaponMasterDataRepository;
            private StartPointsRepository _StartPointsRepository => Owner._startPointsRepository;

            //Factory
            private EnemySearchPlayer.Factory _EnemySearchPlayerFactory => Owner._enemySearchPlayerFactory;
            private TranslateStatusInBattleUseCase.Factory _TranslateStatusInBattleUseCaseFactory => Owner._translateStatusInBattleUseCaseFactory;
            private EnemySkillTimer.Factory _EnemySkillTimerFactory => Owner._enemySkillTimerFactory;

            //Facade
            private SkillAnimationFacade _SkillAnimationFacade => Owner._skillAnimationFacade;

            //Others
            private List<PlayerStatusUI> _PlayerStatusUiList => Owner._playerStatusUiList;
            private GameObject _ArrowIndicatorPrefab => Owner._arrowSkillIndicatorPrefab;
            private GameObject _CircleIndicatorPrefab => Owner._circleSkillIndicatorPrefab;
            private AbnormalConditionEffectUseCase _AbnormalConditionEffectUseCase => Owner._abnormalConditionEffectUseCase;
            private BombProvider _BombProvider => Owner._bombProvider;
            private StateMachine<BattleCore> _StateMachineClone => Owner._stateMachine;

            private PhotonView _photonView;
            private static readonly Vector3 ColliderCenter = new(0, 0.6f, 0);
            private static readonly Vector3 ColliderSize = new(0.6f, 0.6f, 0.6f);
            private const float MaxRate = 1f;
            private const int PlayerNotification = 1;
            private const int DefaultTeamMember = 0;

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
                _PhotonNetworkManager._PlayerGenerateCompleteObservable.Subscribe(_ =>
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
                var playerKey = PhotonNetworkManager.GetPlayerKey(index, DefaultTeamMember);
                var characterData = _PhotonNetworkManager.GetCharacterData(playerKey);
                var weaponData = _PhotonNetworkManager.GetWeaponData(playerKey);
                var spawnPoint = _StartPointsRepository.GetSpawnPoint(index);
                var playerCore = _PlayerGeneratorUseCase.InstantiatePlayerCore(false, spawnPoint);
                var playerObj = _PlayerGeneratorUseCase.InstantiatePlayerObj(characterData, playerCore.transform, weaponData.Id, false);
                _CharacterCreateUseCase.CreateWeapon(playerObj, weaponData, true);
                _photonView = playerCore.GetComponent<PhotonView>();
                var instantiationId = _photonView.InstantiationId;
                _PhotonNetworkManager.SetTeamMembersInfo(instantiationId);
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
                    var masterActorNr = PhotonNetwork.MasterClient.ActorNumber;
                    var cpuActorNr = PhotonNetwork.CurrentRoom.PlayerCount + i;
                    var characterId = _CharacterMasterDataRepository.GetRandomCharacterId();
                    //todo review later
                    //var weaponId = _WeaponMasterDataRepository.GetWeaponRandomWeaponId();
                    var characterData = _CharacterMasterDataRepository.GetCharacterData(characterId);
                    var weaponData = _WeaponMasterDataRepository.GetWeaponData(300);
                    var spawnPoint = _StartPointsRepository.GetSpawnPoint(cpuActorNr);
                    var playerCore = _PlayerGeneratorUseCase.InstantiatePlayerCore(true, spawnPoint);
                    var photonView = playerCore.GetComponent<PhotonView>();
                    var instantiationId = photonView.InstantiationId;
                    var playerKey = PhotonNetworkManager.GetPlayerKey(instantiationId, DefaultTeamMember);
                    var playerObj = _PlayerGeneratorUseCase.InstantiatePlayerObj(characterData, playerCore.transform, weaponData.Id, true);
                    _CharacterCreateUseCase.CreateWeapon(playerObj, weaponData, true, true);
                    var characterDic = new Dictionary<int, int> { { playerKey, characterId } };
                    var weaponDic = new Dictionary<int, int> { { playerKey, weaponData.Id } };
                    var levelDic = new Dictionary<int, int> { { playerKey, GameCommonData.MaxCharacterLevel } };

                    PhotonNetwork.LocalPlayer.SetCharacterId(characterDic);
                    PhotonNetwork.LocalPlayer.SetWeaponId(weaponDic);
                    PhotonNetwork.LocalPlayer.SetCharacterLevel(levelDic);
                    PhotonNetwork.LocalPlayer.SetPlayerIndex(masterActorNr);
                }
            }

            private void CommonInitializationProcess
            (
                GameObject playerCore,
                out string hpKey,
                out PlayerConditionInfo playerConditionInfo,
                out PhotonView photonView
            )
            {
                photonView = playerCore.GetComponent<PhotonView>();
                var instantiationId = photonView.InstantiationId;
                var characterDatum = GetCharacterDatum(instantiationId);
                var weaponDatum = GetWeaponDatum(instantiationId);
                var levelDatum = GetLevelDatum(instantiationId);
                var characterData = characterDatum[0];
                var weaponData = weaponDatum[0];
                var levelData = levelDatum[0];
                var weaponType = weaponData.WeaponType;

                playerCore.tag = GameCommonData.PlayerTag;
                playerCore.layer = LayerMask.NameToLayer(GameCommonData.EnemyLayer);
                SetPlayerUI(playerCore, instantiationId, out hpKey);
                playerCore.AddComponent<PlayerMove>();
                playerCore.AddComponent<PlayerDash>();
                _SetupAnimatorUseCase.SetAnimatorController(playerCore, weaponType);
                GenerateEffectActivator(playerCore, photonView);
                var translateStatusInBattleUseCase = _TranslateStatusInBattleUseCaseFactory.Create(characterData, weaponData, levelData);
                translateStatusInBattleUseCase.InitializeStatus();
                var putBomb = playerCore.AddComponent<PutBomb>();
                putBomb.Initialize(_BombProvider, _MapManager, translateStatusInBattleUseCase);
                playerConditionInfo = playerCore.AddComponent<PlayerConditionInfo>();
                playerConditionInfo.SetPlayerIndex(instantiationId);
                AddBoxCollider(playerCore);
                AddRigidbody(playerCore);
                AddPlayerSkill(playerCore);
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
                    out var photonView
                );

                InitializeCpu(player, photonView.CreatorActorNr);

                if (!IsMine(photonView))
                {
                    return;
                }

                _CameraManager.Initialize(player.transform);
                player.layer = LayerMask.NameToLayer(GameCommonData.PlayerLayer);
                var playerCore = player.AddComponent<PlayerCore>();
                Owner.SetPlayerCore(playerCore);
                Owner.SetPlayerStatusInfo(playerStatusInfo);
                InstantiateSkillIndicator(playerCore.transform);
                playerCore.Initialize
                (
                    _TranslateStatusInBattleUseCaseFactory,
                    _PhotonNetworkManager,
                    _ActiveSkillManager,
                    _PassiveSkillManager,
                    _OnDamageFacade,
                    _PlayerGeneratorUseCase,
                    _CharacterCreateUseCase,
                    _AbnormalConditionEffectUseCase,
                    _SkillAnimationFacade,
                    hpKey
                );
            }

            private void InitializeCpu(GameObject playerCore, int creatorActorNr)
            {
                if (!PhotonNetworkManager.IsCpu(creatorActorNr)) return;
                var enemyCore = playerCore.AddComponent<EnemyCore>();
                enemyCore.Initialize
                (
                    _EnemySearchPlayerFactory,
                    _EnemySkillTimerFactory,
                    _PhotonNetworkManager,
                    _SkillAnimationFacade
                );
                enemyCore.enabled = PhotonNetwork.IsMasterClient;
            }

            private void InstantiateSkillIndicator(Transform playerTransform)
            {
                var arrowIndicator = Instantiate(_ArrowIndicatorPrefab, playerTransform);
                var arrowIndicatorView = arrowIndicator.GetComponent<ArrowSkillIndicatorView>();
                arrowIndicator.SetActive(false);
                Owner.SetArrowSkillIndicatorView(arrowIndicatorView);
                var circleIndicator = Instantiate(_CircleIndicatorPrefab, playerTransform);
                var circleIndicatorView = circleIndicator.GetComponent<CircleSkillIndicatorView>();
                circleIndicator.SetActive(false);
                Owner.SetCircleSkillIndicatorView(circleIndicatorView);
            }

            private void GenerateEffectActivator(GameObject playerCore, PhotonView photonView)
            {
                var effectActivator = Instantiate(_SkillEffectActivateUseCase, playerCore.transform);
                var effectActivatorTransform = effectActivator.transform;
                effectActivatorTransform.localPosition = new Vector3(0, 0, 0);
                effectActivatorTransform.localRotation = quaternion.identity;
                var activateSkillSubject = _PhotonNetworkManager._ActivateSkillObservable;
                effectActivator.Initialize(activateSkillSubject, photonView);
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
                rigid.useGravity = true;
                rigid.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
                rigid.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            }

            private void AddPlayerSkill(GameObject playerCore)
            {
                var playerSkill = playerCore.AddComponent<PlayerSkill>();
                playerSkill.Initialize(_ActiveSkillManager, _PhotonNetworkManager, playerCore);
            }

            private bool IsMine(PhotonView photonView)
            {
                return _photonView.InstantiationId == photonView.InstantiationId;
            }
        }
    }
}