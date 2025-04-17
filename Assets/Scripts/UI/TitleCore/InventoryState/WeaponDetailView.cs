using System;
using Common.Data;
using Cysharp.Threading.Tasks;
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
        private GameObject _weaponObject;
        private bool _isInitialized;
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
            var normalSkillViewModel = TranslateSkillDataToViewModel(viewModel._NormalSkillMasterData);
            var specialSkillViewModel = TranslateSkillDataToViewModel(viewModel._SpecialSkillMasterData);
            normalSkillGridView.ApplyViewModel(normalSkillViewModel);
            specialSkillGridView.ApplyViewModel(specialSkillViewModel);
            Destroy(_weaponObject);
            _weaponObject = Instantiate(viewModel._WeaponObject, weaponObjectParent);
            FixedTransform(viewModel._WeaponType, viewModel._Scale);
            ApplyRareView(viewModel._Rare);
            if (_isInitialized)
            {
                return;
            }

            Observable.EveryUpdate()
                .Subscribe(_ => _weaponObject.transform.Rotate(Vector3.up, 0.1f))
                .AddTo(gameObject.GetCancellationTokenOnDestroy());
            _isInitialized = true;
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

        private void FixedTransform(WeaponType weaponType, float scale)
        {
            switch (weaponType)
            {
                case WeaponType.Spear:
                    _weaponObject.transform.localPosition = new Vector3(0, -0.67f, 0);
                    _weaponObject.transform.localEulerAngles = new Vector3(180, 0, 0);
                    _weaponObject.transform.localScale *= scale;
                    break;
                case WeaponType.Hammer:
                    _weaponObject.transform.localPosition = new Vector3(0, -0.26f, 0);
                    break;
                case WeaponType.Sword:
                    _weaponObject.transform.localPosition = new Vector3(0, -0.7f, 0);
                    _weaponObject.transform.localEulerAngles = new Vector3(180, 0, 0);
                    _weaponObject.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f) * scale;
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
            }
        }

        private void OnDestroy()
        {
            Destroy(_weaponObject);
        }

        private SkillGridView.ViewModel TranslateSkillDataToViewModel(SkillMasterData skillMasterData)
        {
            return skillMasterData == null ? null : new SkillGridView.ViewModel(skillMasterData.Sprite, skillMasterData.Name);
        }

        public class ViewModel
        {
            public Sprite _Icon { get; }
            public string _Name { get; }
            public SkillMasterData _NormalSkillMasterData { get; }
            public SkillMasterData _SpecialSkillMasterData { get; }
            public GameObject _WeaponObject { get; }
            public WeaponType _WeaponType { get; }
            public float _Scale { get; }
            public int _Rare { get; }


            public ViewModel
            (
                Sprite icon,
                string name,
                SkillMasterData normalSkillMasterData,
                SkillMasterData specialSkillMasterData,
                GameObject weaponObject,
                WeaponType weaponType,
                float scale,
                int rare
            )
            {
                _Icon = icon;
                _Name = name;
                _NormalSkillMasterData = normalSkillMasterData;
                _SpecialSkillMasterData = specialSkillMasterData;
                _WeaponObject = weaponObject;
                _WeaponType = weaponType;
                _Scale = scale;
                _Rare = rare;
            }
        }
    }
}