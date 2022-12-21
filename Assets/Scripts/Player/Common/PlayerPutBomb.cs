using Bomb;
using Photon.Pun;
using UnityEngine;

namespace Player.Common
{
    public class PlayerPutBomb : MonoBehaviour
    {
        private BombProvider _bombProvider;

        public void Initialize(BombProvider bombProvider)
        {
            _bombProvider = bombProvider;
        }

        public void PutBomb(PhotonView photonView, Transform playerTransform, int bombType, int damageAmount,
            int fireRange, int explosionTime, int playerId)
        {
            var playerPos = CalculatePlayerPos(playerTransform.position);
            photonView.RPC(nameof(RpcPutBomb), RpcTarget.All, playerPos, bombType, damageAmount,
                fireRange,
                explosionTime, playerId);
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
    }
}