using System;
using Common.Data;
using Manager.DataManager;
using Zenject;

namespace UI.Title
{
    public class CharacterSelectViewModelUseCase : IDisposable
    {
        private readonly UserDataManager userDataManager;
        private readonly CharacterDataRepository characterDataRepository;
        private readonly CharacterSelectRepository characterSelectRepository;

        [Inject]
        public CharacterSelectViewModelUseCase
        (
            UserDataManager userDataManager,
            CharacterDataRepository characterDataRepository,
            CharacterSelectRepository characterSelectRepository
        )
        {
            this.userDataManager = userDataManager;
            this.characterDataRepository = characterDataRepository;
            this.characterSelectRepository = characterSelectRepository;
        }

        public CharacterSelectView.ViewModel InAsTask()
        {
            var availableAmount = userDataManager.GetAvailableCharacterAmount();
            var totalAmount = characterDataRepository.GetAllCharacterAmount();
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