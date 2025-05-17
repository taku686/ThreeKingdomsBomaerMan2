using System;
using System.Collections.Generic;
using System.Globalization;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.DataManager;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using TMPro;
using UniRx;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class WeaponDetailView : SerializedMonoBehaviour
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

        #region 武器の回転方向

        [Header("武器の回転方向"), Space(10)] [OdinSerialize, DictionaryDrawerSettings(KeyLabel = "WeaponId", ValueLabel = "RotateDirection")]
        private Dictionary<int, RotateDirection> _weaponIdRotateDirection = new();

        #endregion

        #region 武器の位置調整

        private Dictionary<int[], (TransformEnum, Vector3)[]> _spearWeaponIdTransform = new()
        {
            {
                new[] { 159 },
                new[] { (TransformEnum.Rotation, new Vector3(0, 0, 0)), (TransformEnum.Position, new Vector3(0, -0.55f, -0.51f)) }
            },
            {
                new[] { 116, 11 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.2f, 0)) }
            },
            {
                new[] { 125, 8, 13, 31, 9, 17, 33 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.45f, 0)) }
            },
            {
                new[] { 14 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.55f, 0)) }
            },
            {
                new[] { 18 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.27f, 0)) }
            },
        };

        private Dictionary<int[], (TransformEnum, Vector3)[]> _hammerWeaponIdTransform = new()
        {
            {
                new[] { 241 },
                new[] { (TransformEnum.Rotation, new Vector3(0, 0, -90)) }
            },
            {
                new[] { 177 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.76f, 0.33f)) }
            },
            {
                new[] { 150 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.76f, 0)), (TransformEnum.Rotation, new Vector3(0, 0, 90)) }
            },
            {
                new[] { 127 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.28f, 0.37f)) }
            },
            {
                new[] { 139 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.63f, 0.37f)) }
            },
        };

        private Dictionary<int[], (TransformEnum, Vector3)[]> _swordWeaponIdTransform = new()
        {
            {
                new[] { 232 },
                new[] { (TransformEnum.Rotation, new Vector3(0, 0, 90)) }
            },
            {
                new[] { 313 },
                new[] { (TransformEnum.Rotation, new Vector3(0, 0, 180)) }
            },
            {
                new[] { 152 },
                new[] { (TransformEnum.Rotation, new Vector3(0, 0, 90)) }
            },
            {
                new[] { 275, 391 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.68f, -0.3f)) }
            },
            {
                new[] { 328 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.6f, 0.35f)) }
            },
            {
                new[] { 105, 131, 24 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.87f, 0)) }
            },
            {
                new[] { 159 },
                new[] { (TransformEnum.Rotation, new Vector3(0, 0, 0)), (TransformEnum.Position, new Vector3(0, -0.55f, -0.51f)) }
            },
            {
                new[] { 319 },
                new[] { (TransformEnum.Rotation, new Vector3(0, 0, 0)), (TransformEnum.Position, new Vector3(0, -0.6f, -0.38f)) }
            },
        };

        private Dictionary<int[], (TransformEnum, Vector3)[]> _knifeWeaponIdTransform = new()
        {
            {
                new[] { 154 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.16f, -1.05f)), (TransformEnum.Rotation, new Vector3(0, 0, 90)) }
            },
            {
                new[] { 164 },
                new[] { (TransformEnum.Rotation, new Vector3(-90, 0, 90)) }
            },
            {
                new[] { 234 },
                new[] { (TransformEnum.Rotation, new Vector3(0, 0, 90)) }
            },
            {
                new[] { 277, 338, 346 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.32f, -0.89f)) }
            },
            {
                new[] { 314 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.32f, -0.89f)), (TransformEnum.Rotation, new Vector3(0, 0, 180)) }
            }
        };

        private Dictionary<int[], (TransformEnum, Vector3)[]> _fanWeaponIdTransform = new();

        private Dictionary<int[], (TransformEnum, Vector3)[]> _bowWeaponIdTransform = new()
        {
            {
                new[] { 122, 135, 158, 4 },
                new[] { (TransformEnum.Position, new Vector3(0, 0, 0.4f)) }
            },
            {
                new[] { 318 },
                new[] { (TransformEnum.Position, new Vector3(0, 0, 0.81f)), (TransformEnum.Rotation, new Vector3(0, 0, 0)) }
            }
        };

        private Dictionary<int[], (TransformEnum, Vector3)[]> _shieldWeaponIdTransform = new()
        {
            {
                new[] { 155, 311 },
                new[] { (TransformEnum.Rotation, new Vector3(0, 0, 0)) }
            },
            {
                new[] { 236 },
                new[] { (TransformEnum.Rotation, new Vector3(0, 180, 0)) }
            },
            {
                new[] { 316 },
                new[] { (TransformEnum.Rotation, new Vector3(180, 0, -90)), (TransformEnum.Position, new Vector3(0, 0.15f, -0.47f)) }
            },
        };

        private Dictionary<int[], (TransformEnum, Vector3)[]> _axeWeaponIdTransform = new()
        {
            {
                new[] { 121 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.6f, 0)) }
            },
            {
                new[] { 134 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.28f, 0)) }
            },
            {
                new[] { 188, 201, 245, 252, 276, 286, 296, 361 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.45f, 0.77f)) }
            },
            {
                new[] { 153 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.28f, 0)), (TransformEnum.Rotation, new Vector3(0, 0, 90)) }
            },
            {
                new[] { 163 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.28f, 0)), (TransformEnum.Rotation, new Vector3(90, 0, 90)) }
            },
        };

        private Dictionary<int[], (TransformEnum, Vector3)[]> _staffWeaponIdTransform = new()
        {
            {
                new[] { 156 },
                new[] { (TransformEnum.Position, new Vector3(0, 0.39f, 0)), (TransformEnum.Rotation, new Vector3(0, 180, 0)) }
            },
            {
                new[] { 278, 288, 298, 387, 333 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.28f, 0.77f)) }
            },
            {
                new[] { 315 },
                new[] { (TransformEnum.Rotation, new Vector3(180, 0, 0)) }
            },
        };

        private Dictionary<int[], (TransformEnum, Vector3)[]> _bigSwordWeaponIdTransform = new()
        {
            {
                new[] { 72 },
                new[] { (TransformEnum.Position, new Vector3(0, -1.26f, 1.36f)), (TransformEnum.Rotation, new Vector3(180, 0, 0)) }
            },
            {
                new[] { 151 },
                new[] { (TransformEnum.Position, new Vector3(0, -1.02f, 0.8f)), (TransformEnum.Rotation, new Vector3(0, 180, 90)) }
            },
            {
                new[] { 146 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.44f, 1.19f)), (TransformEnum.Rotation, new Vector3(0, 0, 0)) }
            },
            {
                new[] { 312 },
                new[] { (TransformEnum.Position, new Vector3(0, -1.07f, 0.98f)), (TransformEnum.Rotation, new Vector3(180, 0, 0)) }
            },
            {
                new[] { 284, 294, 303, 308, 343, 351 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.87f, 1.61f)) }
            },
        };

        private Dictionary<int[], (TransformEnum, Vector3)[]> _crowWeaponIdTransform = new()
        {
            {
                new[] { 290, 300 },
                new[] { (TransformEnum.Position, new Vector3(0, 0, -0.9f)), (TransformEnum.Rotation, new Vector3(0, 0, -90)) }
            },
            {
                new[] { 357 },
                new[] { (TransformEnum.Position, new Vector3(0, 0, -0.9f)), (TransformEnum.Rotation, new Vector3(0, 180, -90)) }
            },
        };

        private Dictionary<int[], (TransformEnum, Vector3)[]> _katanaWeaponIdTransform = new();

        private Dictionary<int[], (TransformEnum, Vector3)[]> _scytheWeaponIdTransform = new()
        {
            {
                new[] { 149 },
                new[] { (TransformEnum.Position, new Vector3(0, 0, 0.44f)), (TransformEnum.Rotation, new Vector3(90, 0, 0)) }
            },
            {
                new[] { 157 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.44f, 0)), (TransformEnum.Rotation, new Vector3(0, 180, 90)) }
            },
            {
                new[] { 204 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.97f, 0.44f)), (TransformEnum.Rotation, new Vector3(-90, 0, -90)) }
            },
            {
                new[] { 317 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.99f, 0.75f)), (TransformEnum.Rotation, new Vector3(180, -90, 0)) }
            },
        };

        private Dictionary<int[], (TransformEnum, Vector3)[]> _lanceWeaponIdTransform = new()
        {
            {
                new[] { 378 },
                new[] { (TransformEnum.Position, new Vector3(0, -0.81f, 0.29f)) }
            },
        };

        #endregion


        private GameObject _weaponObject;
        private const float RotateSpeed = 0.3f;
        public Button _EquipButton => equipButton;
        public Button _SellButton => sellButton;
        public Button _NormalSkillDetailButton => normalSkillGridView._DetailButton;
        public Button _SpecialSkillDetailButton => specialSkillGridView._DetailButton;

        private enum RotateDirection
        {
            Up,
            Right,
            Forward
        }

        private enum TransformEnum
        {
            Position,
            Rotation,
            Scale
        }

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
            InstantiateWeapon(viewModel._WeaponType, viewModel._Scale, viewModel._WeaponObject, viewModel._WeaponId).Forget();
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

        private void RotateWeapon(ViewModel viewModel)
        {
            foreach (var (weaponId, direction) in _weaponIdRotateDirection)
            {
                if (viewModel._WeaponId != weaponId) continue;
                _weaponObject.transform.Rotate(TranslateRotateDirectionToVector3(direction), RotateSpeed);
                return;
            }

            _weaponObject.transform.Rotate(viewModel._WeaponId >= 146 ? Vector3.forward : Vector3.up, RotateSpeed);
        }

        private static Vector3 TranslateRotateDirectionToVector3(RotateDirection rotateDirection)
        {
            return rotateDirection switch
            {
                RotateDirection.Up => Vector3.up,
                RotateDirection.Right => Vector3.right,
                RotateDirection.Forward => Vector3.forward,
                _ => throw new ArgumentOutOfRangeException(nameof(rotateDirection), rotateDirection, null)
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

            FixedWeaponTransform(weaponType, weaponId, scale);
        }

        private void FixedWeaponTransform(WeaponType weaponType, int weaponId, float scale)
        {
            switch (weaponType)
            {
                case WeaponType.Spear:
                    _weaponObject.transform.localScale *= scale;
                    if (weaponId >= 146)
                    {
                        _weaponObject.transform.localEulerAngles = new Vector3(90, 0, 0);
                        _weaponObject.transform.localPosition = new Vector3(0, -0.35f, 0.43f);
                    }
                    else
                    {
                        _weaponObject.transform.localEulerAngles = new Vector3(180, 0, 0);
                        _weaponObject.transform.localPosition = new Vector3(0, -0.35f, 0);
                    }

                    if (_spearWeaponIdTransform == null)
                    {
                        return;
                    }

                    foreach (var (weaponIds, valueTuples) in _spearWeaponIdTransform)
                    {
                        foreach (var spearId in weaponIds)
                        {
                            if (weaponId != spearId) continue;
                            foreach (var transformEnum in valueTuples)
                            {
                                switch (transformEnum.Item1)
                                {
                                    case TransformEnum.Rotation:
                                        _weaponObject.transform.localEulerAngles = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Position:
                                        _weaponObject.transform.localPosition = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Scale:
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }
                        }
                    }

                    break;
                case WeaponType.Hammer:
                    if (weaponId >= 146)
                    {
                        _weaponObject.transform.localPosition = new Vector3(0, -0.63f, 0);
                        _weaponObject.transform.localEulerAngles = new Vector3(90, 0, 0);
                    }
                    else
                    {
                        _weaponObject.transform.localPosition = new Vector3(0, -0.809f, 0.37f);
                    }

                    if (_hammerWeaponIdTransform == null)
                    {
                        return;
                    }

                    foreach (var (weaponIds, valueTuples) in _hammerWeaponIdTransform)
                    {
                        foreach (var hammerId in weaponIds)
                        {
                            if (weaponId != hammerId) continue;
                            foreach (var transformEnum in valueTuples)
                            {
                                switch (transformEnum.Item1)
                                {
                                    case TransformEnum.Rotation:
                                        _weaponObject.transform.localEulerAngles = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Position:
                                        _weaponObject.transform.localPosition = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Scale:
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }
                        }
                    }


                    break;
                case WeaponType.Sword:
                    if (weaponId >= 146)
                    {
                        _weaponObject.transform.localEulerAngles = new Vector3(90, 0, 0);
                        _weaponObject.transform.localPosition = new Vector3(0, -0.6f, -0.3f);
                    }
                    else
                    {
                        _weaponObject.transform.localPosition = new Vector3(0, -0.7f, 0);
                        _weaponObject.transform.localEulerAngles = new Vector3(180, 0, 0);
                        _weaponObject.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f) * scale;
                    }

                    if (_swordWeaponIdTransform == null)
                    {
                        return;
                    }

                    foreach (var (weaponIds, valueTuples) in _swordWeaponIdTransform)
                    {
                        foreach (var swordId in weaponIds)
                        {
                            if (weaponId != swordId) continue;
                            foreach (var transformEnum in valueTuples)
                            {
                                switch (transformEnum.Item1)
                                {
                                    case TransformEnum.Rotation:
                                        _weaponObject.transform.localEulerAngles = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Position:
                                        _weaponObject.transform.localPosition = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Scale:
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }
                        }
                    }


                    break;
                case WeaponType.Knife:
                    _weaponObject.transform.localPosition = new Vector3(0, -0.16f, -1.32f);
                    _weaponObject.transform.localEulerAngles = new Vector3(0, 0, 0);
                    _weaponObject.transform.localScale = Vector3.one;

                    if (weaponId > 166)
                    {
                        _weaponObject.transform.localPosition = new Vector3(0, -0.16f, -0.89f);
                        _weaponObject.transform.localEulerAngles = new Vector3(-90, 0, 0);
                    }

                    if (_knifeWeaponIdTransform == null)
                    {
                        return;
                    }

                    foreach (var (weaponIds, valueTuples) in _knifeWeaponIdTransform)
                    {
                        foreach (var knifeId in weaponIds)
                        {
                            if (weaponId != knifeId) continue;
                            foreach (var transformEnum in valueTuples)
                            {
                                switch (transformEnum.Item1)
                                {
                                    case TransformEnum.Rotation:
                                        _weaponObject.transform.localEulerAngles = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Position:
                                        _weaponObject.transform.localPosition = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Scale:
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }
                        }
                    }


                    break;
                case WeaponType.Bow:
                    _weaponObject.transform.localPosition = new Vector3(0, 0, 0);
                    _weaponObject.transform.localRotation = quaternion.Euler(0, 0, 0);
                    _weaponObject.transform.localScale *= 1.5f;

                    if (weaponId > 166)
                    {
                        _weaponObject.transform.localPosition = new Vector3(0, 0, 0.4f);
                        _weaponObject.transform.localEulerAngles = new Vector3(90, 180, 0);
                    }

                    if (_bowWeaponIdTransform == null)
                    {
                        return;
                    }

                    foreach (var (weaponIds, valueTuples) in _bowWeaponIdTransform)
                    {
                        foreach (var bowId in weaponIds)
                        {
                            if (weaponId != bowId) continue;
                            foreach (var transformEnum in valueTuples)
                            {
                                switch (transformEnum.Item1)
                                {
                                    case TransformEnum.Rotation:
                                        _weaponObject.transform.localEulerAngles = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Position:
                                        _weaponObject.transform.localPosition = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Scale:
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }
                        }
                    }

                    break;
                case WeaponType.Shield:
                    _weaponObject.transform.localEulerAngles = new Vector3(weaponId >= 146 ? 90 : 0, 0, weaponId >= 146 ? 180 : 0);
                    _weaponObject.transform.localPosition = new Vector3(0, -0.08f, -0.47f);
                    _weaponObject.transform.localScale = Vector3.one;

                    if (_shieldWeaponIdTransform == null)
                    {
                        return;
                    }

                    foreach (var (weaponIds, valueTuples) in _shieldWeaponIdTransform)
                    {
                        foreach (var shieldId in weaponIds)
                        {
                            if (weaponId != shieldId) continue;
                            foreach (var transformEnum in valueTuples)
                            {
                                switch (transformEnum.Item1)
                                {
                                    case TransformEnum.Rotation:
                                        _weaponObject.transform.localEulerAngles = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Position:
                                        _weaponObject.transform.localPosition = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Scale:
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }
                        }
                    }

                    break;
                case WeaponType.Axe:
                    _weaponObject.transform.localPosition = new Vector3(0, weaponId >= 146 ? -0.74f : -0.52f, weaponId >= 146 ? 0.77f : 0);
                    _weaponObject.transform.localEulerAngles = new Vector3(weaponId >= 146 ? 90 : 0, 0, 0);
                    _weaponObject.transform.localScale = Vector3.one;

                    if (_axeWeaponIdTransform == null)
                    {
                        return;
                    }

                    foreach (var (weaponIds, valueTuples) in _axeWeaponIdTransform)
                    {
                        foreach (var axeId in weaponIds)
                        {
                            if (weaponId != axeId) continue;
                            foreach (var transformEnum in valueTuples)
                            {
                                switch (transformEnum.Item1)
                                {
                                    case TransformEnum.Rotation:
                                        _weaponObject.transform.localEulerAngles = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Position:
                                        _weaponObject.transform.localPosition = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Scale:
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }
                        }
                    }

                    break;
                case WeaponType.Fan:
                    if (_fanWeaponIdTransform == null)
                    {
                        return;
                    }

                    foreach (var (weaponIds, valueTuples) in _fanWeaponIdTransform)
                    {
                        foreach (var fanId in weaponIds)
                        {
                            if (weaponId != fanId) continue;
                            foreach (var transformEnum in valueTuples)
                            {
                                switch (transformEnum.Item1)
                                {
                                    case TransformEnum.Rotation:
                                        _weaponObject.transform.localEulerAngles = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Position:
                                        _weaponObject.transform.localPosition = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Scale:
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }
                        }
                    }

                    break;
                case WeaponType.Staff:
                    _weaponObject.transform.localPosition = new Vector3(0, weaponId >= 146 ? -0f : -0.14f, weaponId >= 146 ? 0.77f : 0.39f);
                    _weaponObject.transform.localEulerAngles = new Vector3(weaponId >= 146 ? 90 : 0, 0, 0);

                    if (_staffWeaponIdTransform == null)
                    {
                        return;
                    }

                    foreach (var (weaponIds, valueTuples) in _staffWeaponIdTransform)
                    {
                        foreach (var staffId in weaponIds)
                        {
                            if (weaponId != staffId) continue;
                            foreach (var transformEnum in valueTuples)
                            {
                                switch (transformEnum.Item1)
                                {
                                    case TransformEnum.Rotation:
                                        _weaponObject.transform.localEulerAngles = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Position:
                                        _weaponObject.transform.localPosition = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Scale:
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }
                        }
                    }

                    break;
                case WeaponType.BigSword:
                    _weaponObject.transform.localPosition = new Vector3(0, weaponId >= 146 ? -0.87f : -0.82f, weaponId >= 146 ? 0.98f : 0.37f);
                    _weaponObject.transform.localEulerAngles = new Vector3(weaponId >= 146 ? 90 : 0, 0, 0);

                    if (_bigSwordWeaponIdTransform == null)
                    {
                        return;
                    }

                    foreach (var (weaponIds, valueTuples) in _bigSwordWeaponIdTransform)
                    {
                        foreach (var bigSwordId in weaponIds)
                        {
                            if (weaponId != bigSwordId) continue;
                            foreach (var transformEnum in valueTuples)
                            {
                                switch (transformEnum.Item1)
                                {
                                    case TransformEnum.Rotation:
                                        _weaponObject.transform.localEulerAngles = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Position:
                                        _weaponObject.transform.localPosition = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Scale:
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }
                        }
                    }

                    break;
                case WeaponType.Crow:

                    if (_crowWeaponIdTransform == null)
                    {
                        return;
                    }

                    foreach (var (weaponIds, valueTuples) in _crowWeaponIdTransform)
                    {
                        foreach (var crowId in weaponIds)
                        {
                            if (weaponId != crowId) continue;
                            foreach (var transformEnum in valueTuples)
                            {
                                switch (transformEnum.Item1)
                                {
                                    case TransformEnum.Rotation:
                                        _weaponObject.transform.localEulerAngles = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Position:
                                        _weaponObject.transform.localPosition = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Scale:
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }
                        }
                    }

                    break;
                case WeaponType.Katana:
                    _weaponObject.transform.localPosition = new Vector3(0, -1.18f, 1.5f);
                    _weaponObject.transform.localEulerAngles = new Vector3(90, 0, 0);
                    _weaponObject.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f) * scale;

                    if (_katanaWeaponIdTransform == null)
                    {
                        return;
                    }

                    foreach (var (weaponIds, valueTuples) in _katanaWeaponIdTransform)
                    {
                        foreach (var katanaId in weaponIds)
                        {
                            if (weaponId != katanaId) continue;
                            foreach (var transformEnum in valueTuples)
                            {
                                switch (transformEnum.Item1)
                                {
                                    case TransformEnum.Rotation:
                                        _weaponObject.transform.localEulerAngles = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Position:
                                        _weaponObject.transform.localPosition = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Scale:
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }
                        }
                    }

                    break;
                case WeaponType.Scythe:
                    _weaponObject.transform.localPosition = new Vector3(0, 0, 0.44f);
                    _weaponObject.transform.localEulerAngles = new Vector3(-90, 0, 0);
                    if (_scytheWeaponIdTransform == null)
                    {
                        return;
                    }

                    foreach (var (weaponIds, valueTuples) in _scytheWeaponIdTransform)
                    {
                        foreach (var scytheId in weaponIds)
                        {
                            if (weaponId != scytheId) continue;
                            foreach (var transformEnum in valueTuples)
                            {
                                switch (transformEnum.Item1)
                                {
                                    case TransformEnum.Rotation:
                                        _weaponObject.transform.localEulerAngles = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Position:
                                        _weaponObject.transform.localPosition = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Scale:
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }
                        }
                    }

                    break;
                case WeaponType.Lance:
                    _weaponObject.transform.localPosition = new Vector3(0, -0.44f, 0.29f);
                    _weaponObject.transform.localEulerAngles = new Vector3(90, 0, 0);
                    if (_lanceWeaponIdTransform == null)
                    {
                        return;
                    }

                    foreach (var (weaponIds, valueTuples) in _lanceWeaponIdTransform)
                    {
                        foreach (var lanceId in weaponIds)
                        {
                            if (weaponId != lanceId) continue;
                            foreach (var transformEnum in valueTuples)
                            {
                                switch (transformEnum.Item1)
                                {
                                    case TransformEnum.Rotation:
                                        _weaponObject.transform.localEulerAngles = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Position:
                                        _weaponObject.transform.localPosition = transformEnum.Item2;
                                        break;
                                    case TransformEnum.Scale:
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }
                        }
                    }

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