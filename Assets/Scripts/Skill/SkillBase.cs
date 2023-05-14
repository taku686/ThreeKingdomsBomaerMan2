using UnityEngine;

public class SkillBase : MonoBehaviour
{
    protected GameObject Effect;
    protected Transform PlayerTransform;
    protected Vector3 GridSize = Vector3.one;

    public virtual void Initialize(GameObject effect, Transform playerTransform)
    {
        Effect = effect;
        playerTransform = playerTransform;
    }

    public virtual void SkillActivation()
    {
    }
}