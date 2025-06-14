using System;
using System.Collections.Generic;
using System.Globalization;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.DataManager;
using Sirenix.OdinInspector;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class WeaponDetailView : SerializedMonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI weaponName;
        [SerializeField] private SkillGridView normalSkillGridView;
        [SerializeField] private Button equipButton;
        [SerializeField] private Button sellButton;
        [SerializeField] private Transform weaponObjectParent;
        [SerializeField] private TextMeshProUGUI _sellPriceText;
        [SerializeField] private TextMeshProUGUI _weaponStatusText;
        [SerializeField] private TextMeshProUGUI _weaponStatus2Text;
        [SerializeField] private TextMeshProUGUI _coinStatusText;
        [SerializeField] private TextMeshProUGUI _gemStatusText;
        [SerializeField] private TextMeshProUGUI _skillStatusText;
        [SerializeField] private TextMeshProUGUI _rangeStatusText;
        [SerializeField] private GameObject[] _rareObjects;

        private enum SpecialStatusType
        {
            Coin,
            Gem,
            Skill,
            Range
        }

        #region 武器の位置,角度調整

        private Dictionary<int[], (Vector3, Vector3)> _spearTransform = new()
        {
            {
                new[] { 3, 14, 15, 16, 17, 30, 39, 56, 65, 100, 104, 105, 155, 156, 157, 158, 204, 205, 207, 302, 303, },
                (
                    new Vector3(0, -0.36f, 0.57f),
                    new Vector3(180, 0, 0)
                )
            },
            {
                new[] { 206 },
                (
                    new Vector3(0, -0.46f, 0.57f),
                    new Vector3(180, 0, 0)
                )
            },
            {
                new[] { 304 },
                (
                    new Vector3(0, -0.24f, 0.57f),
                    new Vector3(180, 0, 0)
                )
            },
            {
                new[] { 48 },
                (
                    new Vector3(0, -0.12f, 0.57f),
                    new Vector3(180, 0, 0)
                )
            },
            {
                new[] { 74, 177, 220, 230, 237, 246, 256, 267, 315, 323, 332, 343, 148 },
                (
                    new Vector3(0, -0.18f, 1.91f),
                    new Vector3(90, 0, 0)
                )
            },
            {
                new[] { 87, },
                (
                    new Vector3(0, -0.5f, 0),
                    new Vector3(0, 90, 0)
                )
            },
        };

        private Dictionary<int[], (Vector3, Vector3)> _hammerTransform = new()
        {
            {
                new[] { 31, 40, },
                (
                    new Vector3(0, -0.79f, 1.47f),
                    new Vector3(180, 0, 0)
                )
            },
            {
                new[] { 66 },
                (
                    new Vector3(0, -0.57f, 1.47f),
                    new Vector3(180, 0, 0)
                )
            },
            {
                new[] { 57, },
                (
                    new Vector3(0, -0.39f, 1.13f),
                    new Vector3(180, 0, 0)
                )
            },
            {
                new[] { 78, },
                (
                    new Vector3(0, -0.79f, 0.82f),
                    new Vector3(0, 180, 90)
                )
            },
            {
                new[] { 88, },
                (
                    new Vector3(0, -0.43f, 0),
                    new Vector3(90, 90, 0)
                )
            },
            {
                new[] { 193, },
                (
                    new Vector3(0, -0.6f, 0),
                    new Vector3(0, 0, -90)
                )
            },
            {
                new[] { 121 },
                (
                    new Vector3(0, -0.57f, 0),
                    new Vector3(90, 180, 0)
                )
            },
            {
                new[] { 166, },
                (
                    new Vector3(0, -0.73f, 0.99f),
                    new Vector3(90, 180, 0)
                )
            },
        };

        private Dictionary<int[], (Vector3, Vector3)> _swordTransform = new()
        {
            {
                new[]
                {
                    0, 1, 4, 6, 9, 10, 22, 23, 25, 27, 28, 29, 101,
                    112, 113, 114, 115, 161, 162, 163, 210, 217, 218, 219,
                    305, 310,
                },
                (
                    new Vector3(0, -0.4f, -2.2f),
                    new Vector3(180, 0, 0)
                )
            },
            {
                new[]
                {
                    102,
                },
                (
                    new Vector3(0, -0.53f, -1.79f),
                    new Vector3(180, 0, 0)
                )
            },
            {
                new[]
                {
                    12, 26, 103, 208, 209, 306
                },
                (
                    new Vector3(0, -0.48f, -2.2f),
                    new Vector3(180, 0, 0)
                )
            },
            {
                new[] { 32 },
                (
                    new Vector3(0, -0.48f, -2.2f),
                    new Vector3(180, 0, 0)
                )
            },
            {
                new[] { 49 },
                (
                    new Vector3(0, -0.5f, -2.2f),
                    new Vector3(180, 0, 0)
                )
            },
            {
                new[] { 41, },
                (
                    new Vector3(0, -0.56f, -2.2f),
                    new Vector3(180, 0, 0)
                )
            },
            {
                new[] { 67, },
                (
                    new Vector3(0, -0.47f, -2.2f),
                    new Vector3(180, 0, 0)
                )
            },
            {
                new[] { 58 },
                (
                    new Vector3(0, -0.56f, -1.89f),
                    new Vector3(180, 0, 0)
                )
            },
            {
                new[] { 79 },
                (
                    new Vector3(0, -0.4f, 0),
                    new Vector3(0, 180, 90)
                )
            },
            {
                new[] { 89 },
                (
                    new Vector3(0, -0.58f, 0),
                    new Vector3(90, 90, 0)
                )
            },
            {
                new[] { 186 },
                (
                    new Vector3(0, -0.52f, -1.22f),
                    new Vector3(180, 90, -90)
                )
            },
            {
                new[] { 285 },
                (
                    new Vector3(0, -0.49f, 0),
                    new Vector3(180, 0, 0)
                )
            },
            {
                new[] { 292 },
                (
                    new Vector3(0, -0.57f, 0),
                    new Vector3(0, 0, 0)
                )
            },
            {
                new[]
                {
                    95, 116, 122, 130, 140, 142, 146, 149, 152, 165, 167, 175, 178, 190,
                    194, 196, 198, 201, 221, 231, 238, 247, 257, 268, 277, 293, 297,
                    316, 324, 333, 344, 348
                },
                (
                    new Vector3(0, -0.53f, 0),
                    new Vector3(90, 180, 0)
                )
            },
            {
                new[]
                {
                    300,
                },
                (
                    new Vector3(0, -0.4f, 1.69f),
                    new Vector3(90, 180, 0)
                )
            },
            {
                new[]
                {
                    295,
                },
                (
                    new Vector3(0, -0.53f, 0),
                    new Vector3(90, 180, 180)
                )
            },
        };

        private Dictionary<int[], (Vector3, Vector3)> _knifeTransform = new()
        {
            {
                new[]
                {
                    33, 42, 50, 59, 68
                },
                (
                    new Vector3(0, -0.27f, -2.51f),
                    new Vector3(0, 180, 0)
                )
            },
            {
                new[]
                {
                    80
                },
                (
                    new Vector3(0, -0.2f, -1.69f),
                    new Vector3(0, 0, 90)
                )
            },
            {
                new[]
                {
                    90
                },
                (
                    new Vector3(0, -0.12f, -2.88f),
                    new Vector3(-90, 90, 0)
                )
            },
            {
                new[]
                {
                    187
                },
                (
                    new Vector3(0, -0.25f, -2.1f),
                    new Vector3(0, 0, 90)
                )
            },
            {
                new[]
                {
                    286
                },
                (
                    new Vector3(0, -0.27f, -0.94f),
                    new Vector3(180, 0, 0)
                )
            },
            {
                new[]
                {
                    123, 131, 138, 168, 179, 222, 239, 248, 317, 325
                },
                (
                    new Vector3(0, -0.24f, -1.16f),
                    new Vector3(-90, 0, 0)
                )
            },
        };

        private Dictionary<int[], (Vector3, Vector3)> _bowTransform = new()
        {
            {
                new[]
                {
                    2, 5, 7, 8, 11, 13, 18, 19, 20, 21, 34, 43, 51, 60, 69, 106,
                    107, 108, 109, 110, 111, 154, 159, 160, 203, 211, 212, 213,
                    214, 215, 216, 307, 308, 309,
                },
                (
                    new Vector3(0, 0, -1.22f),
                    new Vector3(180, 180, 0)
                )
            },
            {
                new[]
                {
                    81
                },
                (
                    new Vector3(0, 0, -0.7f),
                    new Vector3(0, 180, 0)
                )
            },
            {
                new[]
                {
                    287
                },
                (
                    new Vector3(0, 0, 0),
                    new Vector3(0, 0, 180)
                )
            },
            {
                new[]
                {
                    119, 124, 132, 143, 169, 180, 223, 232, 240, 249, 258, 269, 278,
                    294, 312, 318, 326, 334, 345,
                },
                (
                    new Vector3(0, 0, -1.25f),
                    new Vector3(90, 0, 180)
                )
            },
            {
                new[]
                {
                    345,
                },
                (
                    new Vector3(0, 0, -0.44f),
                    new Vector3(90, 0, 180)
                )
            },
            {
                new[]
                {
                    258,
                },
                (
                    new Vector3(0, -0.15f, -1.25f),
                    new Vector3(90, 0, 180)
                )
            },
        };

        private Dictionary<int[], (Vector3, Vector3)> _shieldTransform = new()
        {
            {
                new[]
                {
                    35, 44, 52, 61, 70,
                },
                (
                    new Vector3(0, 0, 0),
                    new Vector3(0, 180, 180)
                )
            },
            {
                new[]
                {
                    82
                },
                (
                    new Vector3(0, 0, -1.45f),
                    new Vector3(0, 180, 0)
                )
            },
            {
                new[]
                {
                    91
                },
                (
                    new Vector3(0, 0.15f, -0.77f),
                    new Vector3(0, 90, 0)
                )
            },
            {
                new[]
                {
                    96, 117, 125, 133, 141, 144, 147, 150, 170, 176, 181, 191, 195, 197,
                    199, 202, 224, 241, 250, 270, 279, 296, 298, 301, 319, 327,
                },
                (
                    new Vector3(0, 0f, -1.75f),
                    new Vector3(90, 180, 0)
                )
            },
            {
                new[]
                {
                    170,
                },
                (
                    new Vector3(0, -0.24f, -1.75f),
                    new Vector3(90, 180, 0)
                )
            },
            {
                new[]
                {
                    259
                },
                (
                    new Vector3(0, 0.15f, -1.75f),
                    new Vector3(90, 180, 0)
                )
            },
            {
                new[]
                {
                    335, 349
                },
                (
                    new Vector3(0, -0.12f, -1.75f),
                    new Vector3(90, 180, 0)
                )
            },
            {
                new[]
                {
                    188
                },
                (
                    new Vector3(0, 0f, -0.97f),
                    new Vector3(0, 180, 0)
                )
            },
            {
                new[]
                {
                    284
                },
                (
                    new Vector3(0, 0f, -1.48f),
                    new Vector3(0, 0, 0)
                )
            },
            {
                new[]
                {
                    288
                },
                (
                    new Vector3(0, 0.22f, -0.84f),
                    new Vector3(180, 0, -90)
                )
            },
        };

        private Dictionary<int[], (Vector3, Vector3)> _axeTransform = new()
        {
            {
                new[]
                {
                    36, 45, 53, 62, 71,
                },
                (
                    new Vector3(0, -0.52f, 0),
                    new Vector3(180, 0, 0)
                )
            },
            {
                new[]
                {
                    71,
                },
                (
                    new Vector3(0, -0.25f, 0),
                    new Vector3(180, 0, 0)
                )
            },
            {
                new[]
                {
                    83
                },
                (
                    new Vector3(0, -0.42f, -1.06f),
                    new Vector3(0, 0, 90)
                )
            },
            {
                new[]
                {
                    92
                },
                (
                    new Vector3(0, -0.4f, -1.16f),
                    new Vector3(90, 90, 0)
                )
            },
            {
                new[]
                {
                    126, 136, 151, 225, 233, 251, 260, 271, 346
                },
                (
                    new Vector3(0, -0.29f, 1.67f),
                    new Vector3(90, 180, 0)
                )
            },
            {
                new[]
                {
                    171, 182, 242, 320, 328
                },
                (
                    new Vector3(0, -0.72f, 1.67f),
                    new Vector3(90, 180, 0)
                )
            },
            {
                new[]
                {
                    336, 313
                },
                (
                    new Vector3(0, -0.5f, 1.67f),
                    new Vector3(90, 180, 0)
                )
            },
        };

        private Dictionary<int[], (Vector3, Vector3)> _staffTransform = new()
        {
            {
                new[]
                {
                    37, 54, 63, 72
                },
                (
                    new Vector3(0, -0.25f, 0.66f),
                    new Vector3(180, 0, 0)
                )
            },
            {
                new[]
                {
                    46,
                },
                (
                    new Vector3(0, -0.04f, 0.66f),
                    new Vector3(180, 0, 0)
                )
            },
            {
                new[]
                {
                    84
                },
                (
                    new Vector3(0, 0.28f, 0),
                    new Vector3(0, 180, 0)
                )
            },
            {
                new[]
                {
                    127, 153, 172, 183, 226, 243, 252, 261, 272, 280, 314, 321, 329, 337,
                    347, 350, 351, 145, 234
                },
                (
                    new Vector3(0, -0.38f, 1.18f),
                    new Vector3(90, 0, 0)
                )
            },
            {
                new[]
                {
                    243, 347,
                },
                (
                    new Vector3(0, -0.11f, 1.18f),
                    new Vector3(90, 0, 0)
                )
            },
            {
                new[]
                {
                    289
                },
                (
                    new Vector3(0, 0, 2.02f),
                    new Vector3(180, 0, 0)
                )
            },
        };

        private Dictionary<int[], (Vector3, Vector3)> _bigSwordTransform = new()
        {
            {
                new[]
                {
                    24,
                },
                (
                    new Vector3(0, -1.27f, 3.44f),
                    new Vector3(180, 0, 0)
                )
            },
            {
                new[]
                {
                    38, 47, 55, 64, 73,
                },
                (
                    new Vector3(0, -0.84f, 1.08f),
                    new Vector3(180, 0, 0)
                )
            },
            {
                new[]
                {
                    75, 94, 97, 98, 99, 128, 135, 173, 184, 189, 192, 200, 227, 235, 244, 253,
                    262, 273, 281, 283, 299, 311, 322, 330, 338,
                },
                (
                    new Vector3(0, -1.07f, 2.29f),
                    new Vector3(90, 180, 0)
                )
            },
            {
                new[]
                {
                    330,
                },
                (
                    new Vector3(0, -0.75f, 2.29f),
                    new Vector3(90, 180, 0)
                )
            },
            {
                new[]
                {
                    85
                },
                (
                    new Vector3(0, -1.02f, 2.35f),
                    new Vector3(0, 0, 90)
                )
            },
            {
                new[]
                {
                    164,
                },
                (
                    new Vector3(0, -0.32f, 2.53f),
                    new Vector3(180, 0, 0)
                )
            },
            {
                new[]
                {
                    93
                },
                (
                    new Vector3(0, -0.93f, 1.5f),
                    new Vector3(90, 90, 0)
                )
            },
            {
                new[]
                {
                    290
                },
                (
                    new Vector3(0, -0.94f, 3.33f),
                    new Vector3(180, 0, 0)
                )
            },
        };

        private Dictionary<int[], (Vector3, Vector3)> _crowTransform = new()
        {
            {
                new[]
                {
                    263, 274
                },
                (
                    new Vector3(0, -0.08f, -2.33f),
                    new Vector3(0, 0, -90)
                )
            },
            {
                new[]
                {
                    339
                },
                (
                    new Vector3(0, -0.08f, -2.33f),
                    new Vector3(0, 180, -90)
                )
            },
        };

        private Dictionary<int[], (Vector3, Vector3)> _katanaTransform = new()
        {
            {
                new[]
                {
                    76, 129, 174, 185, 228, 245, 254, 264, 275, 331, 340
                },
                (
                    new Vector3(0, -0.75f, 0),
                    new Vector3(90, 180, 0)
                )
            },
        };

        private Dictionary<int[], (Vector3, Vector3)> _scytheTransform = new()
        {
            {
                new[]
                {
                    77, 118, 134, 137, 229, 236, 255, 265, 276, 282, 341,
                },
                (
                    new Vector3(0, 0, 1.08f),
                    new Vector3(-90, 0, 0)
                )
            },
            {
                new[]
                {
                    86
                },
                (
                    new Vector3(0, -0.34f, 0),
                    new Vector3(0, 180, 90)
                )
            },
            {
                new[]
                {
                    291
                },
                (
                    new Vector3(0, -0.83f, 2.22f),
                    new Vector3(180, -90, 0)
                )
            },
            {
                new[]
                {
                    139
                },
                (
                    new Vector3(0, -0.82f, 1.08f),
                    new Vector3(-90, -90, 0)
                )
            },
        };

        private Dictionary<int[], (Vector3, Vector3)> _lanceTransform = new()
        {
            {
                new[]
                {
                    120, 266,
                },
                (
                    new Vector3(0, -0.61f, 0),
                    new Vector3(90, 0, 0)
                )
            },
            {
                new[]
                {
                    342
                },

                (
                    new Vector3(0, -0.85f, 0),
                    new Vector3(90, 0, 0)
                )
            },
        };

        #endregion

        private GameObject _weaponObject;
        public Button _EquipButton => equipButton;
        public Button _SellButton => sellButton;
        public Button _NormalSkillDetailButton => normalSkillGridView._DetailButton;

        public IObservable<Unit> OnClickNormalSkillDetailButtonAsObservable()
        {
            return normalSkillGridView.OnClickDetailButtonAsObservable();
        }

        public void ApplyViewModel(ViewModel viewModel)
        {
            weaponName.text = viewModel._Name;
            var normalSkillViewModel = TranslateSkillMasterDataToViewModel(viewModel._NormalSkillMasterData);
            normalSkillGridView.ApplyViewModel(normalSkillViewModel);
            InstantiateWeapon(viewModel._WeaponType, viewModel._Scale, viewModel._WeaponObject, viewModel._WeaponId).Forget();
            ApplyRareView(viewModel._Rare);
            ApplyWeaponStatusText(viewModel._StatusSkillMasterDatum);
            SetStatusText(SpecialStatusType.Coin, _coinStatusText, viewModel._CoinMul);
            SetStatusText(SpecialStatusType.Gem, _gemStatusText, viewModel._GemMul);
            SetStatusText(SpecialStatusType.Skill, _skillStatusText, viewModel._SkillMul);
            SetStatusText(SpecialStatusType.Range, _rangeStatusText, viewModel._RangeMul);
            _sellPriceText.text = GameCommonData.GetWeaponSellPrice(viewModel._Rare).ToString();
        }

        private void ApplyWeaponStatusText(SkillMasterData[] statusSkillMasterDatum)
        {
            var length = statusSkillMasterDatum.Length;
            _weaponStatusText.gameObject.SetActive(true);
            _weaponStatus2Text.gameObject.SetActive(true);
            switch (length)
            {
                case 0:
                    _weaponStatusText.text = string.Empty;
                    _weaponStatus2Text.text = string.Empty;
                    _weaponStatusText.gameObject.SetActive(false);
                    _weaponStatus2Text.gameObject.SetActive(false);
                    return;
                case 1:
                {
                    var skillMasterData = statusSkillMasterDatum[0];
                    var result = SkillMasterDataRepository.GetStatusSkillValue(skillMasterData);
                    _weaponStatusText.text = TranslateWeaponStatusText(result.Item1, result.Item2);
                    _weaponStatus2Text.text = string.Empty;
                    _weaponStatus2Text.gameObject.SetActive(false);
                    break;
                }
                case 2:
                {
                    var skillMasterData = statusSkillMasterDatum[0];
                    var skillMasterData2 = statusSkillMasterDatum[1];
                    var result = SkillMasterDataRepository.GetStatusSkillValue(skillMasterData);
                    var result2 = SkillMasterDataRepository.GetStatusSkillValue(skillMasterData2);
                    _weaponStatusText.text = TranslateWeaponStatusText(result.Item1, result.Item2);
                    _weaponStatus2Text.text = TranslateWeaponStatusText(result2.Item1, result2.Item2);
                    break;
                }
            }
        }

        private void SetStatusText(SpecialStatusType specialStatusType, TextMeshProUGUI text, float value)
        {
            if (Mathf.Approximately(value, GameCommonData.InvalidNumber))
            {
                text.text = string.Empty;
                text.gameObject.SetActive(false);
                return;
            }

            text.gameObject.SetActive(true);
            text.text = specialStatusType switch
            {
                SpecialStatusType.Coin => "コイン報酬" + value.ToString(CultureInfo.InvariantCulture) + "倍",
                SpecialStatusType.Gem => "ジェム報酬" + value.ToString(CultureInfo.InvariantCulture) + "倍",
                SpecialStatusType.Skill => "インターバル" + value.ToString(CultureInfo.InvariantCulture) + "倍",
                SpecialStatusType.Range => "効果範囲" + value.ToString(CultureInfo.InvariantCulture) + "倍",
                _ => throw new ArgumentOutOfRangeException(nameof(specialStatusType), specialStatusType, null)
            };
        }

        private static string TranslateWeaponStatusText(StatusType statusType, float value)
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

        private async UniTaskVoid InstantiateWeapon(WeaponType weaponType, float scale, GameObject weaponObject, int weaponId)
        {
            Destroy(_weaponObject);
            _weaponObject = Instantiate(weaponObject, weaponObjectParent);
            var psUpdater = _weaponObject.GetComponentInChildren<PSMeshRendererUpdater>();
            if (psUpdater != null)
            {
                psUpdater.UpdateMeshEffect(_weaponObject);
                await UniTask.DelayFrame(2);
                psUpdater.IsActive = false;
            }

            var weaponEffect = _weaponObject.GetComponent<WeaponMeshEffect>();
            if (weaponEffect != null)
            {
                weaponEffect.Stop();
            }

            FixedWeaponTransform(weaponType, weaponId, scale);
        }

        private void FixedWeaponTransform(WeaponType weaponType, int weaponId, float scale)
        {
            _weaponObject.transform.localScale *= scale;
            _weaponObject.transform.localEulerAngles = Vector3.zero;
            _weaponObject.transform.localPosition = Vector3.zero;
            switch (weaponType)
            {
                case WeaponType.Spear:
                {
                    foreach (var keyValueTuple in _spearTransform)
                    {
                        foreach (var spearId in keyValueTuple.Key)
                        {
                            if (weaponId != spearId) continue;
                            _weaponObject.transform.localPosition = keyValueTuple.Value.Item1;
                            _weaponObject.transform.localEulerAngles = keyValueTuple.Value.Item2;
                        }
                    }

                    break;
                }
                case WeaponType.Hammer:
                {
                    foreach (var keyValueTuple in _hammerTransform)
                    {
                        foreach (var hammerId in keyValueTuple.Key)
                        {
                            if (weaponId != hammerId) continue;
                            _weaponObject.transform.localPosition = keyValueTuple.Value.Item1;
                            _weaponObject.transform.localEulerAngles = keyValueTuple.Value.Item2;
                        }
                    }

                    break;
                }
                case WeaponType.Sword:
                {
                    foreach (var keyValueTuple in _swordTransform)
                    {
                        foreach (var swordId in keyValueTuple.Key)
                        {
                            if (weaponId != swordId) continue;
                            _weaponObject.transform.localPosition = keyValueTuple.Value.Item1;
                            _weaponObject.transform.localEulerAngles = keyValueTuple.Value.Item2;
                        }
                    }

                    break;
                }
                case WeaponType.Knife:
                {
                    foreach (var keyValueTuple in _knifeTransform)
                    {
                        foreach (var knifeId in keyValueTuple.Key)
                        {
                            if (weaponId != knifeId) continue;
                            _weaponObject.transform.localPosition = keyValueTuple.Value.Item1;
                            _weaponObject.transform.localEulerAngles = keyValueTuple.Value.Item2;
                        }
                    }

                    break;
                }
                case WeaponType.Bow:
                {
                    foreach (var keyValueTuple in _bowTransform)
                    {
                        foreach (var bowId in keyValueTuple.Key)
                        {
                            if (weaponId != bowId) continue;
                            _weaponObject.transform.localPosition = keyValueTuple.Value.Item1;
                            _weaponObject.transform.localEulerAngles = keyValueTuple.Value.Item2;
                        }
                    }

                    break;
                }
                case WeaponType.Shield:
                {
                    foreach (var keyValueTuple in _shieldTransform)
                    {
                        foreach (var shieldId in keyValueTuple.Key)
                        {
                            if (weaponId != shieldId) continue;
                            _weaponObject.transform.localPosition = keyValueTuple.Value.Item1;
                            _weaponObject.transform.localEulerAngles = keyValueTuple.Value.Item2;
                        }
                    }

                    break;
                }
                case WeaponType.Axe:
                {
                    foreach (var keyValueTuple in _axeTransform)
                    {
                        foreach (var axeId in keyValueTuple.Key)
                        {
                            if (weaponId != axeId) continue;
                            _weaponObject.transform.localPosition = keyValueTuple.Value.Item1;
                            _weaponObject.transform.localEulerAngles = keyValueTuple.Value.Item2;
                        }
                    }

                    break;
                }
                case WeaponType.Staff:
                {
                    foreach (var keyValueTuple in _staffTransform)
                    {
                        foreach (var staffId in keyValueTuple.Key)
                        {
                            if (weaponId != staffId) continue;
                            _weaponObject.transform.localPosition = keyValueTuple.Value.Item1;
                            _weaponObject.transform.localEulerAngles = keyValueTuple.Value.Item2;
                        }
                    }

                    break;
                }
                case WeaponType.BigSword:
                {
                    foreach (var keyValueTuple in _bigSwordTransform)
                    {
                        foreach (var bigSwordId in keyValueTuple.Key)
                        {
                            if (weaponId != bigSwordId) continue;
                            _weaponObject.transform.localPosition = keyValueTuple.Value.Item1;
                            _weaponObject.transform.localEulerAngles = keyValueTuple.Value.Item2;
                        }
                    }

                    break;
                }
                case WeaponType.Crow:
                {
                    foreach (var keyValueTuple in _crowTransform)
                    {
                        foreach (var crowId in keyValueTuple.Key)
                        {
                            if (weaponId != crowId) continue;
                            _weaponObject.transform.localPosition = keyValueTuple.Value.Item1;
                            _weaponObject.transform.localEulerAngles = keyValueTuple.Value.Item2;
                        }
                    }

                    break;
                }
                case WeaponType.Katana:
                {
                    foreach (var keyValueTuple in _katanaTransform)
                    {
                        foreach (var katanaId in keyValueTuple.Key)
                        {
                            if (weaponId != katanaId) continue;
                            _weaponObject.transform.localPosition = keyValueTuple.Value.Item1;
                            _weaponObject.transform.localEulerAngles = keyValueTuple.Value.Item2;
                        }
                    }

                    break;
                }
                case WeaponType.Scythe:
                {
                    foreach (var keyValueTuple in _scytheTransform)
                    {
                        foreach (var scytheId in keyValueTuple.Key)
                        {
                            if (weaponId != scytheId) continue;
                            _weaponObject.transform.localPosition = keyValueTuple.Value.Item1;
                            _weaponObject.transform.localEulerAngles = keyValueTuple.Value.Item2;
                        }
                    }

                    break;
                }
                case WeaponType.Lance:
                {
                    foreach (var keyValueTuple in _lanceTransform)
                    {
                        foreach (var lanceId in keyValueTuple.Key)
                        {
                            if (weaponId != lanceId) continue;
                            _weaponObject.transform.localPosition = keyValueTuple.Value.Item1;
                            _weaponObject.transform.localEulerAngles = keyValueTuple.Value.Item2;
                        }
                    }

                    break;
                }
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
            public SkillMasterData[] _StatusSkillMasterDatum { get; }
            public GameObject _WeaponObject { get; }
            public WeaponType _WeaponType { get; }
            public float _Scale { get; }
            public int _Rare { get; }
            public float _CoinMul { get; }
            public float _GemMul { get; }
            public float _SkillMul { get; }
            public float _RangeMul { get; }
            public int _WeaponId { get; }

            public ViewModel
            (
                Sprite icon,
                string name,
                SkillMasterData normalSkillMasterData,
                SkillMasterData[] statusSkillMasterDatum,
                GameObject weaponObject,
                WeaponType weaponType,
                float scale,
                int rare,
                float coinMul,
                float gemMul,
                float skillMul,
                float rangeMul,
                int weaponId
            )
            {
                _Icon = icon;
                _Name = name;
                _NormalSkillMasterData = normalSkillMasterData;
                _StatusSkillMasterDatum = statusSkillMasterDatum;
                _WeaponObject = weaponObject;
                _WeaponType = weaponType;
                _Scale = scale;
                _Rare = rare;
                _CoinMul = coinMul;
                _GemMul = gemMul;
                _SkillMul = skillMul;
                _RangeMul = rangeMul;
                _WeaponId = weaponId;
            }
        }
    }
}