using System;
using Common.Data;
using Cysharp.Threading.Tasks;
using Repository;
using UnityEngine;
using UseCase;
using Zenject;

namespace UI.TitleCore.LoginBonusState
{
    public class LoginBonusFacade : IDisposable
    {
        private readonly UserDataRepository _userDataRepository;
        private readonly RewardDataRepository _rewardDataRepository;
        private readonly GetRewardUseCase _getRewardUseCase;
        public LoginBonusData _Data { get; private set; }
        public LoginBonusConfig _LoginBonusConfig { get; }
        private const int MaxConsecutiveDays = 7; // 最大連続ログイン日数

        [Inject]
        public LoginBonusFacade
        (
            LoginBonusConfig config,
            UserDataRepository userDataRepository,
            RewardDataRepository rewardDataRepository,
            GetRewardUseCase getRewardUseCase
        )
        {
            _LoginBonusConfig = config;
            _userDataRepository = userDataRepository;
            _rewardDataRepository = rewardDataRepository;
            _getRewardUseCase = getRewardUseCase;
        }

        public void LoadState()
        {
            var loginBonusData = _userDataRepository.GetLoginBonusData();
            if (loginBonusData == null)
            {
                _Data = new LoginBonusData
                {
                    _lastLoginDate = "",
                    _consecutiveDays = 0,
                    _todayReceived = false
                };
            }
            else
            {
                _Data = loginBonusData;
            }
        }

        // 状態の保存
        private async UniTask SaveState()
        {
            if (_Data == null)
            {
                Debug.LogError("LoginBonusData is null, cannot save state.");
                return;
            }

            _userDataRepository.SetLoginBonusData(_Data);
            await _userDataRepository.UpdateUserData();
        }

        // ログイン判定
        public async UniTask CheckLogin()
        {
            Debug.Log("Last Login Date: " + _Data._lastLoginDate);
            var today = DateTime.UtcNow.ToString("yyyy-MM-dd");
            if (_Data._lastLoginDate == today)
            {
                // すでに今日ログイン済み
                return;
            }

            if (DateTime.TryParse(_Data._lastLoginDate, out var lastDate))
            {
                var diff = (DateTime.UtcNow.Date - lastDate.Date).Days;
                if (diff == 1)
                {
                    _Data._consecutiveDays++;
                    if (_Data._consecutiveDays > MaxConsecutiveDays)
                    {
                        _Data._consecutiveDays = 1; // 最大連続ログイン日数を超えないようにする
                    }
                }
                else
                {
                    _Data._consecutiveDays = 1;
                }
            }
            else
            {
                _Data._consecutiveDays = 1;
            }

            _Data._lastLoginDate = today;
            _Data._todayReceived = false;
            await SaveState();
        }

        // ボーナス受け取り
        public async UniTask ReceiveBonus()
        {
            if (_Data._todayReceived)
            {
                Debug.Log("本日のボーナスはすでに受け取り済みです。");
                return;
            }

            var reward = _LoginBonusConfig._rewards.Find(r => r._day == _Data._consecutiveDays);
            if (reward == null)
            {
                Debug.Log("ボーナス設定がありません。");
                return;
            }

            // ここで報酬を付与（例：コイン加算など）
            var rewardType = reward._rewardType;
            var amount = reward._amount;
            var results = _rewardDataRepository.SetReward(rewardType, amount);
            await _getRewardUseCase.InAsTask(results);
            _Data._todayReceived = true;
            await SaveState();
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}