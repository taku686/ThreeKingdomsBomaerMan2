using Common.Data;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using Player.Common;
using UI.Battle;
using UniRx;
using UnityEngine;
using State = StateMachine<Manager.BattleManager.BattleBase>.State;

namespace Manager.BattleManager
{
    public partial class BattleBase
    {
        public class PlayerCreateState : State
        {
            private static readonly Vector3 ColliderCenter = new(0, 0.5f, 0);
            private static readonly Vector3 ColliderSize = new(0.6f, 0.6f, 0.6f);
            private static readonly float MaxRate = 1f;
            private PlayerStatusManager _playerStatusManager;

            protected override void OnEnter(State prevState)
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
                var index = Owner._networkManager.GetPlayerNumber(PhotonNetwork.LocalPlayer.ActorNumber);
                var characterData =
                    Owner._networkManager.CurrentRoomCharacterList[PhotonNetwork.LocalPlayer.ActorNumber];
                Owner._playerGenerator.GenerateCharacter(index, characterData);
            }

            private void SetPlayerGenerateCompleteSubscribe()
            {
                Owner._networkManager.PlayerGenerateComplete.Subscribe(_ =>
                {
                    var players = GameObject.FindGameObjectsWithTag(GameSettingData.PlayerTag);
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
                var playerStatusManager = new PlayerStatusManager(characterData, photonView.IsMine);
                var playerPutBomb = player.AddComponent<PlayerPutBomb>();
                Debug.Log(Owner._bombProvider);
                playerPutBomb.Initialize(Owner._bombProvider, playerStatusManager);
                var playerUI = Instantiate(Owner.playerUI, Owner.playerUIParent);
                var playerBillBoardUI = playerUI.GetComponentInChildren<PlayerUIBillBoard>();
                playerBillBoardUI.Initialize(player.transform);
                var hpKey = playerId + "Hp";
                SynchronizedValue.Instance.Create(hpKey, MaxRate);
                var playerStatusUI = playerUI.GetComponent<PlayerStatusUI>();
                playerStatusUI.Initialize(SynchronizedValue.Instance.GetFloatValue(hpKey));
                if (!photonView.IsMine)
                {
                    return;
                }

                AddBoxCollider(player);
                AddRigidbody(player);
                var playerCore = player.AddComponent<PLayerBase>();
                playerCore.Initialize(playerStatusManager, hpKey);
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