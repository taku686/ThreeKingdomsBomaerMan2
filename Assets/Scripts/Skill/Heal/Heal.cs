using System;
using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.NetworkManager;
using Photon.Pun;
using Player.Common;
using UniRx;
using UnityEngine;

namespace Skill.Heal
{
    public class Heal : IDisposable
    {
        private PlayerConditionInfo _playerConditionInfo;
        private PlayerCore.PlayerStatusInfo _playerStatusInfo;
        private float _timer;
        private float _oneSecondTimer;
        private const int DeadHp = 0;

        public void Initialize
        (
            PlayerConditionInfo playerConditionInfo,
            PlayerCore.PlayerStatusInfo playerStatusInfo
        )
        {
            _playerConditionInfo = playerConditionInfo;
            _playerStatusInfo = playerStatusInfo;
        }

        public void HealSkill(SkillMasterData skillMasterData)
        {
            var healAmount = GetHealAmount(skillMasterData);
            CalculateHp(healAmount);
        }

        public void ContinuousHealSkill(SkillMasterData skillMasterData)
        {
            var healAmount = GetHealAmount(skillMasterData);
            var effectTime = skillMasterData.EffectTime;
            var cancellationToken = new CancellationTokenSource();
            Observable.EveryUpdate()
                .Subscribe(_ =>
                {
                    _timer += Time.deltaTime;
                    _oneSecondTimer += Time.deltaTime;
                    if (_oneSecondTimer >= 1f)
                    {
                        CalculateHp(healAmount);
                        _oneSecondTimer = 0f;
                    }

                    if (_timer >= effectTime)
                    {
                        _timer = 0f;
                        _oneSecondTimer = 0f;
                        cancellationToken.Cancel();
                        cancellationToken.Dispose();
                        cancellationToken = null;
                    }
                })
                .AddTo(cancellationToken.Token);
        }

        public void ContinuousHealSkillInAbnormalCondition(SkillMasterData skillMasterData)
        {
            var healAmount = GetHealAmount(skillMasterData);
            var cancellationToken = new CancellationTokenSource();
            Observable.EveryUpdate()
                .Where(_ => _playerConditionInfo.HasAbnormalCondition())
                .Subscribe(_ =>
                {
                    _oneSecondTimer += Time.deltaTime;
                    if (_oneSecondTimer >= 1f)
                    {
                        CalculateHp(healAmount);
                        _oneSecondTimer = 0f;
                    }
                })
                .AddTo(cancellationToken.Token);
        }

        private void CalculateHp(int healAmount)
        {
            var tuple = _playerStatusInfo._Hp.Value;
            var maxHp = Mathf.FloorToInt(TranslateStatusInBattleUseCase.Translate(StatusType.Hp, tuple.Item1));
            var hp = Mathf.FloorToInt(TranslateStatusInBattleUseCase.Translate(StatusType.Hp, tuple.Item2));
            hp += healAmount;
            hp = Mathf.Clamp(hp, DeadHp, maxHp);
            _playerStatusInfo._Hp.Value = (maxHp, hp);
        }

        private int GetHealAmount(SkillMasterData skillMasterData)
        {
            var healAmount = 0;

            if (!Mathf.Approximately(skillMasterData.HpPlu, GameCommonData.InvalidNumber))
            {
                healAmount = Mathf.FloorToInt(skillMasterData.HpPlu);
            }

            if (!Mathf.Approximately(skillMasterData.HpMul, GameCommonData.InvalidNumber))
            {
                var maxHp = _playerStatusInfo._Hp.Value.Item1;
                healAmount = Mathf.FloorToInt(maxHp * skillMasterData.HpMul);
            }

            return healAmount;
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}