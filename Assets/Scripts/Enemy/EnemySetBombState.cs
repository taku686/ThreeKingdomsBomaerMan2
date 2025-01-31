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
            private StateMachine<EnemyCore> _stateMachine;
            private PhotonView _photonView;
            private TranslateStatusForBattleUseCase translateStatusForBattleUseCase;
            private MapManager _mapManager;
            private BoxCollider _boxCollider;
            private PutBomb _putBomb;
            private bool _isPutBomb;

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
                translateStatusForBattleUseCase = Owner.translateStatusForBattleUseCase;
                _boxCollider = Owner._boxCollider;
                _putBomb = Owner._putBomb;
                PutBomb();
            }

            private void PutBomb()
            {
                Debug.Log("ボム設置");
                var playerId = _photonView.ViewID;
                var explosionTime = PhotonNetwork.ServerTimestamp + GameCommonData.ThreeMilliSecondsBeforeExplosion;
                var photonView = _photonView;
                var damageAmount = translateStatusForBattleUseCase._Attack;
                var fireRange = translateStatusForBattleUseCase._FireRange;
                var boxCollider = _boxCollider;
                _putBomb.SetBomb(boxCollider, photonView, Owner.transform,
                    (int)BombType.Normal, damageAmount, fireRange, explosionTime, playerId);
                _isPutBomb = true;
            }
        }
    }
}