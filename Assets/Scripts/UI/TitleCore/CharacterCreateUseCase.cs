using System;
using Common.Data;
using Manager.DataManager;
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

        public void CreateCharacter(int characterId)
        {
            var characterObject = _characterObjectRepository.GetCharacterObject();
            if (characterObject != null)
            {
                Object.Destroy(characterObject);
            }

            var createCharacterData = _characterMasterDataRepository.GetCharacterData(characterId);
            var weaponData = _userDataRepository.GetEquippedWeaponData(characterId);
            characterObject = CreateCharacter(createCharacterData);
            CreateWeapon(characterObject, weaponData);
            ChangeAnimatorController(characterObject, weaponData.WeaponType);
            //todo androidでエフェクトの表示がおかしくなるためコメントアウト
            //CreateWeaponEffect(createCharacterData, characterObject);
        }

        private GameObject CreateCharacter(CharacterData createCharacterData)
        {
            var characterObject = Object.Instantiate
            (
                createCharacterData.CharacterObject,
                _characterGenerateTransform.position,
                _characterGenerateTransform.rotation,
                _characterGenerateTransform
            );
            _characterObjectRepository.SetCharacterObject(characterObject);
            return characterObject;
        }

        private void CreateWeapon
        (
            GameObject characterObject,
            WeaponMasterData weaponData
        )
        {
            var weaponObjects = characterObject.GetComponentsInChildren<WeaponObject>();
            foreach (var weaponObject in weaponObjects)
            {
                if (weaponObject.gameObject == null)
                {
                    continue;
                }

                Object.Destroy(weaponObject.gameObject);
            }

            var weaponRightParent = characterObject.GetComponentInChildren<WeaponRightParentObject>();
            var weaponLeftParent = characterObject.GetComponentInChildren<WeaponLeftParentObject>();
            if (IsLeftHand(weaponData.WeaponType))
            {
                if (WeaponType.Bow == weaponData.WeaponType)
                {
                    weaponLeftParent.transform.localPosition = _bowPosition;
                    weaponLeftParent.transform.localEulerAngles = _bowLeftRotation;
                }
                else if (WeaponType.Knife == weaponData.WeaponType)
                {
                    weaponLeftParent.transform.localPosition = _knifePosition;
                    weaponLeftParent.transform.localEulerAngles = _knifeLeftRotation;
                }
                else
                {
                    weaponLeftParent.transform.localPosition = _othersPosition;
                    weaponLeftParent.transform.localEulerAngles = _othersLeftRotation;
                }

                InstantiateWeapon(weaponData, weaponLeftParent.transform);
            }

            if (IsRightHand(weaponData.WeaponType))
            {
                if (WeaponType.Bow == weaponData.WeaponType)
                {
                    weaponRightParent.transform.localPosition = _bowPosition;
                    weaponRightParent.transform.localEulerAngles = _bowRightRotation;
                }
                else
                {
                    weaponRightParent.transform.localPosition = _othersPosition;
                    weaponRightParent.transform.localEulerAngles = _othersRightRotation;
                }

                InstantiateWeapon(weaponData, weaponRightParent.transform);
            }
        }

        private bool IsRightHand(WeaponType weaponType)
        {
            return weaponType != WeaponType.Bow && weaponType != WeaponType.Shield;
        }

        private bool IsLeftHand(WeaponType weaponType)
        {
            return weaponType == WeaponType.Bow || weaponType == WeaponType.Knife || weaponType == WeaponType.Shield;
        }

        private void InstantiateWeapon(WeaponMasterData weaponMasterData, Transform weaponParent)
        {
            var currentWeapon = Object.Instantiate(weaponMasterData.WeaponObject, weaponParent.transform);
            currentWeapon.transform.localPosition = Vector3.zero;
            currentWeapon.transform.localRotation = quaternion.Euler(0, 0, 0);
            currentWeapon.transform.localScale *= weaponMasterData.Scale;
            currentWeapon.tag = GameCommonData.WeaponTag;
            currentWeapon.AddComponent<WeaponObject>();
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

        private void CreateWeaponEffect(CharacterData createCharacterData, GameObject characterObject)
        {
            var currentCharacterLevel = _userDataRepository.GetCurrentLevelData(createCharacterData.Id);
            if (currentCharacterLevel.Level < GameCommonData.MaxCharacterLevel)
            {
                return;
            }

            var weaponObjects = characterObject.GetComponentsInChildren<WeaponObject>();
            foreach (var weapon in weaponObjects)
            {
                var effectObj = Object.Instantiate(createCharacterData.WeaponEffectObj, weapon.transform);
                var particleSystems = effectObj.GetComponentsInChildren<ParticleSystem>();
                foreach (var system in particleSystems)
                {
                    var systemMain = system.main;
                    systemMain.startColor = GameCommonData.GetWeaponColor(createCharacterData.Id);
                }

                var effect = effectObj.GetComponentInChildren<PSMeshRendererUpdater>();
                effect.Color = GameCommonData.GetWeaponColor(createCharacterData.Id);
                effect.UpdateMeshEffect(weapon.gameObject);
            }
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}