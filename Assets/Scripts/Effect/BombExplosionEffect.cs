using System;
using Common.Data;
using UnityEngine;

namespace Bomb
{
    public class BombExplosionEffect : MonoBehaviour
    {
        [SerializeField] private AbnormalCondition _abnormalCondition;
        [SerializeField] private Explosion _explosion;
        public AbnormalCondition _AbnormalCondition => _abnormalCondition;

        private void OnDisable()
        {
            Destroy(gameObject);
        }

        public void SetDamage(int damage)
        {
            if (_explosion != null)
            {
                _explosion._damageAmount = damage;
            }
            else
            {
                Debug.LogError("Explosion component is not assigned in BombExplosionEffect.");
            }
        }
    }
}