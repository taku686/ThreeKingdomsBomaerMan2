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
                var characterData = _PhotonNetworkManager.GetCharacterData(playerKey);
                _SkillMasterData = characterData._NormalSkillMasterData;
                _ActiveSkillManager.ActivateSkill(_SkillMasterData);
            }
        }
    }
}