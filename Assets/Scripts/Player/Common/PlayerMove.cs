using System;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager;
using UnityEngine;

namespace Player.Common
{
    public class PlayerMove : MonoBehaviour
    {
        private static readonly float GridScale = 1.0f;
        private static readonly float ObstacleDistance = 0.05f;
        private static readonly float Radius = 0.3f;
        private static readonly float RayDistance = 1.0f - Radius;
        private static readonly float RotateDuration = 0.1f;
        private Vector3 _initRotation;
        private Transform _playerTransform;
        private bool _isMoving;
        private LayerMask _blockingLayer;
        private float _moveSpeed;
        private Direction _currentDirection;
        private Direction _prevDirection = Direction.None;
        private Animator _animator;
        private AnimationManager _animationManager;
        private CancellationTokenSource _cts;
        private Vector3 _currentDestination;

        private void Start()
        {
            Initialize(3);
        }

        private void Update()
        {
            Move(new Vector3(UltimateJoystick.GetHorizontalAxis(GameSettingData.JoystickName), 0,
                UltimateJoystick.GetVerticalAxis(GameSettingData.JoystickName))).Forget();
        }

        public void Initialize(float moveSpeed)
        {
            _cts = new CancellationTokenSource();
            _blockingLayer = LayerMask.GetMask("BlockingLayer");
            _playerTransform = this.transform;
            _initRotation = _playerTransform.rotation.eulerAngles;
            _moveSpeed = moveSpeed;
            if (!gameObject.TryGetComponent(typeof(Animator), out Component animator))
            {
                Debug.LogError("Animatorがついてない！！");
                return;
            }

            _animator = (Animator)animator;
            _animationManager = new AnimationManager(_animator);
        }

        public async UniTaskVoid Move(Vector3 inputValue)
        {
            inputValue *= 0.5f;
            if (_isMoving)
            {
                if (IsObstacle(_playerTransform.position, _currentDestination, out var hit))
                {
                    Stop();
                }

                return;
            }

            var goDir = GetDirection(inputValue);
            Rotate(goDir, _playerTransform);
            _animationManager.Move(goDir);
            OnChangeDirection(goDir);
            if (goDir == Direction.None)
            {
                return;
            }

            inputValue = ModifiedInputValue(inputValue, goDir);
            var playerPos = _playerTransform.position;
            var destination = GetDestination(playerPos, inputValue);
            var isObstacle = IsObstacle(playerPos, destination, out var obstacle);
            var modifiedDestination =
                ModifiedDestination(goDir, _prevDirection, destination, playerPos, out Direction modifiedDir);
            _currentDestination = modifiedDestination;
            if (!isObstacle)
            {
                Rotate(modifiedDir, _playerTransform);
                await Movement(playerPos, modifiedDestination)
                    .AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
                return;
            }

            var canAvoid = CanAvoid(playerPos, obstacle.transform.position, goDir);
            if (!canAvoid)
            {
                return;
            }

            isObstacle = IsObstacle(playerPos, modifiedDestination, out obstacle);
            if (!isObstacle)
            {
                Rotate(modifiedDir, _playerTransform);
                await Movement(playerPos, modifiedDestination)
                    .AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
            }
        }

        private Direction GetDirection(Vector3 direction)
        {
            if (direction.x == 0 && direction.z == 0)
            {
                return Direction.None;
            }

            float absX = Mathf.Abs(direction.x);
            float absZ = Mathf.Abs(direction.z);
            if (absX > absZ)
            {
                return direction.x > 0 ? Direction.Right : Direction.Left;
            }

            if (absZ > absX)
            {
                return direction.z > 0 ? Direction.Forward : Direction.Back;
            }

            return Direction.None;
        }

        private Vector3 ModifiedInputValue(Vector3 inputValue, Direction dir)
        {
            if (dir == Direction.None)
            {
                return inputValue;
            }

            if (dir == Direction.Right || dir == Direction.Left)
            {
                inputValue.z = 0;
            }

            if (dir == Direction.Forward || dir == Direction.Back)
            {
                inputValue.x = 0;
            }

            return inputValue;
        }

        private Vector3 GetDestination(Vector3 start, Vector3 moveAmount)
        {
            return start + moveAmount;
        }

