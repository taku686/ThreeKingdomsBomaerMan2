using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;
using UnityEditor.Animations;
using UnityEngine;
using Zenject;

public class AnimationChangeUseCase : IDisposable
{
    private readonly IReadOnlyCollection<Motion> spearMotions;
    private readonly IReadOnlyCollection<Motion> hammerMotions;
    private readonly IReadOnlyCollection<Motion> swordMotions;
    private readonly IReadOnlyCollection<Motion> knifeMotions;
    private readonly IReadOnlyCollection<Motion> fanMotions;
    private readonly IReadOnlyCollection<Motion> bowMotions;
    private readonly IReadOnlyCollection<Motion> shieldMotions;
    private readonly IReadOnlyCollection<Motion> axeMotions;
    private readonly IReadOnlyCollection<Motion> staffMotions;
    private readonly string tagName;


    [Inject]
    public AnimationChangeUseCase
    (
        IReadOnlyCollection<Motion> spearMotions,
        IReadOnlyCollection<Motion> hammerMotions,
        IReadOnlyCollection<Motion> swordMotions,
        IReadOnlyCollection<Motion> knifeMotions,
        IReadOnlyCollection<Motion> fanMotions,
        IReadOnlyCollection<Motion> bowMotions,
        IReadOnlyCollection<Motion> shieldMotions,
        IReadOnlyCollection<Motion> axeMotions,
        IReadOnlyCollection<Motion> staffMotions,
        string tagName
    )
    {
        this.spearMotions = spearMotions;
        this.hammerMotions = hammerMotions;
        this.swordMotions = swordMotions;
        this.knifeMotions = knifeMotions;
        this.fanMotions = fanMotions;
        this.bowMotions = bowMotions;
        this.shieldMotions = shieldMotions;
        this.axeMotions = axeMotions;
        this.staffMotions = staffMotions;
        this.tagName = tagName;
    }

    public RuntimeAnimatorController ChangeMotion(AnimatorController animatorController, WeaponType equippedWeaponType)
    {
        
        animatorController.layers[0].stateMachine.states
            .First(state => state.state.tag == tagName).state.motion = GetCandidateMotion(equippedWeaponType);
        return animatorController;
    }

    private Motion GetCandidateMotion(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.Spear:
                return spearMotions.ElementAt(UnityEngine.Random.Range(0, spearMotions.Count));
            case WeaponType.Hammer:
                return hammerMotions.ElementAt(UnityEngine.Random.Range(0, hammerMotions.Count));
            case WeaponType.Sword:
                return swordMotions.ElementAt(UnityEngine.Random.Range(0, swordMotions.Count));
            case WeaponType.Knife:
                return knifeMotions.ElementAt(UnityEngine.Random.Range(0, knifeMotions.Count));
            case WeaponType.Fan:
                return fanMotions.ElementAt(UnityEngine.Random.Range(0, fanMotions.Count));
            case WeaponType.Bow:
                return bowMotions.ElementAt(UnityEngine.Random.Range(0, bowMotions.Count));
            case WeaponType.Shield:
                return shieldMotions.ElementAt(UnityEngine.Random.Range(0, shieldMotions.Count));
            case WeaponType.Axe:
                return axeMotions.ElementAt(UnityEngine.Random.Range(0, axeMotions.Count));
            case WeaponType.Staff:
                return staffMotions.ElementAt(UnityEngine.Random.Range(0, staffMotions.Count));
            default:
                return null;
        }
    }

    public void Dispose()
    {
    }

    public class Factory : PlaceholderFactory
    <
        IReadOnlyCollection<Motion>,
        IReadOnlyCollection<Motion>,
        IReadOnlyCollection<Motion>,
        IReadOnlyCollection<Motion>,
        IReadOnlyCollection<Motion>,
        IReadOnlyCollection<Motion>,
        IReadOnlyCollection<Motion>,
        IReadOnlyCollection<Motion>,
        IReadOnlyCollection<Motion>,
        string,
        AnimationChangeUseCase
    >
    {
    }
}