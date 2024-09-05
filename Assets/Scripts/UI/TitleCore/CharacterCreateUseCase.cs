using System;
using Common.Data;
using Manager.DataManager;
using Unity.Mathematics;
using UnityEditor.Animations;
using UnityEngine;
using Zenject;
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
        private readonly AnimationChangeUseCase idleMotionChangeUseCase;
        private readonly AnimationChangeUseCase performanceMotionChangeUseCase;
        private RuntimeAnimatorController animatorController;

        [Inject]
        public CharacterCreateUseCase
        (
            Transform characterGenerateTransform,
            CharacterMasterDataRepository characterMasterDataRepository,
            UserDataRepository userDataRepository,
            CharacterObjectRepository characterObjectRepository,
            RuntimeAnimatorController animatorController,
            MotionRepository motionRepository,
            AnimationChangeUseCase.Factory animationChangeUseCaseFactory
        )
        {
            this.characterGenerateTransform = characterGenerateTransform;
            this.characterMasterDataRepository = characterMasterDataRepository;
            this.userDataRepository = userDataRepository;
            this.characterObjectRepository = characterObjectRepository;
            this.animatorController = animatorController;
            var idleMotions = motionRepository.GetAllIdleMotions();
            var performanceMotions = motionRepository.GetAllPerformanceMotions();
            idleMotionChangeUseCase = animationChangeUseCaseFactory.Create
            (
                idleMotions[0],
                idleMotions[1],
                idleMotions[2],
                idleMotions[3],
                idleMotions[4],
                idleMotions[5],
                idleMotions[6],
                idleMotions[7],
                idleMotions[8],
                GameCommonData.IdleTag
            );
            performanceMotionChangeUseCase = animationChangeUseCaseFactory.Create
            (
                performanceMotions[0],
                performanceMotions[1],
                performanceMotions[2],
                performanceMotions[3],
                performanceMotions[4],
                performanceMotions[5],
                performanceMotions[6],
                performanceMotions[7],
                performanceMotions[8],
                GameCommonData.PerformanceTag
            );
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

            var weaponData = userDataRepository.GetEquippedWeaponData(characterId);
            characterObject = CreateCharacter(createCharacterData);
            CreateWeapon(characterObject, characterId, weaponData);
            ChangeAnimation(characterObject, weaponData.WeaponType);
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

        private void CreateWeapon
        (
            GameObject characterObject,
            int characterId,
            WeaponMasterData weaponData
        )
        {
            var weaponObjects = characterObject.GetComponentsInChildren<WeaponObject>();
            foreach (var weaponObject in weaponObjects)
            {
                Object.Destroy(weaponObject.gameObject);
            }

            var weaponRightParent = characterObject.GetComponentInChildren<WeaponRightParentObject>();
            var weaponLeftParent = characterObject.GetComponentInChildren<WeaponLeftParentObject>();
            if (IsLeftHand(weaponData.WeaponType))
            {
                weaponLeftParent.transform.localPosition =
                    weaponData.WeaponType == WeaponType.Bow ? bowPosition : weaponPosition;
                weaponLeftParent.transform.localEulerAngles =
                    weaponData.WeaponType == WeaponType.Bow ? bowLeftRotation : weaponLeftRotation;
                InstantiateWeapon(weaponData, weaponLeftParent.transform);
            }

            if (IsRightHand(weaponData.WeaponType))
            {
                weaponRightParent.transform.localPosition =
                    weaponData.WeaponType == WeaponType.Bow ? bowPosition : weaponPosition;
                weaponRightParent.transform.localEulerAngles =
                    weaponData.WeaponType == WeaponType.Bow ? bowRightRotation : weaponRightRotation;
                InstantiateWeapon(weaponData, weaponRightParent.transform);
            }
        }

        private void ChangeAnimation(GameObject characterObject, WeaponType weaponType)
        {
            var animator = characterObject.GetComponent<Animator>();
            if (animator == null)
            {
                return;
            }

            Debug.Log(animator.parameters[0].type);
            /*animatorController = idleMotionChangeUseCase.ChangeMotion(animatorController, weaponType);
            animatorController = performanceMotionChangeUseCase.ChangeMotion(animatorController, weaponType);*/
            animator.runtimeAnimatorController = animatorController;
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
            currentWeapon.transform.localScale =
                FixedScale(weaponMasterData.WeaponType, weaponMasterData.Scale);
            currentWeapon.tag = GameCommonData.WeaponTag;
            currentWeapon.AddComponent<WeaponObject>();
        }

        private Vector3 FixedScale(WeaponType weaponType, float scale)
        {
            switch (weaponType)
            {
                case WeaponType.Bow:
                    return new Vector3(1, 1, 1) * scale;
                case WeaponType.Shield:
                    return new Vector3(1, -1, 1);
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