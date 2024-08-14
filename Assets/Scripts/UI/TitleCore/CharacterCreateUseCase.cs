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
            //CreateWeaponEffect(createCharacterData);
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
            foreach (var currentWeapon in weaponObjects)
            {
                var weaponParent = currentWeapon.transform.parent;
                var prefab = Object.Instantiate(weaponData.WeaponObject, weaponParent);
                FixedTransform(currentWeapon, prefab);
                prefab.transform.rotation = currentWeapon.transform.rotation;
                prefab.tag = GameCommonData.WeaponTag;
                Object.Destroy(currentWeapon);
            }
        }

        private void FixedTransform(GameObject currentWeapon, GameObject prefab)
        {
            var currentBounds = GetCenterPosition(currentWeapon.transform);
            var prefabBounds = GetCenterPosition(prefab.transform);
            Debug.Log("currentBounds: " + currentBounds);
            Debug.Log("prefabBounds: " + prefabBounds);
            Debug.Log("PrefabPosition: " + prefab.transform.localPosition);
            var diff = currentBounds - prefabBounds;
            prefab.transform.localPosition = Vector3.zero;
            prefab.transform.position = diff;
        }

        private static Vector3 GetCenterPosition(Transform target)
        {
            //非アクティブも含めて、targetとtargetの子全てのレンダラーとコライダーを取得
            var cols = target.GetComponentsInChildren<Collider>(true);
            var rens = target.GetComponentsInChildren<Renderer>(true);

            //コライダーとレンダラーが１つもなければ、target.positionがcenterになる
            if (cols.Length == 0 && rens.Length == 0)
                return target.position;

            bool isInit = false;

            Vector3 minPos = Vector3.zero;
            Vector3 maxPos = Vector3.zero;

            for (int i = 0; i < cols.Length; i++)
            {
                var bounds = cols[i].bounds;
                var center = bounds.center;
                var size = bounds.size / 2;

                //最初の１度だけ通って、minPosとmaxPosを初期化する
                if (!isInit)
                {
                    minPos.x = center.x - size.x;
                    minPos.y = center.y - size.y;
                    minPos.z = center.z - size.z;
                    maxPos.x = center.x + size.x;
                    maxPos.y = center.y + size.y;
                    maxPos.z = center.z + size.z;

                    isInit = true;
                    continue;
                }

                if (minPos.x > center.x - size.x) minPos.x = center.x - size.x;
                if (minPos.y > center.y - size.y) minPos.y = center.y - size.y;
                if (minPos.z > center.z - size.z) minPos.z = center.z - size.z;
                if (maxPos.x < center.x + size.x) maxPos.x = center.x + size.x;
                if (maxPos.y < center.y + size.y) maxPos.y = center.y + size.y;
                if (maxPos.z < center.z + size.z) maxPos.z = center.z + size.z;
            }

            for (int i = 0; i < rens.Length; i++)
            {
                var bounds = rens[i].bounds;
                var center = bounds.center;
                var size = bounds.size / 2;

                //コライダーが１つもなければ１度だけ通って、minPosとmaxPosを初期化する
                if (!isInit)
                {
                    minPos.x = center.x - size.x;
                    minPos.y = center.y - size.y;
                    minPos.z = center.z - size.z;
                    maxPos.x = center.x + size.x;
                    maxPos.y = center.y + size.y;
                    maxPos.z = center.z + size.z;

                    isInit = true;
                    continue;
                }

                if (minPos.x > center.x - size.x) minPos.x = center.x - size.x;
                if (minPos.y > center.y - size.y) minPos.y = center.y - size.y;
                if (minPos.z > center.z - size.z) minPos.z = center.z - size.z;
                if (maxPos.x < center.x + size.x) maxPos.x = center.x + size.x;
                if (maxPos.y < center.y + size.y) maxPos.y = center.y + size.y;
                if (maxPos.z < center.z + size.z) maxPos.z = center.z + size.z;
            }

            return (minPos + maxPos) / 2;
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