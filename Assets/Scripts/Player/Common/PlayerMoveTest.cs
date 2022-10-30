using System;
using Common.Data;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Player.Common
{
    public class PlayerMoveTest : MonoBehaviour
    {
        private Transform _playerTransform;
        private bool _isMoving;
        private readonly float _rayDistance = 0.9f;
        private LayerMask _blockingLayer;
        private float _moveSpeed;
        private const float ObstacleDistance = 0.2f;
        private const float Radius = 0.1f;

        private void Start()
        {
            _blockingLayer = LayerMask.GetMask("BlockingLayer");
            Initialize(3);
        }

        private void Update()
        {
            Move(new Vector3(UltimateJoystick.GetHorizontalAxis(GameSettingData.JoystickName), 0,
                UltimateJoystick.GetVerticalAxis(GameSettingData.JoystickName))).Forget();
        }

        public void Initialize(float moveSpeed)
        {
            _playerTransform = this.transform;
            _moveSpeed = moveSpeed;
        }

        public async UniTaskVoid Move(Vector3 direction)
        {
            if (_isMoving)
            {
                return;
            }

            var goDir = GetDirection(direction);
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
            var isObstacle = IsObstacle(position, target, out var obstacle);
            if (!isObstacle)
            {
                await Movement(_playerTransform.position, target)
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

            await Movement(position, avoidDestination).AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
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
            return Physics.SphereCast(start, Radius, end - start, out obstacle, _rayDistance, _blockingLayer,
                QueryTriggerInteraction.Collide);
        }

        private async UniTask Movement(Vector3 start, Vector3 end)
        {
            var sqrRemainingDistance = (start - end).sqrMagnitude;
            _isMoving = true;

            while (sqrRemainingDistance > float.Epsilon)
            {
                var position1 = _playerTransform.position;
                var position = position1;
                position1 = Vector3.MoveTowards(position, end, _moveSpeed * Time.deltaTime);
                transform.position = position1;
                sqrRemainingDistance = (position1 - end).sqrMagnitude;
                await UniTask.Yield();
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
    }
}