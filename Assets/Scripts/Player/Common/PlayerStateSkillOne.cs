using Common.Data;

namespace Player.Common
{
    public partial class PlayerCore
    {
        public class PlayerNormalSkillState : PlayerSkillStateBase
        {
            protected override void Initialize()
            {
                base.Initialize();
                var playerKey = Owner.GetPlayerKey();
                var weaponData = _PhotonNetworkManager.GetWeaponData(playerKey);
                _SkillMasterData = weaponData.NormalSkillMasterData;
                _ActiveSkillManager.ActivateSkill(_SkillMasterData);
            }
        }
    }
}