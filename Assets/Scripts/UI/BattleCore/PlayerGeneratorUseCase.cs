using System.Collections.Generic;
using Common.Data;
using Photon.Pun;
using Player.Common;
using UnityEngine;

namespace Manager.BattleManager
{
    public class PlayerGeneratorUseCase : MonoBehaviour
    {
        [SerializeField] private List<Transform> startPointList;
        [SerializeField] private Transform playerParent;
        private GameObject _playerObj;

        public GameObject InstantiatePlayerCore(int spawnPointIndex, bool isCpu)
        {
            var spawnPoint = GetSpawnPoint(spawnPointIndex);
            GameObject playerCore;
            if (!isCpu)
            {
                playerCore = PhotonNetwork.Instantiate
                (
                    GameCommonData.PlayerCorePath,
                    spawnPoint.position,
                    spawnPoint.rotation
                );
            }
            else
            {
                playerCore = PhotonNetwork.InstantiateRoomObject
                (
                    GameCommonData.PlayerCorePath,
                    spawnPoint.position,
                    spawnPoint.rotation
                );
            }

            return playerCore;
        }

        public GameObject InstantiatePlayerObj
        (
            CharacterData characterData,
            Transform parent,
            int weaponId,
            bool isCpu
        )
        {
            var photonView = parent.GetComponent<PhotonView>();
            var myCustomInitData = new object[] { photonView.InstantiationId, weaponId };
            if (!isCpu)
            {
                _playerObj = PhotonNetwork.Instantiate
                (
                    GameCommonData.CharacterPrefabPath + characterData.CharaObj,
                    Vector3.zero,
                    Quaternion.identity,
                    0,
                    myCustomInitData
                );
            }
            else
            {
                _playerObj = PhotonNetwork.InstantiateRoomObject
                (
                    GameCommonData.CharacterPrefabPath + characterData.CharaObj,
                    Vector3.zero,
                    Quaternion.identity,
                    0,
                    myCustomInitData
                );
            }

            return _playerObj;
        }

        public void DestroyPlayerObj()
        {
            if (_playerObj == null)
            {
                return;
            }

            PhotonNetwork.Destroy(_playerObj);
            _playerObj = null;
        }

        private Transform GetSpawnPoint(int index)
        {
            return startPointList[index - 1];
        }
    }
}