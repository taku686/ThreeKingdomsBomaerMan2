using System;
using UnityEngine;

namespace Bomb
{
    public abstract class BombDataBase : MonoBehaviour, IDisposable
    {
        [SerializeField] protected ParticleSystem explosionEffect;
        protected int damageAmount;
        protected int fireRange;
        protected int playerId;

        public void Dispose()
        {
        }
    }
}