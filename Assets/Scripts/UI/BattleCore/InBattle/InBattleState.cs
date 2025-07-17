using System;
using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using Player.Common;
using Repository;
using Skill;
using UI.Battle;
using UI.BattleCore.InBattle;
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
            private PlayerConditionInfo _PlayerConditionInfo => Owner._playerConditionInfo;
            private StatusInBattleViewModelUseCase _StatusInBattleViewModelUseCase => Owner._statusInBattleViewModelUseCase;
            private ArrowSkillIndicatorView _ArrowSkillIndicatorView => Owner._arrowSkillIndicatorView;
            private CircleSkillIndicatorView _CircleSkillIndicatorView => Owner._circleSkillIndicatorView;
            private AbnormalConditionEffectUseCase _AbnormalConditionEffectUseCase => Owner._abnormalConditionEffectUseCase;

            private CancellationTokenSource _cts;
            private int _startTime;
            private int _rank;
            private SkillIndicatorViewBase.SkillIndicatorInfo _skillIndicatorInfo;
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

            #region Subscribe Methods

            private void OnSubscribe()
            {
                PlayerCoreSubscribe();
                PlayerStatusInfoSubscribe();
                ViewSubscribe();
                EventSubscribe();
            }

            private void EventSubscribe()
            {
                Observable.EveryUpdate()
                    .Subscribe(_ =>
                    {
                        var time = GameCommonData.BattleTime - unchecked(PhotonNetwork.ServerTimestamp - _startTime) / 1000;
                        if (time <= 0)
                        {
                            _StateMachine.Dispatch((int)State.Result);
                        }

                        _View.UpdateTime(time);
                        _View.UpdateInputViewTimer();
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

                _PlayerCore._PlayerStatusInfo
                    ._attack
                    .Subscribe(value => { _View.ApplyBuffState(StatusType.Attack, value); })
                    .AddTo(_cts.Token);

                _PlayerCore._PlayerStatusInfo
                    ._speed
                    .Subscribe(value => { _View.ApplyBuffState(StatusType.Speed, value); })
                    .AddTo(_cts.Token);

                _PlayerCore._PlayerStatusInfo
                    ._defense
                    .Subscribe(value => { _View.ApplyBuffState(StatusType.Defense, value); })
                    .AddTo(_cts.Token);

                _PlayerCore._PlayerStatusInfo
                    ._resistance
                    .Subscribe(value => { _View.ApplyBuffState(StatusType.Resistance, value); })
                    .AddTo(_cts.Token);

                _PlayerCore._PlayerStatusInfo
                    ._fireRange
                    .Subscribe(value => { _View.ApplyBuffState(StatusType.FireRange, value); })
                    .AddTo(_cts.Token);

                _PlayerCore._PlayerStatusInfo
                    ._bombLimit
                    .Subscribe(value => { _View.ApplyBuffState(StatusType.BombLimit, value); })
                    .AddTo(_cts.Token);
            }

            private void PlayerStatusInfoSubscribe()
            {
                _PlayerConditionInfo._AbnormalConditions
                    .ObserveAdd()
                    .Subscribe(value =>
                    {
                        var abnormalCondition = value.Value;
                        var sprite = _AbnormalConditionSpriteRepository.GetAbnormalConditionSprite(abnormalCondition);
                        var icon = _View.GenerateAbnormalConditionImage(sprite);
                        _abnormalConditionImages[abnormalCondition] = icon;
                    })
                    .AddTo(_cts.Token);

                _PlayerConditionInfo._AbnormalConditions
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
                _View.OnClickDashButtonAsObservable()
                    .Subscribe(_ => { _PlayerCore._DashSkillSubject.OnNext(Unit.Default); })
                    .AddTo(_cts.Token);

                _View.OnClickBombButtonAsObservable()
                    .Subscribe(_ => { _PlayerCore._BombSkillSubject.OnNext(Unit.Default); })
                    .AddTo(_cts.Token);

                _View.OnClickCharacterChangeButtonAsObservable()
                    .Subscribe(_ => { _PlayerCore.ChangeTeamMember(); })
                    .AddTo(_cts.Token);

                _View.OnTouchWeaponSkillButtonAsObservable()
                    .Subscribe(skillIndicatorInfo => { ActivateSkillIndicator(skillIndicatorInfo, _PlayerCore._WeaponSkillSubject); })
                    .AddTo(_cts.Token);

                _View.OnTouchNormalSkillButtonAsObservable()
                    .Subscribe(skillIndicatorInfo => { ActivateSkillIndicator(skillIndicatorInfo, _PlayerCore._NormalSkillSubject); })
                    .AddTo(_cts.Token);

                _View.OnTouchSpecialSkillButtonAsObservable()
                    .Subscribe(skillIndicatorInfo => { ActivateSkillIndicator(skillIndicatorInfo, _PlayerCore._SpecialSkillSubject); })
                    .AddTo(_cts.Token);

                _AbnormalConditionEffectUseCase
                    ._canPutBombReactiveProperty
                    .Subscribe(isActive => { _View.ActivateBombButton(isActive); })
                    .AddTo(_cts.Token);

                _AbnormalConditionEffectUseCase
                    ._canSkillReactiveProperty
                    .Subscribe(isActive => { _View.ActiveSkillButton(isActive); })
                    .AddTo(_cts.Token);

                _AbnormalConditionEffectUseCase
                    ._canCharacterChangeReactiveProperty
                    .Subscribe(isActive => { _View.ActiveCharacterChangeButton(isActive); })
                    .AddTo(_cts.Token);

                Observable
                    .EveryFixedUpdate()
                    .Where(_ => CanUpdateSkillIndicator())
                    .Where(_ => !IsInvalidNumber(_skillIndicatorInfo._Range))
                    .Where(_ => _skillIndicatorInfo._IsInteractable)
                    .Subscribe(_ => { SearchEnemy(); })
                    .AddTo(_cts.Token);
            }

            #endregion

            private static bool IsInvalidSkillDirection(SkillDirection skillDirection)
            {
                return skillDirection is not (SkillDirection.Forward or SkillDirection.All);
            }

            private bool CanUpdateSkillIndicator()
            {
                return _ArrowSkillIndicatorView != null &&
                       _CircleSkillIndicatorView != null &&
                       _skillIndicatorInfo != null;
            }

            private static bool IsInvalidNumber(float value)
            {
                return Mathf.Approximately(value, GameCommonData.InvalidNumber);
            }

            private void SearchEnemy()
            {
                var position = _PlayerCore.transform.position;
                var layerMask = GameCommonData.GetObstaclesLayerMask();
                var range = _skillIndicatorInfo._Range;
                var skillDirection = _skillIndicatorInfo._SkillDirection;
                var direction = _PlayerCore.transform.forward;

                switch (skillDirection)
                {
                    case SkillDirection.Forward:
                        var origin = new Vector3(position.x, position.y + 0.5f, position.z);
                        _ArrowSkillIndicatorView.UpdateArrowIndicator(origin, range, layerMask, direction);
                        break;
                    case SkillDirection.Back:
                        break;
                    case SkillDirection.Left:
                        break;
                    case SkillDirection.Right:
                        break;
                    case SkillDirection.ForwardBack:
                        break;
                    case SkillDirection.LeftRight:
                        break;
                    case SkillDirection.All:
                        _CircleSkillIndicatorView.UpdateCircleIndicator(position, range, layerMask);
                        break;
                    case SkillDirection.Random:
                        break;
                    case SkillDirection.Specified:
                        break;
                    case SkillDirection.Everywhere:
                        break;
                    case SkillDirection.None:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            private void ActivateSkillIndicator
            (
                SkillIndicatorViewBase.SkillIndicatorInfo skillIndicatorInfo,
                Subject<Unit> skillSubject
            )
            {
                _skillIndicatorInfo = skillIndicatorInfo;
                var isActive = skillIndicatorInfo._IsTouch;
                var range = skillIndicatorInfo._Range;
                var skillDirection = skillIndicatorInfo._SkillDirection;
                var angle = skillIndicatorInfo._Angle;

                if (!isActive)
                {
                    skillSubject.OnNext(Unit.Default);
                }

                if
                (
                    Mathf.Approximately(range, GameCommonData.InvalidNumber) ||
                    IsInvalidSkillDirection(skillDirection)
                )
                {
                    _ArrowSkillIndicatorView.gameObject.SetActive(false);
                    _CircleSkillIndicatorView.gameObject.SetActive(false);
                    return;
                }

                switch (skillDirection)
                {
                    case SkillDirection.Forward:
                        _ArrowSkillIndicatorView.gameObject.SetActive(isActive);
                        _ArrowSkillIndicatorView.Setup(range);
                        break;
                    case SkillDirection.Back:
                        break;
                    case SkillDirection.Left:
                        break;
                    case SkillDirection.Right:
                        break;
                    case SkillDirection.ForwardBack:
                        break;
                    case SkillDirection.LeftRight:
                        break;
                    case SkillDirection.All:
                        _CircleSkillIndicatorView.gameObject.SetActive(isActive);
                        _CircleSkillIndicatorView.Setup(range, angle);
                        break;
                    case SkillDirection.Random:
                        break;
                    case SkillDirection.Specified:
                        break;
                    case SkillDirection.Everywhere:
                        break;
                    case SkillDirection.None:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
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