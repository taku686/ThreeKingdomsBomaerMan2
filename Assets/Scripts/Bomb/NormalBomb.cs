using System;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Bomb
{
    public class NormalBomb : BombBase
    {
        [SerializeField] private GameObject _bombCollider;
        [SerializeField] private BombExplosionRepository _bombExplosionRepository;
        private static readonly Vector3 EffectOriginPosition = new(0, 0.5f, 0);
        private const float ExplosionMoveDuration = 0.5f;
        private const float ColliderIntervalDistance = 0.3f;

        protected override async UniTask Explosion(int damageAmount)
        {
            if (_IsExplosion)
            {
                return;
            }

            _IsExplosion = true;
            var position = transform.position;
            var startPos = new Vector3(position.x, position.y + 0.5f, position.z);
            await UniTask.WhenAll
            (
                Explosion(startPos, MoveDirection.Forward, damageAmount),
                Explosion(startPos, MoveDirection.Back, damageAmount),
                Explosion(startPos, MoveDirection.Left, damageAmount),
                Explosion(startPos, MoveDirection.Right, damageAmount)
            );

            base.Explosion(damageAmount).Forget();
        }

        private async UniTask Explosion
        (
            Vector3 startPos,
            MoveDirection moveDirection,
            int damageAmount
        )
        {
            var dir = GameCommonData.DirectionToVector3(moveDirection);
            var index = (int)moveDirection;
            _BombRenderer.enabled = false;
            _BoxCollider.enabled = false;
            var isHit = TryGetObstacles(_fireRange, dir, startPos, _ObstaclesLayerMask, out var hit);
            var fireRange = isHit ? CalculateFireRange(hit, startPos) : _fireRange;
            var endPos = CalculateEndPos(isHit, hit, startPos, fireRange, dir);
            var distance = (endPos - startPos).magnitude;
            var canExplosion = distance >= MinDistance;
            if (!canExplosion)
            {
                return;
            }

            GenerateCollider(startPos, moveDirection, fireRange, damageAmount);
            var explosionTransform = explosionList[index].transform;
            await UniTask.WhenAll(SetupExplosionEffect(ExplosionMoveDuration, endPos, explosionTransform));
        }

        private static bool TryGetObstacles
        (
            int fireRange,
            Vector3 direction,
            Vector3 startPos,
            LayerMask obstaclesLayer,
            out RaycastHit obstacle
        )
        {
            return Physics.Linecast
            (
                startPos,
                startPos + direction * fireRange,
                out obstacle,
                obstaclesLayer,
                QueryTriggerInteraction.Collide
            );
        }

        private static float CalculateFireRange(RaycastHit hit, Vector3 startPos)
        {
            var startPosition = new Vector3(startPos.x, 0f, startPos.z);
            var position = hit.transform.position;
            var endPosition = new Vector3(position.x, 0f, position.z);
            return Mathf.Abs((endPosition - startPosition).magnitude);
        }

        private async void GenerateCollider(Vector3 startPos, MoveDirection moveDirection, float fireRange, int damageAmount)
        {
            var generateAmount = fireRange / ColliderIntervalDistance;
            var dir = GameCommonData.DirectionToVector3(moveDirection);
            for (var i = 0; i <= generateAmount; i++)
            {
                var adjustmentValue = i * ColliderIntervalDistance;
                var colliderObj = Instantiate(_bombCollider, gameObject.transform);
                FixTransform(colliderObj.transform, dir, startPos, adjustmentValue);
                var explosion = colliderObj.GetComponent<Explosion>();
                colliderObj.layer = LayerMask.NameToLayer(GameCommonData.ExplosionLayer);
                explosion._explosionMoveDirection = moveDirection;
                explosion.damageAmount = damageAmount;
                await UniTask.Delay(TimeSpan.FromSeconds(ExplosionMoveDuration / generateAmount));
            }
        }

        private static void FixTransform(Transform colliderTransform, Vector3 dir, Vector3 startPos, float adjustmentValue)
        {
            var isX = dir.x != 0;
            colliderTransform.position = CalculateGeneratePos(startPos, dir, adjustmentValue);
            colliderTransform.localEulerAngles = Vector3.zero;
            colliderTransform.localScale = new Vector3(isX ? 1 * ColliderIntervalDistance : 1, 1, isX ? 1 : 1 * ColliderIntervalDistance);
        }

        private static Vector3 CalculateGeneratePos(Vector3 startPos, Vector3 direction, float adjustmentValue)
        {
            var isX = direction.x != 0;
            return isX ? new Vector3(startPos.x + (direction.x * adjustmentValue), startPos.y, startPos.z) : new Vector3(startPos.x, startPos.y, startPos.z + direction.z * adjustmentValue);
        }

        private static Vector3 CalculateEndPos(bool isHit, RaycastHit hit, Vector3 startPos, float fireRange, Vector3 dir)
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

        private async UniTask SetupExplosionEffect
        (
            float moveDuration,
            Vector3 endPos,
            Transform explosionEffectTransform,
            AbnormalCondition abnormalCondition = AbnormalCondition.None
        )
        {
            InitializeEffect(explosionEffectTransform, abnormalCondition);
            explosionEffectTransform.localPosition = EffectOriginPosition;
            explosionEffectTransform.gameObject.SetActive(true);
            explosionEffectTransform.DOMove(endPos, moveDuration).SetLink(gameObject);
            await UniTask.Delay(TimeSpan.FromSeconds(ExplosionDisplayDuration), cancellationToken: _Cts.Token);
            explosionEffectTransform.gameObject.SetActive(false);
        }

        private void InitializeEffect
        (
            Transform parent,
            AbnormalCondition abnormalCondition
        )
        {
            var explosionEffect = _bombExplosionRepository.Get(abnormalCondition);
            if (explosionEffect == null)
            {
                Debug.LogError("Explosion effect is null.");
                return;
            }

            var explosionEffectClone = Instantiate(explosionEffect, parent).gameObject;
            explosionEffectClone.transform.localScale = Vector3.one;
            explosionEffectClone.transform.localEulerAngles = Vector3.zero;
            explosionEffectClone.transform.localPosition = Vector3.zero;
        }
    }
}