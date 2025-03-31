using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using PlayFab.ClientModels;
using UnityEngine;

namespace Manager.ResourceManager
{
    public class ResourceManager : ILoadResource
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

        public UserData GetUser(CancellationToken token)
        {
            throw new System.NotImplementedException();
        }


        public async UniTask<Sprite> LoadCharacterSprite(int id, CancellationToken token)
        {
            var resource = await Resources.LoadAsync<Sprite>(GameCommonData.CharacterSpritePath + id)
                .WithCancellation(token);
            return (Sprite)resource;
        }

        public async UniTask<Sprite> LoadUserIconSprite(string fileName)
        {
            var path = string.IsNullOrEmpty(fileName) ? GameCommonData.UserIconSpritePath + "default" : GameCommonData.UserIconSpritePath + fileName;
            var resource = await Resources.LoadAsync<Sprite>(path);
            return (Sprite)resource;
        }

        public async UniTask<Sprite> LoadCharacterColor(int id, CancellationToken token)
        {
            var resource = await Resources.LoadAsync<Sprite>(GameCommonData.CharacterColorPath + id)
                .WithCancellation(token);
            return (Sprite)resource;
        }

        public async UniTask<Sprite> LoadRewardSprite(GameCommonData.RewardType rewardType, CancellationToken token)
        {
            var resource = await Resources.LoadAsync<Sprite>(GameCommonData.RewardSpritePath + (int)rewardType)
                .WithCancellation(token);
            return (Sprite)resource;
        }

        public void Dispose()
        {
        }
    }
}