using Common.Data;
using UnityEngine;
using  ExitGames.Client.Photon;
using  Photon.Realtime;
namespace Manager.NetworkManager
{
    public static class PlayerPropertiesExtensions
    {
        private const string CharacterDataKey = "Cha";
        private static readonly Hashtable PropsToSet = new Hashtable();


        public static int GetCharacterId(this Photon.Realtime.Player player)
        {
            return (player.CustomProperties[CharacterDataKey] is int characterId) ? characterId : 0;
        }

        public static void SetCharacterData(this Photon.Realtime.Player player, int characterId)
        {
            PropsToSet[CharacterDataKey] = characterId;
            player.SetCustomProperties(PropsToSet);
            PropsToSet.Clear();
        }
    }
}