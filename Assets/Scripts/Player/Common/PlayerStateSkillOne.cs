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
                var normalSkillData = weaponData.NormalSkillMasterData;
                _ActiveSkillManager.ActivateSkill(normalSkillData);
                if (normalSkillData._SkillActionTypeEnum == SkillActionType.None)
                {
                    _StateMachine.Dispatch((int)PLayerState.Idle);
                }
            }
        }
    }
}