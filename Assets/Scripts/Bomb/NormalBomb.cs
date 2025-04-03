using System;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Bomb
{
    public class NormalBomb : BombBase
    {
        private static readonly float ExplosionMoveDuration = 0.5f;
        private static readonly Vector3 EffectOriginPosition = new(0, 0.5f, 0);
        [SerializeField] private GameObject bombCollider;

        protected override async UniTask Explosion(int damageAmount)
        {
            if (IsExplosion)
            {
                return;
            }

            IsExplosion = true;
            BlockShakeAction.Invoke();
            var position = transform.position;
            Vector3 startPos = new Vector3(position.x, 0.5f, position.z);
            await UniTask.WhenAll(
                Explosion(startPos, Direction.Forward, damageAmount),
                Explosion(startPos, Direction.Back, damageAmount),
                Explosion(startPos, Direction.Left, damageAmount),
                Explosion(startPos, Direction.Right, damageAmount));

            await base.Explosion(damageAmount);
        }

        private async UniTask Explosion(Vector3 startPos, Direction direction, int damageAmount)
        {
            var dir = GameCommonData.DirectionToVector3(direction);
            var index = (int)direction;
            BombRenderer.enabled = false;
            BoxColliderComponent.enabled = false;
            var isHit = TryGetObstacles(_fireRange, dir, startPos, ObstaclesLayerMask, out var hit);
            var fireRange = isHit ? CalculateFireRange(hit, startPos) : _fireRange;
            var endPos = CalculateEndPos(isHit, hit, startPos, fireRange, dir);
            var distance = (endPos - startPos).magnitude;
            var isExplosion = distance >= MinDistance;
            if (!isExplosion)
            {
                return;
            }

            GenerateCollider(startPos, direction, fireRange, damageAmount);
            await UniTask.WhenAll(SetupExplosionEffect(ExplosionMoveDuration, endPos, explosionList[index].transform));
        }

        private bool TryGetObstacles
        (
            int fireRange,
            Vector3 direction,
            Vector3 startPos,
            LayerMask obstaclesLayer,
            out RaycastHit obstacle
        )
        {
            return Physics.Raycast(startPos, direction, out obstacle, fireRange, obstaclesLayer, QueryTriggerInteraction.Collide);
        }

        private int CalculateFireRange(RaycastHit hit, Vector3 startPos)
        {
            var position = hit.transform.position;
            var endPos = new Vector3(position.x, 0.5f, position.z);
            return (int)Mathf.Abs((endPos - startPos).magnitude);
        }

        private async void GenerateCollider(Vector3 startPos, Direction direction, int fireRange, int damageAmount)
        {
            var dir = GameCommonData.DirectionToVector3(direction);
            for (var i = 0; i <= fireRange; i++)
            {
                var colliderObj = Instantiate(bombCollider, CalculateGeneratePos(startPos, dir, i), bombCollider.transform.rotation, gameObject.transform);
                var explosion = colliderObj.GetComponent<Explosion>();
                colliderObj.layer = LayerMask.NameToLayer(GameCommonData.ExplosionLayer);
                explosion.explosionDirection = direction;
                explosion.damageAmount = damageAmount;
                await UniTask.Delay(TimeSpan.FromSeconds(ExplosionMoveDuration / fireRange),
                    cancellationToken: Cts.Token);
            }
        }

        private Vector3 CalculateGeneratePos(Vector3 startPos, Vector3 direction, int index)
        {
            var isX = direction.x != 0;
            if (isX)
            {
                return new Vector3(startPos.x + direction.x * index, startPos.y, startPos.z);
            }

            return new Vector3(startPos.x, startPos.y, startPos.z + direction.z * index);
        }

        private Vector3 CalculateEndPos(bool isHit, RaycastHit hit, Vector3 startPos, int fireRange, Vector3 dir)
        {
            var endPos = Vector3.zero;
            if (isHit && !hit.collider.CompareTag(GameCommonData.BreakingWallTag))
            {
                endPos = hit.collider.transform.position - dir;
            }
            else if (isHit && hit.collider.CompareTag(GameCommonData.BreakingWallTag))
            {
                endPos = hit.collider.transform.position;
            }
            else if (!isHit)
            {
                endPos = startPos + fireRange * dir;
            }

            return endPos;
        }

        private async UniTask SetupExplosionEffect(float moveDuration, Vector3 endPos, Transform explosionEffect)
        {
            explosionEffect.localPosition = EffectOriginPosition;
            explosionEffect.gameObject.SetActive(true);
            explosionEffect.DOMove(endPos, moveDuration).SetLink(gameObject);
            await UniTask.Delay(TimeSpan.FromSeconds(ExplosionDisplayDuration), cancellationToken: Cts.Token);
            explosionEffect.gameObject.SetActive(false);
        }
    }
}