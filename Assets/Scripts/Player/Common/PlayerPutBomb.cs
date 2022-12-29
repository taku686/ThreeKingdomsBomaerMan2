using Bomb;
using Common.Data;
using Photon.Pun;
using UnityEngine;

namespace Player.Common
{
    public class PlayerPutBomb : MonoBehaviour
    {
        private BombProvider _bombProvider;
        private const float RayDistance = 1f;
        private const float ModifiedValue = 2f;

        public void Initialize(BombProvider bombProvider,PlayerStatusManager playerStatusManager)
        {
            _bombProvider = bombProvider;
            _bombProvider.Initialize(playerStatusManager);
        }


        public void PutBomb(BoxCollider boxCollider, PhotonView photonView, Transform playerTransform, int bombType,
            int damageAmount,
            int fireRange, int explosionTime, int playerId)
        {
            var playerPos = CalculatePlayerPos(playerTransform.position);
            if (CanPutBomb(playerPos, boxCollider))
            {
                return;
            }

            photonView.RPC(nameof(RpcPutBomb), RpcTarget.All, playerPos, bombType, damageAmount,
                fireRange, explosionTime, playerId);
        }

        [PunRPC]
        private void RpcPutBomb(Vector3 playerPos, int bombType, int damageAmount, int fireRange,
            int explosionTime, int playerId)
        {
            var bomb = _bombProvider.GetBomb(bombType, damageAmount, fireRange, explosionTime, playerId);
            bomb.transform.position = playerPos;
        }

        private Vector3 CalculatePlayerPos(Vector3 playerPos)
        {
            var modifiedPlayerPos =
                new Vector3(Mathf.RoundToInt(playerPos.x), playerPos.y, Mathf.RoundToInt(playerPos.z));
            return modifiedPlayerPos;
        }

        private bool CanPutBomb(Vector3 startPos, BoxCollider boxCollider)
        {
            var pos = new Vector3(startPos.x, startPos.y + ModifiedValue, startPos.z);
            boxCollider.enabled = false;
            var hasBomb = Physics.Raycast(pos, Vector3.down, RayDistance,
                LayerMask.GetMask(GameSettingData.BombLayer),
                QueryTriggerInteraction.Collide);
            boxCollider.enabled = true;
            return hasBomb;
        }
    }
}