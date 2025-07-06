using System.Collections.Generic;
using Repository;
using TitleCore.LoginBonusState;
using UnityEngine;
using Zenject;

namespace UI.TitleCore.LoginBonusState
{
    public class LoginBonusViewModelUseCase
    {
        private readonly LoginBonusFacade _loginBonusFacade;
        private readonly MissionSpriteDataRepository _missionSpriteDataRepository;
        private const int LoginBonusLength = 7;

        [Inject]
        public LoginBonusViewModelUseCase
        (
            LoginBonusFacade loginBonusFacade,
            MissionSpriteDataRepository missionSpriteDataRepository
        )
        {
            _loginBonusFacade = loginBonusFacade;
            _missionSpriteDataRepository = missionSpriteDataRepository;
        }

        public LoginBonusPopup.ViewModel InAsTask()
        {
            var loginBonusData = _loginBonusFacade._Data;
            var config = _loginBonusFacade._LoginBonusConfig;
            var activeImageDictionary = new Dictionary<int, bool>();
            var rewardSprites = new Dictionary<int, Sprite>();
            var rewardAmounts = new Dictionary<int, int>();
            for (var i = 0; i < LoginBonusLength; i++)
            {
                activeImageDictionary[i] = loginBonusData._consecutiveDays > i;
                if (i == loginBonusData._consecutiveDays)
                {
                    activeImageDictionary[i] = loginBonusData._todayReceived;
                }
            }

            foreach (var reward in config._rewards)
            {
                var day = reward._day;
                var rewardType = reward._rewardType;
                var amount = reward._amount;
                var rewardSprite = _missionSpriteDataRepository.GetRewardSprite(rewardType);
                rewardSprites[day] = rewardSprite;
                rewardAmounts[day] = amount;
            }

            return new LoginBonusPopup.ViewModel
            (
                activeImageDictionary,
                rewardSprites,
                rewardAmounts
            );
        }
    }
}