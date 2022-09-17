using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.ResourceManager;
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

        private void Start()
        {
            /*_token = this.GetCancellationTokenOnDestroy();
            GenerateCharacter(_token).Forget();*/
        }

        public async UniTask GenerateCharacter()
        {
            var characterData =
                await _resourceManager.LoadCharacterData(LabelData.BachoPath, this.GetCancellationTokenOnDestroy());
            var spawnPoint = GetSpawnPoint((int)PlayerIndex.Player1);
            var playerObj = Instantiate(characterData.CharaObj, spawnPoint.position, spawnPoint.rotation);
            playerObj.GetComponent<PLayerCore>().Initialize(characterData);
        }

        private Transform GetSpawnPoint(int index)
        {
            return startPointList[index];
        }

        private enum PlayerIndex
        {
            Player1,
            Player2,
            Player3,
            Player4,
        }
    }

    public enum CharacterName
    {
        Bacho,
        Kanu,
        Tyouhi,
        Ryuubi,
        Syoukatsu,
        Sonken,
        Sonsaku,
        Daikyou,
        Syuuyu,
        Sousou,
        Shibasaku,
        Kakouton
    }
}