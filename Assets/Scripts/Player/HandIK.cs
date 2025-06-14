using UnityEngine;

public class HandIK : MonoBehaviour
{
    public Animator _animator;

    [Range(0, 1)] public float _weight = 1;

    public void Initialize(Animator animator)
    {
        _animator = animator;
    }

    private void OnAnimatorIK(int layerIndex) // Animation Controller events
    {
        _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, _weight);
        _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, _weight);
        _animator.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, _weight);
        _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, _weight);
        _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, _weight);
        _animator.SetIKHintPositionWeight(AvatarIKHint.RightElbow, _weight);
    }
}