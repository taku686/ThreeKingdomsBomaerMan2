using System;
using UniRx;
using UnityEngine;

namespace Bomb
{
    public class NormalBomb : BombBase
    {
        protected override void Explosion()
        {
            Debug.Log("ノーマルボム爆発");
            OnExplosionSubject.OnNext(Unit.Default);
        }
    }
}