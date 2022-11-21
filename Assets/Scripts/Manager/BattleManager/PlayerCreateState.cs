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
                    var players = GameObject.FindGameObjectsWithTag(GameSettingData.PlayerTag);
                    foreach (var player in players)
                    {
                        InitializePlayerComponent(player).Forget();
                    }

                    stateMachine.Dispatch((int)Event.Staging);
                }).AddTo(Owner.GetCancellationTokenOnDestroy());
            }

            private async UniTaskVoid InitializePlayerComponent(GameObject player)
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
                /*var zenAutoInjecter = player.AddComponent<ZenAutoInjecter>();
                zenAutoInjecter.ContainerSource = ZenAutoInjecter.ContainerSources.SceneContext;*/
                var characterData = Owner._networkManager.GetCharacterData(playerId);
                await UniTask.NextFrame(PlayerLoopTiming.Update, Owner.GetCancellationTokenOnDestroy());
                playerCore.Initialize(characterData);
            }
        }
    }
}