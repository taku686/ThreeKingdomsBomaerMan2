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
    public class HealSkill : IDisposable
    {
        private Func<int, int> _calculateHp;
        private TranslateStatusInBattleUseCase _translateStatusInBattleUseCase;
        private PlayerStatusInfo _playerStatusInfo;
        private float _timer;
        private float _oneSecondTimer;

        public void Initialize
        (
            Func<int, int> calculateHp,
            TranslateStatusInBattleUseCase translateStatusInBattleUseCase,
            PlayerStatusInfo playerStatusInfo
        )
        {
            _calculateHp = calculateHp;
            _translateStatusInBattleUseCase = translateStatusInBattleUseCase;
            _playerStatusInfo = playerStatusInfo;
        }

        public void Heal(SkillMasterData skillMasterData)
        {
            var healAmount = GetHealAmount(skillMasterData);
            _calculateHp.Invoke(-healAmount);
        }

        public void ContinuousHeal(SkillMasterData skillMasterData)
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
                        _calculateHp.Invoke(-healAmount);
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

        public void ContinuousHealInAbnormalCondition(SkillMasterData skillMasterData)
        {
            var healAmount = GetHealAmount(skillMasterData);
            var cancellationToken = new CancellationTokenSource();
            Observable.EveryUpdate()
                .Where(_ => _playerStatusInfo.HasAbnormalCondition())
                .Subscribe(_ =>
                {
                    _oneSecondTimer += Time.deltaTime;
                    if (_oneSecondTimer >= 1f)
                    {
                        _calculateHp.Invoke(-healAmount);
                        _oneSecondTimer = 0f;
                    }
                })
                .AddTo(cancellationToken.Token);
        }

        private int GetHealAmount(SkillMasterData skillMasterData)
        {
            var playerIndex = _playerStatusInfo.GetPlayerIndex();
            var skillId = skillMasterData.Id;
            var dic = new Dictionary<int, int> { { playerIndex, skillId } };
            PhotonNetwork.LocalPlayer.SetSkillData(dic);

            var healAmount = 0;

            if (!Mathf.Approximately(skillMasterData.HpPlu, GameCommonData.InvalidNumber))
            {
                healAmount = Mathf.FloorToInt(skillMasterData.HpPlu);
            }

            if (!Mathf.Approximately(skillMasterData.HpMul, GameCommonData.InvalidNumber))
            {
                var maxHp = _translateStatusInBattleUseCase._MaxHp;
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