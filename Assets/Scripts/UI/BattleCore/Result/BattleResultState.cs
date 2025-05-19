using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using MoreMountains.Tools;
using Repository;
using UniRx;

namespace Manager.BattleManager
{
    public partial class BattleCore
    {
        public class BattleResultState : StateMachine<BattleCore>.State
        {
            //順位に応じた報酬をもらう処理を行う
            //報酬もらった後はmainシーンに戻る

            private BattleResultView _BattleResultView => Owner.GetView(State.Result) as BattleResultView;
            private BattleResultDataRepository _BattleResultDataRepository => Owner._battleResultDataRepository;
            private MissionManager _MissionManager => Owner._missionManager;
            private UserDataRepository _UserDataRepository => Owner._userDataRepository;
            private CancellationTokenSource _cts;

            protected override void OnEnter(StateMachine<BattleCore>.State prevState)
            {
                Initialize().Forget();
                OnSubscribe();
            }

            protected override void OnExit(StateMachine<BattleCore>.State nextState)
            {
                Cancel();
            }

            private async UniTaskVoid Initialize()
            {
                _cts = new CancellationTokenSource();
                var rank = _BattleResultDataRepository.GetRank();
                _BattleResultView.ApplyView(rank);
                await CheckMission();
                Owner.SwitchUiObject(State.Result);
            }

            private void OnSubscribe()
            {
                _BattleResultView
                    ._ClaimButtonObservable
                    .Subscribe(_ => { MMSceneLoadingManager.LoadScene(GameCommonData.TitleScene); })
                    .AddTo(_cts.Token);
            }

            private async UniTask CheckMission()
            {
                var rank = _BattleResultDataRepository.GetRank();
                var teamMembers = _UserDataRepository.GetTeamMembers();
                //todo あとで修正が必要
                foreach (var (_, characterId) in teamMembers)
                {
                    var weaponId = _UserDataRepository.GetEquippedWeaponId(characterId);
                    _MissionManager.CheckMission(GameCommonData.MissionActionId.BattleCount, 1);
                    _MissionManager.CheckMission(GameCommonData.MissionActionId.CharacterBattleCount, 1, characterId, weaponId);
                    _MissionManager.CheckMission(GameCommonData.MissionActionId.WeaponBattleCount, 1, characterId, weaponId);
                    if (rank == 1)
                    {
                        _MissionManager.CheckMission(GameCommonData.MissionActionId.FirstWonCount, 1);
                        _MissionManager.CheckMission(GameCommonData.MissionActionId.CharacterFirstWonCount, 1, characterId, weaponId);
                        _MissionManager.CheckMission(GameCommonData.MissionActionId.WeaponFirstWonCount, 1, characterId, weaponId);
                    }

                    _MissionManager.CheckMission(GameCommonData.MissionActionId.KillCount, 1);
                    _MissionManager.CheckMission(GameCommonData.MissionActionId.CharacterFirstWonCount, 1, characterId, weaponId);
                    _MissionManager.CheckMission(GameCommonData.MissionActionId.WeaponFirstWonCount, 1, characterId, weaponId);
                    _MissionManager.CheckMission(GameCommonData.MissionActionId.DamageAmount, 1);
                    _MissionManager.CheckMission(GameCommonData.MissionActionId.CharacterDamageAmount, 1, characterId, weaponId);
                    _MissionManager.CheckMission(GameCommonData.MissionActionId.WeaponDamageAmount, 1, characterId, weaponId);
                }

                var userData = _UserDataRepository.GetUserData();
                await _UserDataRepository.UpdateUserData(userData);
            }

            private void Cancel()
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
}