using System;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using PlayFab.ClientModels;
using UnityEngine;

namespace Manager.ResourceManager
{
    public interface ILoadResource : IDisposable
    {
        public UniTask<GameObject> LoadGameObject(string path, CancellationToken token);
        public UniTask<GameObject> LoadGameObject(string path, int id, CancellationToken token);
        public CharacterData LoadCharacterData(int id);
        public CatalogItem LoadCatalogItem(int id, CancellationToken token);
        public UniTask<Sprite> LoadCharacterSprite(int id, CancellationToken token);
        public UniTask<Sprite> LoadCharacterColor(int id, CancellationToken token);
    }
}