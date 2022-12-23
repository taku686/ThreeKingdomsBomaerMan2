using Bomb;
using Common.Data;
using DG.Tweening;
using UI.Battle;
using UniRx;
using UnityEngine;

namespace Player.Common
{
    public class PlayerDead : MonoBehaviour
    {
        private Direction _jumpDirection;
        private static readonly float EndPosY = 10;
        private static readonly float Magnification = 30;
        private static readonly float JumpPower = 0.5f;
        private static readonly int JumpCount = 0;
        private static readonly float JumpDuration = 3f;
        private static readonly Vector3 EndRotate = new Vector3(3600, 0, 3600);
        private Vector3 _endPos;


        public void OnTouchExplosion(Explosion explosion)
        {
            _jumpDirection = explosion.explosionDirection;
        }

        public void BigJump(Transform player)
        {
            var rigid = player.GetComponent<Rigidbody>();
            rigid.constraints = RigidbodyConstraints.None;
            var sequence = DOTween.Sequence();
            var dir = GameSettingData.DirectionToVector3(_jumpDirection);
            var isZ = dir.z != 0;
            var endPosZ = isZ ? dir.z * Magnification : player.position.z;
            var endPosX = isZ ? player.position.x : dir.x * Magnification;
            _endPos = new Vector3(endPosX, EndPosY, endPosZ);
            sequence.Append(player.DOLocalJump(_endPos, JumpPower, JumpCount, JumpDuration))
                .Join(player.DORotate(EndRotate, JumpDuration, RotateMode.WorldAxisAdd)).SetLink(player.gameObject);
        }
    }
}