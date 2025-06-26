using Assets.Scripts.Common.PlayFab;
using Manager.NetworkManager;
using UI.Common;
using Zenject;

namespace Installer
{
    public class LoginSceneInstaller : MonoInstaller<LoginSceneInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayFabLoginManager>().AsCached();
            Container.Bind<UIAnimation>().AsCached();
            Container.Bind<PlayFabShopManager>().AsCached();
        }
    }
}