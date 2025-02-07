using System;
using Common.Data;
using Zenject;

namespace UI.TitleCore.UserInfoState
{
    public class UserInfoViewModelUseCase : IDisposable
    {
        private readonly UserDataRepository _userDataRepository;

        [Inject]
        public UserInfoViewModelUseCase
        (
            UserDataRepository userDataRepository
        )
        {
            _userDataRepository = userDataRepository;
        }

        public UserInfoView.ViewModel InAsTask()
        {
            var userData = _userDataRepository.GetUserData();
            var userName = userData.Name;
            var userIcon = _userDataRepository.GetUserIconSprite();
            return new UserInfoView.ViewModel(userName, userIcon);
        }


        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}