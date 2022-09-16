using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "CharacterData")]
public class CharacterData : ScriptableObject
{
    public GameObject _charaObj;
    public string _name;
    public int _number;
    public int _speed;
    public int _bombLimit;
    public int _attack;
    public int _firePower;
    public int _hp;
    public Color _charaColor;

    public GameObject CharaObj => _charaObj;
    public string Name => _name;
    public int Number => _number;
    public int Speed => _speed;
    public int BombLimit => _bombLimit;
    public int Attack => _attack;
    public int FirePower => _firePower;
    public int Hp => _hp;
    public Color CharaColor => _charaColor;
}