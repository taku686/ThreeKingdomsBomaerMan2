using System;
using Common.Data;
using Zenject;

namespace UI.Title
{
    public class TeamStatusGridViewModelUseCase : IDisposable
    {
        private readonly StatusSpriteManager _statusSpriteManager;

        [Inject]
        public TeamStatusGridViewModelUseCase(StatusSpriteManager statusSpriteManager)
        {
            _statusSpriteManager = statusSpriteManager;
        }

        public TeamStatusGridView.ViewModel InAsTask(StatusType statusType, int statusValue)
        {
            var (iconSprite, iconColor) = _statusSpriteManager.GetStatusSprite(statusType);
            return new TeamStatusGridView.ViewModel(statusType, statusValue, iconSprite, iconColor);
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}