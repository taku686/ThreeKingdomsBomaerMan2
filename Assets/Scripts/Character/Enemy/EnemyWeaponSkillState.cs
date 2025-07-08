using System.Collections.Generic;
using Manager.NetworkManager;
using Photon.Pun;
using State = StateMachine<Enemy.EnemyCore>.State;

namespace Enemy
{
    public partial class EnemyCore
    {
        public class EnemyWeaponSkillState : EnemySkillStateBase
        {
            protected override void OnEnter(State prevState)
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