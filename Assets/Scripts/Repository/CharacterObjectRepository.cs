using System;
using UnityEngine;

namespace Repository
{
    public class CharacterObjectRepository : IDisposable
    {
        private GameObject characterObject;

        public GameObject GetCharacterObject()
        {
            if (characterObject == null)
            {
                Debug.LogError("Character object is null.");
            }

            return characterObject;
        }

        public void SetCharacterObject(GameObject obj)
        {
            characterObject = obj;
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}