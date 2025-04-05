using System;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager;
using UniRx;
using UnityEngine;

namespace Player.Common
{
    public class PlayerMove : MonoBehaviour
    {
        private const float DodgeDistance = 1.3f;
        private const float DodgeDuration = 0.3f;
        private const float GridScale = 1.0f;
        private const float ObstacleDistance = 0.05f;
        private const float Radius = 0.01f;
        private const float RayDistance = 1.0f - Radius;
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
        private CharacterController _characterController;

        public void Initialize
        (
            IObservable<(StatusType statusType, float value)> speedBuffObservable,
            float moveSpeed
        )
        {
            _cts = new CancellationTokenSource();
            _blockingLayer = LayerMask.GetMask(GameCommonData.ObstacleLayer) |
                             LayerMask.GetMask(GameCommonData.BombLayer);
            _playerTransform = transform;
            _initRotation = _playerTransform.rotation.eulerAngles;
            _moveSpeed = moveSpeed;
            if (!gameObject.TryGetComponent(typeof(Animator), out Component animator))
            {
                Debug.LogError("Animatorがついてない！！");
                return;
            }

            _animator = (Animator)animator;
            _animationManager = new AnimationManager(_animator);
            speedBuffObservable
                .Where(tuple => tuple.statusType == StatusType.Speed)
                .Subscribe(tuple => { _moveSpeed = tuple.value; })
                .AddTo(this);
            SetupCharacterController();
        }

        private void SetupCharacterController()
        {
            _characterController = gameObject.AddComponent<CharacterController>();
            _characterController.center = new Vector3(0, 0.5f, 0);
            _characterController.radius = 0f;
            _characterController.height = 0f;
            _characterController.stepOffset = 0;
            _characterController.slopeLimit = 0;
        }

        public void Run(Vector3 inputValue)
        {
            if (inputValue is { x: 0, z: 0 })
            {
                _animationManager.Move(Direction.None);
                return;
            }

            if (IsObstacleOnLine(_playerTransform.position, inputValue))
            {
                transform.localRotation = Quaternion.LookRotation(inputValue);
                _animationManager.Move(GetDirection(inputValue));
                return;
            }

            _characterController.Move(inputValue * (_moveSpeed * Time.deltaTime));
            transform.localRotation = Quaternion.LookRotation(inputValue);
            _animationManager.Move(GetDirection(inputValue));
        }

        public void Dodge()
        {
            var dodgeDirection = transform.forward;
            _characterController.Move(dodgeDirection * (DodgeDistance / DodgeDuration) * Time.deltaTime);
        }

        public async UniTaskVoid MoveOnGrid(Vector3 inputValue)
        {
            inputValue *= 0.5f;
            if (_isMoving)
            {
                if (IsObstacleOnSphere(_playerTransform.position, _currentDestination, out var hit))
                {
                    Stop();
                }

                return;
            }

            var goDir = GetDirection(inputValue);
            Rotate(goDir, _playerTransform).Forget();
            _animationManager.Move(goDir);
            OnChangeDirection(goDir);
            if (goDir == Direction.None)
            {
                return;
            }

            inputValue = ModifiedInputValue(inputValue, goDir);
            var playerPos = _playerTransform.position;
            var destination = GetDestination(playerPos, inputValue);
            var isObstacle = IsObstacleOnSphere(playerPos, destination, out var obstacle);
            var modifiedDestination = ModifiedDestination(goDir, _prevDirection, destination, playerPos, out Direction modifiedDir);
            _currentDestination = modifiedDestination;
            if (!isObstacle)
            {
                Rotate(modifiedDir, _playerTransform).Forget();
                await Movement(playerPos, modifiedDestination)
                    .AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
                return;
            }

            var canAvoid = CanAvoid(playerPos, obstacle.transform.position, goDir);
            if (!canAvoid)
            {
                return;
            }

            isObstacle = IsObstacleOnSphere(playerPos, modifiedDestination, out obstacle);
            if (!isObstacle)
            {
                Rotate(modifiedDir, _playerTransform).Forget();
                await Movement(playerPos, modifiedDestination)
                    .AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
            }
        }

        private Direction GetDirection(Vector3 direction)
        {
            if (direction is { x: 0, z: 0 })
            {
                return Direction.None;
            }

            var absX = Mathf.Abs(direction.x);
            var absZ = Mathf.Abs(direction.z);
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

            if (dir is Direction.Right or Direction.Left)
            {
                inputValue.z = 0;
            }

            if (dir is Direction.Forward or Direction.Back)
            {
                inputValue.x = 0;
            }

            return inputValue;
        }

        private Vector3 GetDestination(Vector3 start, Vector3 moveAmount)
        {
            return start + moveAmount;
        }

        private Vector3 ModifiedDestination
        (
            Direction currentDir,
            Direction previousDir,
            Vector3 currentDestination,
            Vector3 playerPos,
            out Direction modifiedDir
        )
        {
            modifiedDir = currentDir;
            //進行方向が同じ場合
            if (previousDir == currentDir || currentDir == Direction.None)
            {
                return currentDestination;
            }

            //前、後ろ方向に直角に曲がるとき + 止まっていて前、後ろに動き始めるとき
            if (currentDir is Direction.Forward or Direction.Back &&
                previousDir is Direction.Left or Direction.Right or Direction.None)
            {
                //x軸方向の値を修正
                var currentX = currentDestination.x;
                var modifiedX = currentDestination.x;
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
            if (currentDir is Direction.Left or Direction.Right &&
                previousDir is Direction.Forward or Direction.Back or Direction.None)
            {
                //z軸の値を修正
                var currentZ = currentDestination.z;
                var modifiedZ = currentDestination.z;
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

        private bool IsObstacleOnSphere(Vector3 start, Vector3 end, out RaycastHit obstacle)
        {
            start = new Vector3(start.x, 0.5f, start.z);
            end = new Vector3(end.x, 0.5f, end.z);
            return Physics.SphereCast(start, Radius, end - start, out obstacle, RayDistance, _blockingLayer);
        }

        private bool IsObstacleOnLine(Vector3 start, Vector3 inputValue)
        {
            var end = start + inputValue;
            return Physics.Linecast(start, end, _blockingLayer);
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
            if (goDir is Direction.Back or Direction.Forward)
            {
                return Mathf.Abs(playerPos.x - obstaclePos.x) > ObstacleDistance;
            }

            if (goDir is Direction.Left or Direction.Right)
            {
                return Mathf.Abs(playerPos.z - obstaclePos.z) > ObstacleDistance;
            }

            return false;
        }

        private async UniTask Rotate(Direction direction, Transform player)
        {
            if (direction == Direction.None)
            {
                return;
            }

            var nextRotation = direction switch
            {
                Direction.Back => _initRotation,
                Direction.Forward => _initRotation + new Vector3(0, -180, 0),
                Direction.Right => _initRotation + new Vector3(0, -90, 0),
                Direction.Left => _initRotation + new Vector3(0, 90, 0),
                _ => _initRotation
            };

            await player.DOLocalRotate(nextRotation, GameCommonData.TurnDuration).SetLink(player.gameObject).ToUniTask();
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