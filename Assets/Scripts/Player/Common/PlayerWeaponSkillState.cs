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
                var characterData = _PhotonNetworkManager.GetWeaponData(playerKey);
                _SkillMasterData = characterData.NormalSkillMasterData;
                _ActiveSkillManager.ActivateSkill(_SkillMasterData);
            }
        }
    }
}