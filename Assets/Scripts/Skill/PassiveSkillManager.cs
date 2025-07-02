using System;
using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.NetworkManager;
using Photon.Pun;
using Player.Common;
using Skill.Heal;
using UniRx;
using UnityEngine;
using Zenject;

namespace Skill
{
    public class PassiveSkillManager : IDisposable
    {
        private readonly BuffSkill _buffSkill;
        private readonly Heal.Heal _heal;
        private readonly OnDamageFacade _onDamageFacade;
        private CancellationTokenSource _cancellationTokenSource;

        [Inject]
        public PassiveSkillManager
        (
            BuffSkill buffSkill,
            Heal.Heal heal,
            OnDamageFacade onDamageFacade
        )
        {
            _buffSkill = buffSkill;
            _heal = heal;
            _onDamageFacade = onDamageFacade;
        }

        public void Initialize
        (
            SkillMasterData[] statusSkillMasterDatum,
            Transform playerTransform,
            PlayerCore.PlayerStatusInfo playerStatusInfo,
            int characterId
        )
        {
            Cancel();

            _cancellationTokenSource ??= new CancellationTokenSource();
            var playerConditionInfo = playerTransform.GetComponent<PlayerConditionInfo>();
            _buffSkill.Initialize
            (
                characterId,
                statusSkillMasterDatum,
                playerConditionInfo,
                playerStatusInfo
            );

            PassiveSkillSubscribe(playerConditionInfo);
        }

        private void PassiveSkillSubscribe(PlayerConditionInfo playerConditionInfo)
        {
            _onDamageFacade
                .OnDamageAsObservable()
                .Where(skillData => skillData.SkillType == SkillType.Passive)
                .Where(skillData => skillData.BoolRequirementTypeEnum == BoolRequirementType.ReceiveDamage)
                .Subscribe(skillData =>
                {
                    if (skillData == null)
                    {
                        return;
                    }

                    NotifyActivatePassiveSkill(playerConditionInfo, skillData);
                    _buffSkill.Buff(skillData).Forget();
                })
                .AddTo(_cancellationTokenSource.Token);

            _onDamageFacade
                .OnAbnormalConditionAsObservable()
                .Where(tuple => tuple.Item1.GetPlayerIndex() == playerConditionInfo.GetPlayerIndex())
                .Where(tuple => tuple.Item2.SkillType == SkillType.Passive)
                .Subscribe(tuple =>
                {
                    var skillData = tuple.Item2;
                    if (skillData.BoolRequirementTypeEnum != BoolRequirementType.AbnormalCondition)
                    {
                        return;
                    }

                    NotifyActivatePassiveSkill(playerConditionInfo, skillData);
                    _buffSkill.BuffInAbnormalCondition(skillData).Forget();
                    _heal.ContinuousHealSkillInAbnormalCondition(skillData);
                })
                .AddTo(_cancellationTokenSource.Token);
        }

        private static void NotifyActivatePassiveSkill(PlayerConditionInfo playerConditionInfo, SkillMasterData skillData)
        {
            var playerIndex = playerConditionInfo.GetPlayerIndex();
            var skillId = skillData.Id;
            var dic = new Dictionary<int, int> { { playerIndex, skillId } };
            PhotonNetwork.LocalPlayer.SetSkillData(dic);
        }

        private void Cancel()
        {
            if (_cancellationTokenSource == null)
            {
                return;
            }

            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = null;
        }

        public void Dispose()
        {
            Cancel();
        }
    }
}