using Bomb;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Player.Common
{
    public class PlayerDead : MonoBehaviour
    {
        private Direction jumpDirection;
        private static readonly float EndPosY = 10;
        private static readonly float Magnification = 30;
        private static readonly float JumpPower = 0.5f;
        private static readonly int JumpCount = 0;
        private static readonly float JumpDuration = 3f;
        private static readonly Vector3 EndRotate = new(3600, 0, 3600);
        private Vector3 endPos;


        public void OnTouchExplosion(Explosion explosion)
        {
            jumpDirection = explosion.explosionDirection;
        }

        public async UniTask BigJump(Transform player)
        {
            var rigid = player.GetComponent<Rigidbody>();
            rigid.constraints = RigidbodyConstraints.None;
            var sequence = DOTween.Sequence();
            var dir = GameCommonData.DirectionToVector3(jumpDirection);
            var isZ = dir.z != 0;
            var endPosZ = isZ ? dir.z * Magnification : player.position.z;
            var endPosX = isZ ? player.position.x : dir.x * Magnification;
            endPos = new Vector3(endPosX, EndPosY, endPosZ);
            await sequence.Append(player.DOLocalJump(endPos, JumpPower, JumpCount, JumpDuration))
                .Join(player.DORotate(EndRotate, JumpDuration, RotateMode.WorldAxisAdd)).ToUniTask()
                .AttachExternalCancellation(player.GetCancellationTokenOnDestroy());
        }
    }
}