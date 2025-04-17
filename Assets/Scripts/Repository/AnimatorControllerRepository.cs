using Common.Data;
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

    public RuntimeAnimatorController GetAnimatorController(WeaponType weaponType)
    {
        return weaponType switch
        {
            WeaponType.Spear => spearAnimatorController,
            WeaponType.Hammer => hammerAnimatorController,
            WeaponType.Sword => swordAnimatorController,
            WeaponType.Knife => knifeAnimatorController,
            WeaponType.Fan => fanAnimatorController,
            WeaponType.Bow => bowAnimatorController,
            WeaponType.Shield => shieldAnimatorController,
            WeaponType.Axe => axeAnimatorController,
            WeaponType.Staff => staffAnimatorController,
            WeaponType.BigSword => swordAnimatorController,
            WeaponType.Scythe => axeAnimatorController,
            WeaponType.Crow => knifeAnimatorController,
            WeaponType.Katana => swordAnimatorController,
            WeaponType.Lance => spearAnimatorController,
            _ => null
        };
    }
}