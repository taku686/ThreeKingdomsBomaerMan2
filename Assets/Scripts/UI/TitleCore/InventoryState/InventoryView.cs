using System;
using System.Collections.Generic;
using Common.Data;
using Cysharp.Threading.Tasks;
using UI.Common;
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
    [SerializeField] private Button _sortButton;
    [SerializeField] private SortPopupView _sortPopupView;

    private readonly List<WeaponGridView> _weaponGridViews = new();
    public IReadOnlyCollection<WeaponGridView> _WeaponGridViews => _weaponGridViews;
    public SortPopupView _SortPopupView => _sortPopupView;
    private UIAnimation _uiAnimation;
    private Action<bool> _setActivePanelAction;
    public Button _BackButton => backButton;
    public Button _EquipButton => weaponDetailView._EquipButton;

    public IObservable<AsyncUnit> _OnClickSortButtonAsObservable => _sortButton
        .OnClickAsObservable()
        .SelectMany(_ => _uiAnimation.ClickScaleColor(_sortButton.gameObject).ToUniTask().ToObservable());

    public IObservable<AsyncUnit> _OnClickSortOkButtonAsObservable => _sortPopupView
        ._OnClickOkButtonAsObservable
        .SelectMany(button => _uiAnimation.ClickScaleColor(button.gameObject).ToUniTask().ToObservable());

    public IObservable<bool> _OnClickAscendingSwitchAsObservable => _sortPopupView._OnChangeAscendingToggleAsObservable;

    public IObservable<AsyncUnit> _OnClickSellButtonAsObservable
        => weaponDetailView._SellButton
            .OnClickAsObservable()
            .SelectMany(_ => _uiAnimation.ClickScaleColor(weaponDetailView._SellButton.gameObject).ToUniTask().ToObservable());

    public IObservable<AsyncUnit> _OnClickNormalSkillDetailButtonAsObservable
        => weaponDetailView
            .OnClickNormalSkillDetailButtonAsObservable()
            .SelectMany(_ => _uiAnimation.ClickScaleColor(weaponDetailView._NormalSkillDetailButton.gameObject).ToUniTask().ToObservable());

    public IObservable<AsyncUnit> _OnClickSpecialSkillDetailButtonAsObservable
        => weaponDetailView
            .OnClickSpecialSkillDetailButtonAsObservable()
            .SelectMany(_ => _uiAnimation.ClickScaleColor(weaponDetailView._SpecialSkillDetailButton.gameObject).ToUniTask().ToObservable());

    public void ApplyViewModel(ViewModel viewModel, UIAnimation uiAnimation, Action<bool> setActivePanelAction)
    {
        _uiAnimation = uiAnimation;
        _setActivePanelAction = setActivePanelAction;
        GenerateWeaponGridViews(viewModel);
        ApplyWeaponDetailViewModel(viewModel._SelectedWeaponMasterData);
    }

    private void GenerateWeaponGridViews(ViewModel viewModel)
    {
        foreach (var weaponGridView in _weaponGridViews)
        {
            Destroy(weaponGridView.gameObject);
        }

        _weaponGridViews.Clear();
        var sortedWeaponDatum = viewModel._SortedWeaponDatum;
        foreach (var (weaponMasterData, possessedAmount) in sortedWeaponDatum)
        {
            var weaponGridView = Instantiate(weaponGridViewPrefab, weaponGridParent);
            var weaponGridViewModel = TranslateWeaponDataToViewModel(weaponMasterData, possessedAmount, viewModel._SelectedWeaponMasterData.Id, viewModel._IsFocus);
            weaponGridView.ApplyViewModel(weaponGridViewModel, _uiAnimation, _setActivePanelAction);
            _weaponGridViews.Add(weaponGridView);
        }
    }

    private WeaponGridView.ViewModel TranslateWeaponDataToViewModel
    (
        WeaponMasterData weaponMasterData,
        int possessedAmount,
        int selectedWeaponId,
        bool isFocus
    )
    {
        return new WeaponGridView.ViewModel
        (
            weaponMasterData.WeaponIcon,
            possessedAmount,
            weaponMasterData.Id,
            selectedWeaponId,
            weaponMasterData.Rare,
            isFocus
        );
    }

    private void ApplyWeaponDetailViewModel(WeaponMasterData weaponMasterData)
    {
        var weaponDetailViewModel = TranslateWeaponDataToViewModel(weaponMasterData);
        weaponDetailView.ApplyViewModel(weaponDetailViewModel);
    }

    public void ApplySortView()
    {
        _sortPopupView.gameObject.SetActive(true);
    }

    public void CloseSortView()
    {
        _sortPopupView.gameObject.SetActive(false);
    }

    private WeaponDetailView.ViewModel TranslateWeaponDataToViewModel(WeaponMasterData weaponMasterData)
    {
        return new WeaponDetailView.ViewModel
        (
            weaponMasterData.WeaponIcon,
            weaponMasterData.Name,
            weaponMasterData.NormalSkillMasterData,
            weaponMasterData.SpecialSkillMasterData,
            weaponMasterData.StatusSkillMasterDatum,
            weaponMasterData.WeaponObject,
            weaponMasterData.WeaponType,
            weaponMasterData.Scale,
            weaponMasterData.Rare,
            weaponMasterData.Id
        );
    }

    private void OnDestroy()
    {
        _weaponGridViews.Clear();
    }

    public class ViewModel
    {
        public IReadOnlyDictionary<WeaponMasterData, int> _SortedWeaponDatum { get; }
        public WeaponMasterData _SelectedWeaponMasterData { get; }
        public bool _IsFocus { get; }

        public ViewModel
        (
            IReadOnlyDictionary<WeaponMasterData, int> sortedWeaponDatum,
            WeaponMasterData selectedWeaponMasterData,
            bool isFocus
        )
        {
            _SortedWeaponDatum = sortedWeaponDatum;
            _SelectedWeaponMasterData = selectedWeaponMasterData;
            _IsFocus = isFocus;
        }
    }
}