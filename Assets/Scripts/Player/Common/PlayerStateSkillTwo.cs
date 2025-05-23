using Common.Data;

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
                var weaponData = _PhotonNetworkManager.GetWeaponData(playerKey);
                _SkillMasterData = weaponData.SpecialSkillMasterData;
                _ActiveSkillManager.ActivateSkill(_SkillMasterData);
            }
        }
    }
}