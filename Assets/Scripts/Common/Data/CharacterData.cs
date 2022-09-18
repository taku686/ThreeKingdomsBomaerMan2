using UnityEngine;

namespace Common.Data
{
    [CreateAssetMenu(fileName = "Character", menuName = "CharacterData")]
    public class CharacterData : ScriptableObject
    {
        [SerializeField] private GameObject charaObj;
        [SerializeField] private bool isLock;
        [SerializeField] private string name;
        [SerializeField] private int id;
        [SerializeField] private int speed;
        [SerializeField] private int bombLimit;
        [SerializeField] private int attack;
        [SerializeField] private int fireRange;
        [SerializeField] private int hp;
        [SerializeField] private Color charaColor;

        public GameObject CharaObj => charaObj;
        public string Name => name;
        public int ID => id;
        public int Speed => speed;
        public int BombLimit => bombLimit;
        public int Attack => attack;
        public int FireRange => fireRange;
        public int Hp => hp;
        public Color CharaColor => charaColor;
        public bool IsLock => isLock;
    }
}