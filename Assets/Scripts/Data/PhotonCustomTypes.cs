using System.Collections.Generic;
using ExitGames.Client.Photon;

namespace Data
{
    public static class PhotonCustomTypes
    {
        private static readonly byte[] BufferKeyValueIntPair = new byte[8];

        // カスタムタイプを登録するメソッド（起動時に一度だけ呼び出す）
        public static void Register()
        {
            PhotonPeer.RegisterType(typeof(KeyValuePair<int, int>), 1, SerializeKeyValueInt, DeserializeKeyValueInt);
        }

        private static short SerializeKeyValueInt(StreamBuffer outStream, object customObject)
        {
            var v = (KeyValuePair<int, int>)customObject;
            var index = 0;
            lock (BufferKeyValueIntPair)
            {
                Protocol.Serialize(v.Key, BufferKeyValueIntPair, ref index);
                Protocol.Serialize(v.Value, BufferKeyValueIntPair, ref index);
                outStream.Write(BufferKeyValueIntPair, 0, index);
            }

            return (short)index;
        }

        private static object DeserializeKeyValueInt(StreamBuffer inStream, short length)
        {
            int key, value;
            var index = 0;
            lock (BufferKeyValueIntPair)
            {
                inStream.Read(BufferKeyValueIntPair, 0, length);
                Protocol.Deserialize(out key, BufferKeyValueIntPair, ref index);
                Protocol.Deserialize(out value, BufferKeyValueIntPair, ref index);
            }

            return new KeyValuePair<int, int>(key, value);
        }
    }
}