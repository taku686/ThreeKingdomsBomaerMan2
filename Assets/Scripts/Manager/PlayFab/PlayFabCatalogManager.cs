using System;
using System.Collections.Generic;
using System.Threading;
using Assets.Scripts.Common.Data;
using Common.Data;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace Assets.Scripts.Common.ResourceManager
{
    public class PlayFabCatalogManager : IDisposable
    {
        private readonly Catalog _catalog;
        private List<CatalogItem> _catalogItemList;
        private const string CharacterClassKey = "Character";
        private readonly Dictionary<int, GameObject> _characterGameObjects = new();
        private readonly CancellationTokenSource _cancellationTokenSource = new();
        public Dictionary<int, GameObject> CharacterGameObjects => _characterGameObjects;
        private CancellationTokenSource _cts;
        private static readonly int ModifiedValue = 10;

        public List<CatalogItem> CatalogItemList => _catalogItemList;

        public PlayFabCatalogManager()
        {
            _catalog = new Catalog();
        }

        public async UniTask Initialize(List<CatalogItem> catalogItems)
        {
            foreach (var item in catalogItems)
            {
                if (item.ItemClass != CharacterClassKey)
                {
                    continue;
                }

                var customData = JsonConvert.DeserializeObject<CharacterData>(item.CustomData);
                if (customData == null)
                {
                    continue;
                }

                var characterData = new CharacterData
                {
                    CharaObj = customData.CharaObj,
                    Team = customData.Team,
                    Level = customData.Level,
                    Name = customData.Name,
                    ID = customData.ID,
                    Speed = customData.Speed,
                    BombLimit = customData.BombLimit / ModifiedValue,
                    Attack = customData.Attack,
                    FireRange = customData.FireRange / ModifiedValue,
                    Hp = customData.Hp,
                    CharaColor = customData.CharaColor
                };
                _catalog.SetCharacter(customData.ID, characterData);
                await LoadGameObject(LabelData.CharacterPrefabPath, customData.ID,
                        _cancellationTokenSource.Token)
                    .AttachExternalCancellation(_cancellationTokenSource.Token);
            }
        }

        public async UniTask<List<CatalogItem>> GetCatalogItems()
        {
            var response = await PlayFabClientAPI.GetCatalogItemsAsync(new GetCatalogItemsRequest());
            if (response.Error != null)
            {
                Debug.Log(response.Error.GenerateErrorReport());
                return null;
            }

            return _catalogItemList = response.Result.Catalog;
        }

        private async UniTask LoadGameObject(string path, int id, CancellationToken token)
        {
            var charaObj = _catalog.GetCharacterData(id).CharaObj;
            if (charaObj == null)
            {
                return;
            }

            var resource = await Resources.LoadAsync<GameObject>(path + charaObj)
                .WithCancellation(token);
            _characterGameObjects[id] = (GameObject)resource;
        }


        public CharacterData GetCharacterData(int id)
        {
            return _catalog.GetCharacterData(id);
        }

        public async UniTask<Sprite> LoadCharacterSprite(int id, CancellationToken token)
        {
            var response = await Resources.LoadAsync<Sprite>(LabelData.CharacterSpritePath + id)
                .WithCancellation(token);
            return (Sprite)response;
        }

        public async UniTask<Sprite> LoadCharacterColor(int id, CancellationToken token)
        {
            var resource = await Resources.LoadAsync<Sprite>(LabelData.CharacterColorPath + id)
                .WithCancellation(token);
            return (Sprite)resource;
        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            _catalog.Dispose();
        }
    }
}