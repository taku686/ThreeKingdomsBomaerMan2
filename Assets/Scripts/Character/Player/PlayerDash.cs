using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Player.Common
{
    public class PlayerDash : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private const float DashDuration = 0.45f;
        private const float DashDistance = 3f;

        public void Initialize()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Dash()
        {
            var cts = new CancellationTokenSource();
            var dashDirection = transform.forward;
            Observable
                .EveryFixedUpdate()
                .Subscribe(_ => { _rigidbody.velocity = dashDirection * (DashDistance / DashDuration); })
                .AddTo(cts.Token);

            Observable
                .Timer(TimeSpan.FromSeconds(DashDuration))
                .Subscribe(_ =>
                {
                    _rigidbody.velocity = Vector3.zero;
                    cts.Cancel();
                    cts.Dispose();
                })
                .AddTo(cts.Token);
        }
    }
}