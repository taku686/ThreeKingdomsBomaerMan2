using Bomb;
using Common.Data;
using Photon.Pun;
using UnityEngine;
using Zenject;

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
            photonView.RPC(nameof(RpcPutBomb), RpcTarget.All, playerTransform.position, bombType, damageAmount,
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
    }
}