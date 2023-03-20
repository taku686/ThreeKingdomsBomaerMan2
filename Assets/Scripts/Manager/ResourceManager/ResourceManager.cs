using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.ResourceManager;
using PlayFab.ClientModels;
using UnityEngine;

namespace Manager.ResourceManager
{
    public class ResourceManager : MonoBehaviour, ILoadResource
    {
        public async UniTask<GameObject> LoadGameObject(string path, CancellationToken token)
        {
            var resource = await Resources.LoadAsync<GameObject>(path).WithCancellation(token);
            return (GameObject)resource;
        }

        public UniTask<GameObject> LoadGameObject(string path, int id, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }

        public CharacterData LoadCharacterData(int id)
        {
            throw new System.NotImplementedException();
        }

        public UniTask<GameObject> LoadGameObject(int id, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }

        public CatalogItem LoadCatalogItem(int id, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }

        public User GetUser(CancellationToken token)
        {
            throw new System.NotImplementedException();
        }


        public async UniTask<Sprite> LoadCharacterSprite(int id, CancellationToken token)
        {
            var resource = await Resources.LoadAsync<Sprite>(LabelData.CharacterSpritePath + id)
                .WithCancellation(token);
            return (Sprite)resource;
        }

        public async UniTask<Sprite> LoadCharacterColor(int id, CancellationToken token)
        {
            var resource = await Resources.LoadAsync<Sprite>(LabelData.CharacterColorPath + id)
                .WithCancellation(token);
            return (Sprite)resource;
        }
    }
}