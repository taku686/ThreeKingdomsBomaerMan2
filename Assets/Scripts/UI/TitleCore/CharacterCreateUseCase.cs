using System;
using System.Collections.Generic;
using Common.Data;
using Manager.DataManager;
using Photon.Pun;
using Unity.Mathematics;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Repository
{
    public class CharacterCreateUseCase : IDisposable
    {
        private readonly Transform _characterGenerateTransform;
        private readonly CharacterMasterDataRepository _characterMasterDataRepository;
        private readonly UserDataRepository _userDataRepository;
        private readonly CharacterObjectRepository _characterObjectRepository;
        private readonly AnimatorControllerRepository _animatorControllerRepository;
        private readonly Vector3 _bowPosition = new(-0.029f, 0.02f, -0.001f);
        private readonly Vector3 _knifePosition = new(-0.0332f, 0.0284f, -0.0129f);
        private readonly Vector3 _othersPosition = new(-0.061f, 0.026f, 0.003f);
        private readonly Vector3 _bowRightRotation = new(-87.91f, 204.73f, -24.69f);
        private readonly Vector3 _bowLeftRotation = new(87.91f, -204.73f, -24.69f);
        private readonly Vector3 _knifeLeftRotation = new(53.571f, 294.535f, -253.946f);
        private readonly Vector3 _crowLeftRotation = new(233f, -90.7f, 106f);
        private readonly Vector3 _othersRightRotation = new(-90.574f, -421.51f, -292.623f);
        private readonly Vector3 _othersLeftRotation = new(-36.033f, 92.88f, 84.68f);

        private readonly Dictionary<int[], Vector3> _weaponRotation = new()
        {
            {
                new[]
                {
                    74, 177, 220, 230, 237, 246, 256, 267, 315, 323, 332, 343,
                    95, 90, 96, 117, 125, 133, 141, 144, 147, 150, 170, 176,
                    181, 191, 195, 197, 199, 202, 224, 241, 250, 259, 270, 279,
                    296, 298, 301, 319, 327, 335, 349
                },
                new Vector3(-90, 0, 0)
            },
            {
                new[]
                {
                    121, 166, 116, 122, 130, 140, 142, 146, 149, 152, 165, 167,
                    175, 178, 190, 194, 196, 198, 201, 221, 231, 238, 247, 257,
                    268, 277, 293, 295, 297, 300, 316, 324, 333, 344, 348, 123,
                    131, 138, 168, 179, 222, 239, 248, 317, 325, 126, 136, 151,
                    171, 182, 225, 233, 242, 251, 260, 271, 313, 320, 328, 336,
                    346, 127, 145, 153, 172, 183, 226, 234, 243, 252, 261, 272,
                    280, 314, 321, 329, 337, 347, 350, 351, 75, 94, 97, 98, 99,
                    128, 135, 173, 184, 189, 192, 200, 227, 235, 244, 253, 262,
                    273, 281, 283, 299, 311, 322, 330, 338, 76, 129, 174, 185,
                    228, 245, 254, 264, 275, 331, 340, 120, 266, 342, 148
                },
                new Vector3(-90, 180, 0)
            },
            {
                new[]
                {
                    193, 80, 187
                },
                new Vector3(0, 0, 90)
            },
            {
                new[]
                {
                    286, 284
                },
                new Vector3(0, 0, 180)
            },
            {
                new[]
                {
                    79
                },
                new Vector3(0, 0, -90)
            },
            {
                new[]
                {
                    186
                },
                new Vector3(0, 90, -90)
            },
            {
                new[]
                {
                    288, 83, 85
                },
                new Vector3(0, 180, -90)
            },
            {
                new[]
                {
                    82, 188
                },
                new Vector3(0, 180, 180)
            },
            {
                new[]
                {
                    89
                },
                new Vector3(-90, 0, -90)
            },
            {
                new[]
                {
                    92, 88
                },
                new Vector3(-90, -90, 0)
            },
            {
                new[]
                {
                    87, 91
                },
                new Vector3(180, 90, 0)
            },
            {
                new[]
                {
                    78, 86
                },
                new Vector3(180, 180, 90)
            },
            {
                new[]
                {
                    292, 287, 84, 339
                },
                new Vector3(180, 0, 0)
            },
            {
                new[]
                {
                    119, 124, 132, 143, 169, 180, 223, 232, 240, 249, 258,
                    269, 278, 294, 312, 318, 326, 334, 345, 77, 118, 134,
                    137, 229, 236, 255, 265, 276, 282, 341
                },
                new Vector3(90, 0, 0)
            },
            {
                new[]
                {
                    35, 44, 52, 61, 70
                },
                new Vector3(180, 0, 180)
            },
            {
                new[]
                {
                    93
                },
                new Vector3(-90, 90, 0)
            },
            {
                new[]
                {
                    139
                },
                new Vector3(90, 90, 0)
            },
            {
                new[]
                {
                    291
                },
                new Vector3(0, 90, 0)
            },
        };

        [Inject]
        public CharacterCreateUseCase
        (
            Transform characterGenerateTransform,
            CharacterMasterDataRepository characterMasterDataRepository,
            UserDataRepository userDataRepository,
            CharacterObjectRepository characterObjectRepository,
            AnimatorControllerRepository animatorControllerRepository
        )
        {
            _characterGenerateTransform = characterGenerateTransform;
            _characterMasterDataRepository = characterMasterDataRepository;
            _userDataRepository = userDataRepository;
            _characterObjectRepository = characterObjectRepository;
            _animatorControllerRepository = animatorControllerRepository;
        }

        public void CreateTeam(int characterId, int index = 0, Transform createParent = null)
        {
            var characterObject = _characterObjectRepository.GetCharacterObject(index);
            if (characterObject != null)
            {
                Object.Destroy(characterObject);
            }

            CreateCharacter(characterId, createParent, index);
        }

        public void CreateTeamMember(int characterId, int index = 0, Transform createParent = null)
        {
            var characterObjects = _characterObjectRepository.GetCharacterObjects();
            foreach (var characterObject in characterObjects)
            {
                if (characterObject == null)
                {
                    continue;
                }

                Object.Destroy(characterObject);
            }

            CreateCharacter(characterId, createParent, index);
        }

        private void CreateCharacter(int characterId, Transform createParent = null, int index = 0)
        {
            var createCharacterData = _characterMasterDataRepository.GetCharacterData(characterId);
            var weaponData = _userDataRepository.GetEquippedWeaponData(characterId);

            if (createParent == null)
            {
                createParent = _characterGenerateTransform;
            }

            var characterObject = Object.Instantiate
            (
                createCharacterData.CharacterObject,
                createParent.position,
                createParent.rotation,
                createParent
            );
            _characterObjectRepository.SetCharacterObject(characterObject, index);
            CreateWeapon(characterObject, weaponData);
            ChangeAnimatorController(characterObject, weaponData.WeaponType);
        }

        private void DestroyWeaponObj(GameObject playerObj)
        {
            var weaponObjects = playerObj.GetComponentsInChildren<WeaponObject>();
            foreach (var weaponObject in weaponObjects)
            {
                if (weaponObject.gameObject == null)
                {
                    continue;
                }

                var isPhotonObject = weaponObject.gameObject.GetComponent<PhotonView>() != null;
                if (isPhotonObject)
                {
                    PhotonNetwork.Destroy(weaponObject.gameObject);
                }
                else
                {
                    Object.Destroy(weaponObject.gameObject);
                }
            }
        }

        public void CreateWeapon
        (GameObject playerObj,
            WeaponMasterData weaponMasterData,
            bool isPhotonObject = false,
            bool isCpu = false)
        {
            DestroyWeaponObj(playerObj);

            if (IsLeftHand(weaponMasterData.WeaponType))
            {
                InstantiateWeapon(playerObj, weaponMasterData, isPhotonObject, isCpu);
            }

            if (IsRightHand(weaponMasterData.WeaponType))
            {
                InstantiateWeapon(playerObj, weaponMasterData, isPhotonObject, isCpu);
            }

            if (IsBothHand(weaponMasterData.WeaponType))
            {
                for (var i = 0; i < 2; i++)
                {
                    var isLeftHand = i == 0;
                    InstantiateWeapon(playerObj, weaponMasterData, isPhotonObject, isCpu, isLeftHand);
                }
            }
        }

        private void InstantiateWeapon
        (
            GameObject playerObj,
            WeaponMasterData weaponMasterData,
            bool isPhotonObject = false,
            bool isCpu = false,
            bool isLeftHand = false
        )
        {
            if (isPhotonObject)
            {
                var photonView = playerObj.GetComponent<PhotonView>();
                GameObject weapon;
                var myCustomInitData = new object[] { photonView.InstantiationId, weaponMasterData.Id, isLeftHand };
                if (isCpu)
                {
                    weapon = PhotonNetwork.InstantiateRoomObject
                    (
                        GameCommonData.WeaponPrefabPath + weaponMasterData.Id,
                        Vector3.zero,
                        quaternion.Euler(0, 0, 0),
                        0,
                        myCustomInitData
                    );
                }
                else
                {
                    weapon = PhotonNetwork.Instantiate
                    (
                        GameCommonData.WeaponPrefabPath + weaponMasterData.Id,
                        Vector3.zero,
                        quaternion.Euler(0, 0, 0),
                        0,
                        myCustomInitData
                    );
                }

                FixPhotonWeaponTransform(weapon, weaponMasterData.WeaponType);
            }
            else
            {
                var currentWeapon = Object.Instantiate(weaponMasterData.WeaponObject);
                FixWeaponTransform(playerObj, currentWeapon, weaponMasterData, isLeftHand);
            }
        }

        private static void FixPhotonWeaponTransform
        (
            GameObject weapon,
            WeaponType weaponType
        )
        {
            if (weaponType == WeaponType.Hammer)
            {
            }
        }

        public void FixWeaponTransform
        (
            GameObject characterObject,
            GameObject currentWeapon,
            WeaponMasterData weaponMasterData,
            bool isLeftHand = false
        )
        {
            var weaponRightParent = characterObject.GetComponentInChildren<WeaponRightParentObject>();
            var weaponLeftParent = characterObject.GetComponentInChildren<WeaponLeftParentObject>();
            if (IsLeftHand(weaponMasterData.WeaponType) || (IsBothHand(weaponMasterData.WeaponType) && isLeftHand))
            {
                switch (weaponMasterData.WeaponType)
                {
                    case WeaponType.Bow:
                        weaponLeftParent.transform.localPosition = _bowPosition;
                        weaponLeftParent.transform.localEulerAngles = _bowLeftRotation;
                        break;
                    case WeaponType.Knife:
                        weaponLeftParent.transform.localPosition = _knifePosition;
                        weaponLeftParent.transform.localEulerAngles = _knifeLeftRotation;
                        break;
                    case WeaponType.Crow:
                        weaponLeftParent.transform.localPosition = _othersPosition;
                        weaponLeftParent.transform.localEulerAngles = _crowLeftRotation;
                        break;
                    default:
                        weaponLeftParent.transform.localPosition = _othersPosition;
                        weaponLeftParent.transform.localEulerAngles = _othersLeftRotation;
                        break;
                }

                currentWeapon.transform.SetParent(weaponLeftParent.transform);
            }

            if (IsRightHand(weaponMasterData.WeaponType) || (IsBothHand(weaponMasterData.WeaponType) && !isLeftHand))
            {
                if (WeaponType.Bow == weaponMasterData.WeaponType)
                {
                    weaponRightParent.transform.localPosition = _bowPosition;
                    weaponRightParent.transform.localEulerAngles = _bowRightRotation;
                }
                else
                {
                    weaponRightParent.transform.localPosition = _othersPosition;
                    weaponRightParent.transform.localEulerAngles = _othersRightRotation;
                }

                currentWeapon.transform.SetParent(weaponRightParent.transform);
            }

            currentWeapon.transform.localPosition = Vector3.zero;
            currentWeapon.transform.localEulerAngles = weaponMasterData.Id >= 146 ? new Vector3(-90, 0, 0) : new Vector3(0, 0, 0);
            currentWeapon.transform.localScale = Vector3.one;
            currentWeapon.transform.localScale *= weaponMasterData.Scale;
            FixWeaponAngle(currentWeapon, weaponMasterData, isLeftHand);
            currentWeapon.AddComponent<WeaponObject>();
            SetUpWeaponEffect(currentWeapon);
        }

        private static void SetUpWeaponEffect(GameObject weapon)
        {
            var psUpdater = weapon.GetComponentInChildren<PSMeshRendererUpdater>();
            if (psUpdater != null)
            {
                psUpdater.UpdateMeshEffect(weapon);
            }

            var weaponEffect = weapon.GetComponent<WeaponMeshEffect>();
            if (weaponEffect != null)
            {
                weaponEffect.Initialize();
            }
        }

        private void FixWeaponAngle(GameObject currentWeapon, WeaponMasterData weaponMasterData, bool isLeftHand)
        {
            foreach (var rotationKeyValuePair in _weaponRotation)
            {
                foreach (var weaponId in rotationKeyValuePair.Key)
                {
                    if (weaponId != weaponMasterData.Id)
                    {
                        continue;
                    }

                    currentWeapon.transform.localEulerAngles = rotationKeyValuePair.Value;
                    return;
                }
            }

            currentWeapon.transform.localEulerAngles = Vector3.zero;
        }

        private void ChangeAnimatorController(GameObject characterObject, WeaponType weaponType)
        {
            var animator = characterObject.GetComponent<Animator>();
            if (animator == null)
            {
                return;
            }

            animator.runtimeAnimatorController = _animatorControllerRepository.GetAnimatorController(weaponType);
        }

        private static bool IsRightHand(WeaponType weaponType)
        {
            return weaponType is WeaponType.Spear or WeaponType.Hammer or WeaponType.Sword or WeaponType.Fan or WeaponType.Axe or WeaponType.Staff or WeaponType.BigSword or WeaponType.Katana or WeaponType.Scythe or WeaponType.Lance;
        }

        private static bool IsLeftHand(WeaponType weaponType)
        {
            return weaponType is WeaponType.Bow or WeaponType.Shield;
        }

        private static bool IsBothHand(WeaponType weaponType)
        {
            return weaponType is WeaponType.Knife or WeaponType.Crow;
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}