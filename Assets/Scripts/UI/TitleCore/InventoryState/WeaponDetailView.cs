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
        [SerializeField] private TextMeshProUGUI weaponName;
        [SerializeField] private SkillGridView statusSkillGridView;
        [SerializeField] private SkillGridView normalSkillGridView;
        [SerializeField] private SkillGridView specialSkillGridView;
        [SerializeField] private Button equipButton;
        [SerializeField] private Button sellButton;
        [SerializeField] private Transform weaponObjectParent;
        private GameObject weaponObject;
        public Button EquipButton => equipButton;
        public Button SellButton => sellButton;

        public void ApplyViewModel(ViewModel viewModel)
        {
            weaponName.text = viewModel.Name;
            var statusSkillViewModel = TranslateSkillDataToViewModel(viewModel.StatusSkillMasterData);
            var normalSkillViewModel = TranslateSkillDataToViewModel(viewModel.NormalSkillMasterData);
            var specialSkillViewModel = TranslateSkillDataToViewModel(viewModel.SpecialSkillMasterData);
            statusSkillGridView.ApplyViewModel(statusSkillViewModel);
            normalSkillGridView.ApplyViewModel(normalSkillViewModel);
            specialSkillGridView.ApplyViewModel(specialSkillViewModel);
            Destroy(weaponObject);
            weaponObject = Instantiate(viewModel.WeaponObject, weaponObjectParent);
            FixedTransform(viewModel.WeaponType, viewModel.Scale);
            Observable.EveryUpdate()
                .Subscribe(_ => weaponObject.transform.Rotate(Vector3.up, 0.1f))
                .AddTo(weaponObject.GetCancellationTokenOnDestroy());
        }

        private void FixedTransform(WeaponType weaponType, float scale)
        {
            switch (weaponType)
            {
                case WeaponType.Spear:
                    weaponObject.transform.localPosition = new Vector3(0, 0.39f, 0);
                    weaponObject.transform.localRotation = quaternion.Euler(0, 0, 0);
                    weaponObject.transform.localScale *= scale;
                    break;
                case WeaponType.Sword:
                    weaponObject.transform.localPosition = new Vector3(0, 0.83f, 0);
                    weaponObject.transform.localRotation = quaternion.Euler(0, 0, 0);
                    weaponObject.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f) * scale;
                    break;
                case WeaponType.Bow:
                    weaponObject.transform.localPosition = new Vector3(0, 0, 0);
                    weaponObject.transform.localRotation = quaternion.Euler(0, 0, 0);
                    weaponObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                    break;
            }
        }

        private void OnDestroy()
        {
            Destroy(weaponObject);
        }

        private SkillGridView.ViewModel TranslateSkillDataToViewModel(SkillMasterData skillMasterData)
        {
            return new SkillGridView.ViewModel(skillMasterData.Sprite, skillMasterData.Name);
        }

        public class ViewModel
        {
            public Sprite Icon { get; }
            public string Name { get; }
            public SkillMasterData StatusSkillMasterData { get; }
            public SkillMasterData NormalSkillMasterData { get; }
            public SkillMasterData SpecialSkillMasterData { get; }
            public GameObject WeaponObject { get; }
            public WeaponType WeaponType { get; }
            public float Scale { get; }


            public ViewModel
            (
                Sprite icon,
                string name,
                SkillMasterData statusSkillMasterData,
                SkillMasterData normalSkillMasterData,
                SkillMasterData specialSkillMasterData,
                GameObject weaponObject,
                WeaponType weaponType,
                float scale
            )
            {
                Icon = icon;
                Name = name;
                StatusSkillMasterData = statusSkillMasterData;
                NormalSkillMasterData = normalSkillMasterData;
                SpecialSkillMasterData = specialSkillMasterData;
                WeaponObject = weaponObject;
                WeaponType = weaponType;
                Scale = scale;
            }
        }
    }
}