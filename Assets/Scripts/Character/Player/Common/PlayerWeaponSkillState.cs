using System.Collections.Generic;
using Manager.NetworkManager;
using Photon.Pun;

namespace Player.Common
{
    public partial class PlayerCore
    {
        public class PlayerWeaponSkillState : PlayerSkillStateBase
        {
            protected override void Initialize()
            {
                base.Initialize();
                var playerKey = Owner.GetPlayerKey();
                var weaponData = _PhotonNetworkManager.GetWeaponData(playerKey);
                _SkillMasterData = weaponData.NormalSkillMasterData;
                SetupAnimation(_SkillMasterData);
                var playerIndex = _PlayerConditionInfo.GetPlayerIndex();
                var dic = new Dictionary<int, int> { { playerIndex, _SkillMasterData.Id } };
                PhotonNetwork.LocalPlayer.SetSkillData(dic);
            }
        }
    }
}