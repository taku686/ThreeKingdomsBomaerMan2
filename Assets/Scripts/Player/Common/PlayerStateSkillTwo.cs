namespace Player.Common
{
    public partial class PlayerCore
    {
        public class PlayerSpecialSkillState : PlayerSkillStateBase
        {
            protected override void Initialize()
            {
                base.Initialize();
                var index = _PhotonView.OwnerActorNr;
                var weaponData = _PhotonNetworkManager.GetWeaponData(index);
                var specialSkillData = weaponData.SpecialSkillMasterData;
                _ActiveSkillManager.ActivateSkill(specialSkillData);
            }
        }
    }
}