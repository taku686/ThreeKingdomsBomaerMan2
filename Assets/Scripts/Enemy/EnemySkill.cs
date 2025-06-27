using System;
using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.NetworkManager;
using Photon.Pun;
using Player.Common;
using UniRx;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public class EnemySkill : IDisposable
    {
        private readonly SkillMasterData _normalSkillMasterData;
        private SkillMasterData _specialSkillMasterData;
        private SkillMasterData _weaponSkillMasterData;
        private readonly SearchPlayer _searchPlayer;
        private readonly Animator _animator;
        private readonly PlayerConditionInfo _playerConditionInfo;
        private CancellationTokenSource _cancellationTokenSource = new();

        [Inject]
        public EnemySkill
        (
            SkillMasterData normalSkillMasterData,
            SkillMasterData specialSkillMasterData,
            SkillMasterData weaponSkillMasterData,
            SearchPlayer searchPlayer,
            Animator animator,
            PlayerConditionInfo playerConditionInfo
        )
        {
            _normalSkillMasterData = normalSkillMasterData;
            _specialSkillMasterData = specialSkillMasterData;
            _weaponSkillMasterData = weaponSkillMasterData;
            _searchPlayer = searchPlayer;
            _animator = animator;
            _playerConditionInfo = playerConditionInfo;
        }

        public void Subscribe()
        {
            _cancellationTokenSource = new CancellationTokenSource();

            var validRange = Observable
                .Timer(TimeSpan.FromSeconds(_normalSkillMasterData.Interval))
                .Select(_ => !Mathf.Approximately(_normalSkillMasterData.Range, GameCommonData.InvalidNumber))
                .Publish();

            validRange
                .Where(valid => valid)
                .SelectMany(_ => _searchPlayer.SearchObservable(_normalSkillMasterData.Range, _cancellationTokenSource.Token))
                .Subscribe(player =>
                {
                    PlayBackAnimation(_normalSkillMasterData);
                    var playerIndex = _playerConditionInfo.GetPlayerIndex();
                    var dic = new Dictionary<int, int> { { playerIndex, _normalSkillMasterData.Id } };
                    PhotonNetwork.LocalPlayer.SetSkillData(dic);
                    Cancel();
                })
                .AddTo(_cancellationTokenSource.Token);

            validRange
                .Where(valid => !valid)
                .Subscribe(_ =>
                {
                    PlayBackAnimation(_normalSkillMasterData);
                    var playerIndex = _playerConditionInfo.GetPlayerIndex();
                    var dic = new Dictionary<int, int> { { playerIndex, _normalSkillMasterData.Id } };
                    PhotonNetwork.LocalPlayer.SetSkillData(dic);
                    Cancel();
                })
                .AddTo(_cancellationTokenSource.Token);

            validRange.Connect().AddTo(_cancellationTokenSource.Token);
        }

        private void SkillSubscribe(SkillMasterData skillMasterData)
        {
            _cancellationTokenSource = new CancellationTokenSource();

            var validRange = Observable
                .Timer(TimeSpan.FromSeconds(skillMasterData.Interval))
                .Select(_ => !Mathf.Approximately(skillMasterData.Range, GameCommonData.InvalidNumber))
                .Publish();

            validRange
                .Where(valid => valid)
                .SelectMany(_ => _searchPlayer.SearchObservable(skillMasterData.Range, _cancellationTokenSource.Token))
                .Subscribe(player =>
                {
                    PlayBackAnimation(skillMasterData);
                    var playerIndex = _playerConditionInfo.GetPlayerIndex();
                    var dic = new Dictionary<int, int> { { playerIndex, skillMasterData.Id } };
                    PhotonNetwork.LocalPlayer.SetSkillData(dic);
                    Cancel();
                })
                .AddTo(_cancellationTokenSource.Token);

            validRange
                .Where(valid => !valid)
                .Subscribe(_ =>
                {
                    PlayBackAnimation(skillMasterData);
                    var playerIndex = _playerConditionInfo.GetPlayerIndex();
                    var dic = new Dictionary<int, int> { { playerIndex, skillMasterData.Id } };
                    PhotonNetwork.LocalPlayer.SetSkillData(dic);
                    Cancel();
                })
                .AddTo(_cancellationTokenSource.Token);

            validRange.Connect().AddTo(_cancellationTokenSource.Token);
        }

        private void PlayBackAnimation(SkillMasterData skillMasterData)
        {
            if (skillMasterData._SkillActionTypeEnum == SkillActionType.None)
            {
                return;
            }

            _animator.SetTrigger(GameCommonData.GetAnimatorHashKey(skillMasterData._SkillActionTypeEnum));
        }

        private void Cancel()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }

        public void Dispose()
        {
            Cancel();
        }

        public class Factory : PlaceholderFactory
        <
            SkillMasterData,
            SkillMasterData,
            SkillMasterData,
            SearchPlayer,
            Animator,
            PlayerConditionInfo,
            EnemySkill
        >
        {
        }
    }
}