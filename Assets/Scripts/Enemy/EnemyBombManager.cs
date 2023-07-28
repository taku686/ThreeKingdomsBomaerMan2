using System.Collections;
using System.Collections.Generic;
using Bomb;
using UnityEngine;

public class EnemyBombManager : MonoBehaviour
{
    private readonly List<BombBase> _bombList = new();

    public void AddBomb(BombBase bomb)
    {
        _bombList.Add(bomb);
    }

    public void RemoveBomb(BombBase bomb)
    {
        _bombList.Remove(bomb);
    }

    public int GetBombCount()
    {
        return _bombList.Count;
    }
}