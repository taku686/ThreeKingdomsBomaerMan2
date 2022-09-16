using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Interface
{
    public interface IPlayerMove
    {
        public void Initialize();
        public UniTaskVoid Move(Vector3 direction);
    }
}