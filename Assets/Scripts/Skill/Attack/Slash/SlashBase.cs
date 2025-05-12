using System.Collections.Generic;
using System.Linq;
using AttributeAttack;
using Common.Data;
using Manager.NetworkManager;
using Photon.Pun;
using Repository;
using UnityEngine;
using Zenject;
using TargetScanner = DC.Scanner.TargetScanner;

namespace Skill.Attack
{
    public class SlashBase : IAttackBehaviour
    {
        protected readonly SkillEffectRepository _SkillEffectRepository;

        [Inject]
        public SlashBase
        (
            SkillEffectRepository skillEffectRepository
        )
        {
            _SkillEffectRepository = skillEffectRepository;
        }

        public virtual void Attack()
        {
        }

        protected void HitPlayer(TargetScanner targetScanner, int skillId)
        {
            var hitPlayers = targetScanner.GetTargetList();
            if (hitPlayers == null || hitPlayers.Count == 0)
            {
                return;
            }

            foreach (var hitPlayer in hitPlayers)
            {
                var statusInfo = hitPlayer.GetComponent<PlayerStatusInfo>();
                var playerIndex = statusInfo.GetPlayerIndex();
                var dic = new Dictionary<int, int>
                {
                    { playerIndex, skillId }
                };
                PhotonNetwork.LocalPlayer.SetSkillData(dic);
            }
        }

        public virtual void Dispose()
        {
        }
    }
}