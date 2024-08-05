using System;
using Common.Data;
using Manager.DataManager;
using Zenject;

namespace UI.Title
{
    public class CharacterSelectViewModelUseCase : IDisposable
    {
        private readonly UserDataManager userDataManager;
        private readonly CharacterDataManager characterDataManager;

        [Inject]
        public CharacterSelectViewModelUseCase
        (
            UserDataManager userDataManager,
            CharacterDataManager characterDataManager
        )
        {
            this.userDataManager = userDataManager;
            this.characterDataManager = characterDataManager;
        }

        public CharacterSelectView.ViewModel InAsTask()
        {
            var availableAmount = userDataManager.GetAvailableCharacterAmount();
            var totalAmount = characterDataManager.GetAllCharacterAmount();

            return new CharacterSelectView.ViewModel
            (
                availableAmount,
                totalAmount
            );
        }

        public void Dispose()
        {
        }
    }
}