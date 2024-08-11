using System;
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
            
            CreateCharacter(createCharacterData);
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