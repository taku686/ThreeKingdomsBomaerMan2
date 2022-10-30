using System;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager;
using ModestTree;
using UniRx;
using UnityEngine;
using Zenject;

namespace Player.Common
{
    public class PlayerMove : MonoBehaviour, IPlayerMove
    {
        [Inject] private AnimationManager _animationManager;
        private float _moveSpeed;

        private Vector3 _initRotation;
        private Animator _animator;
        private bool _isMoving;
        private ReactiveProperty<Direction> _currentDirection = new ReactiveProperty<Direction>(Direction.None);
        private CancellationToken _token;
        private bool _isTurn;


        public void Initialize(float moveSpeed)
        {
            _token = this.GetCancellationTokenOnDestroy();
            _animator = GetComponent<Animator>();
            _initRotation = transform.localEulerAngles;
            _moveSpeed = moveSpeed;
        }

        public async UniTask Rotate(Vector3 direction)
        {
            if (_isTurn || (direction.x == 0 && direction.z == 0))
            {
                return;
            }

            await transform
                .DOLocalRotate(GetRotation(GetDirection(direction.x, direction.z)).eulerAngles,
                    GameSettingData.TurnDuration)
                .AsyncWaitForCompletion();
            _isTurn = false;
        }

        public async UniTask Rotate(float dirX, float dirZ)
        {
            if (_isTurn || (dirX == 0 && dirZ == 0))
            {
                return;
            }

            await transform
                .DOLocalRotate(GetRotation(GetDirection(dirX, dirZ)).eulerAngles,
                    GameSettingData.TurnDuration)
                .AsyncWaitForCompletion();
            _isTurn = false;
        }

        public void AnimationMove(Vector3 direction)
        {
           // _animationManager.Move(direction.x, direction.z);
        }

        public async UniTaskVoid Move(Vector3 direction)
        {
            if (_isMoving)
            {
                return;
            }

            float xDir = direction.x;
            float zDir = direction.z;
            float absX = Mathf.Abs(xDir);
            float absZ = Mathf.Abs(zDir);
            if (absX > absZ)
            {
                if (absX >= GameSettingData.MoveThreshold)
                {
                    xDir = xDir > 0 ? 1 : -1;
                }
                else
                {
                    xDir = 0;
                }
                zDir = 0;
            }
            else if (absX < absZ)
            {
                if (absZ >= GameSettingData.MoveThreshold)
                {
                    zDir = zDir > 0 ? 1 : -1;
                }
                else
                {
                    zDir = 0;
                }

                xDir = 0;
            }
            
            Rotate(xDir, zDir).AttachExternalCancellation(this.GetCancellationTokenOnDestroy()).Forget();
          //  _animationManager.Move(xDir, zDir);
            if (xDir != 0 || zDir != 0)
            {
                Vector3 start = transform.position;
                Vector3 end = start + new Vector3(xDir, 0, zDir);

                bool isHit = Physics.Raycast(new Vector3(start.x, 0.5f, start.z),
                    new Vector3(end.x, 0.5f, end.z) - start,
                    1, LayerMask.GetMask("BlockingLayer"), QueryTriggerInteraction.Collide);

                // 衝突しておらず、移動中でなく
                if (!isHit)
                {
                    // 滑らかな移動を開始
                    SmoothMovement(end);
                }
            }
        }

        private async void SmoothMovement(Vector3 end)
        {
            var sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            _isMoving = true;

            while (sqrRemainingDistance > float.Epsilon)
            {
                var position1 = transform.position;
                var position = position1;
                position1 = Vector3.MoveTowards(position, end, _moveSpeed * Time.deltaTime);
                transform.position = position1;
                sqrRemainingDistance = (position1 - end).sqrMagnitude;
                await UniTask.Yield();
            }

            _isMoving = false;
        }

        private Quaternion GetRotation(float h, float v)
        {
            if (h > GameSettingData.MoveThreshold)
            {
                return Quaternion.Euler(_initRotation + new Vector3(0, -90, 0));
            }

            if (h < -GameSettingData.MoveThreshold)
            {
                return Quaternion.Euler(_initRotation + new Vector3(0, 90, 0));
            }

            if (v > GameSettingData.MoveThreshold)
            {
                return Quaternion.Euler(_initRotation + new Vector3(0, -180, 0));
            }

            if (v < -GameSettingData.MoveThreshold)
            {
                return Quaternion.Euler(_initRotation);
            }
            else
            {
                return Quaternion.Euler(Vector3.zero);
            }
        }

        private Quaternion GetRotation(Direction dir)
        {
            if (dir == Direction.Right)
            {
                return Quaternion.Euler(_initRotation + new Vector3(0, -90, 0));
            }

            if (dir == Direction.Left)
            {
                return Quaternion.Euler(_initRotation + new Vector3(0, 90, 0));
            }

            if (dir == Direction.Back)
            {
                return Quaternion.Euler(_initRotation + new Vector3(0, -180, 0));
            }

            if (dir == Direction.Forward)
            {
                return Quaternion.Euler(_initRotation);
            }

            if (dir == Direction.None)
            {
                return transform.rotation;
            }

            return Quaternion.Euler(Vector3.zero);
        }

        private Direction GetDirection(float h, float v)
        {
            if (h > GameSettingData.RotateThreshold)
            {
                return Direction.Right;
            }

            if (h < -GameSettingData.RotateThreshold)
            {
                return Direction.Left;
            }

            if (v > GameSettingData.RotateThreshold)
            {
                return Direction.Back;
            }

            if (v < -GameSettingData.RotateThreshold)
            {
                return Direction.Forward;
            }
            else
            {
                return Direction.None;
            }
        }
    }
}