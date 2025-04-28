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
using UI.Battle;
using Unity.Mathematics;
using UnityEngine;
using UniRx;
using Random = UnityEngine.Random;

namespace Manager.BattleManager
{
    public partial class BattleCore
    {
        public class PlayerCreateState : StateMachine<BattleCore>.State
        {
            private static readonly Vector3 ColliderCenter = new(0, 0.6f, 0);
            private static readonly Vector3 ColliderSize = new(0.4f, 0.6f, 0.4f);
            private static readonly float MaxRate = 1f;
            private PhotonNetworkManager _PhotonNetworkManager => Owner._photonNetworkManager;
            private PlayerGeneratorUseCase _PlayerGeneratorUseCase => Owner._playerGeneratorUseCase;
            private MapManager _MapManager => Owner.mapManager;
            private CameraManager _CameraManager => Owner.cameraManager;
            private StateMachine<BattleCore> _StateMachineClone => Owner._stateMachine;
            private BombProvider _BombProvider => Owner._bombProvider;
            private AnimatorControllerRepository _AnimatorControllerRepository => Owner.animatorControllerRepository;
            private WeaponCreateInBattleUseCase _WeaponCreateInBattleUseCase => Owner._weaponCreateInBattleUseCase;
            private EffectActivateUseCase _EffectActivateUseCase => Owner.effectActivator;
            private ApplyStatusSkillUseCase _ApplyStatusSkillUseCase => Owner._applyStatusSkillUseCase;
            private List<PlayerStatusUI> _PlayerStatusUiList => Owner._playerStatusUiList;
            private CharacterMasterDataRepository _CharacterMasterDataRepository => Owner._characterMasterDataRepository;
            private WeaponMasterDataRepository _WeaponMasterDataRepository => Owner._weaponMasterDataRepository;
            private CharacterCreateUseCase _CharacterCreateUseCase => Owner._characterCreateUseCase;

            protected override void OnEnter(StateMachine<BattleCore>.State prevState)
            {
                OnInitialize();
            }

            private void OnInitialize()
            {
                GeneratePlayer();
                GenerateCPU();
                SetPlayerGenerateCompleteSubscribe();
            }

            private void GeneratePlayer()
            {
                var index = PhotonNetwork.LocalPlayer.ActorNumber;
                var characterData = _PhotonNetworkManager.GetCharacterData(index);
                var playerObj = _PlayerGeneratorUseCase.GenerateCharacter(index, characterData);
                var weaponData = _PhotonNetworkManager.GetWeaponData(index);
                _CharacterCreateUseCase.CreateWeapon(playerObj, weaponData, true);
                playerObj.tag = GameCommonData.PlayerTag;
                playerObj.layer = LayerMask.NameToLayer(GameCommonData.PlayerLayer);
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
                    var playerIndex = PhotonNetwork.CurrentRoom.PlayerCount + i;
                    var characterCount = _CharacterMasterDataRepository.GeCharacterCount();
                    var candidateCharacterId = Random.Range(0, characterCount);
                    var characterData = _CharacterMasterDataRepository.GetCharacterData(candidateCharacterId);
                    var weaponCount = _WeaponMasterDataRepository.GetWeaponCount();
                    var candidateWeaponId = Random.Range(0, weaponCount);
                    var weaponData = _WeaponMasterDataRepository.GetWeaponData(candidateWeaponId);
                    var cpuObj = _PlayerGeneratorUseCase.GenerateCPUCharacter(playerIndex, characterData);
                    _CharacterCreateUseCase.CreateWeapon(cpuObj, weaponData, true);
                    cpuObj.tag = GameCommonData.PlayerTag;
                    cpuObj.layer = LayerMask.NameToLayer(GameCommonData.PlayerLayer);
                    cpuObj.AddComponent<EnemyCore>();
                }
            }

            private void SetPlayerGenerateCompleteSubscribe()
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

            private void InitializePlayerComponent(GameObject player)
            {
                var isCPU = player.TryGetComponent<EnemyCore>(out _);
                if (isCPU)
                {
                    return;
                }

                var photonView = player.GetComponent<PhotonView>();
                var photonAnimator = player.GetComponent<PhotonAnimatorView>();
                var playerPutBomb = player.AddComponent<PutBomb>();
                var playerId = photonView.OwnerActorNr;
                var characterData = _PhotonNetworkManager.GetCharacterData(playerId);
                var weaponData = _PhotonNetworkManager.GetWeaponData(playerId);
                var weaponType = weaponData.WeaponType;
                SetPlayerUI(player, playerId, out var hpKey);
                SetAnimatorController(player, weaponType, photonAnimator);
                GenerateEffectActivator(player, playerId);
                var playerStatusManager = InitializeStatus(characterData, weaponData, photonView.IsMine);
                playerPutBomb.Initialize(_BombProvider, playerStatusManager, _MapManager);
                if (!photonView.IsMine)
                {
                    return;
                }

                AddBoxCollider(player);
                AddRigidbody(player);
                _CameraManager.Initialize(player.transform);
                var playerCore = player.AddComponent<PlayerCore>();
                Owner.SetPlayerCore(playerCore);
                playerCore.Initialize
                (
                    playerStatusManager,
                    _PhotonNetworkManager,
                    _ApplyStatusSkillUseCase,
                    hpKey
                );
            }

            private TranslateStatusInBattleUseCase InitializeStatus
            (
                CharacterData characterData,
                WeaponMasterData weaponData,
                bool isMine
            )
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
                    hp = _ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Hp);
                    speed = _ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Speed);
                    attack = _ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Attack);
                    fireRange = _ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.FireRange);
                    bombLimit = _ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.BombLimit);
                    defense = _ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Defense);
                    resistance = _ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Resistance);
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
                var effect = Instantiate(_EffectActivateUseCase, playerObj.transform);
                effect.transform.localPosition = new Vector3(0, 0, 0);
                effect.transform.localRotation = quaternion.identity;
                var subject = _PhotonNetworkManager._ActivateSkillSubject;
                effect.Initialize(subject, playerId);
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

            private void SetAnimatorController
            (
                GameObject player,
                WeaponType weaponType,
                PhotonAnimatorView photonAnimatorView
            )
            {
                var animator = player.GetComponent<Animator>();
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
            }

            private void AddBoxCollider(GameObject player)
            {
                var collider = player.AddComponent<BoxCollider>();
                collider.isTrigger = true;
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