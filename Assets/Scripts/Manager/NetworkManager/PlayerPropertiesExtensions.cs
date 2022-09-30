using Common.Data;
using UnityEngine;
using  ExitGames.Client.Photon;
using  Photon.Realtime;
namespace Manager.NetworkManager
{
    public static class PlayerPropertiesExtensions
    {
        public const string CharacterDataKey = "Cha";
        public const string PlayerIndexKey = "Index";
        private static readonly Hashtable PropsToSet = new Hashtable();


        public static int GetCharacterId(this Photon.Realtime.Player player)
        {
            return (player.CustomProperties[CharacterDataKey] is int characterId) ? characterId : -1;
        }
        
        public static int GetPlayerIndex(this Photon.Realtime.Player player)
        {
            return (player.CustomProperties[PlayerIndexKey] is int playerIndex) ? playerIndex : -1;
        }

        public static void SetCharacterData(this Photon.Realtime.Player player, int characterId)
        {
            PropsToSet[CharacterDataKey] = characterId;
            player.SetCustomProperties(PropsToSet);
            PropsToSet.Clear();
        } 

        public static void SetPlayerIndex(this Photon.Realtime.Player player, int playerIndex)
        {
            PropsToSet[PlayerIndexKey] = playerIndex;
            player.SetCustomProperties(PropsToSet);
            PropsToSet.Clear();
        }
    }
}