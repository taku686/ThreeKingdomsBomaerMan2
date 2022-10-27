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
                var token = Owner.GetCancellationTokenOnDestroy();
                Owner._inputManager.MoveDirection.Subscribe(async direction =>
                    {
                        Debug.Log(direction);
                        //await Owner._playerMove.Rotate(direction).AttachExternalCancellation(Owner.GetCancellationTokenOnDestroy());
                       // Owner._playerMove.Move(direction);
                    })
                    .AddTo(Owner.gameObject);
                _isSetup = true;
            }
        }
    }
}