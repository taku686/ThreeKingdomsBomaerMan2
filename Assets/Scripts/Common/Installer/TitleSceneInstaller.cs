using UI.Title.MainTitle;
using UnityEngine;
using Zenject;

namespace Common.Installer
{
    public class TitleSceneInstaller : MonoInstaller<BattleSceneInstaller>
    {
        public override void InstallBindings()
        {
            //Model
            Container.Bind<TitleModel>().AsCached();
        }
    }
}