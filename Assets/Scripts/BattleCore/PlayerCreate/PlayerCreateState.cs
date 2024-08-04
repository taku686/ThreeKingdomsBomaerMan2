using System.Linq;
using Common.Data;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using Player.Common;
using UI.Battle;
using UniRx;
using UnityEngine;
using State = StateMachine<Manager.BattleManager.BattleCore>.State;

namespace Manager.BattleManager
{
    public partial class BattleCore
    {
        public class PlayerCreateState : StateMachine<BattleCore>.State
        {
            private static readonly Vector3 ColliderCenter = new(0, 0.6f, 0);
            private static readonly Vector3 ColliderSize = new(0.4f, 0.6f, 0.4f);
            private static readonly float MaxRate = 1f;
            private CharacterStatusManager characterStatusManager;
            private UserDataManager userDataManager;
            private MapManager mapManager;

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
                var index = Owner.networkManager.GetPlayerNumber(PhotonNetwork.LocalPlayer.ActorNumber);
                var characterData = Owner.networkManager.CurrentRoomCharacterDatum[PhotonNetwork.LocalPlayer.ActorNumber];
                Owner.playerGenerator.GenerateCharacter(index, characterData);
            }

            private void SetPlayerGenerateCompleteSubscribe()
            {
                Owner.networkManager.PlayerGenerateCompleteSubject.Subscribe(_ =>
                {
                    var players = GameObject.FindGameObjectsWithTag(GameCommonData.PlayerTag);
                    foreach (var player in players)
                    {
                        InitializePlayerComponent(player);
                    }

                    Owner.stateMachine.Dispatch((int)State.BattleStart);
                }).AddTo(Owner.GetCancellationTokenOnDestroy());
            }

            private void InitializePlayerComponent(GameObject player)
            {
                mapManager = Owner.mapManager;
                var photonView = player.GetComponent<PhotonView>();
                var playerId = photonView.OwnerActorNr;
                var characterData = Owner.networkManager.GetCharacterData(playerId);
                var characterLevelData = Owner.networkManager.GetCharacterLevelData(playerId);
                var playerStatusManager = new CharacterStatusManager(characterData, photonView.IsMine);
                var playerPutBomb = player.AddComponent<PutBomb>();
                playerPutBomb.Initialize(Owner.bombProvider, playerStatusManager, mapManager);
                var playerUI = Instantiate(Owner.playerUI, Owner.playerUIParent);
                var playerBillBoardUI = playerUI.GetComponentInChildren<PlayerUIBillBoard>();
                playerBillBoardUI.Initialize(player.transform);
                var hpKey = playerId + "Hp";
                SynchronizedValue.Instance.Create(hpKey, MaxRate);
                CreateWeaponEffect(player, characterLevelData.Level, characterData);
                var playerStatusUI = playerUI.GetComponent<PlayerStatusUI>();
                playerStatusUI.Initialize(SynchronizedValue.Instance.GetFloatValue(hpKey));
                if (!photonView.IsMine)
                {
                    return;
                }

                AddBoxCollider(player);
                AddRigidbody(player);
                Owner.cameraManager.Initialize(player.transform);
                var playerCore = player.AddComponent<PlayerCore>();
                Owner.SetPlayerCore(playerCore);
                userDataManager = Owner.userDataManager;
                playerCore.Initialize(playerStatusManager, hpKey, characterData, userDataManager);
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

            private void CreateWeaponEffect(GameObject player, int characterLevel, CharacterData characterData)
            {
                if (characterLevel < GameCommonData.MaxCharacterLevel)
                {
                    return;
                }

                var weapons = player.GetComponentsInChildren<Transform>()
                    .Where(x => x.CompareTag(GameCommonData.WeaponTag)).Select(x => x.gameObject);
                foreach (var weapon in weapons)
                {
                    var effectObj = Instantiate(characterData.WeaponEffectObj, weapon.transform);
                    var particleSystems = effectObj.GetComponentsInChildren<ParticleSystem>();
                    foreach (var system in particleSystems)
                    {
                        var systemCollision = system.collision;
                        var inheritVelocity = system.inheritVelocity;
                        systemCollision.enabled = false;
                        inheritVelocity.enabled = false;
                    }

                    var effect = effectObj.GetComponentInChildren<PSMeshRendererUpdater>();
                    effect.Color = GameCommonData.GetWeaponColor(characterData.Id);
                    effect.UpdateMeshEffect(weapon);
                }
            }
        }
    }
}