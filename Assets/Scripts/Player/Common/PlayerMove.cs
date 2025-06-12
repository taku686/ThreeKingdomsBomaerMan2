using System;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager;
using Photon.Pun;
using UniRx;
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
        private Rigidbody _rigidbody;
        private Vector3 _currentDestination;
        private LayerMask _blockingLayer;
        private MoveDirection _currentMoveDirection;
        private MoveDirection _prevMoveDirection = MoveDirection.None;

        public void Initialize
        (
            Animator animator,
            IObservable<(StatusType statusType, float value)> speedBuffObservable,
            float moveSpeed
        )
        {
            _blockingLayer = LayerMask.GetMask(GameCommonData.ObstacleLayer) | LayerMask.GetMask(GameCommonData.BombLayer);
            _playerTransform = transform;
            _moveSpeed = moveSpeed;
            _rigidbody = GetComponent<Rigidbody>();
            SetAnimator(animator);
            Subscribe(speedBuffObservable);
        }

        public void ChangeCharacter(Animator animator, float moveSpeed)
        {
            SetAnimator(animator);
            _moveSpeed = moveSpeed;
        }

        private void SetAnimator(Animator animator)
        {
            _animator = animator;
            _movementAnimationManager ??= new MovementAnimationManager();
            _movementAnimationManager.SetAnimator(_animator);
        }

        private void Subscribe(IObservable<(StatusType statusType, float value)> speedBuffObservable)
        {
            speedBuffObservable
                .Where(tuple => tuple.statusType == StatusType.Speed)
                .Subscribe(tuple => { _moveSpeed = tuple.value; })
                .AddTo(gameObject);
        }

        public void Run(Vector3 inputValue)
        {
            if (!PhotonNetwork.LocalPlayer.IsLocal)
            {
                return;
            }

            _movementAnimationManager.Move(GetDirection(inputValue));
            if (inputValue is { x: 0, z: 0 })
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

        public void Dash()
        {
            if (!PhotonNetwork.LocalPlayer.IsLocal)
            {
                return;
            }

            var dodgeDirection = transform.forward * 0.1f;
            _rigidbody.AddForce(dodgeDirection, ForceMode.Acceleration);
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