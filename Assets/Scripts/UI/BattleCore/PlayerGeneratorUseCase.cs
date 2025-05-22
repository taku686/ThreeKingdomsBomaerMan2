using System.Collections.Generic;
using Common.Data;
using Photon.Pun;
using UnityEngine;

namespace Manager.BattleManager
{
    public class PlayerGeneratorUseCase : MonoBehaviour
    {
        [SerializeField] private List<Transform> startPointList;
        [SerializeField] private Transform playerParent;
        private GameObject _playerObj;
        private const float PlayerSize = 0.8f;

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

        public void SetupPlayerCore(GameObject playerCore)
        {
            playerCore.transform.SetParent(playerParent);
            var photonTransformView = playerCore.GetComponent<PhotonTransformView>();
            if (photonTransformView != null)
            {
                photonTransformView.m_SynchronizePosition = true;
                photonTransformView.m_SynchronizeRotation = true;
                photonTransformView.m_SynchronizeScale = true;
                photonTransformView.m_UseLocal = false;
            }
        }

        public GameObject InstantiatePlayerObj(CharacterData characterData, Transform parent, bool isCpu)
        {
            var photonView = parent.GetComponent<PhotonView>();
            var myCustomInitData = new object[] { photonView.InstantiationId };
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

            _playerObj.transform.SetParent(parent);
            _playerObj.transform.localPosition = Vector3.zero;
            _playerObj.transform.localEulerAngles = Vector3.zero;
            return _playerObj;
        }

        public void DestroyPlayerObj()
        {
            if (_playerObj == null)
            {
                return;
            }

            Debug.Log("Destroy PlayerObj");
            PhotonNetwork.Destroy(_playerObj);
            _playerObj = null;
        }

        private Transform GetSpawnPoint(int index)
        {
            return startPointList[index - 1];
        }
    }
}