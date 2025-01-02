using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;
using MoreMountains.Tools;
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
    [SerializeField] private SkillDetailView skillDetailView;

    private readonly List<WeaponGridView> _weaponGridViews = new();
    public Button _BackButton => backButton;
    public Button _EquipButton => weaponDetailView._EquipButton;
    public Button _SellButton => weaponDetailView._SellButton;

    public IObservable<Unit> OnClickBackButtonAsObservable()
    {
        return skillDetailView.OnClickCloseButtonAsObservable();
    }

    public IObservable<Unit> OnClickStatusSkillDetailButtonAsObservable()
    {
        return weaponDetailView.OnClickStatusSkillDetailButtonAsObservable();
    }

    public IObservable<Unit> OnClickNormalSkillDetailButtonAsObservable()
    {
        return weaponDetailView.OnClickNormalSkillDetailButtonAsObservable();
    }

    public IObservable<Unit> OnClickSpecialSkillDetailButtonAsObservable()
    {
        return weaponDetailView.OnClickSpecialSkillDetailButtonAsObservable();
    }

    public IReadOnlyCollection<WeaponGridView> WeaponGridViews => _weaponGridViews;

    public void ApplyViewModel(ViewModel viewModel)
    {
        GenerateWeaponGridViews(viewModel);
        ApplyWeaponDetailViewModel(viewModel.WeaponMasterData);
    }

    private void GenerateWeaponGridViews(ViewModel viewModel)
    {
        foreach (var weaponGridView in _weaponGridViews)
        {
            Destroy(weaponGridView.gameObject);
        }

        _weaponGridViews.Clear();
        var possessedWeaponDatum =
            viewModel.PossessedWeaponDatum
                .OrderBy(data => data.Key.Rare)
                .ThenBy(data => data.Key.WeaponType)
                .ThenBy(data => data.Key.Id);
        foreach (var keyValuePair in possessedWeaponDatum)
        {
            var weaponGridView = Instantiate(weaponGridViewPrefab, weaponGridParent);
            var weaponMasterData = keyValuePair.Key;
            var possessedAmount = keyValuePair.Value;
            var weaponGridViewModel = TranslateWeaponDataToViewModel(weaponMasterData, possessedAmount, viewModel.WeaponMasterData.Id);
            weaponGridView.ApplyViewModel(weaponGridViewModel);
            _weaponGridViews.Add(weaponGridView);
        }
    }

    public void ApplySkillDetailViewModel(SkillDetailView.ViewModel viewModel)
    {
        skillDetailView.ApplyViewModel(viewModel);
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
            selectedWeaponId,
            weaponMasterData.Rare
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
            weaponMasterData.WeaponType,
            weaponMasterData.Scale,
            weaponMasterData.Rare
        );
    }

    public void CloseSkillDetailView()
    {
        skillDetailView.Close();
    }

    private void OnDestroy()
    {
        _weaponGridViews.Clear();
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