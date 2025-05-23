using System.Collections.Generic;
using ExitGames.Client.Photon;

namespace Manager.NetworkManager
{
    public static class PlayerPropertiesExtensions
    {
        private const string CharacterDataKey = "Cha";
        private const string WeaponDataKey = "Wea";
        private const string CharacterLevelKey = "Lev";
        public const string SkillDataKey = "Ski";
        public const string PlayerIndexKey = "Index";
        public const string PlayerGenerateKey = "Gen";
        public const string PlayerCoreInfoKey = "Core";
        public const string WeaponCoreInfoKey = "WCore";
        private static readonly Hashtable PropsToSet = new();


        public static Dictionary<int, int> GetCharacterId(this Photon.Realtime.Player player)
        {
            return (Dictionary<int, int>)player.CustomProperties[CharacterDataKey];
        }

        public static Dictionary<int, int> GetWeaponId(this Photon.Realtime.Player player)
        {
            return (Dictionary<int, int>)player.CustomProperties[WeaponDataKey];
        }

        public static Dictionary<int, int> GetSkillId(this Photon.Realtime.Player player)
        {
            return (Dictionary<int, int>)player.CustomProperties[SkillDataKey];
        }

        public static Dictionary<int, int> GetCharacterLevel(this Photon.Realtime.Player player)
        {
            return (Dictionary<int, int>)player.CustomProperties[CharacterLevelKey];
        }

        public static int GetPlayerIndex(this Photon.Realtime.Player player)
        {
            return player.CustomProperties[PlayerIndexKey] is int playerIndex ? playerIndex : -1;
        }

        public static KeyValuePair<int, int> GetPlayerCoreInfo(this Photon.Realtime.Player player)
        {
            return (KeyValuePair<int, int>)player.CustomProperties[PlayerCoreInfoKey];
        }

        public static KeyValuePair<int, int> GetWeaponCoreInfo(this Photon.Realtime.Player player)
        {
            return (KeyValuePair<int, int>)player.CustomProperties[WeaponCoreInfoKey];
        }

        public static void SetCharacterId(this Photon.Realtime.Player player, Dictionary<int, int> characterId)
        {
            PropsToSet[CharacterDataKey] = characterId;
            player.SetCustomProperties(PropsToSet);
            PropsToSet.Clear();
        }

        public static void SetWeaponId(this Photon.Realtime.Player player, Dictionary<int, int> weaponId)
        {
            PropsToSet[WeaponDataKey] = weaponId;
            player.SetCustomProperties(PropsToSet);
            PropsToSet.Clear();
        }

        public static void SetSkillData(this Photon.Realtime.Player player, Dictionary<int, int> dic)
        {
            PropsToSet[SkillDataKey] = dic;
            player.SetCustomProperties(PropsToSet);
            PropsToSet.Clear();
        }

        public static void SetCharacterLevel(this Photon.Realtime.Player player, Dictionary<int, int> characterLevel)
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

        public static void SetPlayerCoreInfo(this Photon.Realtime.Player player, KeyValuePair<int, int> playerCoreInfo)
        {
            PropsToSet[PlayerCoreInfoKey] = playerCoreInfo;
            player.SetCustomProperties(PropsToSet);
            PropsToSet.Clear();
        }

        public static void SetWeaponCoreInfo(this Photon.Realtime.Player player, KeyValuePair<int, int> weaponViewInfo)
        {
            PropsToSet[WeaponCoreInfoKey] = weaponViewInfo;
            player.SetCustomProperties(PropsToSet);
            PropsToSet.Clear();
        }

        public static void SetFloatValue(this Photon.Realtime.Player player, string key, object value)
        {
            PropsToSet[key] = value;
            player.SetCustomProperties(PropsToSet);
            PropsToSet.Clear();
        }
    }
}