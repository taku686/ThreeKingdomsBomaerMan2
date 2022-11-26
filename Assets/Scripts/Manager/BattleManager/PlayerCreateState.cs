using Common.Data;
using Cysharp.Threading.Tasks;
using ModestTree;
using Photon.Pun;
using Player.Common;
using UniRx;
using UnityEngine;
using Zenject;
using State = StateMachine<Manager.BattleManager.BattleManager>.State;

namespace Manager.BattleManager
{
    public partial class BattleManager
    {
        public class PlayerCreateState : State
        {
            private static readonly Vector3 ColliderCenter = new Vector3(0, 0.5f, 0);

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
                var playerPutBomb = player.AddComponent<PlayerPutBomb>();
                playerPutBomb.Initialize(Owner._bombProvider);
                var photonView = player.GetComponent<PhotonView>();
                AddBoxCollider(player);
                AddRigidbody(player);
                var playerId = photonView.OwnerActorNr;
                if (!photonView.IsMine)
                {
                    return;
                }

                var playerCore = player.AddComponent<PLayerCore>();
                var characterData = Owner._networkManager.GetCharacterData(playerId);
                playerCore.Initialize(characterData);
            }

            private void AddBoxCollider(GameObject player)
            {
                var collider = player.AddComponent<BoxCollider>();
                collider.isTrigger = true;
                collider.center = ColliderCenter;
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