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
        private readonly CharacterLevelMasterDataRepository characterLevelMasterDataRepository;
        private readonly UserDataRepository userDataRepository;
        private GameObject characterObject;

        public CharacterCreateUseCase
        (
            Transform characterGenerateTransform,
            CharacterMasterDataRepository characterMasterDataRepository,
            CharacterLevelMasterDataRepository characterLevelMasterDataRepository,
            UserDataRepository userDataRepository
        )
        {
            this.characterGenerateTransform = characterGenerateTransform;
            this.characterMasterDataRepository = characterMasterDataRepository;
            this.characterLevelMasterDataRepository = characterLevelMasterDataRepository;
            this.userDataRepository = userDataRepository;
        }


        public void CreateCharacter(int characterId)
        {
            if (characterObject != null)
            {
                Object.Destroy(characterObject);
            }

            var createCharacterData = characterMasterDataRepository.GetCharacterData(characterId);
            if (createCharacterData.CharacterObject == null || createCharacterData.WeaponEffectObj == null)
            {
                Debug.LogError(characterId + " is not found");
            }

            characterObject = Object.Instantiate
            (
                createCharacterData.CharacterObject,
                characterGenerateTransform.position,
                characterGenerateTransform.rotation,
                characterGenerateTransform
            );

            var currentCharacterLevel = userDataRepository.GetCurrentLevelData(characterId);
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
                    systemMain.startColor = GameCommonData.GetWeaponColor(characterId);
                }

                var effect = effectObj.GetComponentInChildren<PSMeshRendererUpdater>();
                effect.Color = GameCommonData.GetWeaponColor(characterId);
                effect.UpdateMeshEffect(weapon);
            }
        }

        public GameObject GetCharacterObject()
        {
            if (characterObject == null)
            {
                Debug.LogError("Character object is null.");
            }

            return characterObject;
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}