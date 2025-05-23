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
        private const float DodgeDistance = 1.3f;
        private const float DodgeDuration = 0.3f;
        private const float GridScale = 1.0f;
        private const float ObstacleDistance = 0.05f;
        private const float Radius = 0.01f;
        private const float RayDistance = 1.0f - Radius;
        private bool _isMoving;
        private float _moveSpeed;
        private Transform _playerTransform;
        private Animator _animator;
        private MovementAnimationManager _movementAnimationManager;
        private CancellationTokenSource _cts;
        private CharacterController _characterController;
        private Vector3 _currentDestination;
        private Vector3 _initRotation;
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
            _cts = new CancellationTokenSource();
            _blockingLayer = LayerMask.GetMask(GameCommonData.ObstacleLayer) | LayerMask.GetMask(GameCommonData.BombLayer);
            _playerTransform = transform;
            _initRotation = _playerTransform.rotation.eulerAngles;
            _moveSpeed = moveSpeed;
            SetAnimator(animator);
            SetupCharacterController();
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
            if (!PhotonNetwork.LocalPlayer.IsLocal)
            {
                return;
            }

            _movementAnimationManager.Move(GetDirection(inputValue));
            if (inputValue is { x: 0, z: 0 })
            {
                return;
            }


            if (IsObstacleOnLine(_playerTransform.position, inputValue))
            {
                transform.localRotation = Quaternion.LookRotation(inputValue);
                return;
            }

            _characterController.Move(inputValue * (_moveSpeed * Time.deltaTime));
            transform.localRotation = Quaternion.LookRotation(inputValue);
        }

        public void Dash()
        {
            if (!PhotonNetwork.LocalPlayer.IsLocal)
            {
                return;
            }

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
            _movementAnimationManager.Move(goDir);
            OnChangeDirection(goDir);
            if (goDir == MoveDirection.None)
            {
                return;
            }

            inputValue = ModifiedInputValue(inputValue, goDir);
            var playerPos = _playerTransform.position;
            var destination = GetDestination(playerPos, inputValue);
            var isObstacle = IsObstacleOnSphere(playerPos, destination, out var obstacle);
            var modifiedDestination = ModifiedDestination(goDir, _prevMoveDirection, destination, playerPos, out MoveDirection modifiedDir);
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

        private static Vector3 ModifiedInputValue(Vector3 inputValue, MoveDirection dir)
        {
            switch (dir)
            {
                case MoveDirection.None:
                    return inputValue;
                case MoveDirection.Right or MoveDirection.Left:
                    inputValue.z = 0;
                    break;
                case MoveDirection.Forward or MoveDirection.Back:
                    inputValue.x = 0;
                    break;
            }

            return inputValue;
        }

        private static Vector3 GetDestination(Vector3 start, Vector3 moveAmount)
        {
            return start + moveAmount;
        }

        private static Vector3 ModifiedDestination
        (
            MoveDirection currentDir,
            MoveDirection previousDir,
            Vector3 currentDestination,
            Vector3 playerPos,
            out MoveDirection modifiedDir
        )
        {
            modifiedDir = currentDir;
            //進行方向が同じ場合
            if (previousDir == currentDir || currentDir == MoveDirection.None)
            {
                return currentDestination;
            }

            switch (currentDir)
            {
                //前、後ろ方向に直角に曲がるとき + 止まっていて前、後ろに動き始めるとき
                case MoveDirection.Forward or MoveDirection.Back when
                    previousDir is MoveDirection.Left or MoveDirection.Right or MoveDirection.None:
                {
                    //x軸方向の値を修正
                    var currentX = currentDestination.x;
                    var modifiedX = currentDestination.x;
                    if (currentX % GridScale == 0)
                    {
                        return currentDestination;
                    }

                    switch (currentX)
                    {
                        case > 0:
                            modifiedX = (int)currentX % 2 == 0 ? Mathf.Floor(currentX) : Mathf.Ceil(currentX);
                            modifiedDir = (int)currentX % 2 == 0 ? MoveDirection.Left : MoveDirection.Right;
                            break;
                        case < 0:
                            modifiedX = (int)currentX % 2 == 0 ? Mathf.Ceil(currentX) : Mathf.Floor(currentX);
                            modifiedDir = (int)currentX % 2 == 0 ? MoveDirection.Right : MoveDirection.Left;
                            break;
                    }

                    return new Vector3(modifiedX, currentDestination.y, playerPos.z);
                }
                //左、右に直角に曲がるとき　+ 止まっていて左、右に動き始めるとき
                case MoveDirection.Left or MoveDirection.Right when
                    previousDir is MoveDirection.Forward or MoveDirection.Back or MoveDirection.None:
                {
                    //z軸の値を修正
                    var currentZ = currentDestination.z;
                    var modifiedZ = currentDestination.z;
                    if (currentZ % GridScale == 0)
                    {
                        return currentDestination;
                    }

                    switch (currentZ)
                    {
                        case > 0:
                            modifiedZ = (int)currentZ % 2 == 0 ? Mathf.Ceil(currentZ) : Mathf.Floor(currentZ);
                            modifiedDir = (int)currentZ % 2 == 0 ? MoveDirection.Forward : MoveDirection.Back;
                            break;
                        case < 0:
                            modifiedZ = (int)currentZ % 2 == 0 ? Mathf.Floor(currentZ) : Mathf.Ceil(currentZ);
                            modifiedDir = (int)currentZ % 2 == 0 ? MoveDirection.Back : MoveDirection.Forward;
                            break;
                    }

                    return new Vector3(playerPos.x, currentDestination.y, modifiedZ);
                }
                default:
                    return currentDestination;
            }
        }

        private void OnChangeDirection(MoveDirection currentMoveDirection)
        {
            if (_currentMoveDirection == currentMoveDirection)
            {
                return;
            }

            _prevMoveDirection = _currentMoveDirection;
            _currentMoveDirection = currentMoveDirection;
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

        private static bool CanAvoid(Vector3 playerPos, Vector3 obstaclePos, MoveDirection goDir)
        {
            return goDir switch
            {
                MoveDirection.Back or MoveDirection.Forward => Mathf.Abs(playerPos.x - obstaclePos.x) > ObstacleDistance,
                MoveDirection.Left or MoveDirection.Right => Mathf.Abs(playerPos.z - obstaclePos.z) > ObstacleDistance,
                _ => false
            };
        }

        private async UniTask Rotate(MoveDirection moveDirection, Transform player)
        {
            if (moveDirection == MoveDirection.None)
            {
                return;
            }

            var nextRotation = moveDirection switch
            {
                MoveDirection.Back => _initRotation,
                MoveDirection.Forward => _initRotation + new Vector3(0, -180, 0),
                MoveDirection.Right => _initRotation + new Vector3(0, -90, 0),
                MoveDirection.Left => _initRotation + new Vector3(0, 90, 0),
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