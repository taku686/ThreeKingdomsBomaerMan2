using System;
using Common.Data;
using Zenject;

namespace UI.Title
{
    public class SettingViewModelUseCase : IDisposable
    {
        private readonly UserDataRepository _userDataRepository;

        [Inject]
        public SettingViewModelUseCase(UserDataRepository userDataRepository)
        {
            _userDataRepository = userDataRepository;
        }

        public SettingPopup.ViewModel InAsTask()
        {
            var settingData = _userDataRepository.GetSettingData();
            return new SettingPopup.ViewModel
            (
                "",
                "",
                settingData
            );
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}