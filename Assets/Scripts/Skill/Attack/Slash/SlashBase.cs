using System;
using System.Collections.Generic;
using AttributeAttack;
using Common.Data;
using Manager.NetworkManager;
using Photon.Pun;
using Repository;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;
using TargetScanner = DC.Scanner.TargetScanner;

namespace Skill.Attack
{
    public class SlashBase : IAttackBehaviour
    {
        private readonly SkillEffectRepository _skillEffectRepository;
        private const float DelayTime = 0.1f;
        private const float EffectHeight = 0.5f;

        [Inject]
        public SlashBase
        (
            SkillEffectRepository skillEffectRepository
        )
        {
            _skillEffectRepository = skillEffectRepository;
        }

        public virtual void Attack()
        {
        }

        protected void Slash
        (
            AbnormalCondition abnormalCondition,
            Animator animator,
            TargetScanner targetScanner,
            int skillId,
            Transform playerTransform
        )
        {
            var observableStateMachineTrigger = animator.GetBehaviour<ObservableStateMachineTrigger>();
            observableStateMachineTrigger
                .OnStateEnterAsObservable()
                .Where(info => info.StateInfo.IsName(GameCommonData.SlashKey))
                .Take(1)
                .Delay(TimeSpan.FromSeconds(DelayTime))
                .Subscribe(_ =>
                {
                    ActivateEffect(playerTransform, abnormalCondition);
                    HitPlayer(targetScanner, skillId);
                })
                .AddTo(playerTransform);
        }

        protected virtual void ActivateEffect(Transform playerTransform, AbnormalCondition abnormalCondition)
        {
            var effect = _skillEffectRepository.GetSkillEffect(abnormalCondition);
            var playerPosition = playerTransform.position;
            var spawnPosition = new Vector3(playerPosition.x, EffectHeight, playerPosition.z);
            var spawnRotation = FixedRotation(abnormalCondition, playerTransform) + playerTransform.eulerAngles;
            Object.Instantiate(effect, spawnPosition, Quaternion.Euler(spawnRotation), playerTransform);
        }

        private Vector3 FixedRotation(AbnormalCondition abnormalCondition, Transform playerTransform)
        {
            var spawnRotation = playerTransform.localEulerAngles;

            switch (abnormalCondition)
            {
                case AbnormalCondition.HellFire:
                    spawnRotation = new Vector3(0, 0, 180);
                    break;
                case AbnormalCondition.Poison:
                    spawnRotation = new Vector3(0, 0, 180);
                    break;
                case AbnormalCondition.Confusion:
                    spawnRotation = new Vector3(0, 0, 180);
                    break;
                case AbnormalCondition.Curse:
                    spawnRotation = new Vector3(0, 180, 180);
                    break;
                case AbnormalCondition.Apraxia:
                    spawnRotation = new Vector3(0, -90, 180);
                    break;
            }

            return spawnRotation;
        }

        private static void HitPlayer(TargetScanner targetScanner, int skillId)
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
                var dic = new Dictionary<int, int> { { playerIndex, skillId } };
                PhotonNetwork.LocalPlayer.SetSkillData(dic);
            }
        }

        public virtual void Dispose()
        {
        }
    }
}