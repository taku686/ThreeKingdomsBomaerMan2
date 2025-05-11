using AttributeAttack;
using UnityEngine;
using Zenject;

namespace Skill.Attack
{
    public class NormalSlash : IAttackBehaviour
    {
        public void Attack()
        {
            Debug.Log("Normal Attack");
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }

        public class Factory : PlaceholderFactory<NormalSlash>
        {
        }
    }
}