using System.Collections.Generic;
using Common.Data;
using Cysharp.Threading.Tasks;
using UI.Title;
using UniRx;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : ViewBase
{
    [SerializeField] private Button backButton;
    [SerializeField] private WeaponGridView weaponGridViewPrefab;
    [SerializeField] private WeaponDetailView weaponDetailView;
    [SerializeField] private Transform weaponGridParent;
    [SerializeField] private Transform weaponObjectParent;

    private GameObject weaponObject;
    private readonly List<WeaponGridView> weaponGridViews = new();
    public Button BackButton => backButton;
    public Button EquipButton => weaponDetailView.EquipButton;
    public Button SellButton => weaponDetailView.SellButton;
    public IReadOnlyCollection<WeaponGridView> WeaponGridViews => weaponGridViews;

    public void ApplyViewModel(ViewModel viewModel, int selectedWeaponId)
    {
        foreach (var weaponGridView in weaponGridViews)
        {
            Destroy(weaponGridView.gameObject);
        }

        weaponGridViews.Clear();

        foreach (var weaponData in viewModel.PossessedWeaponDatum)
        {
            var weaponGridView = Instantiate(weaponGridViewPrefab, weaponGridParent);
            var weaponMasterData = weaponData.Key;
            var possessedAmount = weaponData.Value;
            var weaponGridViewModel =
                TranslateWeaponDataToViewModel(weaponMasterData, possessedAmount, selectedWeaponId);
            weaponGridView.ApplyViewModel(weaponGridViewModel);
            weaponGridViews.Add(weaponGridView);
        }

        ApplyWeaponDetailViewModel(viewModel.EquippedWeaponMasterData);
    }

    private WeaponGridView.ViewModel TranslateWeaponDataToViewModel(WeaponMasterData weaponMasterData,
        int possessedAmount, int selectedWeaponId)
    {
        return new WeaponGridView.ViewModel
        (
            weaponMasterData.WeaponIcon,
            possessedAmount,
            weaponMasterData.Id,
            selectedWeaponId
        );
    }

    public void ApplyWeaponDetailViewModel(WeaponMasterData weaponMasterData)
    {
        Destroy(weaponObject);
        var weaponDetailViewModel = TranslateWeaponDataToViewModel(weaponMasterData);
        weaponDetailView.ApplyViewModel(weaponDetailViewModel);
        weaponObject = Instantiate(weaponMasterData.WeaponObject, weaponObjectParent);
        FixedTransform(weaponMasterData.WeaponType);
        Observable.EveryUpdate()
            .Subscribe(_ => weaponObject.transform.Rotate(Vector3.up, 0.1f))
            .AddTo(weaponObject.GetCancellationTokenOnDestroy());
    }

    private void FixedTransform(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.Spear:
                weaponObject.transform.localPosition = new Vector3(0, 0, 0);
                weaponObject.transform.localRotation = quaternion.Euler(0, 0, 0);
                break;
            case WeaponType.Sword:
                weaponObject.transform.localPosition = new Vector3(0, 0.73f, 0);
                weaponObject.transform.localRotation = quaternion.Euler(0, 0, 0);
                weaponObject.transform.localScale = new Vector3(20f, 20f, 20f);
                break;
            case WeaponType.Bow:
                weaponObject.transform.localPosition = new Vector3(0, 0, 0);
                weaponObject.transform.localRotation = quaternion.Euler(0, 0, 0);
                weaponObject.transform.localScale = new Vector3(15f, 15f, 15f);
                break;
        }
    }

    private WeaponDetailView.ViewModel TranslateWeaponDataToViewModel(WeaponMasterData weaponMasterData)
    {
        return new WeaponDetailView.ViewModel
        (
            weaponMasterData.WeaponIcon,
            weaponMasterData.Name,
            weaponMasterData.StatusSkillMasterData,
            weaponMasterData.NormalSkillMasterData,
            weaponMasterData.SpecialSkillMasterData
        );
    }

    private void OnDestroy()
    {
        weaponGridViews.Clear();
    }

    public class ViewModel
    {
        public IReadOnlyDictionary<WeaponMasterData, int> PossessedWeaponDatum { get; }
        public WeaponMasterData EquippedWeaponMasterData { get; }

        public ViewModel
        (
            IReadOnlyDictionary<WeaponMasterData, int> possessedWeaponDatum,
            WeaponMasterData equippedWeaponMasterData
        )
        {
            PossessedWeaponDatum = possessedWeaponDatum;
            EquippedWeaponMasterData = equippedWeaponMasterData;
        }
    }
}