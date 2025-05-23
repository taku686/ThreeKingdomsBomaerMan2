using System.Collections.Generic;
using Common.Data;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Repository
{
    public class ResourcesObjectRepository : SerializedMonoBehaviour
    {
        [OdinSerialize, DictionaryDrawerSettings(KeyLabel = "Id", ValueLabel = "Prefab")]
        private Dictionary<int, GameObject> _characterPrefab = new();

        [OdinSerialize, DictionaryDrawerSettings(KeyLabel = "Id", ValueLabel = "Prefab")]
        private Dictionary<int, GameObject> _weaponPrefab = new();

        [OdinSerialize, DictionaryDrawerSettings(KeyLabel = "Id", ValueLabel = "Prefab")]
        private Dictionary<int, Sprite> _characterIcon = new();

        [OdinSerialize, DictionaryDrawerSettings(KeyLabel = "Id", ValueLabel = "Prefab")]
        private Dictionary<CharacterColor, Sprite> _characterColor = new();

        [OdinSerialize, DictionaryDrawerSettings(KeyLabel = "Id", ValueLabel = "Prefab")] [SerializeField]
        private Dictionary<int, Sprite> _weaponIcon = new();

        [OdinSerialize, DictionaryDrawerSettings(KeyLabel = "Id", ValueLabel = "Prefab")] [SerializeField]
        private Dictionary<int, Sprite> _skillIcon = new();


        public GameObject GetCharacterPrefab(int index)
        {
            if (!_characterPrefab.TryGetValue(index, value: out var prefab))
            {
                Debug.LogError($"Character prefab with index {index} not found.");
                return null;
            }

            return prefab;
        }

        public GameObject GetWeaponPrefab(int index)
        {
            if (!_weaponPrefab.TryGetValue(index, value: out var prefab))
            {
                Debug.LogError($"Weapon prefab with index {index} not found.");
                return null;
            }

            return prefab;
        }

        public Sprite GetCharacterIcon(int index)
        {
            if (!_characterIcon.TryGetValue(index, value: out var icon))
            {
                Debug.LogError($"Character icon with index {index} not found.");
                return null;
            }

            return icon;
        }

        public Sprite GetWeaponIcon(int index)
        {
            if (!_weaponIcon.TryGetValue(index, value: out var icon))
            {
                Debug.LogError($"Weapon icon with index {index} not found.");
                return null;
            }

            return icon;
        }

        public Sprite GetSkillIcon(int index)
        {
            if (!_skillIcon.TryGetValue(index, value: out var icon))
            {
                Debug.LogError($"Sprite icon with index {index} not found.");
                return null;
            }

            return icon;
        }
        
        public Sprite GetCharacterColor(CharacterColor index)
        {
            if (!_characterColor.TryGetValue(index, value: out var color))
            {
                Debug.LogError($"Character color with index {index} not found.");
                return null;
            }

            return color;
        }
    }
}