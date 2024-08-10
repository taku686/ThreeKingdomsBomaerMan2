using System;
using Common.Data;
using Manager.DataManager;
using Zenject;

namespace UI.Title
{
    public class CharacterSelectViewModelUseCase : IDisposable
    {
        private readonly UserDataRepository userDataRepository;
        private readonly CharacterMasterDataRepository characterMasterDataRepository;
        private readonly CharacterSelectRepository characterSelectRepository;

        [Inject]
        public CharacterSelectViewModelUseCase
        (
            UserDataRepository userDataRepository,
            CharacterMasterDataRepository characterMasterDataRepository,
            CharacterSelectRepository characterSelectRepository
        )
        {
            this.userDataRepository = userDataRepository;
            this.characterMasterDataRepository = characterMasterDataRepository;
            this.characterSelectRepository = characterSelectRepository;
        }

        public CharacterSelectView.ViewModel InAsTask()
        {
            var availableAmount = userDataRepository.GetAvailableCharacterAmount();
            var totalAmount = characterMasterDataRepository.GetAllCharacterAmount();
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