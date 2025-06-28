using System.Collections.Generic;
using Manager.NetworkManager;
using Photon.Pun;

namespace Player.Common
{
    public partial class PlayerCore
    {
        public class PlayerSpecialSkillState : PlayerSkillStateBase
        {
            protected override void Initialize()
            {
                base.Initialize();
                var playerKey = Owner.GetPlayerKey();
                var characterData = _PhotonNetworkManager.GetCharacterData(playerKey);
                _skillMasterData = characterData._SpecialSkillMasterData;
                SetupAnimation(_skillMasterData);
                var playerIndex = _PlayerConditionInfo.GetPlayerIndex();
                var dic = new Dictionary<int, int> { { playerIndex, _skillMasterData.Id } };
                PhotonNetwork.LocalPlayer.SetSkillData(dic);
            }
        }
    }
}