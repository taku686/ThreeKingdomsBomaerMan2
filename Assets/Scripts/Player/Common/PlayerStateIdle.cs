using System;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using State = StateMachine<Player.Common.PLayerBase>.State;

namespace Player.Common
{
    public partial class PLayerBase
    {
        public class PlayerStateIdle : State
        {
            private Transform _playerTransform;
            private bool _isSetup;
            private PlayerMove _playerMove;
            private CancellationTokenSource _cancellationTokenSource;

            protected override void OnEnter(State prevState)
            {
                base.OnEnter(prevState);
                InitializeComponent();
                InitializeCancellationToken();
                InitialiseIdleState();
                InitializeButton();
            }

            protected override void OnExit(State nextState)
            {
                base.OnExit(nextState);
                Cancel();
                _playerMove = null;
            }

            protected override void OnUpdate()
            {
                if (_playerMove == null)
                {
                    return;
                }

                var direction = new Vector3(UltimateJoystick.GetHorizontalAxis(GameSettingData.JoystickName), 0,
                    UltimateJoystick.GetVerticalAxis(GameSettingData.JoystickName));
                _playerMove.Move(direction).Forget();
            }

            private void InitializeComponent()
            {
                _playerMove = Owner._playerMove;
            }

            private void InitialiseIdleState()
            {
                if (_isSetup)
                {
                    return;
                }

                _playerTransform = Owner.transform;
                Owner._inputManager.SetOnClickSkillOne(SkillOneIntervalTime, OnClickSkillOne,
                    Owner.GetCancellationTokenOnDestroy());
                Owner._inputManager.SetOnClickSkillTwo(SkillTwoIntervalTime, OnClickSkillTwo,
                    Owner.GetCancellationTokenOnDestroy());
                _isSetup = true;
            }

            private void InitializeCancellationToken()
            {
                _cancellationTokenSource ??= new CancellationTokenSource();
            }

            private void InitializeButton()
            {
                Owner._inputManager.BombButton.OnClickAsObservable()
                    .Throttle(TimeSpan.FromSeconds(GameSettingData.InputBombInterval))
                    .Subscribe(
                        _ =>
                        {
                            var playerId = Owner._photonView.ViewID;
                            var explosionTime = PhotonNetwork.ServerTimestamp +
                                                GameSettingData.ThreeMilliSecondsBeforeExplosion;
                            var photonView = Owner._photonView;
                            var damageAmount = Owner._characterData.Attack;
                            var fireRange = Owner._characterData.FireRange;
                            var boxCollider = Owner._boxCollider;
                            Owner._playerPutBomb.PutBomb(boxCollider, photonView, _playerTransform,
                                (int)BombType.Normal,
                                damageAmount,
                                fireRange, explosionTime, playerId);
                        }).AddTo(_cancellationTokenSource.Token);
            }

            private void OnClickSkillOne()
            {
                Owner._stateMachine.Dispatch((int)PLayerState.Skill1);
            }

            private void OnClickSkillTwo()
            {
                Owner._stateMachine.Dispatch((int)PLayerState.Skill2);
            }

            private void Cancel()
            {
                _cancellationTokenSource?.Cancel();
                _cancellationTokenSource?.Dispose();
                _cancellationTokenSource = null;
            }
        }
    }
}