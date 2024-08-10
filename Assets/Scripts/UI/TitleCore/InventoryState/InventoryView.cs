using System.Collections.Generic;
using Common.Data;
using Cysharp.Threading.Tasks;
using UI.Title;
using UniRx;
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
        weaponGridViews.Clear();

        foreach (var weaponData in viewModel.PossessedWeaponDatum)
        {
            var weaponGridView = Instantiate(weaponGridViewPrefab, weaponGridParent);
            var weaponMasterData = weaponData.Key;
            var possessedAmount = weaponData.Value;
            weaponGridView.ApplyViewModel(weaponMasterData.WeaponIcon, possessedAmount, weaponMasterData.Id);
            weaponGridView.OnClick
                .Subscribe(weaponId => { }).AddTo(weaponGridView.GetCancellationTokenOnDestroy());
            weaponGridViews.Add(weaponGridView);
        }

        ApplyWeaponDetailViewModel(viewModel.EquippedWeaponMasterData);
    }

    public void ApplyWeaponDetailViewModel(WeaponMasterData weaponMasterData)
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