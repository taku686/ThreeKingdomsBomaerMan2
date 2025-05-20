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
                var specialSkillData = weaponData.SpecialSkillMasterData;
                _ActiveSkillManager.ActivateSkill(specialSkillData);
                if (specialSkillData._SkillActionTypeEnum == SkillActionType.None)
                {
                    _StateMachine.Dispatch((int)PLayerState.Idle);
                }
            }
        }
    }
}