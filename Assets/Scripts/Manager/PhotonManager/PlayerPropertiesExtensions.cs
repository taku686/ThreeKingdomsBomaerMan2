using Common.Data;
using UnityEngine;
using ExitGames.Client.Photon;
using Photon.Realtime;

namespace Manager.NetworkManager
{
    public static class PlayerPropertiesExtensions
    {
        private const string CharacterDataKey = "Cha";
        private const string CharacterLevelKey = "Lev";
        public const string PlayerIndexKey = "Index";
        public const string PlayerGenerateKey = "Gen";
        private static readonly Hashtable PropsToSet = new Hashtable();


        public static int GetCharacterId(this Photon.Realtime.Player player)
        {
            return (player.CustomProperties[CharacterDataKey] is int characterId) ? characterId : -1;
        }

        public static int GetCharacterLevel(this Photon.Realtime.Player player)
        {
            return (player.CustomProperties[CharacterLevelKey] is int level) ? level : -1;
        }

        public static int GetPlayerIndex(this Photon.Realtime.Player player)
        {
            return (player.CustomProperties[PlayerIndexKey] is int playerIndex) ? playerIndex : -1;
        }

        public static int GetPlayerGenerate(this Photon.Realtime.Player player)
        {
            return (player.CustomProperties[PlayerGenerateKey] is int playerGenerate) ? playerGenerate : -1;
        }

        public static object GetPlayerValue(this Photon.Realtime.Player player, string key)
        {
            return player.CustomProperties[key];
        }


        public static void SetCharacterData(this Photon.Realtime.Player player, int characterId)
        {
            PropsToSet[CharacterDataKey] = characterId;
            player.SetCustomProperties(PropsToSet);
            PropsToSet.Clear();
        }

        public static void SetCharacterLevel(this Photon.Realtime.Player player, int characterLevel)
        {
            PropsToSet[CharacterLevelKey] = characterLevel;
            player.SetCustomProperties(PropsToSet);
            PropsToSet.Clear();
        }

        public static void SetPlayerIndex(this Photon.Realtime.Player player, int playerIndex)
        {
            PropsToSet[PlayerIndexKey] = playerIndex;
            player.SetCustomProperties(PropsToSet);
            PropsToSet.Clear();
        }

        public static void SetPlayerGenerate(this Photon.Realtime.Player player, int playerGenerate)
        {
            PropsToSet[PlayerGenerateKey] = playerGenerate;
            player.SetCustomProperties(PropsToSet);
            PropsToSet.Clear();
        }

        public static void SetPlayerValue(this Photon.Realtime.Player player, string key, object value)
        {
            PropsToSet[key] = value;
            player.SetCustomProperties(PropsToSet);
            PropsToSet.Clear();
        }
    }
}