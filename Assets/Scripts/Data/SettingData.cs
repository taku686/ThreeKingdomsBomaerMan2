using System;

namespace Data
{
    [Serializable]
    public class SettingData : IDisposable
    {
        public float _BgmVolume { get; set; } = 1.0f;
        public bool _IsActivePushNotification { get; set; } = true;

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}