using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Manager.ResourceManager
{
    public interface ILoadResource
    {
        public UniTask<GameObject> LoadGameObject(string path, CancellationToken token);
        public UniTask<CharacterData> LoadCharacterData(string path, CancellationToken token);
    }
}