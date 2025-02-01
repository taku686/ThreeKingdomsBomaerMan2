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

    private readonly List<WeaponGridView> _weaponGridViews = new();
    public IReadOnlyCollection<WeaponGridView> _WeaponGridViews => _weaponGridViews;
    private UIAnimation _uiAnimation;
    private Action<bool> _setActivePanelAction;
    public Button _BackButton => backButton;
    public Button _EquipButton => weaponDetailView._EquipButton;

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
        var possessedWeaponDatum = viewModel._PossessedWeaponDatum
            .OrderBy(data => data.Key.Rare)
            .ThenBy(data => data.Key.WeaponType)
            .ThenBy(data => data.Key.Id);
        foreach (var keyValuePair in possessedWeaponDatum)
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
        public IReadOnlyDictionary<WeaponMasterData, int> _PossessedWeaponDatum { get; }
        public WeaponMasterData _WeaponMasterData { get; }

        public ViewModel
        (
            IReadOnlyDictionary<WeaponMasterData, int> possessedWeaponDatum,
            WeaponMasterData weaponMasterData
        )
        {
            _PossessedWeaponDatum = possessedWeaponDatum;
            _WeaponMasterData = weaponMasterData;
        }
    }
}