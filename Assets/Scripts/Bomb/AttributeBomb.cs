using UnityEngine;

namespace Bomb
{
    public class AttributeBomb : BombBase
    {
        [SerializeField] private BombExplosionRepository _bombExplosionRepository;
        private static readonly Vector3 EffectOriginPosition = new(0, 0f, 0);
    }
}