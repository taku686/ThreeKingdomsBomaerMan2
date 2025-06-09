using System;
using Common.Data;
using UnityEngine;
using Zenject;

namespace Player.Common
{
    public class TranslateStatusInBattleUseCase : IDisposable
    {
        private readonly CharacterData _characterData;
        private readonly WeaponMasterData _weaponData;
        private readonly LevelMasterData _levelData;
        private readonly ApplyStatusSkillUseCase _applyStatusSkillUseCase;
        private int _maxBombLimit;
        private int _currentBombLimit;
        public int _CurrentHp { get; set; }
        public int _MaxHp { get; private set; }
        public float _Speed { get; private set; }
        public int _Attack { get; private set; }
        public int _Defense { get; private set; }
        public int _Resistance { get; private set; }
        public int _FireRange { get; private set; }


        [Inject]
        public TranslateStatusInBattleUseCase
        (
            CharacterData characterData,
            WeaponMasterData weaponData,
            LevelMasterData levelData,
            ApplyStatusSkillUseCase applyStatusSkillUseCase
        )
        {
            _characterData = characterData;
            _weaponData = weaponData;
            _levelData = levelData;
            _applyStatusSkillUseCase = applyStatusSkillUseCase;
        }

        public void InitializeStatus()
        {
            var statusSkillDatum = _weaponData.StatusSkillMasterDatum;
            var characterId = _characterData.Id;
            var hp = 0;
            var attack = 0;
            var speed = 0;
            var bombLimit = 0;
            var fireRange = 0;
            var defense = 0;
            var resistance = 0;

            foreach (var statusSkillData in statusSkillDatum)
            {
                var skillId = statusSkillData.Id;
                hp = _applyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Hp, _levelData);
                speed = _applyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Speed, _levelData);
                attack = _applyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Attack, _levelData);
                fireRange = _applyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.FireRange, _levelData);
                bombLimit = _applyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.BombLimit, _levelData);
                defense = _applyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Defense, _levelData);
                resistance = _applyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Resistance, _levelData);
            }

            _CurrentHp = (int)TranslateStatusValueForBattle(StatusType.Hp, hp);
            _MaxHp = (int)TranslateStatusValueForBattle(StatusType.Hp, hp);
            _Speed = TranslateStatusValueForBattle(StatusType.Speed, speed);
            _currentBombLimit = 0;
            _maxBombLimit = (int)TranslateStatusValueForBattle(StatusType.BombLimit, bombLimit);
            _Attack = (int)TranslateStatusValueForBattle(StatusType.Attack, attack);
            _Defense = (int)TranslateStatusValueForBattle(StatusType.Defense, defense);
            _Resistance = (int)TranslateStatusValueForBattle(StatusType.Resistance, resistance);
            _FireRange = (int)TranslateStatusValueForBattle(StatusType.FireRange, fireRange);
        }

        public float TranslateStatusValueForBattle(StatusType statusType, int value)
        {
            switch (statusType)
            {
                case StatusType.Hp:
                    _MaxHp = value;
                    return _MaxHp;
                case StatusType.Attack:
                    _Attack = value;
                    return _Attack;
                case StatusType.Speed:
                    _Speed = Mathf.Sqrt(value * 0.1f);
                    return _Speed;
                case StatusType.BombLimit:
                    _maxBombLimit = value;
                    return _maxBombLimit;
                case StatusType.FireRange:
                    _FireRange = Mathf.FloorToInt(value / 2f);
                    return _FireRange;
                case StatusType.Defense:
                    return value / 2f;
                case StatusType.Resistance:
                    return _Resistance;
                case StatusType.None:
                default:
                    throw new ArgumentOutOfRangeException(nameof(statusType), statusType, null);
            }
        }

        public bool CanPutBomb()
        {
            return _currentBombLimit < _maxBombLimit;
        }

        public void IncrementBombCount()
        {
            _currentBombLimit++;
        }

        public void DecrementBombCount()
        {
            if (_currentBombLimit <= 0)
            {
                return;
            }

            _currentBombLimit--;
        }


        public void Dispose()
        {
        }

        public class Factory : PlaceholderFactory<CharacterData, WeaponMasterData, LevelMasterData, TranslateStatusInBattleUseCase>
        {
        }
    }
}