using System.Collections.Generic;
using System.Linq;
using Common.Data;
using UI.Title;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : ViewBase
{
    [SerializeField] private Button backButton;
    [SerializeField] private WeaponGridView weaponGridViewPrefab;
    [SerializeField] private WeaponDetailView weaponDetailView;
    [SerializeField] private Transform weaponGridParent;

    private readonly List<WeaponGridView> weaponGridViews = new();
    public Button BackButton => backButton;
    public Button EquipButton => weaponDetailView.EquipButton;
    public Button SellButton => weaponDetailView.SellButton;
    public IReadOnlyCollection<WeaponGridView> WeaponGridViews => weaponGridViews;

    public void ApplyViewModel(ViewModel viewModel)
    {
        foreach (var weaponGridView in weaponGridViews)
        {
            Destroy(weaponGridView.gameObject);
        }

        weaponGridViews.Clear();
        var possessedWeaponDatum =
            viewModel.PossessedWeaponDatum
                .OrderBy(data => data.Key.WeaponType)
                .ThenBy(data => data.Key.Id);
        foreach (var keyValuePair in possessedWeaponDatum)
        {
            var weaponGridView = Instantiate(weaponGridViewPrefab, weaponGridParent);
            var weaponMasterData = keyValuePair.Key;
            var possessedAmount = keyValuePair.Value;
            var weaponGridViewModel =
                TranslateWeaponDataToViewModel(weaponMasterData, possessedAmount, viewModel.WeaponMasterData.Id);
            weaponGridView.ApplyViewModel(weaponGridViewModel);
            weaponGridViews.Add(weaponGridView);
        }

        ApplyWeaponDetailViewModel(viewModel.WeaponMasterData);
    }

    private WeaponGridView.ViewModel TranslateWeaponDataToViewModel
    (
        WeaponMasterData weaponMasterData,
        int possessedAmount,
        int selectedWeaponId
    )
    {
        return new WeaponGridView.ViewModel
        (
            weaponMasterData.WeaponIcon,
            possessedAmount,
            weaponMasterData.Id,
            selectedWeaponId
        );
    }

    private void ApplyWeaponDetailViewModel(WeaponMasterData weaponMasterData)
    {
        var weaponDetailViewModel = TranslateWeaponDataToViewModel(weaponMasterData);
        weaponDetailView.ApplyViewModel(weaponDetailViewModel);
    }

    private WeaponDetailView.ViewModel TranslateWeaponDataToViewModel(WeaponMasterData weaponMasterData)
    {
        return new WeaponDetailView.ViewModel
        (
            weaponMasterData.WeaponIcon,
            weaponMasterData.Name,
            weaponMasterData.StatusSkillMasterData,
            weaponMasterData.NormalSkillMasterData,
            weaponMasterData.SpecialSkillMasterData,
            weaponMasterData.WeaponObject,
            weaponMasterData.WeaponType
        );
    }

    private void OnDestroy()
    {
        weaponGridViews.Clear();
    }

    public class ViewModel
    {
        public IReadOnlyDictionary<WeaponMasterData, int> PossessedWeaponDatum { get; }
        public WeaponMasterData WeaponMasterData { get; }

        public ViewModel
        (
            IReadOnlyDictionary<WeaponMasterData, int> possessedWeaponDatum,
            WeaponMasterData weaponMasterData
        )
        {
            PossessedWeaponDatum = possessedWeaponDatum;
            WeaponMasterData = weaponMasterData;
        }
    }
}