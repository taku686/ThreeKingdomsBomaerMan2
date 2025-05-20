using System;
using Manager.NetworkManager;
using Photon.Pun;
using UI.Common;
using UnityEngine;
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
            var weaponData = _photonNetworkManager.GetWeaponData(playerKey);
            var normalSkill = weaponData.NormalSkillMasterData;
            var specialSkill = weaponData.SpecialSkillMasterData;
            var currentLevelData = _photonNetworkManager.GetLevelMasterData(playerKey);

            return new InputView.ViewModel
            (
                normalSkill,
                specialSkill,
                currentLevelData
            );
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}