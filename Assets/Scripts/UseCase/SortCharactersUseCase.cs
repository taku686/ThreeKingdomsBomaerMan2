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
        private readonly UserDataManager userDataManager;

        public SortCharactersUseCase
        (
            UserDataManager userDataManager
        )
        {
            this.userDataManager = userDataManager;
        }

        public IReadOnlyCollection<CharacterData> InAsTask(CharacterSelectRepository.OrderType orderType)
        {
            var result = new List<CharacterData>();
            var characterDatum = userDataManager.GetAvailableCharacters();
            if (orderType == CharacterSelectRepository.OrderType.Id)
            {
                return characterDatum.OrderBy(data => data.Id).ToArray();
            }

            foreach (var characterData in characterDatum)
            {
                var level = userDataManager.GetCurrentLevelData(characterData.Id);
                var hp = Mathf.RoundToInt(level.StatusRate * characterData.Hp);
                var attack = Mathf.RoundToInt(level.StatusRate * characterData.Attack);
                var speed = Mathf.RoundToInt(level.StatusRate * characterData.Speed);
                var bomb = Mathf.RoundToInt(level.StatusRate * characterData.BombLimit);
                var fire = Mathf.RoundToInt(level.StatusRate * characterData.FireRange);
                var newCharacterData = new CharacterData()
                {
                    Id = characterData.Id,
                    Level = level.Level,
                    Hp = hp,
                    Attack = attack,
                    Speed = speed,
                    BombLimit = bomb,
                    FireRange = fire,
                    Name = characterData.Name,
                    SelfPortraitSprite = characterData.SelfPortraitSprite,
                    ColorSprite = characterData.ColorSprite,
                    SkillOneSprite = characterData.SkillOneSprite,
                    SkillTwoSprite = characterData.SkillTwoSprite,
                    WeaponEffectObj = characterData.WeaponEffectObj
                };
                result.Add(newCharacterData);
            }

            return result
                .OrderByDescending(data => TranslateOrderType(orderType, data))
                .ThenBy(data => data.Id)
                .ToArray();
        }

        private int TranslateOrderType(CharacterSelectRepository.OrderType orderType, CharacterData data)
        {
            return orderType switch
            {
                CharacterSelectRepository.OrderType.Id => data.Id,
                CharacterSelectRepository.OrderType.Level => data.Level,
                CharacterSelectRepository.OrderType.Hp => data.Hp,
                CharacterSelectRepository.OrderType.Attack => data.Attack,
                CharacterSelectRepository.OrderType.Speed => data.Speed,
                CharacterSelectRepository.OrderType.Bomb => data.BombLimit,
                CharacterSelectRepository.OrderType.Fire => data.FireRange,
                _ => 0
            };
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}