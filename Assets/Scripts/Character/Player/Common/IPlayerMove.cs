using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Player.Common
{
    public interface IPlayerMove
    {
        public void Initialize(float moveSpeed);
        public UniTaskVoid Move(Vector3 direction);
        public UniTask Rotate(Vector3 direction);
        public void AnimationMove(Vector3 direction);
    }
}