using Common.Data;
using UnityEngine;

namespace Manager.BattleManager.Environment
{
    public class BreakingWall : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(GameCommonData.BombEffectTag))
            {
                return;
            }

            Destroy(gameObject);
        }
    }
}