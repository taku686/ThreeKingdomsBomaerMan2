using System;
using UnityEngine;

namespace Common
{
    public static class PlayerPrefsManager
    {
        public static string UserID
        {
            get
            {
                string userId = PlayerPrefs.GetString("UserID");
           
                if (userId == null)
                {
                    userId = Guid.NewGuid().ToString("N");
                    Debug.Log(userId);
                    PlayerPrefs.SetString("UserID", userId);
                    PlayerPrefs.Save();
                }
                return userId;
            }
            set
            {
                PlayerPrefs.SetString("UserID", value);
                PlayerPrefs.Save();
            }
        }
    
        /// <summary>
        /// メールアドレスを使ってログイン済みなら true
        /// </summary>
        public static bool IsLoginEmailAddress
        {
            get => bool.TryParse(PlayerPrefs.GetString("IsLoginEmailAddress"), out var result) && result;
            set
            {
                PlayerPrefs.SetString("IsLoginEmailAddress", value.ToString());
                PlayerPrefs.Save();
            }
        }

    }
}