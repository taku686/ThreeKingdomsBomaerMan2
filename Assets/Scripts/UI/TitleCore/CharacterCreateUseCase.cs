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
        private readonly Vector3 _crowLeftRotation = new(107f, 114f, 106f);
        private readonly Vector3 _othersRightRotation = new(-90.574f, -421.51f, -292.623f);
        private readonly Vector3 _othersLeftRotation = new(-36.033f, 92.88f, 84.68f);

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

        public GameObject[] CreateWeapon
        (
            GameObject playerObj,
            WeaponMasterData weaponMasterData,
            bool isPhotonObject = false,
            bool isCpu = false
        )
        {
            var currentWeapons = new List<GameObject>();
            DestroyWeaponObj(playerObj);

            if (IsLeftHand(weaponMasterData.WeaponType))
            {
                var weaponObj = InstantiateWeapon(playerObj, weaponMasterData, isPhotonObject, isCpu);
                currentWeapons.Add(weaponObj);
            }

            if (IsRightHand(weaponMasterData.WeaponType))
            {
                var weaponObj = InstantiateWeapon(playerObj, weaponMasterData, isPhotonObject, isCpu);
                currentWeapons.Add(weaponObj);
            }

            if (IsBothHand(weaponMasterData.WeaponType))
            {
                for (var i = 0; i < 2; i++)
                {
                    var isLeftHand = i == 0;
                    var weaponObj = InstantiateWeapon(playerObj, weaponMasterData, isPhotonObject, isCpu, isLeftHand);
                    currentWeapons.Add(weaponObj);
                }
            }

            return currentWeapons.ToArray();
        }

        private GameObject InstantiateWeapon
        (
            GameObject playerObj,
            WeaponMasterData weaponMasterData,
            bool isPhotonObject = false,
            bool isCpu = false,
            bool isLeftHand = false
        )
        {
            GameObject currentWeapon;

            if (isPhotonObject)
            {
                var photonView = playerObj.GetComponent<PhotonView>();
                var myCustomInitData = new object[] { photonView.InstantiationId, weaponMasterData.Id, isLeftHand };
                if (isCpu)
                {
                    currentWeapon = PhotonNetwork.InstantiateRoomObject
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
                    currentWeapon = PhotonNetwork.Instantiate
                    (
                        GameCommonData.WeaponPrefabPath + weaponMasterData.Id,
                        Vector3.zero,
                        quaternion.Euler(0, 0, 0),
                        0,
                        myCustomInitData
                    );
                }
            }
            else
            {
                currentWeapon = Object.Instantiate(weaponMasterData.WeaponObject);
                FixWeaponTransform(playerObj, currentWeapon, weaponMasterData, isLeftHand);
            }

            return currentWeapon;
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
            var psUpdater = currentWeapon.GetComponentInChildren<PSMeshRendererUpdater>();
            if (psUpdater == null)
            {
                return;
            }

            psUpdater.UpdateMeshEffect(currentWeapon);
        }

        private static void FixWeaponAngle(GameObject currentWeapon, WeaponMasterData weaponMasterData, bool isLeftHand)
        {
            switch (weaponMasterData.WeaponType)
            {
                case WeaponType.Hammer:
                {
                    currentWeapon.transform.localEulerAngles = weaponMasterData.Id switch
                    {
                        241 => new Vector3(0, 0, 90),
                        150 => new Vector3(180, 180, 90),
                        _ => currentWeapon.transform.localEulerAngles
                    };

                    break;
                }
                case WeaponType.Sword when weaponMasterData.Id >= 146:
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(-90, 0, 180);

                    switch (weaponMasterData.Id)
                    {
                        case 319:
                            currentWeapon.transform.localEulerAngles = new Vector3(0, 180, 180);
                            break;
                        case 152:
                            currentWeapon.transform.localEulerAngles = new Vector3(0, 0, -90);
                            break;
                        case 313:
                            currentWeapon.transform.localEulerAngles = new Vector3(180, 0, 180);
                            break;
                        case 322:
                            currentWeapon.transform.localEulerAngles = new Vector3(-90, 0, 234);
                            break;
                        case 232:
                            currentWeapon.transform.localEulerAngles = new Vector3(0, 90, -90);
                            break;
                    }

                    break;
                }
                case WeaponType.Knife when weaponMasterData.Id >= 146:
                {
                    currentWeapon.transform.localEulerAngles = isLeftHand ? new Vector3(-90, 0, 180) : new Vector3(-90, 0, 0);

                    switch (weaponMasterData.Id)
                    {
                        case 314:
                            currentWeapon.transform.localEulerAngles = new Vector3(180, 0, 0);
                            break;
                        case 154:
                        case 234:
                            currentWeapon.transform.localEulerAngles = new Vector3(0, 0, 90);
                            break;
                    }

                    break;
                }
                case WeaponType.Bow when weaponMasterData.Id >= 146:
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(90, 0, 0);

                    switch (weaponMasterData.Id)
                    {
                        case 318:
                            currentWeapon.transform.localEulerAngles = new Vector3(180, 0, 0);
                            break;
                        case 158:
                            currentWeapon.transform.localEulerAngles = new Vector3(0, 0, 0);
                            break;
                    }

                    break;
                }
                case WeaponType.Shield when weaponMasterData.Id >= 146:
                {
                    currentWeapon.transform.localEulerAngles = weaponMasterData.Id switch
                    {
                        165 => new Vector3(180, 90, 0),
                        236 or 155 => new Vector3(0, 180, 180),
                        311 => new Vector3(0, 0, 180),
                        316 => new Vector3(180, 0, 90),
                        _ => currentWeapon.transform.localEulerAngles
                    };

                    break;
                }
                case WeaponType.Axe when weaponMasterData.Id >= 146:
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(-90, 180, 0);

                    switch (weaponMasterData.Id)
                    {
                        case 163:
                            currentWeapon.transform.localEulerAngles = new Vector3(-90, 90, 0);
                            break;
                        case 153:
                            currentWeapon.transform.localEulerAngles = new Vector3(0, 0, -90);
                            break;
                    }

                    break;
                }
                case WeaponType.Staff when weaponMasterData.Id >= 146:
                {
                    currentWeapon.transform.localEulerAngles = weaponMasterData.Id switch
                    {
                        156 => new Vector3(180, 0, 0),
                        315 => new Vector3(0, 0, 0),
                        _ => currentWeapon.transform.localEulerAngles
                    };

                    break;
                }
                case WeaponType.BigSword when weaponMasterData.Id >= 146:
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(-90, 180, 0);
                    switch (weaponMasterData.Id)
                    {
                        case 146:
                            currentWeapon.transform.localEulerAngles = new Vector3(180, 0, -180);
                            break;
                        case 151:
                            currentWeapon.transform.localEulerAngles = new Vector3(0, 180, -90);
                            break;
                        case 312:
                            currentWeapon.transform.localEulerAngles = new Vector3(0, 0, 0);
                            break;
                    }

                    break;
                }
                case WeaponType.Crow:
                {
                    currentWeapon.transform.localEulerAngles = isLeftHand ? new Vector3(180, 0, 0) : new Vector3(0, 0, 0);
                    if (weaponMasterData.Id == 357)
                    {
                        currentWeapon.transform.localEulerAngles = isLeftHand ? new Vector3(0, 0, 0) : new Vector3(180, 0, 0);
                    }

                    break;
                }
                case WeaponType.Katana:
                    currentWeapon.transform.localEulerAngles = new Vector3(-90, 180, 0);
                    break;
                case WeaponType.Scythe:
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(90, 180, 180);

                    switch (weaponMasterData.Id)
                    {
                        case 317:
                            currentWeapon.transform.localEulerAngles = new Vector3(0, 90, 0);
                            break;
                        case 204:
                            currentWeapon.transform.localEulerAngles = new Vector3(90, 90, 0);
                            break;
                        case 157:
                            currentWeapon.transform.localEulerAngles = new Vector3(180, 180, 90);
                            break;
                    }

                    break;
                }
            }
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