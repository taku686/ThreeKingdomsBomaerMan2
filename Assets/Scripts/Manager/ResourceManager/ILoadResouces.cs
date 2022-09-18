using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Manager.ResourceManager
{
    public interface ILoadResource
    {
        public UniTask<GameObject> LoadGameObject(string path, CancellationToken token);
        public UniTask<CharacterData> LoadCharacterData(int id, CancellationToken token);
        public UniTask<UserData> LoadUserData(CancellationToken token);
        public UniTask<Sprite> LoadCharacterSprite(int id, CancellationToken token);
    }
}