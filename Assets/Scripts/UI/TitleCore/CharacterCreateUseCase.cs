using System;
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
            var weaponObj = InstantiateWeapon(characterObject, weaponData);
            FixedWeaponTransform(characterObject, weaponObj, weaponData);
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

        private bool IsRightHand(WeaponType weaponType)
        {
            return weaponType != WeaponType.Bow && weaponType != WeaponType.Shield;
        }

        private bool IsLeftHand(WeaponType weaponType)
        {
            return weaponType is WeaponType.Bow or WeaponType.Knife or WeaponType.Shield or WeaponType.Crow;
        }

        public GameObject InstantiateWeapon
        (
            GameObject playerObj,
            WeaponMasterData weaponMasterData,
            bool isPhotonObject = false,
            bool isCpu = false
        )
        {
            GameObject currentWeapon;
            DestroyWeaponObj(playerObj);
            if (isPhotonObject)
            {
                if (isCpu)
                {
                    currentWeapon = PhotonNetwork.InstantiateRoomObject
                    (
                        GameCommonData.WeaponPrefabPath + weaponMasterData.Id,
                        Vector3.zero,
                        quaternion.Euler(0, 0, 0)
                    );
                }
                else
                {
                    currentWeapon = PhotonNetwork.Instantiate
                    (
                        GameCommonData.WeaponPrefabPath + weaponMasterData.Id,
                        Vector3.zero,
                        quaternion.Euler(0, 0, 0)
                    );
                }
            }
            else
            {
                currentWeapon = Object.Instantiate(weaponMasterData.WeaponObject);
                FixedWeaponTransform(playerObj, currentWeapon, weaponMasterData);
            }

            return currentWeapon;
        }

        public void FixedWeaponTransform
        (
            GameObject characterObject,
            GameObject currentWeapon,
            WeaponMasterData weaponMasterData
        )
        {
            var weaponRightParent = characterObject.GetComponentInChildren<WeaponRightParentObject>();
            var weaponLeftParent = characterObject.GetComponentInChildren<WeaponLeftParentObject>();
            var isLeftHand = false;
            if (IsLeftHand(weaponMasterData.WeaponType))
            {
                if (WeaponType.Bow == weaponMasterData.WeaponType)
                {
                    weaponLeftParent.transform.localPosition = _bowPosition;
                    weaponLeftParent.transform.localEulerAngles = _bowLeftRotation;
                }
                else if (WeaponType.Knife == weaponMasterData.WeaponType)
                {
                    weaponLeftParent.transform.localPosition = _knifePosition;
                    weaponLeftParent.transform.localEulerAngles = _knifeLeftRotation;
                }
                else if (WeaponType.Crow == weaponMasterData.WeaponType)
                {
                    weaponLeftParent.transform.localPosition = _othersPosition;
                    weaponLeftParent.transform.localEulerAngles = _crowLeftRotation;
                }
                else
                {
                    weaponLeftParent.transform.localPosition = _othersPosition;
                    weaponLeftParent.transform.localEulerAngles = _othersLeftRotation;
                }

                isLeftHand = true;
                currentWeapon.transform.SetParent(weaponLeftParent.transform);
            }

            if (IsRightHand(weaponMasterData.WeaponType))
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

                isLeftHand = false;
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

        private void FixWeaponAngle(GameObject currentWeapon, WeaponMasterData weaponMasterData, bool isLeftHand)
        {
            if (weaponMasterData.WeaponType == WeaponType.Hammer)
            {
                if (weaponMasterData.Id == 241)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(0, 0, 90);
                }

                if (weaponMasterData.Id == 150)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(180, 180, 90);
                }
            }

            if (weaponMasterData.WeaponType == WeaponType.Sword && weaponMasterData.Id >= 146)
            {
                currentWeapon.transform.localEulerAngles = new Vector3(-90, 0, 180);

                if (weaponMasterData.Id == 319)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(0, 180, 180);
                }

                if (weaponMasterData.Id == 152)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(0, 0, -90);
                }

                if (weaponMasterData.Id == 313)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(180, 0, 180);
                }

                if (weaponMasterData.Id == 322)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(-90, 0, 234);
                }

                if (weaponMasterData.Id == 232)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(0, 90, -90);
                }
            }

            if (weaponMasterData.WeaponType == WeaponType.Knife && weaponMasterData.Id >= 146)
            {
                currentWeapon.transform.localEulerAngles = isLeftHand ? new Vector3(-90, 0, 180) : new Vector3(-90, 0, 0);

                if (weaponMasterData.Id == 314)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(180, 0, 0);
                }

                if (weaponMasterData.Id == 154)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(0, 0, 90);
                }

                if (weaponMasterData.Id == 234)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(0, 0, 90);
                }
            }

            if (weaponMasterData.WeaponType == WeaponType.Bow && weaponMasterData.Id >= 146)
            {
                currentWeapon.transform.localEulerAngles = new Vector3(90, 0, 0);

                if (weaponMasterData.Id == 318)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(180, 0, 0);
                }

                if (weaponMasterData.Id == 158)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(0, 0, 0);
                }
            }

            if (weaponMasterData.WeaponType == WeaponType.Shield && weaponMasterData.Id >= 146)
            {
                if (weaponMasterData.Id == 165)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(180, 90, 0);
                }

                if (weaponMasterData.Id is 236 or 155)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(0, 180, 180);
                }

                if (weaponMasterData.Id == 311)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(0, 0, 180);
                }

                if (weaponMasterData.Id == 316)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(180, 0, 90);
                }
            }

            if (weaponMasterData.WeaponType == WeaponType.Axe && weaponMasterData.Id >= 146)
            {
                currentWeapon.transform.localEulerAngles = new Vector3(-90, 180, 0);

                if (weaponMasterData.Id == 163)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(-90, 90, 0);
                }

                if (weaponMasterData.Id == 153)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(0, 0, -90);
                }
            }

            if (weaponMasterData.WeaponType == WeaponType.Staff && weaponMasterData.Id >= 146)
            {
                if (weaponMasterData.Id == 156)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(180, 0, 0);
                }

                if (weaponMasterData.Id == 315)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(0, 0, 0);
                }
            }

            if (weaponMasterData.WeaponType == WeaponType.BigSword && weaponMasterData.Id >= 146)
            {
                currentWeapon.transform.localEulerAngles = new Vector3(-90, 180, 0);
                if (weaponMasterData.Id == 146)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(180, 0, -180);
                }

                if (weaponMasterData.Id == 151)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(0, 180, -90);
                }

                if (weaponMasterData.Id == 312)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(0, 0, 0);
                }
            }

            if (weaponMasterData.WeaponType == WeaponType.Crow)
            {
                currentWeapon.transform.localEulerAngles = isLeftHand ? new Vector3(180, 0, 0) : new Vector3(0, 0, 0);
                if (weaponMasterData.Id == 357)
                {
                    currentWeapon.transform.localEulerAngles = isLeftHand ? new Vector3(0, 0, 0) : new Vector3(180, 0, 0);
                }
            }

            if (weaponMasterData.WeaponType == WeaponType.Katana)
            {
                currentWeapon.transform.localEulerAngles = new Vector3(-90, 180, 0);
            }

            if (weaponMasterData.WeaponType == WeaponType.Scythe)
            {
                currentWeapon.transform.localEulerAngles = new Vector3(90, 180, 180);

                if (weaponMasterData.Id == 317)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(0, 90, 0);
                }

                if (weaponMasterData.Id == 204)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(90, 90, 0);
                }

                if (weaponMasterData.Id == 157)
                {
                    currentWeapon.transform.localEulerAngles = new Vector3(180, 180, 90);
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

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}