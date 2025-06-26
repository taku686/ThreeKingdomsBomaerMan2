using System;
using UnityEngine;

namespace Repository
{
    public class CharacterObjectRepository : IDisposable
    {
        private readonly GameObject[] _characterObjects = { null, null, null };

        public GameObject GetCharacterObject(int index = 0)
        {
            if (index < 0 || index >= _characterObjects.Length)
            {
                return null;
            }

            return _characterObjects[index];
        }

        public GameObject[] GetCharacterObjects()
        {
            return _characterObjects;
        }

        public void SetCharacterObject(GameObject obj, int index)
        {
            if (index < 0 || index >= _characterObjects.Length)
            {
                return;
            }

            _characterObjects[index] = obj;
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}