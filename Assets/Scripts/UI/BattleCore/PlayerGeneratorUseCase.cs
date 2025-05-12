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
        private GameObject _playerObj;
        private const int PlayerNotification = 1;
        private const float PlayerSize = 0.8f;

        public GameObject GenerateCharacter(int playerIndex, CharacterData characterData)
        {
            var spawnPoint = GetSpawnPoint(playerIndex);
            _playerObj = PhotonNetwork.Instantiate
            (
                GameCommonData.CharacterPrefabPath + characterData.CharaObj,
                spawnPoint.position,
                spawnPoint.rotation
            );
            _playerObj.transform.localScale *= PlayerSize;
            _playerObj.transform.SetParent(playerParent);
            PhotonNetwork.LocalPlayer.SetPlayerGenerate(PlayerNotification);
            return _playerObj;
        }

        public GameObject GenerateCPUCharacter(int playerIndex, CharacterData characterData)
        {
            var spawnPoint = GetSpawnPoint(playerIndex);
            _playerObj = PhotonNetwork.InstantiateRoomObject
            (
                GameCommonData.CharacterPrefabPath + characterData.CharaObj,
                spawnPoint.position,
                spawnPoint.rotation
            );
            _playerObj.transform.localScale *= PlayerSize;
            _playerObj.transform.SetParent(playerParent);
            return _playerObj;
        }

        private Transform GetSpawnPoint(int index)
        {
            return startPointList[index - 1];
        }
    }
}