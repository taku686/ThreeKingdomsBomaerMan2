using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using Player.Common;
using Repository;
using UI.Battle;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Manager.BattleManager
{
    public partial class BattleCore
    {
        public class InBattleState : StateMachine<BattleCore>.State
        {
            private InBattleView _View => Owner.GetView(State.InBattle) as InBattleView;
            private PlayerCore _PlayerCore => Owner._playerCore;
            private StateMachine<BattleCore> _StateMachine => Owner._stateMachine;
            private List<PlayerStatusUI> _PlayerStatusUiList => Owner._playerStatusUiList;
            private BattleResultDataRepository _BattleResultDataRepository => Owner._battleResultDataRepository;
            private InputViewModelUseCase _InputViewModelUseCase => Owner._inputViewModelUseCase;
            private AbnormalConditionSpriteRepository _AbnormalConditionSpriteRepository => Owner._abnormalConditionSpriteRepository;
            private PlayerStatusInfo _PlayerStatusInfo => Owner._playerStatusInfo;
            private StatusInBattleViewModelUseCase _StatusInBattleViewModelUseCase => Owner._statusInBattleViewModelUseCase;

            private CancellationTokenSource _cts;
            private int _startTime;
            private int _rank;
            private readonly Dictionary<AbnormalCondition, Image> _abnormalConditionImages = new();

            protected override void OnEnter(StateMachine<BattleCore>.State prevState)
            {
                Initialize();
            }

            protected override void OnExit(StateMachine<BattleCore>.State nextState)
            {
                DestroyPlayerListUi();
                Cancel();
            }


            private void Initialize()
            {
                _cts = new CancellationTokenSource();
                _startTime = PhotonNetwork.ServerTimestamp;
                _View.UpdateTime(GameCommonData.BattleTime);
                OnSubscribe();
                Owner.SwitchUiObject(State.InBattle);
            }

            private void ApplyStatusInBattleViewModel(int playerKey)
            {
                var viewModel = _StatusInBattleViewModelUseCase.InAsTask(playerKey);
                _View.ApplyStatusViewModel(viewModel);
            }

            private void OnSubscribe()
            {
                PlayerCoreSubscribe();
                PlayerStatusInfoSubscribe();
                ViewSubscribe();

                Observable.EveryUpdate()
                    .Subscribe(_ =>
                    {
                        var time = GameCommonData.BattleTime - unchecked(PhotonNetwork.ServerTimestamp - _startTime) / 1000;
                        if (time <= 0)
                        {
                            _StateMachine.Dispatch((int)State.Result);
                        }

                        _View.UpdateTime(time);
                        _View.UpdateSkillUI();
                    })
                    .AddTo(_cts.Token);
            }

            private void PlayerCoreSubscribe()
            {
                _PlayerCore._DeadObservable
                    .Subscribe(_ =>
                    {
                        _rank = PhotonNetwork.CurrentRoom.PlayerCount;
                        _BattleResultDataRepository.SetRank(_rank);
                        PhotonNetwork.LeaveRoom();
                        _StateMachine.Dispatch((int)State.Result);
                    })
                    .AddTo(_cts.Token);

                _PlayerCore._TeamMemberReactiveProperty
                    .Subscribe(playerKey =>
                    {
                        var viewModel = _InputViewModelUseCase.InAsTask(playerKey);
                        _View.ApplyInputViewModel(viewModel);
                        ApplyStatusInBattleViewModel(playerKey);
                    })
                    .AddTo(_cts.Token);

                _PlayerCore._StatusBuffUiObservable
                    .Subscribe(tuple => { _View.ApplyBuffState(tuple.statusType, tuple.speed, tuple.isBuff, tuple.isDebuff); })
                    .AddTo(_cts.Token);
            }

            private void PlayerStatusInfoSubscribe()
            {
                _PlayerStatusInfo._AbnormalConditions
                    .ObserveAdd()
                    .Subscribe(value =>
                    {
                        var abnormalCondition = value.Value;
                        var sprite = _AbnormalConditionSpriteRepository.GetAbnormalConditionSprite(abnormalCondition);
                        var icon = _View.GenerateAbnormalConditionImage(sprite);
                        _abnormalConditionImages[abnormalCondition] = icon;
                    })
                    .AddTo(_cts.Token);

                _PlayerStatusInfo._AbnormalConditions
                    .ObserveRemove()
                    .Subscribe(value =>
                    {
                        var abnormalCondition = value.Value;
                        if (_abnormalConditionImages.TryGetValue(abnormalCondition, out var icon))
                        {
                            Destroy(icon.gameObject);
                            _abnormalConditionImages.Remove(abnormalCondition);
                        }
                    })
                    .AddTo(_cts.Token);
            }

            private void ViewSubscribe()
            {
                _View.OnClickNormalSkillButtonAsObservable()
                    .Subscribe(_ => { _PlayerCore._NormalSkillSubject.OnNext(Unit.Default); })
                    .AddTo(_cts.Token);

                _View.OnClickSpecialSkillButtonAsObservable()
                    .Subscribe(_ => { _PlayerCore._SpecialSkillSubject.OnNext(Unit.Default); })
                    .AddTo(_cts.Token);

                _View.OnClickDashButtonAsObservable()
                    .Subscribe(_ => { _PlayerCore._DashSkillSubject.OnNext(Unit.Default); })
                    .AddTo(_cts.Token);

                _View.OnClickBombButtonAsObservable()
                    .Subscribe(_ => { _PlayerCore._BombSkillSubject.OnNext(Unit.Default); })
                    .AddTo(_cts.Token);

                _View.OnClickCharacterChangeButtonAsObservable()
                    .Subscribe(_ => { _PlayerCore.ChangeTeamMember(); })
                    .AddTo(_cts.Token);
            }

            private void DestroyPlayerListUi()
            {
                foreach (var playerStatusUI in _PlayerStatusUiList)
                {
                    Destroy(playerStatusUI.gameObject);
                }

                _PlayerStatusUiList.Clear();
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