using Common.Data;
using Effect;
using UnityEngine;

namespace Bomb
{
    public class AttributeBombEffectRepository : MonoBehaviour
    {
        [SerializeField] private AttributeBombEffect[] _attributeBombEffects;

        public AttributeBombEffect Get(AbnormalCondition abnormalCondition)
        {
            foreach (var effect in _attributeBombEffects)
            {
                if (effect._AbnormalCondition == abnormalCondition)
                {
                    return effect;
                }
            }

            Debug.LogError($"No AttributeBombEffect found for AbnormalCondition: {abnormalCondition}");
            return null;
        }
    }
}