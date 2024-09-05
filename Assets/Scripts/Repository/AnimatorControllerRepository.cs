using UnityEngine;

public class AnimatorControllerRepository : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController spearAnimatorController;
    [SerializeField] private RuntimeAnimatorController hammerAnimatorController;
    [SerializeField] private RuntimeAnimatorController swordAnimatorController;
    [SerializeField] private RuntimeAnimatorController knifeAnimatorController;
    [SerializeField] private RuntimeAnimatorController fanAnimatorController;
    [SerializeField] private RuntimeAnimatorController bowAnimatorController;
    [SerializeField] private RuntimeAnimatorController shieldAnimatorController;
    [SerializeField] private RuntimeAnimatorController axeAnimatorController;
    [SerializeField] private RuntimeAnimatorController staffAnimatorController;

    public RuntimeAnimatorController[] GetAllAnimatorControllers()
    {
        return new[]
        {
            spearAnimatorController,
            hammerAnimatorController,
            swordAnimatorController,
            knifeAnimatorController,
            fanAnimatorController,
            bowAnimatorController,
            shieldAnimatorController,
            axeAnimatorController,
            staffAnimatorController
        };
    }
}