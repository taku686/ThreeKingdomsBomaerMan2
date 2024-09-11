using System;
using Common.Data;
using Photon.Pun;
using Unity.Mathematics;
using UnityEngine;
using Object = UnityEngine.Object;

public class WeaponCreateInBattleUseCase : IDisposable
{
    private readonly Vector3 bowPosition = new(-0.029f, 0.02f, -0.001f);
    private readonly Vector3 weaponPosition = new(-0.061f, 0.026f, 0.003f);
    private readonly Vector3 bowRightRotation = new(-87.91f, 204.73f, -24.69f);
    private readonly Vector3 bowLeftRotation = new(87.91f, -204.73f, -24.69f);
    private readonly Vector3 weaponRightRotation = new(36.033f, -92.88f, 84.68f);
    private readonly Vector3 weaponLeftRotation = new(-36.033f, 92.88f, 84.68f);

    public void CreateWeapon
    (
        GameObject characterObject,
        WeaponMasterData weaponData,
        PhotonView photonView
    )
    {
        var weaponObjects = characterObject.GetComponentsInChildren<WeaponObject>();
        foreach (var weaponObject in weaponObjects)
        {
            Object.Destroy(weaponObject.gameObject);
        }

        if (!photonView.IsMine)
        {
            return;
        }

        var weaponRightParent = characterObject.GetComponentInChildren<WeaponRightParentObject>();
        var weaponLeftParent = characterObject.GetComponentInChildren<WeaponLeftParentObject>();
        if (IsLeftHand(weaponData.WeaponType))
        {
            weaponLeftParent.transform.localPosition =
                weaponData.WeaponType == WeaponType.Bow ? bowPosition : weaponPosition;
            weaponLeftParent.transform.localEulerAngles =
                weaponData.WeaponType == WeaponType.Bow ? bowLeftRotation : weaponLeftRotation;
            InstantiateWeapon(weaponData, weaponLeftParent.transform);
        }

        if (IsRightHand(weaponData.WeaponType))
        {
            weaponRightParent.transform.localPosition =
                weaponData.WeaponType == WeaponType.Bow ? bowPosition : weaponPosition;
            weaponRightParent.transform.localEulerAngles =
                weaponData.WeaponType == WeaponType.Bow ? bowRightRotation : weaponRightRotation;
            InstantiateWeapon(weaponData, weaponRightParent.transform);
        }
    }

    private bool IsRightHand(WeaponType weaponType)
    {
        return weaponType != WeaponType.Bow && weaponType != WeaponType.Shield;
    }

    private bool IsLeftHand(WeaponType weaponType)
    {
        return weaponType == WeaponType.Bow || weaponType == WeaponType.Knife || weaponType == WeaponType.Shield;
    }

    private void InstantiateWeapon(WeaponMasterData weaponMasterData, Transform weaponParent)
    {
        var currentWeapon = PhotonNetwork.Instantiate
        (
            GameCommonData.WeaponPrefabPath + weaponMasterData.WeaponObject.name,
            Vector3.zero,
            quaternion.Euler(0, 0, 0)
        );
        currentWeapon.transform.SetParent(weaponParent);
        currentWeapon.transform.localPosition = Vector3.zero;
        currentWeapon.transform.localRotation = quaternion.Euler(0, 0, 0);
        currentWeapon.transform.localScale = FixedScale(weaponMasterData.WeaponType, weaponMasterData.Scale);
        currentWeapon.tag = GameCommonData.WeaponTag;
        currentWeapon.AddComponent<WeaponObject>();
    }

    private Vector3 FixedScale(WeaponType weaponType, float scale)
    {
        switch (weaponType)
        {
            case WeaponType.Bow:
                return new Vector3(1, 1, 1) * scale;
            case WeaponType.Shield:
                return new Vector3(1, -1, 1);
            default:
                return new Vector3(1, 1, 1) * scale;
        }
    }

    public void Dispose()
    {
        // TODO マネージリソースをここで解放します
    }
}