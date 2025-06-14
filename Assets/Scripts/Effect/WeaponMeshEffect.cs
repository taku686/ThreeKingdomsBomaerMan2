using UnityEngine;

public class WeaponMeshEffect : MonoBehaviour
{
    [SerializeField] private float _startScaleMultiplier = 1;
    
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

        var particles = GetComponentsInChildren<ParticleSystem>();
        if (particles == null || particles.Length == 0)
        {
            Debug.LogWarning("No ParticleSystem found in children.");
            return;
        }

        foreach (var particle in particles)
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