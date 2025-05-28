using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UI.Common;
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
    [SerializeField] private GameObject _cautionObject;
    private int _weaponId;
    private UIAnimation _uiAnimation;
    private readonly Subject<int> _onClickObservableSubject = new();
    public IObservable<int> _OnClickObservable => _onClickObservableSubject;

    public void ApplyViewModel(ViewModel viewModel, UIAnimation uiAnimation, Action<bool> setActivePanelAction)
    {
        _uiAnimation = uiAnimation;
        iconImage.sprite = viewModel._Icon;
        countText.gameObject.SetActive(viewModel._Count > 1);
        countText.text = viewModel._Count.ToString();
        _weaponId = viewModel._GridId;
        _gridImage.sprite = _rareGridSprites[viewModel._Rare - 1];
        _cautionObject.SetActive(viewModel._IsCaution);
        if (viewModel._IsFocus)
        {
            focusObject.SetActive(viewModel._SelectedWeaponId == viewModel._GridId);
        }
        else
        {
            focusObject.SetActive(false);
        }

        OnClickButton(setActivePanelAction);
    }

    private void OnClickButton(Action<bool> setActivePanelAction)
    {
        button.OnClickAsObservable()
            .Do(_ => setActivePanelAction.Invoke(true))
            .SelectMany(_ => _uiAnimation.ClickScaleColor(button.gameObject).ToUniTask().ToObservable())
            .Subscribe(_ =>
            {
                _onClickObservableSubject.OnNext(_weaponId);
                setActivePanelAction.Invoke(false);
            })
            .AddTo(gameObject);
    }

    public class ViewModel
    {
        public Sprite _Icon { get; }
        public int _Count { get; }
        public int _GridId { get; }
        public int _SelectedWeaponId { get; }
        public int _Rare { get; }
        public bool _IsFocus { get; }
        public bool _IsCaution { get; }

        public ViewModel
        (
            Sprite icon,
            int count,
            int gridId,
            int selectedWeaponId,
            int rare,
            bool isFocus,
            bool isCaution
        )
        {
            _Icon = icon;
            _Count = count;
            _GridId = gridId;
            _SelectedWeaponId = selectedWeaponId;
            _Rare = rare;
            _IsFocus = isFocus;
            _IsCaution = isCaution;
        }
    }
}