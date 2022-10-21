using UnityEngine;

namespace Common.Data
{
    public class CharacterData
    {
        [SerializeField] private string _charaObj;
        [SerializeField] private bool _isLock;
        [SerializeField] private string _name;
        [SerializeField] private int _id;
        [SerializeField] private int _speed;
        [SerializeField] private int _bombLimit;
        [SerializeField] private int _attack;
        [SerializeField] private int _fireRange;
        [SerializeField] private int _hp;
        [SerializeField] private string _charaColor;

        public string CharaObj
        {
            get => _charaObj;
            set => _charaObj = value;
        }

        public bool IsLock
        {
            get => _isLock;
            set => _isLock = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int ID
        {
            get => _id;
            set => _id = value;
        }

        public int Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public int BombLimit
        {
            get => _bombLimit;
            set => _bombLimit = value;
        }

        public int Attack
        {
            get => _attack;
            set => _attack = value;
        }

        public int FireRange
        {
            get => _fireRange;
            set => _fireRange = value;
        }

        public int Hp
        {
            get => _hp;
            set => _hp = value;
        }


        public string CharaColor
        {
            get => _charaColor;
            set => _charaColor = value;
        }
    }
}