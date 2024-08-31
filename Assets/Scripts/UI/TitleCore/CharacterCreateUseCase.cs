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
        private readonly WeaponMasterDataRepository weaponMasterDataRepository;

        public CharacterCreateUseCase
        (
            Transform characterGenerateTransform,
            CharacterMasterDataRepository characterMasterDataRepository,
            UserDataRepository userDataRepository,
            CharacterObjectRepository characterObjectRepository,
            WeaponMasterDataRepository weaponMasterDataRepository
        )
        {
            this.characterGenerateTransform = characterGenerateTransform;
            this.characterMasterDataRepository = characterMasterDataRepository;
            this.userDataRepository = userDataRepository;
            this.characterObjectRepository = characterObjectRepository;
            this.weaponMasterDataRepository = weaponMasterDataRepository;
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
            CreateWeapon(createCharacterData, characterObject);
            CreateWeaponEffect(createCharacterData, characterObject);
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

        private void CreateWeapon(CharacterData characterData, GameObject characterObject)
        {
            var weaponObjects = characterObject.GetComponentsInChildren<WeaponObject>();
            foreach (var weaponObject in weaponObjects)
            {
                Object.Destroy(weaponObject.gameObject);
            }

            var weaponData = userDataRepository.GetEquippedWeaponData(characterData.Id);
            var weaponParents = characterObject.GetComponentsInChildren<WeaponParentObject>();
            foreach (var weaponParent in weaponParents)
            {
                var currentWeapon = Object.Instantiate(weaponData.WeaponObject, weaponParent.transform);
                currentWeapon.transform.localPosition = Vector3.zero;
                currentWeapon.transform.localRotation = quaternion.Euler(0, 0, 0);
                currentWeapon.tag = GameCommonData.WeaponTag;
                currentWeapon.AddComponent<WeaponObject>();
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