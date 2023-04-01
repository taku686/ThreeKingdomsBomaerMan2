using System;
using Common.Data;
using Cysharp.Threading.Tasks;
using UnityEngine;
using State = StateMachine<Manager.BattleManager.BattleCore>.State;

namespace Manager.BattleManager
{
    public partial class BattleCore
    {
        public class BattleStartState : State
        {
            private UserDataManager _userDataManager;

            protected override async void OnEnter(State prevState)
            {
                await Initialize();
                Debug.Log("プレイヤーデータ更新");
            }

            private async UniTask Initialize()
            {
                _userDataManager = Owner._userDataManager;
                await UniTask.Delay(TimeSpan.FromSeconds(1));
                Owner.CheckMission(GameCommonData.CharacterBattleActionId);
                Owner.CheckMission(GameCommonData.BattleCountActionId);
                var userData = _userDataManager.GetUserData();
                await _userDataManager.UpdateUserData(userData);
            }
        }
    }
}