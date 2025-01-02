using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class WeaponGridView : MonoBehaviour
{
    [SerializeField] private Sprite[] _rareGridSprites;
    [SerializeField] private Image _gridImage;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private Button button;
    [SerializeField] private GameObject focusObject;
    private int _weaponId;
    private readonly Subject<int> _onClickObservableSubject = new();
    public IObservable<int> _OnClickObservable => _onClickObservableSubject;

    public void ApplyViewModel(ViewModel viewModel)
    {
        iconImage.sprite = viewModel._Icon;
        countText.gameObject.SetActive(viewModel._Count > 1);
        countText.text = viewModel._Count.ToString();
        _weaponId = viewModel._GridId;
        _gridImage.sprite = _rareGridSprites[viewModel._Rare - 1];
        focusObject.SetActive(viewModel._SelectedWeaponId == viewModel._GridId);
        OnClickButton();
    }

    private void OnClickButton()
    {
        button.OnClickAsObservable()
            .Subscribe(_ => { _onClickObservableSubject.OnNext(_weaponId); })
            .AddTo(gameObject.GetCancellationTokenOnDestroy());
    }

    public class ViewModel
    {
        public Sprite _Icon { get; }
        public int _Count { get; }
        public int _GridId { get; }
        public int _SelectedWeaponId { get; }
        public int _Rare { get; }

        public ViewModel
        (
            Sprite icon,
            int count,
            int gridId,
            int selectedWeaponId,
            int rare
        )
        {
            _Icon = icon;
            _Count = count;
            _GridId = gridId;
            _SelectedWeaponId = selectedWeaponId;
            _Rare = rare;
        }
    }
}