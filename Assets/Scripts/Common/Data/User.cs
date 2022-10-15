using System.Collections;
using System.Collections.Generic;
using Common.Data;
using UnityEngine;

public class User
{
    public Gender Gender;
    public int EquipCharacterId;
    public int Level;
    public string Name;
    public bool IsTutorial;
    public Dictionary<int, CharacterData> Characters;

    public static User Create()
    {
        var user = new User();
        return user;
    }
}