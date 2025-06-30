using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Manager.NetworkManager;
using Photon.Pun;
using Player.Common;
using UnityEngine;

namespace Skill
{
    public class AttackSkillBase
    {
        protected CancellationTokenSource _Cts;
        private bool _isHitAttack;

        protected static bool IsObstaclesTag(GameObject hitObject)
        {
            return hitObject.CompareTag(GameCommonData.BushTag) ||
                   hitObject.CompareTag(GameCommonData.BreakingWallTag) ||
                   hitObject.CompareTag(GameCommonData.PlayerTag) ||
                   hitObject.CompareTag(GameCommonData.WallTag);
        }

        protected void HitPlayer(GameObject player, GameObject hitPlayer, int skillId)
        {
            var playerPhotonView = player.GetComponent<PhotonView>();
            var hitPlayerPhotonView = hitPlayer.GetComponent<PhotonView>();
            if (hitPlayerPhotonView == null || playerPhotonView == null)
            {
                return;
            }

            if (playerPhotonView.InstantiationId == hitPlayerPhotonView.InstantiationId)
            {
                return;
            }

            if (_isHitAttack)
            {
                return;
            }

            Debug.Log("HitPlayer: " + hitPlayer.name + " with skillId: " + skillId);
            _isHitAttack = true;
            var statusInfo = hitPlayer.GetComponent<PlayerConditionInfo>();
            var playerIndex = statusInfo.GetPlayerIndex();
            var dic = new Dictionary<int, int> { { playerIndex, skillId } };
            PhotonNetwork.LocalPlayer.SetHitAttackData(dic);
        }

        protected void Cancel()
        {
            if (_Cts == null)
            {
                return;
            }

            _Cts.Cancel();
            _Cts.Dispose();
            _Cts = null;
        }
    }
}