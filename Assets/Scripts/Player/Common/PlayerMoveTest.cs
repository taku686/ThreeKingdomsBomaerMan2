using System;
using System.Diagnostics.Eventing.Reader;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager;
using UnityEngine;
using Zenject;

namespace Player.Common
{
    public class PlayerMoveTest : MonoBehaviour
    {
        private static readonly float ObstacleDistance = 0.1f;
        private static readonly float Radius = 0.3f;
        private static readonly float RayDistance = 1.0f - Radius;
        private static readonly float RotateDuration = 0.1f;
        private Vector3 _initRotation;
        private Transform _playerTransform;
        private bool _isMoving;
        private LayerMask _blockingLayer;
        private float _moveSpeed;
        private Direction _currentDirection;
        private Direction _prevDirection;
        private Animator _animator;
        private AnimationManager _animationManager;
        private CancellationTokenSource _cts;

        /*void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            var isHit = Physics.SphereCast(transform.position, Radius, _playerTransform.forward * RayDistance,
                out var hit);
            if (isHit)
            {
                Gizmos.DrawRay(transform.position, transform.forward * RayDistance);
                Gizmos.DrawWireSphere(transform.position + transform.forward * (RayDistance), Radius);
            }
            else
            {
                Gizmos.DrawRay(transform.position, transform.forward * RayDistance);
                Gizmos.DrawWireSphere(transform.position + transform.forward * (RayDistance), Radius);
            }
        }*/

        private void Start()
        {
            Initialize(3);
        }

        private void Update()
        {
#if UNITY_EDITOR
            Move(new Vector3(Input.GetAxis("Horizontal"), 0,
                Input.GetAxis("Vertical"))).Forget();
#else
             Move(new Vector3(UltimateJoystick.GetHorizontalAxis(GameSettingData.JoystickName), 0,
                UltimateJoystick.GetVerticalAxis(GameSettingData.JoystickName))).Forget();
#endif
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

        public async UniTaskVoid Move(Vector3 direction)
        {
            if (_isMoving)
            {
                var end = _playerTransform.position + _playerTransform.forward * RayDistance;
                if (IsObstacle(_playerTransform.position, end, out var hit))
                {
                    Stop();
                }

                return;
            }

            var goDir = GetDirection(direction);
            _animationManager.Move(goDir);
            Rotate(goDir, _playerTransform);
            OnChangeDirection(goDir);
            if (goDir == Direction.None)
            {
                return;
            }

            if (goDir == Direction.Right || goDir == Direction.Left)
            {
                direction.z = 0;
            }

            if (goDir == Direction.Forward || goDir == Direction.Back)
            {
                direction.x = 0;
            }

            var position = _playerTransform.position;
            var target = GetDestination(direction, position);
            var modifiedTarget = ModifiedDestination(_currentDirection, _prevDirection, target);
            var isObstacle = IsObstacle(position, modifiedTarget, out var obstacle);
            if (!isObstacle)
            {
                await Movement(position, modifiedTarget)
                    .AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
                return;
            }

            var canAvoid = CanAvoid(position, obstacle.transform.position, goDir);
            if (!canAvoid)
            {
                return;
            }

            var avoidDir = AvoidDirection(position, obstacle.transform.position, goDir);
            var avoidDestination = AvoidDestination(position, avoidDir);
            isObstacle = IsObstacle(position, avoidDestination, out obstacle);
            if (isObstacle)
            {
                return;
            }

            var lastDestination = GetDestination(direction, avoidDestination);
            isObstacle = IsObstacle(avoidDestination, lastDestination, out obstacle);
            if (isObstacle)
            {
                return;
            }

            Rotate(avoidDir, _playerTransform);
            _animationManager.Move(avoidDir);
            await Movement(position, avoidDestination).AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
            Rotate(goDir, _playerTransform);
            _animationManager.Move(goDir);
            await Movement(position, lastDestination).AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
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

        private Vector3 GetDestination(Vector3 movingDistance, Vector3 player)
        {
            return player + movingDistance;
        }

        private bool IsObstacle(Vector3 start, Vector3 end, out RaycastHit obstacle)
        {
            start = new Vector3(start.x, 0.5f, start.z);
            end = new Vector3(end.x, 0.5f, end.z);
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
                await UniTask.Yield(PlayerLoopTiming.Update,_cts.Token);
            }

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

        private Direction AvoidDirection(Vector3 playerPos, Vector3 obstaclePos, Direction goDir)
        {
            if (goDir == Direction.Back || goDir == Direction.Forward)
            {
                return playerPos.x > obstaclePos.x ? Direction.Right : Direction.Left;
            }

            if (goDir == Direction.Left || goDir == Direction.Right)
            {
                return playerPos.z > obstaclePos.z ? Direction.Forward : Direction.Back;
            }

            return Direction.None;
        }

        private Vector3 AvoidDestination(Vector3 playerPos, Direction avoidDir)
        {
            if (avoidDir == Direction.None)
            {
                return playerPos;
            }

            if (avoidDir == Direction.Forward)
            {
                return new Vector3(playerPos.x, playerPos.y, Mathf.Ceil(playerPos.z));
            }

            if (avoidDir == Direction.Back)
            {
                return new Vector3(playerPos.x, playerPos.y, Mathf.Floor(playerPos.z));
            }

            if (avoidDir == Direction.Right)
            {
                return new Vector3(Mathf.Ceil(playerPos.x), playerPos.y, playerPos.z);
            }

            if (avoidDir == Direction.Left)
            {
                return new Vector3(Mathf.Floor(playerPos.x), playerPos.y, playerPos.z);
            }

            return playerPos;
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
                case Direction.Forward:
                    nextRotation = _initRotation;
                    break;
                case Direction.Back:
                    nextRotation = _initRotation + new Vector3(0, -180, 0);
                    break;
                case Direction.Left:
                    nextRotation = _initRotation + new Vector3(0, -90, 0);
                    break;
                case Direction.Right:
                    nextRotation = _initRotation + new Vector3(0, 90, 0);
                    break;
                default:
                    break;
            }

            player.DOLocalRotate(nextRotation, RotateDuration);
        }

        private Vector3 ModifiedDestination(Direction currentDir, Direction prevDir, Vector3 targetPos)
        {
            if (currentDir == prevDir || currentDir == Direction.None || prevDir == Direction.None)
            {
                return targetPos;
            }

            if ((currentDir == Direction.Forward || currentDir == Direction.Back) &&
                (prevDir == Direction.Left || prevDir == Direction.Right))
            {
                return new Vector3(targetPos.x, targetPos.y, Mathf.Round(targetPos.z));
            }

            if ((currentDir == Direction.Left || currentDir == Direction.Right) &&
                (prevDir == Direction.Forward || prevDir == Direction.Back))
            {
                return new Vector3(Mathf.Round(targetPos.x), targetPos.y, targetPos.z);
            }

            return targetPos;
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

        private void Stop()
        {
            _isMoving = false;
            _cts.Cancel();
            _cts.Dispose();
            _cts = new CancellationTokenSource();
        }
    }
}