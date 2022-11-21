using System.Collections.Generic;
using System.Threading;
using Assets.Scripts.Common.ResourceManager;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.NetworkManager;
using Manager.ResourceManager;
using Photon.Pun;
using Player.Common;
using UnityEngine;
using Zenject;

namespace Manager.BattleManager
{
    public class PlayerGenerator : MonoBehaviour
    {
        [SerializeField] private List<Transform> startPointList;
        [SerializeField] private Transform playerParent;
        private GameObject _playerObj;
        private static readonly int PlayerNotification = 1;

        public void GenerateCharacter(int playerIndex, CharacterData characterData)
        {
            var spawnPoint = GetSpawnPoint(playerIndex);
            _playerObj = PhotonNetwork.Instantiate(LabelData.CharacterPrefabPath + characterData.CharaObj,
                spawnPoint.position, spawnPoint.rotation);
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