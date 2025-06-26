using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;
using UI.Title;
using UnityEngine;

namespace UseCase
{
    public class SortCharactersUseCase : IDisposable
    {
        private readonly UserDataRepository _userDataRepository;
        private readonly ApplyStatusSkillUseCase _applyStatusSkillUseCase;

        public SortCharactersUseCase
        (
            UserDataRepository userDataRepository,
            ApplyStatusSkillUseCase applyStatusSkillUseCase
        )
        {
            _userDataRepository = userDataRepository;
            _applyStatusSkillUseCase = applyStatusSkillUseCase;
        }

        public IReadOnlyCollection<CharacterData> InAsTask(TemporaryCharacterRepository.OrderType orderType)
        {
            var result = new List<CharacterData>();
            var characterDatum = _userDataRepository.GetAvailableCharacters();
            if (orderType == TemporaryCharacterRepository.OrderType.Id)
            {
                return characterDatum.OrderBy(data => data.Id).ToArray();
            }

            foreach (var characterData in characterDatum)
            {
                var level = _userDataRepository.GetCurrentLevelData(characterData.Id);
                var characterId = characterData.Id;
                var hp = _applyStatusSkillUseCase.ApplyLevelStatus(characterId, StatusType.Hp);
                var attack = _applyStatusSkillUseCase.ApplyLevelStatus(characterId, StatusType.Attack);
                var speed = _applyStatusSkillUseCase.ApplyLevelStatus(characterId, StatusType.Speed);
                var bomb = _applyStatusSkillUseCase.ApplyLevelStatus(characterId, StatusType.BombLimit);
                var fire = _applyStatusSkillUseCase.ApplyLevelStatus(characterId, StatusType.FireRange);
                var defense = _applyStatusSkillUseCase.ApplyLevelStatus(characterId, StatusType.Defense);
                var resistance = _applyStatusSkillUseCase.ApplyLevelStatus(characterId, StatusType.Resistance);
                var newCharacterData = new CharacterData
                {
                    Id = characterData.Id,
                    Level = level.Level,
                    Hp = hp,
                    Attack = attack,
                    Speed = speed,
                    BombLimit = bomb,
                    FireRange = fire,
                    Defense = defense,
                    Resistance = resistance,
                    Name = characterData.Name,
                    SelfPortraitSprite = characterData.SelfPortraitSprite,
                    ColorSprite = characterData.ColorSprite,
                    Type = characterData.Type,
                    Team = characterData.Team,
                };
                result.Add(newCharacterData);
            }

            return result
                .OrderByDescending(data => TranslateOrderType(orderType, data))
                .ThenBy(data => data.Id)
                .ToArray();
        }

        private static int TranslateOrderType(TemporaryCharacterRepository.OrderType orderType, CharacterData data)
        {
            return orderType switch
            {
                TemporaryCharacterRepository.OrderType.Id => data.Id,
                TemporaryCharacterRepository.OrderType.Level => data.Level,
                TemporaryCharacterRepository.OrderType.Hp => data.Hp,
                TemporaryCharacterRepository.OrderType.Attack => data.Attack,
                TemporaryCharacterRepository.OrderType.Speed => data.Speed,
                TemporaryCharacterRepository.OrderType.Bomb => data.BombLimit,
                TemporaryCharacterRepository.OrderType.Fire => data.FireRange,
                TemporaryCharacterRepository.OrderType.Defense => data.Defense,
                TemporaryCharacterRepository.OrderType.Resistance => data.Resistance,
                _ => 0
            };
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}