using System.Collections.Generic;
using UnityEngine;

namespace Common.Data
{
    [CreateAssetMenu(fileName = "UserData", menuName = "UserData", order = 0)]
    public class UserData : ScriptableObject
    {
        public int currentCharacterID;
    }
}