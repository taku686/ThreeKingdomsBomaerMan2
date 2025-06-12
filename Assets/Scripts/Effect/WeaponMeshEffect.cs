using UnityEngine;

public class WeaponMeshEffect : MonoBehaviour
{
    private void Awake()
    {
        var meshRenderer = GetComponent<MeshRenderer>();
        var particles = GetComponentsInChildren<ParticleSystem>();
        if (particles == null || particles.Length == 0)
        {
            Debug.LogWarning("No ParticleSystem found in children.");
            return;
        }

        foreach (var particle in particles)
        {
            var shape = particle.shape;
            if (shape.enabled)
            {
                if (shape.shapeType == ParticleSystemShapeType.MeshRenderer)
                {
                    shape.meshRenderer = meshRenderer;
                }
            }
        }
    }
}