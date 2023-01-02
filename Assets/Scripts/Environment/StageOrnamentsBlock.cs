using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Environment
{
    public class StageOrnamentsBlock : MonoBehaviour
    {
        [SerializeField] private Transform[] blockTransforms;
        [SerializeField] private float Duration = 0.3f;
        private const float BackDuration = 0.1f;
        [SerializeField] private float JumpLength = 2f;
        private bool _isShaking;
        private readonly List<Vector3> _originPosition = new();

        private void Start()
        {
            for (int i = 0; i < blockTransforms.Length; i++)
            {
                _originPosition.Add(blockTransforms[i].position);
            }
        }

        public void Shake()
        {
            if (_isShaking)
            {
                return;
            }

            _isShaking = true;
            for (int i = 0; i < blockTransforms.Length; i++)
            {
                var position = blockTransforms[i].position;
                Sequence sequence = DOTween.Sequence();
                sequence.Append(blockTransforms[i]
                    .DOLocalMove(new Vector3(position.x, position.y + JumpLength, position.z), Duration)
                    .SetEase(Ease.InFlash));
                sequence.Append(blockTransforms[i].DOLocalMove(_originPosition[i], BackDuration))
                    .SetEase(Ease.OutElastic);
                sequence.Play().SetLink(gameObject);
            }

            _isShaking = false;
        }
    }
}