using System;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using Player.Common;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public class EnemySearchPlayer : IDisposable
    {
        private readonly PhotonView _photonView;
        private readonly SphereCollider _searchCollider;
        private ReactiveCollection<GameObject> _playerList;
        private CancellationTokenSource _cts;

        [Inject]
        public EnemySearchPlayer(GameObject playerCore)
        {
            _cts = new CancellationTokenSource();
            _photonView = playerCore.GetComponent<PhotonView>();
            var skillCollider = new GameObject("SkillCollider");
            skillCollider.transform.SetParent(playerCore.transform);
            skillCollider.transform.localPosition = Vector3.zero;
            skillCollider.transform.localRotation = Quaternion.identity;
            skillCollider.layer = LayerMask.NameToLayer(GameCommonData.DefaultLayer);
            _searchCollider = skillCollider.AddComponent<SphereCollider>();
            _searchCollider.radius = 0;
            _searchCollider.isTrigger = true;
            _searchCollider.enabled = false;
            ColliderObservable(_searchCollider);
        }

        private void ColliderObservable(SphereCollider searchCollider)
        {
            searchCollider
                .OnTriggerEnterAsObservable()
                .Where(other => other.gameObject.CompareTag(GameCommonData.PlayerTag))
                .Subscribe(other => { AddPlayer(other.gameObject); })
                .AddTo(_cts.Token);

            searchCollider
                .OnTriggerStayAsObservable()
                .Where(other => other.gameObject.CompareTag(GameCommonData.PlayerTag))
                .Subscribe(other => { AddPlayer(other.gameObject); })
                .AddTo(_cts.Token);
        }

        public IObservable<GameObject> SearchObservable(float radius)
        {
            SetupPlayerList();
            SetupCollider(radius, true);

            return _playerList
                .ObserveAdd()
                .Do(_ => SetupCollider(0, false))
                .Select(player => player.Value);
        }

        private void Cancel()
        {
            if (_cts == null) return;
            _cts.Cancel();
            _cts.Dispose();
            _cts = null;
        }

        private void SetupPlayerList()
        {
            _playerList?.Clear();
            _playerList?.Dispose();
            _playerList = null;
            _playerList = new ReactiveCollection<GameObject>();
        }

        private void AddPlayer(GameObject player)
        {
            var playerConditionInfo = player.GetComponent<PlayerConditionInfo>();
            if (playerConditionInfo == null || playerConditionInfo.GetPlayerIndex() == _photonView.InstantiationId)
            {
                return;
            }

            if (!_playerList.Contains(player))
            {
                _playerList.Add(player);
            }
        }

        private void SetupCollider(float radius, bool enable)
        {
            if (_searchCollider == null)
            {
                return;
            }

            _searchCollider.enabled = enable;
            _searchCollider.radius = radius;
        }

        public void Dispose()
        {
            _playerList?.Dispose();
            Cancel();
        }

        public class Factory : PlaceholderFactory<GameObject, EnemySearchPlayer>
        {
        }
    }
}