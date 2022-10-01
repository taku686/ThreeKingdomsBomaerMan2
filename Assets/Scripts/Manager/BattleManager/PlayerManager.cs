using System.Collections.Generic;
using System.Threading;
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
    public class PlayerManager : MonoBehaviour
    {
        [Inject] private ILoadResource _resourceManager;

        private CancellationToken _token;
        [SerializeField] private List<Transform> startPointList;
        [SerializeField] private Transform playerParent;

        public void GenerateCharacter(int playerIndex, CharacterData characterData)
        {
            _token = this.GetCancellationTokenOnDestroy();
            var spawnPoint = GetSpawnPoint(playerIndex);
            var playerObj =
                PhotonNetwork.Instantiate(LabelData.CharacterPrefabPath + characterData.CharaObj.name,
                    spawnPoint.position, spawnPoint.rotation);
            playerObj.transform.SetParent(playerParent);
            InitializeComponent(playerObj, characterData);
        }

        private Transform GetSpawnPoint(int index)
        {
            return startPointList[index];
        }

        private void InitializeComponent(GameObject player, CharacterData characterData)
        {
            player.AddComponent<PlayerMove>();
            var playerCore = player.AddComponent<PLayerCore>();
            player.AddComponent<ZenAutoInjecter>();
            playerCore.Initialize(characterData);
        }
    }
}