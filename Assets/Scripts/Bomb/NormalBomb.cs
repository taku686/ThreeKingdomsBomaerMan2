using System;
using System.Collections.Generic;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace Bomb
{
    public class NormalBomb : BombBase
    {
        private static readonly float ExplosionMoveDuration = 0.5f;
        private static readonly Vector3 EffectOriginPosition = new Vector3(0, 0.5f, 0);
        private static readonly Vector3 ColliderOriginPosition = Vector3.zero;

        private List<Func<Vector3, int, Transform, UniTask>> _colliderFunctions =
            new List<Func<Vector3, int, Transform, UniTask>>();

        private List<Func<float, Vector3, Transform, UniTask>> _effectFunctions =
            new List<Func<float, Vector3, Transform, UniTask>>();

        private List<UniTask> _colliderUniTasks = new List<UniTask>();
        private List<UniTask> _effectUniTasks = new List<UniTask>();

        private readonly List<Vector3> _directions = new List<Vector3>
        {
            Vector3.forward,
            Vector3.back,
            Vector3.left,
            Vector3.right
        };


        protected override async UniTask Explosion()
        {
            if (IsExplosion)
            {
                return;
            }

            IsExplosion = true;
            var position = transform.position;
            StartPos = new Vector3(position.x, 0.5f, position.z);
            await UniTask.WhenAll(Explosion(Direction.Forward),
                Explosion(Direction.Back),
                Explosion(Direction.Left),
                Explosion(Direction.Right));

            await base.Explosion();
        }

        private async UniTask Explosion(Direction direction)
        {
            var dir = GameSettingData.DirectionToVector3(direction);
            var index = (int)direction;
            BombRenderer.enabled = false;
            BoxColliderComponent.enabled = false;
            var isHit = TryGetObstacles(FireRange, dir, StartPos, ObstaclesLayerMask, out var hit);
            var fireRange = isHit ? CalculateFireRange(hit, StartPos) : FireRange;
            var endPos = isHit ? hit.collider.transform.position - dir : StartPos + fireRange * dir;
            var isExplosion = (endPos - StartPos).magnitude >= MinDistance;
            if (!isExplosion)
            {
                return;
            }

            explosionList[index].explosionDirection = direction;
            await UniTask.WhenAll(SetupCollider(dir, fireRange, explosionList[index].boxCollider),
                SetupExplosionEffect(ExplosionMoveDuration, endPos, explosionList[index].explosionTransform));
        }

        private bool TryGetObstacles(int fireRange, Vector3 direction, Vector3 startPos, LayerMask obstaclesLayer,
            out RaycastHit obstacle)
        {
            return Physics.Raycast(startPos, direction, out obstacle, fireRange, obstaclesLayer,
                QueryTriggerInteraction.Collide);
        }

        private int CalculateFireRange(RaycastHit hit, Vector3 startPos)
        {
            var position = hit.transform.position;
            var endPos = new Vector3(position.x, 0.5f, position.z);
            return (int)Mathf.Abs((endPos - startPos).magnitude);
        }

        private async UniTask SetupCollider(Vector3 direction, int fireRange, Transform boxCollider)
        {
            boxCollider.localPosition = ColliderOriginPosition;
            var isZ = direction.z != 0;
            var colliderScale = isZ ? new Vector3(1, 1, fireRange) : new Vector3(fireRange, 1, 1);
            boxCollider.tag = GameSettingData.BombEffectTag;
            boxCollider.localScale = colliderScale;
            var offset = direction;
            boxCollider.localPosition += (direction * fireRange / 2) + (offset / 2);
            boxCollider.gameObject.SetActive(true);
            await UniTask.Delay(TimeSpan.FromSeconds(ExplosionDisplayDuration), cancellationToken: Cts.Token);
            boxCollider.gameObject.SetActive(false);
        }

        private async UniTask SetupExplosionEffect(float moveDuration, Vector3 endPos, Transform explosionEffect)
        {
            explosionEffect.localPosition = EffectOriginPosition;
            explosionEffect.gameObject.SetActive(true);
            explosionEffect.DOMove(endPos, moveDuration).SetLink(this.gameObject);
            await UniTask.Delay(TimeSpan.FromSeconds(ExplosionDisplayDuration), cancellationToken: Cts.Token);
            explosionEffect.gameObject.SetActive(false);
        }
    }
}