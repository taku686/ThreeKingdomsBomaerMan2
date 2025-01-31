using System.Collections.Generic;
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
                var characterData = _PhotonNetworkManager.GetCharacterData(index);
                _PlayerGeneratorUseCase.GenerateCharacter(index, characterData);
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
                var photonView = player.GetComponent<PhotonView>();
                var photonAnimator = player.GetComponent<PhotonAnimatorView>();
                var playerPutBomb = player.AddComponent<PutBomb>();
                var playerId = photonView.OwnerActorNr;
                var characterData = _PhotonNetworkManager.GetCharacterData(playerId);
                var weaponData = _PhotonNetworkManager.GetWeaponData(playerId);
                var weaponType = weaponData.WeaponType;
                player.tag = GameCommonData.PlayerTag;
                player.layer = LayerMask.NameToLayer(GameCommonData.PlayerLayer);
                SetPlayerUI(player, playerId, out var hpKey);
                SetAnimatorController(player, weaponType, photonAnimator);
                GenerateEffectActivator(player, playerId);
                _WeaponCreateInBattleUseCase.CreateWeapon(player, weaponData, photonView);
                InitializeStatus(out var playerStatusManager, characterData, weaponData, photonView.IsMine);
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
                var hp = _ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Hp);
                var speed = _ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Speed);
                var attack = _ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Attack);
                var fireRange = _ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.FireRange);
                var bombLimit = _ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.BombLimit);

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