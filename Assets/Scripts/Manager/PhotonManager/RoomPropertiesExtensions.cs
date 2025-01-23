using ExitGames.Client.Photon;

namespace Manager.NetworkManager
{
    public static class RoomPropertiesExtensions
    {
        private static readonly Hashtable PropsToSet = new();
        private const string RankKey = "Rnk";

        public static int GetRank(this Photon.Realtime.Room room)
        {
            return room.CustomProperties[RankKey] is int rank ? rank : -1;
        }

        public static void SetRank(this Photon.Realtime.Room room, int rank)
        {
            PropsToSet[RankKey] = rank;
            room.SetCustomProperties(PropsToSet);
            PropsToSet.Clear();
        }
    }
}