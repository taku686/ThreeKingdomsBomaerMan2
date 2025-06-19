using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Manager.NetworkManager;
using Photon.Pun;
using UnityEngine;

namespace Skill
{
    public class AttackSkillBase
    {
        protected CancellationTokenSource _Cts;

        protected static bool IsObstaclesTag(GameObject hitObject)
        {
            return hitObject.CompareTag(GameCommonData.BushTag) ||
                   hitObject.CompareTag(GameCommonData.BreakingWallTag) ||
                   hitObject.CompareTag(GameCommonData.PlayerTag) ||
                   hitObject.CompareTag(GameCommonData.WallTag);
        }

        protected static void HitPlayer(GameObject player, GameObject hitPlayer, int skillId)
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

            var statusInfo = hitPlayer.GetComponent<PlayerStatusInfo>();
            if (statusInfo == null)
            {
                return;
            }

            var playerIndex = statusInfo.GetPlayerIndex();
            var dic = new Dictionary<int, int> { { playerIndex, skillId } };
            PhotonNetwork.LocalPlayer.SetSkillData(dic);
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