        private Vector3 ModifiedDestination(Direction currentDir, Direction previousDir, Vector3 currentDestination,
            Vector3 playerPos, out Direction modifiedDir)
        {
            modifiedDir = currentDir;
            //進行方向が同じ場合
            if (previousDir == currentDir || currentDir == Direction.None)
            {
                return currentDestination;
            }

            //前、後ろ方向に直角に曲がるとき + 止まっていて前、後ろに動き始めるとき
            if ((currentDir == Direction.Forward || currentDir == Direction.Back) &&
                (previousDir == Direction.Left || previousDir == Direction.Right || previousDir == Direction.None))
            {
                //x軸方向の値を修正
                float currentX = currentDestination.x;
                float modifiedX = currentDestination.x;
                if (currentX % GridScale == 0)
                {
                    return currentDestination;
                }

                if (currentX > 0)
                {
                    modifiedX = (int)currentX % 2 == 0 ? Mathf.Floor(currentX) : Mathf.Ceil(currentX);
                    modifiedDir = (int)currentX % 2 == 0 ? Direction.Left : Direction.Right;
                }
                else if (currentX < 0)
                {
                    modifiedX = (int)currentX % 2 == 0 ? Mathf.Ceil(currentX) : Mathf.Floor(currentX);
                    modifiedDir = (int)currentX % 2 == 0 ? Direction.Right : Direction.Left;
                }

                return new Vector3(modifiedX, currentDestination.y, playerPos.z);
            }

            //左、右に直角に曲がるとき　+ 止まっていて左、右に動き始めるとき
            if ((currentDir == Direction.Left || currentDir == Direction.Right) &&
                (previousDir == Direction.Forward || previousDir == Direction.Back || previousDir == Direction.None))
            {
                //z軸の値を修正
                float currentZ = currentDestination.z;
                float modifiedZ = currentDestination.z;
                if (currentZ % GridScale == 0)
                {
                    return currentDestination;
                }

                if (currentZ > 0)
                {
                    modifiedZ = (int)currentZ % 2 == 0 ? Mathf.Ceil(currentZ) : Mathf.Floor(currentZ);
                    modifiedDir = (int)currentZ % 2 == 0 ? Direction.Forward : Direction.Back;
                }
                else if (currentZ < 0)
                {
                    modifiedZ = (int)currentZ % 2 == 0 ? Mathf.Floor(currentZ) : Mathf.Ceil(currentZ);
                    modifiedDir = (int)currentZ % 2 == 0 ? Direction.Back : Direction.Forward;
                }

                return new Vector3(playerPos.x, currentDestination.y, modifiedZ);
            }

            return currentDestination;
        }

        private void OnChangeDirection(Direction currentDirection)
        {
            if (_currentDirection == currentDirection)
            {
                return;
            }

            _prevDirection = _currentDirection;
            _currentDirection = currentDirection;
        }

        private bool IsObstacle(Vector3 start, Vector3 end, out RaycastHit obstacle)
        {
            start = new Vector3(start.x, 0.5f, start.z);
            end = new Vector3(end.x, 0.5f, end.z);
            Debug.DrawLine(start, end, Color.red, 0.1f);
            return Physics.SphereCast(start, Radius, end - start, out obstacle, RayDistance, _blockingLayer,
                QueryTriggerInteraction.Collide);
        }

        private async UniTask Movement(Vector3 start, Vector3 end)
        {
            var sqrRemainingDistance = (start - end).sqrMagnitude;
            _isMoving = true;

            while (sqrRemainingDistance > float.Epsilon && !_cts.Token.IsCancellationRequested)
            {
                var position1 = _playerTransform.position;
                var position = position1;
                position1 = Vector3.MoveTowards(position, end, _moveSpeed * Time.deltaTime);
                transform.position = position1;
                sqrRemainingDistance = (position1 - end).sqrMagnitude;
                await UniTask.Yield(PlayerLoopTiming.Update, _cts.Token);
            }

            _playerTransform.position = end;
            _isMoving = false;
        }

        private bool CanAvoid(Vector3 playerPos, Vector3 obstaclePos, Direction goDir)
        {
            if (goDir == Direction.Back || goDir == Direction.Forward)
            {
                return Mathf.Abs(playerPos.x - obstaclePos.x) > ObstacleDistance;
            }

            if (goDir == Direction.Left || goDir == Direction.Right)
            {
                return Mathf.Abs(playerPos.z - obstaclePos.z) > ObstacleDistance;
            }

            return false;
        }

        private void Rotate(Direction direction, Transform player)
        {
            if (direction == Direction.None)
            {
                return;
            }

            Vector3 nextRotation = _initRotation;
            switch (direction)
            {
                case Direction.Back:
                    nextRotation = _initRotation;
                    break;
                case Direction.Forward:
                    nextRotation = _initRotation + new Vector3(0, -180, 0);
                    break;
                case Direction.Right:
                    nextRotation = _initRotation + new Vector3(0, -90, 0);
                    break;
                case Direction.Left:
                    nextRotation = _initRotation + new Vector3(0, 90, 0);
                    break;
                default:
                    break;
            }

            player.DOLocalRotate(nextRotation, RotateDuration);
        }

        private void Stop()
        {
            _isMoving = false;
            _cts.Cancel();
            _cts.Dispose();
            _cts = new CancellationTokenSource();
        }
    }
}