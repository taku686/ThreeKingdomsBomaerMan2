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
        private readonly CharacterSelectRepository characterSelectRepository;

        [Inject]
        public CharacterSelectViewModelUseCase
        (
            UserDataManager userDataManager,
            CharacterDataManager characterDataManager,
            CharacterSelectRepository characterSelectRepository
        )
        {
            this.userDataManager = userDataManager;
            this.characterDataManager = characterDataManager;
            this.characterSelectRepository = characterSelectRepository;
        }

        public CharacterSelectView.ViewModel InAsTask()
        {
            var availableAmount = userDataManager.GetAvailableCharacterAmount();
            var totalAmount = characterDataManager.GetAllCharacterAmount();
            var orderType = characterSelectRepository.GetOrderType();
            return new CharacterSelectView.ViewModel
            (
                availableAmount,
                totalAmount,
                orderType
            );
        }

        public void Dispose()
        {
        }
    }
}