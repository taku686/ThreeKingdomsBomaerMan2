using System.Collections.Concurrent;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using UnityEngine;
using State = StateMachine<Manager.BattleManager.BattleManager>.State;

namespace Manager.BattleManager
{
    public partial class BattleManager
    {
        public class PlayerCreateState : State
        {
            protected override void OnEnter(State prevState)
            {
                Debug.Log("PlayerCreate初期化");
                OnInitialize();
            }

            private void OnInitialize()
            {
                CreatePlayer();
            }

            private void CreatePlayer()
            {
                if (Owner.isTest)
                {
                    var testIndex = Random.Range(0, 4);
                    var testCharacterData = Owner._characterDataModel.GetUserEquipCharacterData();
                        Owner._playerManager.GenerateCharacter(testIndex, testCharacterData);
                    return;
                }
                Debug.Log("Create Player");
                var index = Owner._networkManager.GetPlayerNumber(PhotonNetwork.LocalPlayer.ActorNumber);
                var characterData =
                    Owner._networkManager.CurrentRoomCharacterList[PhotonNetwork.LocalPlayer.ActorNumber];
                Owner._playerManager.GenerateCharacter(index, characterData);
            }
        }
    }
}