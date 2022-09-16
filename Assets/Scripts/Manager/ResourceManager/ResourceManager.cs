using System.Threading;
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

        public async UniTask<CharacterData> LoadCharacterData(string path, CancellationToken token)
        {
            var resource = await Resources.LoadAsync<CharacterData>(path).WithCancellation(token);
            return (CharacterData)resource;
        }
    }
}