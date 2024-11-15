using Bomb;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.BattleManager.Camera;
using Manager.NetworkManager;
using Photon.Pun;
using Player.Common;
using UI.Battle;
using UniRx;
using Unity.Mathematics;
using UnityEngine;

namespace Manager.BattleManager
{
    public partial class BattleCore
    {
        public class PlayerCreateState : StateMachine<BattleCore>.State
        {
            private static readonly Vector3 ColliderCenter = new(0, 0.6f, 0);
            private static readonly Vector3 ColliderSize = new(0.4f, 0.6f, 0.4f);
            private static readonly float MaxRate = 1f;
            private PhotonNetworkManager PhotonNetworkManager => Owner.photonNetworkManager;
            private PlayerGeneratorUseCase PlayerGeneratorUseCase => Owner.playerGeneratorUseCase;
            private MapManager MapManager => Owner.mapManager;
            private CameraManager CameraManager => Owner.cameraManager;
            private StateMachine<BattleCore> StateMachineClone => Owner.stateMachine;
            private BombProvider BombProvider => Owner.bombProvider;
            private AnimatorControllerRepository AnimatorControllerRepository => Owner.animatorControllerRepository;
            private WeaponCreateInBattleUseCase WeaponCreateInBattleUseCase => Owner.weaponCreateInBattleUseCase;
            private EffectActivateUseCase EffectActivateUseCase => Owner.effectActivator;
            private ApplyStatusSkillUseCase ApplyStatusSkillUseCase => Owner.applyStatusSkillUseCase;

            protected override void OnEnter(StateMachine<BattleCore>.State prevState)
            {
                OnInitialize();
            }

            private void OnInitialize()
            {
                CreatePlayer();
                SetPlayerGenerateCompleteSubscribe();
            }

            private void CreatePlayer()
            {
                var index = PhotonNetwork.LocalPlayer.ActorNumber;
                var characterData = PhotonNetworkManager.GetCharacterData(index);
                PlayerGeneratorUseCase.GenerateCharacter(index, characterData);
            }

            private void SetPlayerGenerateCompleteSubscribe()
            {
                PhotonNetworkManager.PlayerGenerateCompleteSubject.Subscribe(_ =>
                {
                    var players = GameObject.FindGameObjectsWithTag(GameCommonData.PlayerTag);
                    foreach (var player in players)
                    {
                        InitializePlayerComponent(player);
                    }

                    StateMachineClone.Dispatch((int)State.BattleStart);
                }).AddTo(Owner.GetCancellationTokenOnDestroy());
            }

            private void InitializePlayerComponent(GameObject player)
            {
                var photonView = player.GetComponent<PhotonView>();
                var photonAnimator = player.GetComponent<PhotonAnimatorView>();
                var playerPutBomb = player.AddComponent<PutBomb>();
                var playerId = photonView.OwnerActorNr;
                var characterData = PhotonNetworkManager.GetCharacterData(playerId);
                var weaponData = PhotonNetworkManager.GetWeaponData(playerId);
                var weaponType = weaponData.WeaponType;
                player.tag = GameCommonData.PlayerTag;
                player.layer = LayerMask.NameToLayer(GameCommonData.PlayerLayer);
                InitializeStatus(out var playerStatusManager, characterData, weaponData, photonView.IsMine);
                playerPutBomb.Initialize(BombProvider, playerStatusManager, MapManager);
                SetPlayerUI(player, playerId, out var hpKey);
                SetAnimatorController(player, weaponType, photonAnimator);
                GenerateEffectActivator(player, playerId);
                WeaponCreateInBattleUseCase.CreateWeapon(player, weaponData, photonView);
                if (!photonView.IsMine)
                {
                    return;
                }

                AddBoxCollider(player);
                AddRigidbody(player);
                CameraManager.Initialize(player.transform);
                var playerCore = player.AddComponent<PlayerCore>();
                Owner.SetPlayerCore(playerCore);
                playerCore.Initialize
                (
                    playerStatusManager,
                    PhotonNetworkManager,
                    ApplyStatusSkillUseCase,
                    hpKey
                );
            }

            private void InitializeStatus
            (
                out TranslateStatusForBattleUseCase playerStatusForBattleUseCase,
                CharacterData characterData,
                WeaponMasterData weaponData,
                bool isMine
            )
            {
                var statusSkillData = weaponData.StatusSkillMasterData;
                var characterId = characterData.Id;
                var skillId = statusSkillData.Id;
                var hp = ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Hp);
                var speed = ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Speed);
                var attack = ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Attack);
                var fireRange = ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.FireRange);
                var bombLimit = ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.BombLimit);

                playerStatusForBattleUseCase = new TranslateStatusForBattleUseCase
                (
                    hp,
                    speed,
                    bombLimit,
                    attack,
                    fireRange,
                    isMine
                );
            }

            private void GenerateEffectActivator(GameObject playerObj, int playerId)
            {
                var effect = Instantiate(EffectActivateUseCase, playerObj.transform);
                effect.transform.localPosition = new Vector3(0, 0, 0);
                effect.transform.localRotation = quaternion.identity;
                var subject = PhotonNetworkManager.ActivateSkillSubject;
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
            }

            private void SetAnimatorController
            (
                GameObject player,
                WeaponType weaponType,
                PhotonAnimatorView photonAnimatorView
            )
            {
                var animator = player.GetComponent<Animator>();
                animator.runtimeAnimatorController = AnimatorControllerRepository.GetAnimatorController(weaponType);
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