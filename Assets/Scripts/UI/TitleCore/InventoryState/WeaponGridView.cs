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
    private int weaponId;
    private readonly Subject<int> onClickSubject = new();
    public IObservable<int> OnClick => onClickSubject;

    public void ApplyViewModel(Sprite icon, int count, int id)
    {
        iconImage.sprite = icon;
        countText.gameObject.SetActive(count > 1);
        countText.text = count.ToString();
        weaponId = id;
        OnClickButton();
    }

    private void OnClickButton()
    {
        button.OnClickAsObservable()
            .Subscribe(_ => { onClickSubject.OnNext(weaponId); })
            .AddTo(gameObject.GetCancellationTokenOnDestroy());
    }
}