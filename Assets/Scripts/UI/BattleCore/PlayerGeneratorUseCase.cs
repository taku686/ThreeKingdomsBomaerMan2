using System.Collections.Generic;
using Common.Data;
using Manager.NetworkManager;
using Photon.Pun;
using Unity.Mathematics;
using UnityEngine;

namespace Manager.BattleManager
{
    public class PlayerGeneratorUseCase : MonoBehaviour
    {
        [SerializeField] private List<Transform> startPointList;
        [SerializeField] private Transform playerParent;
        private GameObject playerObj;
        private const int PlayerNotification = 1;
        private const float PlayerSize = 0.8f;

        public void GenerateCharacter(int playerIndex, CharacterData characterData)
        {
            var spawnPoint = GetSpawnPoint(playerIndex);
            playerObj = PhotonNetwork.Instantiate
            (
                GameCommonData.CharacterPrefabPath + characterData.CharaObj,
                spawnPoint.position,
                spawnPoint.rotation
            );
            playerObj.transform.localScale *= PlayerSize;
            playerObj.transform.SetParent(playerParent);

            PlayerGenerateNotification();
        }

        private Transform GetSpawnPoint(int index)
        {
            return startPointList[index - 1];
        }

        private void PlayerGenerateNotification()
        {
            PhotonNetwork.LocalPlayer.SetPlayerGenerate(PlayerNotification);
        }
    }
}