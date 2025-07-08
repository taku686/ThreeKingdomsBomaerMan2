using Character;
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
            private PlayerStatusInfo _PlayerStatusInfo => Owner._playerStatusInfo;
            private StateMachine<EnemyCore> _StateMachine => Owner._stateMachine;
            private PhotonView _PhotonView => Owner._photonView;
            private BoxCollider _BoxCollider => Owner._boxCollider;
            private PutBomb _PutBomb => Owner._putBomb;
            private bool _isPutBomb;

            private const int WaitDurationBeforeExplosion = 3000; // 3 seconds

            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            protected override void OnUpdate()
            {
                if (!_isPutBomb) return;
                _StateMachine.Dispatch((int)EnemyState.Move);
            }

            private void Initialize()
            {
                _isPutBomb = false;
                PutBomb();
            }

            private void PutBomb()
            {
                var playerTransform = Owner.transform;
                var playerId = _PhotonView.ViewID;
                var explosionTime = PhotonNetwork.ServerTimestamp + WaitDurationBeforeExplosion;
                var photonView = _PhotonView;
                var damageAmount = _PlayerStatusInfo._Attack.Value;
                var fireRange = _PlayerStatusInfo._FireRange.Value;
                var boxCollider = _BoxCollider;
                _PutBomb.SetBomb
                (
                    boxCollider,
                    photonView,
                    playerTransform,
                    (int)BombType.Normal,
                    damageAmount,
                    fireRange,
                    explosionTime,
                    playerId
                );
                _isPutBomb = true;
            }
        }
    }
}