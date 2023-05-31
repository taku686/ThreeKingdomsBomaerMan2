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
            private PhotonView _photonView;
            private CharacterStatusManager _characterStatusManager;
            private BoxCollider _boxCollider;
            private PutBomb _putBomb;

            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            private void Initialize()
            {
                _photonView = Owner._photonView;
                _characterStatusManager = Owner._characterStatusManager;
                _boxCollider = Owner._boxCollider;
                _putBomb = Owner._putBomb;
                PutBomb();
            }

            private void PutBomb()
            {
                Debug.Log("ボム設置");
                var playerId = _photonView.ViewID;
                var explosionTime = PhotonNetwork.ServerTimestamp +
                                    GameCommonData.ThreeMilliSecondsBeforeExplosion;
                var photonView = _photonView;
                var damageAmount = _characterStatusManager.DamageAmount;
                var fireRange = _characterStatusManager.FireRange;
                var boxCollider = _boxCollider;
                _putBomb.SetBomb(boxCollider, photonView, Owner.transform,
                    (int)BombType.Normal, damageAmount, fireRange, explosionTime, playerId);
            }
        }
    }
}