using System;
using System.Collections.Generic;
using System.Linq;
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
    [SerializeField] private SkillDetailView skillDetailView;
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

    public IObservable<AsyncUnit> _OnClickSellButtonAsObservable => weaponDetailView._SellButton
        .OnClickAsObservable()
        .SelectMany(_ => _uiAnimation.ClickScaleColor(weaponDetailView._SellButton.gameObject).ToUniTask().ToObservable());

    public IObservable<AsyncUnit> _OnClickSkillDetailViewCloseButtonAsObservable
        => skillDetailView.OnClickCloseButtonAsObservable();

    public IObservable<AsyncUnit> _OnClickStatusSkillDetailButtonAsObservable
        => weaponDetailView
            .OnClickStatusSkillDetailButtonAsObservable()
            .SelectMany(_ => _uiAnimation.ClickScaleColor(weaponDetailView._StatusSkillDetailButton.gameObject).ToUniTask().ToObservable());

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
        ApplyWeaponDetailViewModel(viewModel._WeaponMasterData);
    }

    private void GenerateWeaponGridViews(ViewModel viewModel)
    {
        foreach (var weaponGridView in _weaponGridViews)
        {
            Destroy(weaponGridView.gameObject);
        }

        _weaponGridViews.Clear();
        var sortedWeaponDatum = viewModel._SortedWeaponDatum;
        foreach (var keyValuePair in sortedWeaponDatum)
        {
            var weaponGridView = Instantiate(weaponGridViewPrefab, weaponGridParent);
            var weaponMasterData = keyValuePair.Key;
            var possessedAmount = keyValuePair.Value;
            var weaponGridViewModel = TranslateWeaponDataToViewModel(weaponMasterData, possessedAmount, viewModel._WeaponMasterData.Id);
            weaponGridView.ApplyViewModel(weaponGridViewModel, _uiAnimation, _setActivePanelAction);
            _weaponGridViews.Add(weaponGridView);
        }
    }

    public void ApplySkillDetailViewModel(SkillDetailView.ViewModel viewModel)
    {
        skillDetailView.ApplyViewModel(viewModel, _uiAnimation, _setActivePanelAction);
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
        public IReadOnlyDictionary<WeaponMasterData, int> _SortedWeaponDatum { get; }
        public WeaponMasterData _WeaponMasterData { get; }

        public ViewModel
        (
            IReadOnlyDictionary<WeaponMasterData, int> sortedWeaponDatum,
            WeaponMasterData weaponMasterData
        )
        {
            _SortedWeaponDatum = sortedWeaponDatum;
            _WeaponMasterData = weaponMasterData;
        }
    }
}