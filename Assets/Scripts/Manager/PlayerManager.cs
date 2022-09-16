using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.ResourceManager;
using Player.Common;
using UniRx;
using UnityEngine;
using Zenject;

public class PlayerManager : MonoBehaviour
{
    [Inject] private ILoadResource _resourceManager;
    [Inject] private DiContainer _container;

    private CancellationTokenSource _cts = new CancellationTokenSource();
    private List<IPlayerModelBase> _playerList = new List<IPlayerModelBase>();

    [SerializeField] private CharacterName characterName;
    [SerializeField] private List<Transform> startPointList;

    private void Start()
    {
        GenerateCharacter().Forget();
    }

    private async UniTask GenerateCharacter()
    {
        var characterData = await _resourceManager.LoadCharacterData(LabelData.BachoPath, _cts.Token);
        var spawnPoint = GetSpawnPoint((int)PlayerIndex.Player1);
        var playerObj = Instantiate(characterData.CharaObj, spawnPoint.position, spawnPoint.rotation);
        playerObj.GetComponent<PLayerCore>().Initialize(characterData);
    }

    private void Cancel()
    {
        if (_cts != null)
        {
            _cts.Cancel();
            _cts.Dispose();
            _cts = null;
        }

        _cts = new CancellationTokenSource();
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