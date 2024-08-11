using System;
using System.Linq;
using Common.Data;
using Manager.DataManager;
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

            CreateCharacter(createCharacterData);
            CreateWeapon(createCharacterData);
            CreateWeaponEffect(createCharacterData);
        }

        private void CreateCharacter(CharacterData createCharacterData)
        {
            var characterObject = Object.Instantiate
            (
                createCharacterData.CharacterObject,
                characterGenerateTransform.position,
                characterGenerateTransform.rotation,
                characterGenerateTransform
            );
            characterObjectRepository.SetCharacterObject(characterObject);
        }

        private void CreateWeapon(CharacterData characterData)
        {
            var weaponData = userDataRepository.GetEquippedWeaponData(characterData.Id);
            var weaponObjects = GameObject.FindGameObjectsWithTag(GameCommonData.WeaponTag);
            foreach (var weaponObject in weaponObjects)
            {
                var weaponParent = weaponObject.transform.parent;
                var position = weaponObject.transform.position;
                var rotation = weaponObject.transform.rotation;
                var weapon = Object.Instantiate(weaponData.WeaponObject, position, rotation, weaponParent);
                weapon.tag = GameCommonData.WeaponTag;
                Object.Destroy(weaponObject);
            }
        }

        private void CreateWeaponEffect(CharacterData createCharacterData)
        {
            var currentCharacterLevel = userDataRepository.GetCurrentLevelData(createCharacterData.Id);
            if (currentCharacterLevel.Level < GameCommonData.MaxCharacterLevel)
            {
                return;
            }

            var weapons = GameObject.FindGameObjectsWithTag(GameCommonData.WeaponTag);
            foreach (var weapon in weapons)
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
                effect.UpdateMeshEffect(weapon);
            }
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}