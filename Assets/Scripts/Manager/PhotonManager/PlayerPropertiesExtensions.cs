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
        public const string AbnormalConditionKey = "Abn";
        private static readonly Hashtable PropsToSet = new();


        public static int GetCharacterId(this Photon.Realtime.Player player)
        {
            return player.CustomProperties[CharacterDataKey] is int characterId ? characterId : -1;
        }

        public static int GetWeaponId(this Photon.Realtime.Player player)
        {
            return player.CustomProperties[WeaponDataKey] is int weaponId ? weaponId : -1;
        }

        public static Dictionary<int, int> GetSkillId(this Photon.Realtime.Player player)
        {
            return player.CustomProperties[SkillDataKey] as Dictionary<int, int>;
        }

        public static int GetCharacterLevel(this Photon.Realtime.Player player)
        {
            return player.CustomProperties[CharacterLevelKey] is int level ? level : -1;
        }

        public static int GetPlayerIndex(this Photon.Realtime.Player player)
        {
            return player.CustomProperties[PlayerIndexKey] is int playerIndex ? playerIndex : -1;
        }

        public static int GetAbnormalCondition(this Photon.Realtime.Player player)
        {
            return player.CustomProperties[AbnormalConditionKey] is int abnormalCondition ? abnormalCondition : -1;
        }

        public static void SetCharacterData(this Photon.Realtime.Player player, int characterId)
        {
            PropsToSet[CharacterDataKey] = characterId;
            player.SetCustomProperties(PropsToSet);
            PropsToSet.Clear();
        }

        public static void SetWeaponData(this Photon.Realtime.Player player, int weaponId)
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

        public static void SetAbnormalCondition(this Photon.Realtime.Player player, object value)
        {
            PropsToSet[AbnormalConditionKey] = value;
            player.SetCustomProperties(PropsToSet);
            PropsToSet.Clear();
        }
    }
}