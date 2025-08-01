﻿using Common.Data;
using UnityEngine;

namespace Bomb
{
    public class Explosion : MonoBehaviour
    {
        public Transform boxCollider;
        public Transform explosionTransform;
        public MoveDirection _explosionMoveDirection;
        public int damageAmount;
    }
}