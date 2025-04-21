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
    [SerializeField] private RuntimeAnimatorController _bigSwordAnimatorController;
    [SerializeField] private RuntimeAnimatorController _crowAnimatorController;
    [SerializeField] private RuntimeAnimatorController _katanaAnimatorController;
    [SerializeField] private RuntimeAnimatorController _scytheAnimatorController;
    [SerializeField] private RuntimeAnimatorController _lanceAnimatorController;

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
            WeaponType.BigSword => _bigSwordAnimatorController,
            WeaponType.Scythe => _scytheAnimatorController,
            WeaponType.Crow => _crowAnimatorController,
            WeaponType.Katana => _katanaAnimatorController,
            WeaponType.Lance => _lanceAnimatorController,
            _ => null
        };
    }
}