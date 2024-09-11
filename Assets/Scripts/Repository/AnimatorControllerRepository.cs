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
        switch (weaponType)
        {
            case WeaponType.Spear:
                return spearAnimatorController;
            case WeaponType.Hammer:
                return hammerAnimatorController;
            case WeaponType.Sword:
                return swordAnimatorController;
            case WeaponType.Knife:
                return knifeAnimatorController;
            case WeaponType.Fan:
                return fanAnimatorController;
            case WeaponType.Bow:
                return bowAnimatorController;
            case WeaponType.Shield:
                return shieldAnimatorController;
            case WeaponType.Axe:
                return axeAnimatorController;
            case WeaponType.Staff:
                return staffAnimatorController;
            default:
                return null;
        }
        
    }
}