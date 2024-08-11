using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class WeaponGridView : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private Button button;
    [SerializeField] private GameObject focusObject;
    private int weaponId;
    private readonly Subject<int> onClickObservableSubject = new();
    public IObservable<int> OnClickObservable => onClickObservableSubject;

    public void ApplyViewModel(ViewModel viewModel)
    {
        iconImage.sprite = viewModel.Icon;
        countText.gameObject.SetActive(viewModel.Count > 1);
        countText.text = viewModel.Count.ToString();
        weaponId = viewModel.GridId;
        focusObject.SetActive(viewModel.SelectedWeaponId == viewModel.GridId);
        OnClickButton();
    }

    private void OnClickButton()
    {
        button.OnClickAsObservable()
            .Subscribe(_ => { onClickObservableSubject.OnNext(weaponId); })
            .AddTo(gameObject.GetCancellationTokenOnDestroy());
    }

    public class ViewModel
    {
        public Sprite Icon { get; }
        public int Count { get; }
        public int GridId { get; }
        public int SelectedWeaponId { get; }

        public ViewModel
        (
            Sprite icon,
            int count,
            int gridId,
            int selectedWeaponId
        )
        {
            Icon = icon;
            Count = count;
            GridId = gridId;
            SelectedWeaponId = selectedWeaponId;
        }
    }
}