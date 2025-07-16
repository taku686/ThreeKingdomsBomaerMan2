using Common.Data;
using UnityEngine;

namespace Bomb
{
    public class BombExplosionEffect : MonoBehaviour
    {
        [SerializeField] private AbnormalCondition _abnormalCondition;

        public AbnormalCondition _AbnormalCondition => _abnormalCondition;

        private void OnDisable()
        {
            Destroy(gameObject);
        }
    }
}