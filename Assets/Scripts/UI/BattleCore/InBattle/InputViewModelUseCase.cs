using System;
using Manager.NetworkManager;
using UI.Common;
using Zenject;

namespace Manager.BattleManager
{
    public class InputViewModelUseCase : IDisposable
    {
        private readonly PhotonNetworkManager _photonNetworkManager;

        [Inject]
        public InputViewModelUseCase
        (
            PhotonNetworkManager photonNetworkManager
        )
        {
            _photonNetworkManager = photonNetworkManager;
        }

        public InputView.ViewModel InAsTask(int playerKey)
        {
            var characterData = _photonNetworkManager.GetCharacterData(playerKey);
            var weaponData = _photonNetworkManager.GetWeaponData(playerKey);
            var canChangeCharacter = _photonNetworkManager.CanChangeCharacter();
            var weaponSkill = weaponData.NormalSkillMasterData;
            var normalSkill = characterData._NormalSkillMasterData;
            var specialSkill = characterData._SpecialSkillMasterData;
            var currentLevelData = _photonNetworkManager.GetLevelMasterData(playerKey);

            return new InputView.ViewModel
            (
                normalSkill,
                specialSkill,
                weaponSkill,
                currentLevelData,
                canChangeCharacter
            );
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}