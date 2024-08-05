using System;
using System.Collections.Generic;
using System.Threading;
using Common.Data;
using PlayFab.ClientModels;
using Zenject;
using Random = UnityEngine.Random;

namespace Manager.DataManager
{
    public class CharacterDataManager : IDisposable
    {
        [Inject] private MainManager mainManager;
        private UserDataManager userDataManager;
        private static readonly Dictionary<int, CharacterData> CharacterDatum = new();

        public void Initialize(UserDataManager dataManager, CancellationToken cancellationToken)
        {
            if (mainManager.isInitialize)
            {
                return;
            }

            userDataManager = dataManager;
        }

        public void SetCharacterData(CharacterData characterData)
        {
            CharacterDatum[characterData.Id] = characterData;
        }

        public CharacterData GetCharacterData(int id)
        {
            return CharacterDatum[id];
        }

        public int GetAllCharacterAmount()
        {
            return CharacterDatum.Count;
        }

        public CharacterData GetUserEquippedCharacterData()
        {
            return GetCharacterData(userDataManager.GetUserData().EquipCharacterId);
        }

        public void Dispose()
        {
        }

        public CharacterData DebugGetCharacterData()
        {
            var characterData = new CharacterData()
            {
                Hp = 100,
                Speed = 100,
                BombLimit = 10,
                Attack = 100,
                FireRange = 10
            };
            return characterData;
        }
    }
}