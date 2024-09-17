using Bomb;
using Manager.BattleManager;
using UI.Common;
using UnityEngine;
using Zenject;

namespace Common.Installer
{
    public class BattleSceneInstaller : MonoInstaller<BattleSceneInstaller>
    {
        [SerializeField] private GameObject playerManagerGameObject;
        [SerializeField] private GameObject bombProviderGameObject;
        [SerializeField] private GameObject buttonsGameObject;

        public override void InstallBindings()
        {
            //Manager
            Container.Bind<PlayerGeneratorUseCase>().FromComponentOn(playerManagerGameObject).AsCached();
            Container.Bind<BombProvider>().FromComponentOn(bombProviderGameObject).AsCached();
            Container.Bind<InputView>().FromComponentOn(buttonsGameObject).AsCached();
            Container.Bind<WeaponCreateInBattleUseCase>().AsCached();
            Container.Bind<StatusInBattleViewModelUseCase>().AsCached();
        }
    }
}