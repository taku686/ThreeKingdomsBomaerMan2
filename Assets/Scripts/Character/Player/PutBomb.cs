using Bomb;
using Common.Data;
using Photon.Pun;
using UnityEngine;

namespace Player.Common
{
    public class PutBomb : MonoBehaviour
    {
        private Transform _playerTransform;
        private BombProvider _bombProvider;
        private BoxCollider _boxCollider;
        private PhotonView _photonView;
        private int _instantiationId;

        public void Initialize
        (
            Transform playerTransform,
            PhotonView photonView,
            BoxCollider boxCollider,
            BombProvider bombProvider,
            TranslateStatusInBattleUseCase translateStatusInBattleUseCase
        )
        {
            _playerTransform = playerTransform;
            _photonView = photonView;
            _boxCollider = boxCollider;
            _bombProvider = bombProvider;
            _instantiationId = photonView.InstantiationId;
            SetupBombProvider(translateStatusInBattleUseCase);
        }

        //todo BombType毎に処理を分けるように修正する
        public void SetupBombProvider
        (
            TranslateStatusInBattleUseCase translateStatusInBattleUseCase
        )
        {
            _bombProvider.Initialize(translateStatusInBattleUseCase, BombType.Normal);
            _bombProvider.Initialize(translateStatusInBattleUseCase, BombType.Attribute);
        }

        public void SetBomb
        (
            int bombType,
            int damageAmount,
            int fireRange,
            int explosionTime,
            int skillId,
            AbnormalCondition abnormalCondition = AbnormalCondition.None
        )
        {
            var playerPos = _playerTransform.position;
            if (CanPutBomb(playerPos, _boxCollider))
            {
                return;
            }

            _photonView.RPC
            (
                nameof(RpcPutBomb),
                RpcTarget.All,
                playerPos,
                bombType,
                damageAmount,
                fireRange,
                explosionTime,
                _instantiationId,
                skillId,
                abnormalCondition
            );
        }

        [PunRPC]
        private void RpcPutBomb
        (
            Vector3 playerPos,
            int bombType,
            int damageAmount,
            int fireRange,
            int explosionTime,
            int instantiationId,
            int skillId,
            AbnormalCondition abnormalCondition
        )
        {
            var bomb = _bombProvider.GetBomb
            (
                bombType,
                damageAmount,
                fireRange,
                explosionTime,
                instantiationId,
                skillId,
                abnormalCondition
            );
            bomb.transform.position = new Vector3(playerPos.x, playerPos.y, playerPos.z);
        }

        private static bool CanPutBomb(Vector3 startPos, BoxCollider boxCollider)
        {
            var pos = new Vector3(startPos.x, startPos.y, startPos.z);
            boxCollider.enabled = false;
            var hasBomb = Physics.CheckSphere
            (
                pos,
                0.4f,
                LayerMask.GetMask(GameCommonData.BombLayer),
                QueryTriggerInteraction.Collide
            );
            boxCollider.enabled = true;
            return hasBomb;
        }
    }
}