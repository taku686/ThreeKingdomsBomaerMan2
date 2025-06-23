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
        private PlayerCore.PlayerStatusInfo _playerStatusInfo;
        private int _maxBombLimit;
        private int _currentBombLimit;


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

        public PlayerCore.PlayerStatusInfo InitializeStatus()
        {
            var statusSkillDatum = _weaponData.StatusSkillMasterDatum;
            var characterId = _characterData.Id;
            var hp = 0;
            var attack = 0;
            var speed = 0f;
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
                fireRange = _applyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.FireRange,
                    _levelData);
                bombLimit = _applyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.BombLimit,
                    _levelData);
                defense = _applyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Defense,
                    _levelData);
                resistance =
                    _applyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Resistance, _levelData);
            }

            hp = (int)TranslateStatusValueForBattle(StatusType.Hp, hp);
            speed = TranslateStatusValueForBattle(StatusType.Speed, speed);
            _currentBombLimit = 0;
            _maxBombLimit = (int)TranslateStatusValueForBattle(StatusType.BombLimit, bombLimit);
            attack = (int)TranslateStatusValueForBattle(StatusType.Attack, attack);
            defense = (int)TranslateStatusValueForBattle(StatusType.Defense, defense);
            resistance = (int)TranslateStatusValueForBattle(StatusType.Resistance, resistance);
            fireRange = (int)TranslateStatusValueForBattle(StatusType.FireRange, fireRange);

            return new PlayerCore.PlayerStatusInfo
            (
                hp,
                speed,
                hp,
                attack,
                defense,
                resistance,
                fireRange,
                _maxBombLimit
            );
        }

        public float TranslateStatusValueForBattle(StatusType statusType, float value)
        {
            switch (statusType)
            {
                case StatusType.Hp:
                    return value;
                case StatusType.Attack:
                    return value;
                case StatusType.Speed:
                    return Mathf.Sqrt(value * 0.1f);
                case StatusType.BombLimit:
                    return value;
                case StatusType.FireRange:
                    value = Mathf.FloorToInt(value / 2f);
                    return value;
                case StatusType.Defense:
                    return value / 2f;
                case StatusType.Resistance:
                    return value;
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

        public class Factory : PlaceholderFactory<CharacterData, WeaponMasterData, LevelMasterData,
            TranslateStatusInBattleUseCase>
        {
        }
    }
}