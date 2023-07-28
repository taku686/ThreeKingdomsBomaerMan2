using System;
using Common.Data;
using Photon.Pun;
using UniRx;
using UnityEngine;

namespace Manager.BattleManager.Environment
{
    public class BreakingWall : MonoBehaviour
    {
        [SerializeField] private AStarManager _aStarManager;
        public Subject<Unit> onDestroy = new();

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(GameCommonData.BombEffectTag))
            {
                return;
            }

            Destroy(gameObject);
            //PhotonNetwork.Destroy(gameObject);
        }

        private void OnDestroy()
        {
            onDestroy.OnNext(Unit.Default);
        }
    }
}