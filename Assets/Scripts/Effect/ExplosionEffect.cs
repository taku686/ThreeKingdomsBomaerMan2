using UnityEngine;

namespace Effect
{
    public class ExplosionEffect : MonoBehaviour
    {
        [SerializeField] private GameObject effect;
        private int _ownerId;
        private int _takeDamagePlayerId;
        private int _damageAmount;
    }
}