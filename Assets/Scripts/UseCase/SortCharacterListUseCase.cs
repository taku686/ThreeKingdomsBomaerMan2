using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;
using UI.Title;
using UnityEngine;

namespace UseCase
{
    public class SortCharacterListUseCase : IDisposable
    {
        private readonly UserDataManager userDataManager;

        public SortCharacterListUseCase
        (
            UserDataManager userDataManager
        )
        {
            this.userDataManager = userDataManager;
        }

        public IReadOnlyCollection<CharacterData> InAsTask(CharacterSelectRepository.OrderType orderType)
        {
            var result = new List<CharacterData>();
            var characterDataArray = userDataManager.GetAvailableCharacters().ToArray();
            if (orderType == CharacterSelectRepository.OrderType.Id)
            {
                return characterDataArray.OrderBy(data => data.Id).ToArray();
            }


            foreach (var characterData in characterDataArray)
            {
                var level = userDataManager.GetCurrentLevelData(characterData.Id);
                switch (orderType)
                {
                    case CharacterSelectRepository.OrderType.Level:
                        characterData.Level = level.Level;
                        break;
                    case CharacterSelectRepository.OrderType.Hp:
                        characterData.Hp = Mathf.FloorToInt(level.StatusRate * characterData.Hp);
                        break;
                    case CharacterSelectRepository.OrderType.Attack:
                        characterData.Attack = Mathf.FloorToInt(level.StatusRate * characterData.Attack);
                        break;
                    case CharacterSelectRepository.OrderType.Speed:
                        characterData.Speed = Mathf.FloorToInt(level.StatusRate * characterData.Speed);
                        break;
                    case CharacterSelectRepository.OrderType.Bomb:
                        characterData.BombLimit = Mathf.FloorToInt(level.StatusRate * characterData.BombLimit);
                        break;
                    case CharacterSelectRepository.OrderType.Fire:
                        characterData.FireRange = Mathf.FloorToInt(level.StatusRate * characterData.FireRange);
                        break;
                    case CharacterSelectRepository.OrderType.Type:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(orderType), orderType, null);
                }

                result.Add(characterData);
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