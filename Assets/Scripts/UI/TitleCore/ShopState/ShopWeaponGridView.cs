using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ShopWeaponGridView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _itemTitleText;
    [SerializeField] private TextMeshProUGUI _itemText;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private Button _weaponButton;

    public Button _WeaponButton => _weaponButton;

    public void ApplyView(int createCount, int cost)
    {
        _itemTitleText.text = $"ランダムで\n\n武器{createCount}個入手";
        _itemText.text = $"Weapon\n<size=50>x{createCount}</size>";
        _costText.text = (cost * createCount).ToString("D");
    }
}