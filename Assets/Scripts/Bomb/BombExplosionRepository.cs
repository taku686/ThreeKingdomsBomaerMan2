using Common.Data;
using UnityEngine;

namespace Bomb
{
    public class BombExplosionRepository : MonoBehaviour
    {
        [SerializeField] private BombExplosionEffect[] _bombExplosionEffectPrefabs;

        public BombExplosionEffect Get(AbnormalCondition abnormalCondition)
        {
            foreach (var effect in _bombExplosionEffectPrefabs)
            {
                if (effect._AbnormalCondition == abnormalCondition)
                {
                    return effect;
                }
            }

            Debug.LogError($"No BombExplosionEffect found for AbnormalCondition: {abnormalCondition}");
            return null;
        }
    }
}