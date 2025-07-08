using Common.Data;
using Cysharp.Threading.Tasks;

namespace Player.Common
{
    public interface IPlayerModelBase
    {
        public UniTaskVoid Initialize();

        public CharacterData CharacterData { get; }
    }
}