using System;
using Common.Data;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using State = StateMachine<Player.Common.PLayerCore>.State;

namespace Player.Common
{
    public partial class PLayerCore
    {
        public class PlayerStateIdle : State
        {
            private Transform _playerTransform;
            private bool _isSetup;

            protected override void OnEnter(State prevState)
            {
                InitialiseIdleState();
            }

            protected override void OnExit(State nextState)
            {
            }

            protected override void OnUpdate()
            {
            }

            private void InitialiseIdleState()
            {
                if (_isSetup)
                {
                    return;
                }

                _playerTransform = Owner.transform;
                Owner._inputManager.MoveDirection
                    .Subscribe(direction => { Owner._playerMove.Move(direction).Forget(); })
                    .AddTo(Owner.gameObject);
                Owner._inputManager.PutBombIObservable
                    .Subscribe(tuple =>
                    {
                        var photonView = Owner._photonView;
                        var playerId = tuple.Item1;
                        var serverTime = tuple.Item2;
                        var damageAmount = Owner._characterData.Attack;
                        var fireRange = Owner._characterData.FireRange;
                        Owner._playerPutBomb.PutBomb(photonView, _playerTransform, (int)BombType.Normal, damageAmount,
                            fireRange, serverTime, playerId);
                    })
                    .AddTo(Owner.gameObject);
                _isSetup = true;
            }
        }
    }
}