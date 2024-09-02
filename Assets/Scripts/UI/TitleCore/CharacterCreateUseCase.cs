using System;
using Common.Data;
using Manager.DataManager;
using Unity.Mathematics;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Repository
{
    public class CharacterCreateUseCase : IDisposable
    {
        private readonly Transform characterGenerateTransform;
        private readonly CharacterMasterDataRepository characterMasterDataRepository;
        private readonly UserDataRepository userDataRepository;
        private readonly CharacterObjectRepository characterObjectRepository;
        private readonly Vector3 bowPosition = new(-0.029f, 0.02f, -0.001f);
        private readonly Vector3 weaponPosition = new(-0.061f, 0.026f, 0.003f);
        private readonly Vector3 bowRightRotation = new(-87.91f, 204.73f, -24.69f);
        private readonly Vector3 bowLeftRotation = new(87.91f, -204.73f, -24.69f);
        private readonly Vector3 weaponRightRotation = new(36.033f, -92.88f, 84.68f);
        private readonly Vector3 weaponLeftRotation = new(-36.033f, 92.88f, 84.68f);
        private const int KakouenId = 15;

        public CharacterCreateUseCase
        (
            Transform characterGenerateTransform,
            CharacterMasterDataRepository characterMasterDataRepository,
            UserDataRepository userDataRepository,
            CharacterObjectRepository characterObjectRepository
        )
        {
            this.characterGenerateTransform = characterGenerateTransform;
            this.characterMasterDataRepository = characterMasterDataRepository;
            this.userDataRepository = userDataRepository;
            this.characterObjectRepository = characterObjectRepository;
        }


        public void CreateCharacter(int characterId)
        {
            var characterObject = characterObjectRepository.GetCharacterObject();
            if (characterObject != null)
            {
                Object.Destroy(characterObject);
            }

            var createCharacterData = characterMasterDataRepository.GetCharacterData(characterId);
            if (createCharacterData.CharacterObject == null || createCharacterData.WeaponEffectObj == null)
            {
                Debug.LogError(characterId + " is not found");
            }

            characterObject = CreateCharacter(createCharacterData);
            CreateWeapon(createCharacterData, characterObject, characterId);
            //todo androidでエフェクトの表示がおかしくなるためコメントアウト
            //CreateWeaponEffect(createCharacterData, characterObject);
        }

        private GameObject CreateCharacter(CharacterData createCharacterData)
        {
            var characterObject = Object.Instantiate
            (
                createCharacterData.CharacterObject,
                characterGenerateTransform.position,
                characterGenerateTransform.rotation,
                characterGenerateTransform
            );
            characterObjectRepository.SetCharacterObject(characterObject);
            return characterObject;
        }

        private void CreateWeapon(CharacterData characterData, GameObject characterObject, int characterId)
        {
            var weaponObjects = characterObject.GetComponentsInChildren<WeaponObject>();
            foreach (var weaponObject in weaponObjects)
            {
                Object.Destroy(weaponObject.gameObject);
            }

            var weaponData = userDataRepository.GetEquippedWeaponData(characterData.Id);
            var weaponRightParent = characterObject.GetComponentInChildren<WeaponRightParentObject>();
            var weaponLeftParent = characterObject.GetComponentInChildren<WeaponLeftParentObject>();
            if (weaponLeftParent != null)
            {
                weaponLeftParent.transform.localPosition =
                    weaponData.WeaponType == WeaponType.Bow ? bowPosition : weaponPosition;
                weaponLeftParent.transform.localEulerAngles =
                    weaponData.WeaponType == WeaponType.Bow ? bowLeftRotation : weaponLeftRotation;
                InstantiateWeapon(weaponData, weaponLeftParent.transform, characterId, false);
            }

            if (weaponRightParent != null)
            {
                weaponRightParent.transform.localPosition =
                    weaponData.WeaponType == WeaponType.Bow ? bowPosition : weaponPosition;
                weaponRightParent.transform.localEulerAngles =
                    weaponData.WeaponType == WeaponType.Bow ? bowRightRotation : weaponRightRotation;
                InstantiateWeapon(weaponData, weaponRightParent.transform, characterId);
            }
        }

        private void InstantiateWeapon(WeaponMasterData weaponMasterData, Transform weaponParent, int characterId,
            bool isRight = true)
        {
            var currentWeapon = Object.Instantiate(weaponMasterData.WeaponObject, weaponParent.transform);
            currentWeapon.transform.localPosition = Vector3.zero;
            currentWeapon.transform.localRotation = quaternion.Euler(0, 0, 0);
            currentWeapon.transform.localScale =
                FixedScale(weaponMasterData.WeaponType, characterId, weaponMasterData.Scale, isRight);
            currentWeapon.tag = GameCommonData.WeaponTag;
            currentWeapon.AddComponent<WeaponObject>();
        }

        private Vector3 FixedScale(WeaponType weaponType, int characterId, float scale, bool isRight)
        {
            switch (weaponType)
            {
                case WeaponType.Shield:
                    return (characterId == KakouenId || !isRight) ? new Vector3(1, -1, -1) : new Vector3(1, -1, 1);
                case WeaponType.Bow:
                    return new Vector3(1, 1, 1) * scale;
                default:
                    return new Vector3(1, 1, 1) * scale;
            }
        }

        private void CreateWeaponEffect(CharacterData createCharacterData, GameObject characterObject)
        {
            var currentCharacterLevel = userDataRepository.GetCurrentLevelData(createCharacterData.Id);
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