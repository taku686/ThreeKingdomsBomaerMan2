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
                var index = _PhotonView.OwnerActorNr;
                var weaponData = _PhotonNetworkManager.GetWeaponData(index);
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