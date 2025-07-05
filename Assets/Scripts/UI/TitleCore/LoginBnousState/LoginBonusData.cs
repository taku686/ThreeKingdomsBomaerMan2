using System.Collections.Generic;
using Common.Data;
using UnityEngine;

namespace UI.TitleCore.LoginBonusState
{
    [System.Serializable]
    public class LoginBonusData
    {
        public string _lastLoginDate; // 最終ログイン日（例: "2024-06-01"）
        public int _consecutiveDays; // 連続ログイン日数
        public bool _todayReceived; // 今日のボーナス受け取り済みか
    }

    [System.Serializable]
    public class LoginBonusRewardData
    {
        public int _day;
        public GameCommonData.RewardType _rewardType;
        public int _amount;
    }
    
    [CreateAssetMenu(fileName = "LoginBonusConfig", menuName = "ScriptableObjects/LoginBonusConfig", order = 1)]
    public class LoginBonusConfig : ScriptableObject
    {
        public List<LoginBonusRewardData> _rewards;
    }
}