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
        protected CancellationTokenSource _cts;
        private bool _isHitAttack;

        public static bool IsObstaclesTag(GameObject hitObject)
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

            _isHitAttack = true;
            var statusInfo = hitPlayer.GetComponent<PlayerConditionInfo>();
            var playerIndex = statusInfo.GetPlayerIndex();
            var dic = new Dictionary<int, int> { { playerIndex, skillId } };
            PhotonNetwork.LocalPlayer.SetHitAttackData(dic);
        }

        protected void SetupParticleSystem(GameObject effect)
        {
            var particleSystems = effect.GetComponentsInChildren<ParticleSystem>();
            foreach (var particleSystem in particleSystems)
            {
                var main = particleSystem.main;
                main.stopAction = ParticleSystemStopAction.Destroy;
            }
        }

        protected void Cancel()
        {
            if (_cts == null)
            {
                return;
            }

            _cts.Cancel();
            _cts.Dispose();
            _cts = null;
        }
    }
}