using System;
using Common.Data;
using Manager.DataManager;
using Manager.NetworkManager;
using Zenject;

namespace UI.Title
{
    public class CharacterSelectViewModelUseCase : IDisposable
    {
        private readonly UserDataRepository _userDataRepository;
        private readonly CharacterMasterDataRepository _characterMasterDataRepository;
        private readonly TemporaryCharacterRepository _temporaryCharacterRepository;

        [Inject]
        public CharacterSelectViewModelUseCase
        (
            UserDataRepository userDataRepository,
            CharacterMasterDataRepository characterMasterDataRepository,
            TemporaryCharacterRepository temporaryCharacterRepository
        )
        {
            _userDataRepository = userDataRepository;
            _characterMasterDataRepository = characterMasterDataRepository;
            _temporaryCharacterRepository = temporaryCharacterRepository;
        }

        public CharacterSelectView.ViewModel InAsTask()
        {
            var availableAmount = _userDataRepository.GetAvailableCharacterAmount();
            var totalAmount = _characterMasterDataRepository.GetAllCharacterAmount();
            var orderType = _temporaryCharacterRepository.GetOrderType();
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