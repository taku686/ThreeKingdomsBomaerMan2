using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.ResourceManager;
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

        public async UniTask<CharacterData> LoadCharacterData(int id, CancellationToken token)
        {
            var resource = await Resources.LoadAsync<CharacterData>(LabelData.CharacterDataPath + id)
                .WithCancellation(token);
            return (CharacterData)resource;
        }

        public async UniTask<UserData> LoadUserData(CancellationToken token)
        {
            var resource = await Resources.LoadAsync<GameObject>(LabelData.UserDataPath).WithCancellation(token);
            return (UserData)resource;
        }

        public async UniTask<Sprite> LoadCharacterSprite(int id, CancellationToken token)
        {
            var resource = await Resources.LoadAsync<GameObject>(LabelData.CharacterSpritePath + id)
                .WithCancellation(token);
            return (Sprite)resource;
        }
    }
}