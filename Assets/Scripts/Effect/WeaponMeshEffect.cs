using UnityEngine;

public class WeaponMeshEffect : MonoBehaviour
{
    [SerializeField] private float _startScaleMultiplier = 1;
    private ParticleSystem[] _particles;

    public void Initialize()
    {
        var meshRenderer = GetComponent<MeshRenderer>();
        var realBound = 1f;
        var transformMax = 1f;
        if (meshRenderer != null)
        {
            realBound = meshRenderer.bounds.size.magnitude;
            transformMax = meshRenderer.transform.lossyScale.magnitude;
        }

        _particles = GetComponentsInChildren<ParticleSystem>();
        if (_particles == null || _particles.Length == 0)
        {
            Debug.LogWarning("No ParticleSystem found in children.");
            return;
        }

        foreach (var particle in _particles)
        {
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
        }
    }

    public void Stop()
    {
        if (_particles == null || _particles.Length == 0)
        {
            _particles = GetComponentsInChildren<ParticleSystem>();
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