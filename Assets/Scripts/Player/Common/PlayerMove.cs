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
        private static readonly float Radius = 0.01f;
        private static readonly float RayDistance = 1.0f - Radius;
        private Vector3 initRotation;
        private Transform playerTransform;
        private bool isMoving;
        private LayerMask blockingLayer;
        private float moveSpeed;
        private Direction currentDirection;
        private Direction prevDirection = Direction.None;
        private Animator animator;
        private AnimationManager animationManager;
        private CancellationTokenSource cts;
        private Vector3 currentDestination;
        private CharacterController characterController;

        public void Initialize(float moveSpeed)
        {
            cts = new CancellationTokenSource();
            blockingLayer = LayerMask.GetMask(GameCommonData.ObstacleLayer) |
                            LayerMask.GetMask(GameCommonData.BombLayer);
            playerTransform = transform;
            initRotation = playerTransform.rotation.eulerAngles;
            this.moveSpeed = moveSpeed;
            if (!gameObject.TryGetComponent(typeof(Animator), out Component animator))
            {
                Debug.LogError("Animatorがついてない！！");
                return;
            }

            this.animator = (Animator)animator;
            animationManager = new AnimationManager(this.animator);
            SetupCharacterController();
        }

        private void SetupCharacterController()
        {
            characterController = gameObject.AddComponent<CharacterController>();
            characterController.center = new Vector3(0, 0.5f, 0);
            characterController.radius = 0f;
            characterController.height = 0f;
            characterController.stepOffset = 0;
            characterController.slopeLimit = 0;
        }

        public void Move(Vector3 inputValue)
        {
            if (inputValue.x == 0 && inputValue.z == 0)
            {
                animationManager.Move(Direction.None);
                return;
            }

            characterController.Move(inputValue * moveSpeed * Time.deltaTime);
            transform.localRotation = Quaternion.LookRotation(inputValue);
            animationManager.Move(GetDirection(inputValue));
        }

        public async UniTaskVoid MoveOnGrid(Vector3 inputValue)
        {
            inputValue *= 0.5f;
            if (isMoving)
            {
                if (IsObstacle(playerTransform.position, currentDestination, out var hit))
                {
                    Stop();
                }

                return;
            }

            var goDir = GetDirection(inputValue);
            Rotate(goDir, playerTransform).Forget();
            animationManager.Move(goDir);
            OnChangeDirection(goDir);
            if (goDir == Direction.None)
            {
                return;
            }

            inputValue = ModifiedInputValue(inputValue, goDir);
            var playerPos = playerTransform.position;
            var destination = GetDestination(playerPos, inputValue);
            var isObstacle = IsObstacle(playerPos, destination, out var obstacle);
            var modifiedDestination =
                ModifiedDestination(goDir, prevDirection, destination, playerPos, out Direction modifiedDir);
            currentDestination = modifiedDestination;
            if (!isObstacle)
            {
                Rotate(modifiedDir, playerTransform).Forget();
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
                Rotate(modifiedDir, playerTransform).Forget();
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
            if (this.currentDirection == currentDirection)
            {
                return;
            }

            prevDirection = this.currentDirection;
            this.currentDirection = currentDirection;
        }

        private bool IsObstacle(Vector3 start, Vector3 end, out RaycastHit obstacle)
        {
            start = new Vector3(start.x, 0.5f, start.z);
            end = new Vector3(end.x, 0.5f, end.z);
            return Physics.SphereCast(start, Radius, end - start, out obstacle, RayDistance, blockingLayer);
        }

        private async UniTask Movement(Vector3 start, Vector3 end)
        {
            var sqrRemainingDistance = (start - end).sqrMagnitude;
            isMoving = true;

            while (sqrRemainingDistance > float.Epsilon && !cts.Token.IsCancellationRequested)
            {
                var position1 = playerTransform.position;
                var position = position1;
                position1 = Vector3.MoveTowards(position, end, moveSpeed * Time.deltaTime);
                transform.position = position1;
                sqrRemainingDistance = (position1 - end).sqrMagnitude;
                await UniTask.Yield(PlayerLoopTiming.Update, cts.Token);
            }

            playerTransform.position = end;
            isMoving = false;
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

        private async UniTask Rotate(Direction direction, Transform player)
        {
            if (direction == Direction.None)
            {
                return;
            }

            Vector3 nextRotation = initRotation;
            switch (direction)
            {
                case Direction.Back:
                    nextRotation = initRotation;
                    break;
                case Direction.Forward:
                    nextRotation = initRotation + new Vector3(0, -180, 0);
                    break;
                case Direction.Right:
                    nextRotation = initRotation + new Vector3(0, -90, 0);
                    break;
                case Direction.Left:
                    nextRotation = initRotation + new Vector3(0, 90, 0);
                    break;
            }

            await player.DOLocalRotate(nextRotation, GameCommonData.TurnDuration).SetLink(player.gameObject)
                .ToUniTask();
        }

        private void Stop()
        {
            isMoving = false;
            cts.Cancel();
            cts.Dispose();
            cts = new CancellationTokenSource();
        }
    }
}