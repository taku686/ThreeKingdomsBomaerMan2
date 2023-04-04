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
        public class PlayerCreateState : State
        {
            private static readonly Vector3 ColliderCenter = new(0, 0.6f, 0);
            private static readonly Vector3 ColliderSize = new(0.4f, 0.6f, 0.4f);
            private static readonly float MaxRate = 1f;
            private PlayerStatusManager _playerStatusManager;
            private UserDataManager _userDataManager;

            protected override void OnEnter(State prevState)
            {
                OnInitialize();
            }

            protected override void OnUpdate()
            {
                Owner._stateMachine.Dispatch((int)Event.BattleStart);
            }

            private void OnInitialize()
            {
                CreatePlayer();
                SetPlayerGenerateCompleteSubscribe();
            }

            private void CreatePlayer()
            {
                var index = Owner._networkManager.GetPlayerNumber(PhotonNetwork.LocalPlayer.ActorNumber);
                var characterData =
                    Owner._networkManager.CurrentRoomCharacterDatum[PhotonNetwork.LocalPlayer.ActorNumber];
                Owner._playerGenerator.GenerateCharacter(index, characterData);
            }

            private void SetPlayerGenerateCompleteSubscribe()
            {
                Owner._networkManager.PlayerGenerateComplete.Subscribe(_ =>
                {
                    var players = GameObject.FindGameObjectsWithTag(GameCommonData.PlayerTag);
                    foreach (var player in players)
                    {
                        InitializePlayerComponent(player);
                    }

                    stateMachine.Dispatch((int)Event.Staging);
                }).AddTo(Owner.GetCancellationTokenOnDestroy());
            }

            private void InitializePlayerComponent(GameObject player)
            {
                var photonView = player.GetComponent<PhotonView>();
                var playerId = photonView.OwnerActorNr;
                var characterData = Owner._networkManager.GetCharacterData(playerId);
                var characterLevelData = Owner._networkManager.GetCharacterLevelData(playerId);
                var playerStatusManager = new PlayerStatusManager(characterData, photonView.IsMine);
                var playerPutBomb = player.AddComponent<PlayerPutBomb>();
                playerPutBomb.Initialize(Owner._bombProvider, playerStatusManager);
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
                var playerCore = player.AddComponent<PLayerCore>();
                _userDataManager = Owner._userDataManager;
                playerCore.Initialize(playerStatusManager, hpKey, characterData, _userDataManager);
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