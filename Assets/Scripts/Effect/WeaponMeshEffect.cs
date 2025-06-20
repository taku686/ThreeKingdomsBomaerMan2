using UnityEngine;

public class WeaponMeshEffect : MonoBehaviour
{
    [SerializeField] private float _startScaleMultiplier = 1;
    [SerializeField] private bool _playOnStart;
    [SerializeField] private ParticleSystem[] _particles;


    private void Start()
    {
        if (!_playOnStart)
        {
            return;
        }

        Initialize();
    }

    public void Initialize()
    {
        var meshRenderer = GetComponentInChildren<MeshRenderer>(true);
        var realBound = 1f;
        var transformMax = 1f;
        if (meshRenderer != null)
        {
            realBound = meshRenderer.bounds.size.magnitude;
            transformMax = meshRenderer.transform.lossyScale.magnitude;
        }

        _particles = GetComponentsInChildren<ParticleSystem>(true);
        if (_particles == null || _particles.Length == 0)
        {
            Debug.LogWarning("No ParticleSystem found in children.");
            return;
        }

        foreach (var particle in _particles)
        {
            particle.Stop(true);
            SetupShape(particle, meshRenderer);
            var main = particle.main;
            main.startSize = UpdateParticleParam
            (
                main.startSize,
                main.startSize,
                (realBound / transformMax) * _startScaleMultiplier
            );
            main.startSpeed = UpdateParticleParam
            (
                main.startSpeed,
                main.startSpeed,
                (realBound / transformMax) * _startScaleMultiplier
            );

            particle.Play(true);
        }
    }

    public void Stop()
    {
        if (_particles == null || _particles.Length == 0)
        {
            _particles = GetComponentsInChildren<ParticleSystem>(true);
        }

        foreach (var particle in _particles)
        {
            if (particle.isPlaying)
            {
                particle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            }
        }
    }

    private static void SetupShape(ParticleSystem particle, MeshRenderer meshRenderer)
    {
        var shape = particle.shape;
        if (!shape.enabled) return;
        if (shape.shapeType == ParticleSystemShapeType.MeshRenderer)
        {
            shape.meshRenderer = meshRenderer;
        }
    }

    private static ParticleSystem.MinMaxCurve UpdateParticleParam(ParticleSystem.MinMaxCurve startParam, ParticleSystem.MinMaxCurve currentParam, float scale)
    {
        if (currentParam.mode == ParticleSystemCurveMode.TwoConstants)
        {
            currentParam.constantMin = startParam.constantMin * scale;
            currentParam.constantMax = startParam.constantMax * scale;
        }
        else if (currentParam.mode == ParticleSystemCurveMode.Constant)
            currentParam.constant = startParam.constant * scale;

        return currentParam;
    }
}