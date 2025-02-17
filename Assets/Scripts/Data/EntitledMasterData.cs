using System;

namespace Data
{
    public class EntitledMasterData : IDisposable
    {
        public int Id;
        public string Entitled;
        public int WonCount;
        public int DefeatEnemyCount;

        public void Dispose()
        {
        }
    }
}