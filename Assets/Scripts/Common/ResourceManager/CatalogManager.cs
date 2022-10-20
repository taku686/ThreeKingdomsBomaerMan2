using System.Threading;
using Assets.Scripts.Common.Data;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.ResourceManager;
using Newtonsoft.Json;
using PlayFab.ClientModels;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Common.ResourceManager
{
    public class CatalogManager : MonoBehaviour, ILoadResource
    {
        private readonly Catalog _catalog;
        private const string ObjKey = "charaObj";

        public CatalogManager(Catalog catalog, User user)
        {
            _catalog = catalog;
            
          //  _user = user;
        }

        public UniTask<GameObject> LoadGameObject(string path, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }

        public async UniTask<GameObject> LoadGameObject(string path, int id, CancellationToken token)
        {
            var customData = JsonConvert.DeserializeObject<CharacterData>(_catalog.Characters[id].CustomData);
            if (customData != null)
            {
                var resource = await Resources.LoadAsync<GameObject>(path + customData.CharaObj)
                    .WithCancellation(token);
                return (GameObject)resource;
            }
            else
            {
                return null;
            }
        }

        public UniTask<GameObject> LoadGameObject(int id, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }

        public UniTask<CharacterData> LoadCharacterData(int id, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }

        public CatalogItem LoadCatalogItem(int id, CancellationToken token)
        {
            return _catalog.Characters[id];
        }

        public UniTask<UserData> LoadUserData(CancellationToken token)
        {
            throw new System.NotImplementedException();
        }

        /*public User GetUser(CancellationToken token)
        {
            return _user;
        }*/

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
    }
}