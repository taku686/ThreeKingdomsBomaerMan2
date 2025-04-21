using System;
using System.Globalization;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.DataManager;
using TMPro;
using UniRx;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class WeaponDetailView : MonoBehaviour
    {
        [SerializeField] private GameObject[] _rareObjects;
        [SerializeField] private TextMeshProUGUI weaponName;
        [SerializeField] private SkillGridView normalSkillGridView;
        [SerializeField] private SkillGridView specialSkillGridView;
        [SerializeField] private Button equipButton;
        [SerializeField] private Button sellButton;
        [SerializeField] private Transform weaponObjectParent;
        [SerializeField] private TextMeshProUGUI _sellPriceText;
        [SerializeField] private TextMeshProUGUI _weaponStatusText;
        [SerializeField] private TextMeshProUGUI _weaponStatus2Text;

        private GameObject _weaponObject;
        private const float RotateSpeed = 0.3f;
        public Button _EquipButton => equipButton;
        public Button _SellButton => sellButton;
        public Button _NormalSkillDetailButton => normalSkillGridView._DetailButton;
        public Button _SpecialSkillDetailButton => specialSkillGridView._DetailButton;

        public IObservable<Unit> OnClickNormalSkillDetailButtonAsObservable()
        {
            return normalSkillGridView.OnClickDetailButtonAsObservable();
        }

        public IObservable<Unit> OnClickSpecialSkillDetailButtonAsObservable()
        {
            return specialSkillGridView.OnClickDetailButtonAsObservable();
        }

        public void ApplyViewModel(ViewModel viewModel)
        {
            weaponName.text = viewModel._Name;
            var normalSkillViewModel = TranslateSkillMasterDataToViewModel(viewModel._NormalSkillMasterData);
            var specialSkillViewModel = TranslateSkillMasterDataToViewModel(viewModel._SpecialSkillMasterData);
            normalSkillGridView.ApplyViewModel(normalSkillViewModel);
            specialSkillGridView.ApplyViewModel(specialSkillViewModel);
            InstantiateWeapon(viewModel._WeaponType, viewModel._Scale, viewModel._WeaponObject, viewModel._WeaponId);
            ApplyRareView(viewModel._Rare);
            ApplyWeaponStatusText(viewModel._StatusSkillMasterDatum);
            _sellPriceText.text = GameCommonData.GetWeaponSellPrice(viewModel._Rare).ToString();

            Observable.EveryUpdate()
                .Subscribe(_ => { RotateWeapon(viewModel); })
                .AddTo(_weaponObject.GetCancellationTokenOnDestroy());
        }

        private void ApplyWeaponStatusText(SkillMasterData[] skillMasterDatum)
        {
            var length = skillMasterDatum.Length;
            switch (length)
            {
                case 0:
                    _weaponStatusText.text = string.Empty;
                    _weaponStatus2Text.text = string.Empty;
                    return;
                case 1:
                {
                    var skillMasterData = skillMasterDatum[0];
                    var result = SkillMasterDataRepository.GetStatusSkillValue(skillMasterData);
                    _weaponStatusText.text = TranslateWeaponStatusText(result.Item1, result.Item2);
                    _weaponStatus2Text.text = string.Empty;
                    break;
                }
                case 2:
                {
                    var skillMasterData = skillMasterDatum[0];
                    var skillMasterData2 = skillMasterDatum[1];
                    var result = SkillMasterDataRepository.GetStatusSkillValue(skillMasterData);
                    var result2 = SkillMasterDataRepository.GetStatusSkillValue(skillMasterData2);
                    _weaponStatusText.text = TranslateWeaponStatusText(result.Item1, result.Item2);
                    _weaponStatus2Text.text = TranslateWeaponStatusText(result2.Item1, result2.Item2);
                    break;
                }
            }
        }

        private string TranslateWeaponStatusText(StatusType statusType, float value)
        {
            return statusType switch
            {
                StatusType.Attack => "攻撃力+" + value.ToString(CultureInfo.InvariantCulture),
                StatusType.Defense => "防御力+" + value.ToString(CultureInfo.InvariantCulture),
                StatusType.Hp => "HP+" + value.ToString(CultureInfo.InvariantCulture),
                StatusType.Speed => "スピード+" + value.ToString(CultureInfo.InvariantCulture),
                StatusType.BombLimit => "ボム数+" + value.ToString(CultureInfo.InvariantCulture),
                StatusType.FireRange => "火力+" + value.ToString(CultureInfo.InvariantCulture),
                StatusType.Resistance => "精神力+" + value.ToString(CultureInfo.InvariantCulture),
                StatusType.None => "",
                _ => throw new ArgumentOutOfRangeException(nameof(statusType), statusType, null)
            };
        }

        private void RotateWeapon(ViewModel viewModel)
        {
            if (viewModel._WeaponId >= 146)
            {
                if (viewModel._WeaponId is 159 or 313 or 319)
                {
                    _weaponObject.transform.Rotate(Vector3.up, RotateSpeed);
                    return;
                }

                if (viewModel._WeaponId is 241 or 232)
                {
                    _weaponObject.transform.Rotate(Vector3.right, RotateSpeed);
                    return;
                }

                _weaponObject.transform.Rotate(Vector3.forward, RotateSpeed);
            }
            else
            {
                _weaponObject.transform.Rotate(Vector3.up, RotateSpeed);
            }
        }

        private void ApplyRareView(int rare)
        {
            foreach (var rareObject in _rareObjects)
            {
                rareObject.SetActive(false);
            }

            for (var i = 0; i < rare; i++)
            {
                _rareObjects[i].SetActive(true);
            }
        }

        private void InstantiateWeapon(WeaponType weaponType, float scale, GameObject weaponObject, int weaponId)
        {
            Destroy(_weaponObject);
            _weaponObject = Instantiate(weaponObject, weaponObjectParent);
            switch (weaponType)
            {
                case WeaponType.Spear:
                    _weaponObject.transform.localPosition = weaponId >= 146 ? new Vector3(0, -0.35f, 0.43f) : new Vector3(0, -0.67f, 0);
                    if (weaponId >= 146)
                    {
                        _weaponObject.transform.localEulerAngles = new Vector3(90, 0, 0);
                        _weaponObject.transform.localPosition = new Vector3(0, -0.35f, 0.43f);
                        if (weaponId == 159)
                        {
                            _weaponObject.transform.localEulerAngles = new Vector3(0, 0, 0);
                            _weaponObject.transform.localPosition = new Vector3(0, -0.55f, -0.51f);
                        }
                    }
                    else
                    {
                        _weaponObject.transform.localEulerAngles = new Vector3(180, 0, 0);
                        _weaponObject.transform.localPosition = new Vector3(0, -0.67f, 0);
                    }

                    _weaponObject.transform.localScale *= scale;
                    break;
                case WeaponType.Hammer:
                    if (weaponId >= 146)
                    {
                        _weaponObject.transform.localPosition = new Vector3(0, -0.63f, 0);
                        _weaponObject.transform.localEulerAngles = new Vector3(90, 0, 0);

                        if (weaponId == 241)
                        {
                            _weaponObject.transform.localEulerAngles = new Vector3(0, 0, -90);
                        }
                    }
                    else
                    {
                        _weaponObject.transform.localPosition = new Vector3(0, -0.809f, 0.37f);
                    }

                    break;
                case WeaponType.Sword:
                    if (weaponId >= 146)
                    {
                        _weaponObject.transform.localEulerAngles = new Vector3(90, 0, 0);
                        _weaponObject.transform.localPosition = new Vector3(0, -0.6f, -0.3f);
                        if (weaponId == 232)
                        {
                            _weaponObject.transform.localEulerAngles = new Vector3(0, 0, 90);
                        }

                        if (weaponId == 313)
                        {
                            _weaponObject.transform.localEulerAngles = new Vector3(0, 0, 180);
                        }

                        if (weaponId == 319)
                        {
                            _weaponObject.transform.localEulerAngles = new Vector3(0, 0, 0);
                        }

                        if (weaponId == 319)
                        {
                            _weaponObject.transform.localPosition = new Vector3(0, -0.6f, 0);
                        }
                    }
                    else
                    {
                        _weaponObject.transform.localPosition = new Vector3(0, -0.7f, 0);
                        _weaponObject.transform.localEulerAngles = new Vector3(180, 0, 0);
                        _weaponObject.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f) * scale;
                    }

                    break;
                case WeaponType.Knife:
                    _weaponObject.transform.localPosition = new Vector3(0, -0.16f, -1.32f);
                    _weaponObject.transform.localEulerAngles = new Vector3(0, 0, 0);
                    _weaponObject.transform.localScale = Vector3.one;
                    break;
                case WeaponType.Bow:
                    _weaponObject.transform.localPosition = new Vector3(0, 0, 0);
                    _weaponObject.transform.localRotation = quaternion.Euler(0, 0, 0);
                    _weaponObject.transform.localScale *= 1.5f;
                    break;
                case WeaponType.Shield:
                    _weaponObject.transform.localPosition = new Vector3(0, -0.08f, -0.47f);
                    _weaponObject.transform.localRotation = quaternion.Euler(0, 0, 0);
                    _weaponObject.transform.localScale = Vector3.one;
                    break;
                case WeaponType.Axe:
                    _weaponObject.transform.localPosition = new Vector3(0, -0.3f, -0.73f);
                    _weaponObject.transform.localRotation = quaternion.Euler(0, 0, 0);
                    _weaponObject.transform.localScale = Vector3.one;
                    break;
                case WeaponType.Fan:
                    break;
                case WeaponType.Staff:
                    break;
                case WeaponType.BigSword:
                    break;
                case WeaponType.Crow:
                    break;
                case WeaponType.Katana:
                    break;
                case WeaponType.Scythe:
                    break;
                case WeaponType.Lance:
                    break;
                case WeaponType.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(weaponType), weaponType, null);
            }
        }

        private void OnDestroy()
        {
            Destroy(_weaponObject);
        }

        private SkillGridView.ViewModel TranslateSkillMasterDataToViewModel(SkillMasterData skillMasterData)
        {
            return skillMasterData == null ? null : new SkillGridView.ViewModel(skillMasterData.Sprite, skillMasterData.Name);
        }

        public class ViewModel
        {
            public Sprite _Icon { get; }
            public string _Name { get; }
            public SkillMasterData _NormalSkillMasterData { get; }
            public SkillMasterData _SpecialSkillMasterData { get; }
            public SkillMasterData[] _StatusSkillMasterDatum { get; }
            public GameObject _WeaponObject { get; }
            public WeaponType _WeaponType { get; }
            public float _Scale { get; }
            public int _Rare { get; }
            public int _WeaponId { get; }

            public ViewModel
            (
                Sprite icon,
                string name,
                SkillMasterData normalSkillMasterData,
                SkillMasterData specialSkillMasterData,
                SkillMasterData[] statusSkillMasterDatum,
                GameObject weaponObject,
                WeaponType weaponType,
                float scale,
                int rare,
                int weaponId
            )
            {
                _Icon = icon;
                _Name = name;
                _NormalSkillMasterData = normalSkillMasterData;
                _SpecialSkillMasterData = specialSkillMasterData;
                _StatusSkillMasterDatum = statusSkillMasterDatum;
                _WeaponObject = weaponObject;
                _WeaponType = weaponType;
                _Scale = scale;
                _Rare = rare;
                _WeaponId = weaponId;
            }
        }
    }
}