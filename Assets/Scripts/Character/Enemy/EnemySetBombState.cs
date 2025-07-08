using Common.Data;
using Photon.Pun;
using Player.Common;
using UnityEngine;
using State = StateMachine<Enemy.EnemyCore>.State;

namespace Enemy
{
    public partial class EnemyCore
    {
        public class EnemyPutBombState : State
        {
            private TranslateStatusInBattleUseCase _TranslateStatusInBattleUseCase => Owner._translateStatusInBattleUseCase;
            private StateMachine<EnemyCore> _stateMachine => Owner._stateMachine;
            private PhotonView _photonView => Owner._photonView;
            private MapManager _mapManager => Owner.mapManager;
            private BoxCollider _boxCollider => Owner._boxCollider;
            private PutBomb _putBomb => Owner._putBomb;
            private bool _isPutBomb;

            private const int WaitDurationBeforeExplosion = 3000; // 3 seconds

            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            protected override void OnUpdate()
            {
                if (_isPutBomb)
                {
                    _stateMachine.Dispatch((int)EnemyState.Escape);
                }
            }

            private void Initialize()
            {
                _isPutBomb = false;
                _stateMachine = Owner._stateMachine;
                _photonView = Owner._photonView;
                _boxCollider = Owner._boxCollider;
                _putBomb = Owner._putBomb;
                PutBomb();
            }

            private void PutBomb()
            {
                var playerId = _photonView.ViewID;
                var explosionTime = PhotonNetwork.ServerTimestamp + WaitDurationBeforeExplosion;
                var photonView = _photonView;
                //todo 後で修正
                var damageAmount = _TranslateStatusInBattleUseCase._Attack;
                var fireRange = _TranslateStatusInBattleUseCase._FireRange;
                var boxCollider = _boxCollider;
                _putBomb.SetBomb
                (
                    boxCollider,
                    photonView,
                    Owner.transform,
                    (int)BombType.Normal,
                    50,
                    5,
                    explosionTime,
                    playerId
                );
                _isPutBomb = true;
            }
        }
    }
}