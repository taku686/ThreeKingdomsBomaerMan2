using System;
using Bomb;
using Common.Data;
using Photon.Pun;
using UnityEngine;

namespace Player.Common
{
    public class PutBomb : MonoBehaviour
    {
        private MapManager _mapManager;
        private BombProvider _bombProvider;

        public void Initialize(BombProvider bombProvider, MapManager mapManager, TranslateStatusInBattleUseCase translateStatusInBattleUseCase)
        {
            _bombProvider = bombProvider;
            _mapManager = mapManager;
            SetupBombProvider(translateStatusInBattleUseCase);
        }

        //todo BombType毎に処理を分けるように修正する
        public void SetupBombProvider
        (
            TranslateStatusInBattleUseCase translateStatusInBattleUseCase
        )
        {
            _bombProvider.Initialize(translateStatusInBattleUseCase, BombType.Normal);
        }
        
        public void SetBomb
        (
            BoxCollider boxCollider,
            PhotonView photonView,
            Transform playerTransform,
            int bombType,
            int damageAmount,
            int fireRange,
            int explosionTime,
            int playerId
        )
        {
            var playerPos = playerTransform.position;
            if (CanPutBomb(playerPos, boxCollider))
            {
                return;
            }

            photonView.RPC(nameof(RpcPutBomb), RpcTarget.All, playerPos, bombType, damageAmount, fireRange, explosionTime, playerId);
        }

        [PunRPC]
        private void RpcPutBomb
        (
            Vector3 playerPos,
            int bombType,
            int damageAmount,
            int fireRange,
            int explosionTime,
            int playerId
        )
        {
            _mapManager.AddMap(MapManager.Area.Bomb, playerPos.x, playerPos.z);
            for (var i = 0; i <= fireRange; i++)
            {
                _mapManager.AddMap(MapManager.Area.Explosion, playerPos.x + i, playerPos.z);
                _mapManager.AddMap(MapManager.Area.Explosion, playerPos.x - i, playerPos.z);
                _mapManager.AddMap(MapManager.Area.Explosion, playerPos.x, playerPos.z + i);
                _mapManager.AddMap(MapManager.Area.Explosion, playerPos.x, playerPos.z - i);
            }

            var bomb = _bombProvider.GetBomb(bombType, damageAmount, fireRange, explosionTime, playerId);
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