using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.ResourceManager;
using Photon.Pun;
using Player.Common;
using UniRx;
using UnityEngine;
using Zenject;

namespace Manager.BattleManager
{
    public class PlayerManager : MonoBehaviour
    {
        [Inject] private ILoadResource _resourceManager;

        private CancellationToken _token;
        private List<IPlayerModelBase> _playerList = new List<IPlayerModelBase>();

        [SerializeField] private CharacterName characterName;
        [SerializeField] private List<Transform> startPointList;
        [SerializeField] private Transform playerParent;

        private void Start()
        {
            /*_token = this.GetCancellationTokenOnDestroy();
            GenerateCharacter(_token).Forget();*/
        }

        public async UniTask GenerateCharacter()
        {
            var characterData =
                await _resourceManager.LoadCharacterData((int)CharacterName.Bacho, this.GetCancellationTokenOnDestroy());
            var spawnPoint = GetSpawnPoint((int)PlayerIndex.Player1);
            var playerObj = Instantiate(characterData.CharaObj, spawnPoint.position, spawnPoint.rotation, playerParent);
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
            UniTask.Yield();
            playerCore.Initialize(characterData);
        }

        private enum PlayerIndex
        {
            Player1,
            Player2,
            Player3,
            Player4,
        }
    }

   
}