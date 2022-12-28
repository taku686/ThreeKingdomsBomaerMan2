using System;

namespace Player.Common
{
    public class PlayerStatusManager : IDisposable
    {
        public int CurrentHp;
        public readonly int MaxHp;

        public PlayerStatusManager(int maxHp)
        {
            CurrentHp = maxHp;
            MaxHp = maxHp;
        }
        
        

        public void Dispose()
        {
        }
    }
}