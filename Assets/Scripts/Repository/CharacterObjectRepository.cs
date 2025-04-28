using System;
using UnityEngine;

namespace Repository
{
    public class CharacterObjectRepository : IDisposable
    {
        private GameObject _characterObject;

        public GameObject GetCharacterObject()
        {
            return _characterObject;
        }

        public void SetCharacterObject(GameObject obj)
        {
            _characterObject = obj;
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}