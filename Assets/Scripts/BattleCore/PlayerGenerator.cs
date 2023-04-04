using System.Collections.Generic;
using Common.Data;
using Manager.NetworkManager;
using Photon.Pun;
using UnityEngine;

namespace Manager.BattleManager
{
    public class PlayerGenerator : MonoBehaviour
    {
        [SerializeField] private List<Transform> startPointList;
        [SerializeField] private Transform playerParent;
        private GameObject _playerObj;
        private const int PlayerNotification = 1;
        private const float PlayerSize = 0.8f;

        public void GenerateCharacter(int playerIndex, CharacterData characterData)
        {
            var spawnPoint = GetSpawnPoint(playerIndex);
            _playerObj = PhotonNetwork.Instantiate(GameCommonData.CharacterPrefabPath + characterData.CharaObj,
                spawnPoint.position, spawnPoint.rotation);
            _playerObj.transform.localScale *= PlayerSize;
            _playerObj.transform.SetParent(playerParent);
            PlayerGenerateNotification();
        }

        private Transform GetSpawnPoint(int index)
        {
            return startPointList[index];
        }

        private void PlayerGenerateNotification()
        {
            PhotonNetwork.LocalPlayer.SetPlayerGenerate(PlayerNotification);
        }
    }
}