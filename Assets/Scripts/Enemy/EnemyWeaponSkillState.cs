using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Manager.NetworkManager;
using Photon.Pun;
using UnityEngine;
using State = StateMachine<Enemy.EnemyCore>.State;

namespace Enemy
{
    public partial class EnemyCore
    {
        public class EnemyWeaponSkillState : State
        {
            protected override void OnEnter(State prevState)
            {
             
            }
            
            /*private void ActiveSkill
            (
                SkillMasterData skillMasterData,
                CancellationTokenSource cancellationTokenSource
            )
            {
                PlayBackAnimation(skillMasterData);
                var playerIndex = _playerConditionInfo.GetPlayerIndex();
                var dic = new Dictionary<int, int> { { playerIndex, skillMasterData.Id } };
                PhotonNetwork.LocalPlayer.SetSkillData(dic);
                Cancel(cancellationTokenSource);
            }

            private void PlayBackAnimation(SkillMasterData skillMasterData)
            {
                if (skillMasterData._SkillActionTypeEnum == SkillActionType.None)
                {
                    return;
                }

                _animator.SetTrigger(GameCommonData.GetAnimatorHashKey(skillMasterData._SkillActionTypeEnum));
            }*/

            private static void Cancel(CancellationTokenSource cancellationTokenSource)
            {
                cancellationTokenSource?.Cancel();
                cancellationTokenSource?.Dispose();
            }
        }
    }
}