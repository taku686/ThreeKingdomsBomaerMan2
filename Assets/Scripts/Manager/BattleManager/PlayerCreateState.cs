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
                    Debug.Log("player生成完了");
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
                var playerId = photonView.OwnerActorNr;
                if (!photonView.IsMine)
                {
                    return;
                    
                }
                var playerCore = player.AddComponent<PLayerCore>();
                player.AddComponent<ZenAutoInjecter>();
                var characterData = Owner._networkManager.GetCharacterData(playerId);
                playerCore.Initialize(characterData);
            }
        }
    }
}