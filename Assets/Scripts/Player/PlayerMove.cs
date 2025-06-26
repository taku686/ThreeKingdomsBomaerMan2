using Common.Data;
using Manager;
using Photon.Pun;
using Skill;
using UnityEngine;

namespace Player.Common
{
    public class PlayerMove : MonoBehaviour
    {
        private bool _isMoving;
        private float _moveSpeed;
        private Transform _playerTransform;
        private Animator _animator;
        private MovementAnimationManager _movementAnimationManager;
        private AbnormalConditionEffect _abnormalConditionEffect;
        private Rigidbody _rigidbody;
        private Vector3 _currentDestination;
        private LayerMask _blockingLayer;
        private MoveDirection _currentMoveDirection;

        public void Initialize
        (
            Animator animator,
            AbnormalConditionEffect abnormalConditionEffect
        )
        {
            _blockingLayer = LayerMask.GetMask(GameCommonData.ObstacleLayer) | LayerMask.GetMask(GameCommonData.BombLayer);
            _playerTransform = transform;
            _rigidbody = GetComponent<Rigidbody>();
            _abnormalConditionEffect = abnormalConditionEffect;
            SetAnimator(animator);
        }

        public void ChangeSpeed(float moveSpeed)
        {
            _moveSpeed = moveSpeed;
        }

        public void SetAnimator(Animator animator)
        {
            _animator = animator;
            _movementAnimationManager ??= new MovementAnimationManager();
            _movementAnimationManager.SetAnimator(_animator);
        }

        public void Run(Vector3 inputValue)
        {
            _movementAnimationManager.Move(GetDirection(inputValue));
            if (inputValue is { x: 0, z: 0 } || !_abnormalConditionEffect._canMove)
            {
                _rigidbody.velocity = Vector3.zero;
                return;
            }

            {
                _rigidbody.velocity = Vector3.zero;
                return;
            }


            if (IsObstacleOnLine(_playerTransform.position, inputValue))
            {
                transform.localRotation = Quaternion.LookRotation(inputValue);
                _rigidbody.velocity = Vector3.zero;
                return;
            }

            _rigidbody.velocity = inputValue * _moveSpeed;
            transform.localRotation = Quaternion.LookRotation(inputValue);
        }

        public void Stop()
        {
            if (!PhotonNetwork.LocalPlayer.IsLocal)
            {
                return;
            }

            _rigidbody.velocity = Vector3.zero;
        }

        private static MoveDirection GetDirection(Vector3 direction)
        {
            if (direction is { x: 0, z: 0 })
            {
                return MoveDirection.None;
            }

            var absX = Mathf.Abs(direction.x);
            var absZ = Mathf.Abs(direction.z);
            if (absX > absZ)
            {
                return direction.x > 0 ? MoveDirection.Right : MoveDirection.Left;
            }

            if (absZ > absX)
            {
                return direction.z > 0 ? MoveDirection.Forward : MoveDirection.Back;
            }

            return MoveDirection.None;
        }

        private bool IsObstacleOnLine(Vector3 start, Vector3 inputValue)
        {
            var end = start + inputValue;
            return Physics.Linecast(start, end, _blockingLayer);
        }
    }
}