using Common.Data;
using UnityEngine;

namespace Effect
{
    public class AttributeBombEffect : MonoBehaviour
    {
        [SerializeField] private AbnormalCondition _abnormalCondition;
        public AbnormalCondition _AbnormalCondition => _abnormalCondition;
    }
}