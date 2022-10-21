using System.Collections.Generic;
using System.Linq;
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
    public class CatalogManager : MonoBehaviour
    {
        private Catalog _catalog;
        private const string ObjKey = "charaObj";
        private const string IsLockKey = "isLock";
        private const string NameKey = "name";
        private const string IDKey = "id";
        private const string SpeedKey = "speed";
        private const string BombLimitKey = "bombLimit";
        private const string AttackKey = "attack";
        private const string FireRangeKey = "fireRange";
        private const string HpKey = "hp";
        private const string CharaColorKey = "charaColor";
        private const string CharacterClassKey = "Character";
        private readonly Dictionary<int, GameObject> _characterGameObjects = new Dictionary<int, GameObject>();

        public Dictionary<int, GameObject> CharacterGameObjects => _characterGameObjects;

        public async UniTask Initialize(List<CatalogItem> catalogItems)
        {
            _catalog = new Catalog();
            foreach (var item in catalogItems)
            {
                if (item.ItemClass != CharacterClassKey)
                {
                    continue;
                }

                var customData = JsonConvert.DeserializeObject<CharacterData[]>(item.CustomData);
                if (customData == null)
                {
                    continue;
                }

                var characterData = new CharacterData
                {
                    CharaObj = customData[0].CharaObj,
                    IsLock = customData[0].IsLock,
                    Name = customData[0].Name,
                    ID = customData[0].ID,
                    Speed = customData[0].Speed,
                    BombLimit = customData[0].BombLimit,
                    Attack = customData[0].Attack,
                    FireRange = customData[0].FireRange,
                    Hp = customData[0].Hp,
                };
                _catalog.Characters[customData[0].ID] = characterData;
                await LoadGameObject(LabelData.CharacterPrefabPath, customData[0].ID,
                        this.GetCancellationTokenOnDestroy())
                    .AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
            }
        }

        private async UniTask LoadGameObject(string path, int id, CancellationToken token)
        {
            var charaObj = _catalog.Characters[id].CharaObj;
            if (charaObj == null)
            {
                return;
            }

            var resource = await Resources.LoadAsync<GameObject>(path + charaObj)
                .WithCancellation(token);
            _characterGameObjects[id] = (GameObject)resource;
        }


        public CharacterData LoadCharacterData(int id)
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