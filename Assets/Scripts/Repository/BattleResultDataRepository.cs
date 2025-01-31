using System;

namespace Repository
{
    public class BattleResultDataRepository : IDisposable
    {
        private int _rank;

        public int GetRank()
        {
            return _rank;
        }

        public void SetRank(int rank)
        {
            _rank = rank;
        }

        public void Dispose()
        {
        }
    }
}