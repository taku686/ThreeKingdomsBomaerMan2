using System;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public class EnemySearchPlayer : IDisposable
    {
        private readonly SphereCollider _searchCollider;
        private readonly ReactiveCollection<GameObject> _playerList = new();

        [Inject]
        public EnemySearchPlayer(GameObject transform)
        {
            _searchCollider = transform.AddComponent<SphereCollider>();
            _searchCollider.isTrigger = true;
            _searchCollider.enabled = false;
        }

        public IObservable<GameObject> ColliderObservable(float radius, CancellationToken token)
        {
            SetupCollider(radius, true);

            _searchCollider
                .OnCollisionEnterAsObservable()
                .Where(other => other.gameObject.CompareTag(GameCommonData.PlayerTag))
                .Subscribe(other => { _playerList.Add(other.gameObject); })
                .AddTo(token);

            _searchCollider
                .OnCollisionStayAsObservable()
                .Where(other => other.gameObject.CompareTag(GameCommonData.PlayerTag))
                .Subscribe(other => { _playerList.Add(other.gameObject); })
                .AddTo(token);

            _searchCollider
                .OnCollisionExitAsObservable()
                .Where(other => other.gameObject.CompareTag(GameCommonData.PlayerTag))
                .Subscribe(other => { _playerList.Remove(other.gameObject); })
                .AddTo(token);

            return _playerList
                .ObserveAdd()
                .Do(player => Debug.Log($"Player found: {player.Value.name}"))
                .Do(_ => SetupCollider(0, false))
                .Select(player => player.Value);
        }

        private void SetupCollider(float radius, bool enable)
        {
            _searchCollider.enabled = enable;
            _searchCollider.radius = radius;
        }

        public void Dispose()
        {
            _playerList?.Dispose();
        }

        public class Factory : PlaceholderFactory<GameObject, EnemySearchPlayer>
        {
        }
    }
}