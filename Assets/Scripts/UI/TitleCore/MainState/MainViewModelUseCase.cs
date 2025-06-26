using System;
using Common.Data;
using Repository;
using Zenject;

namespace UI.Title
{
    public class MainViewModelUseCase : IDisposable
    {
        private readonly WeaponCautionRepository _weaponCautionRepository;
        private readonly UserDataRepository _userDataRepository;

        [Inject]
        public MainViewModelUseCase
        (
            WeaponCautionRepository weaponCautionRepository,
            UserDataRepository userDataRepository
        )
        {
            _weaponCautionRepository = weaponCautionRepository;
            _userDataRepository = userDataRepository;
        }

        public MainView.ViewModel InAsTask()
        {
            var isInventoryCaution = _weaponCautionRepository.HaveCaution();
            var isMissionCaution = _userDataRepository.HaveClearMission();

            return new MainView.ViewModel
            (
                isInventoryCaution,
                isMissionCaution
            );
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}