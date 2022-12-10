using System;
using UnityEngine;

namespace Common.Data
{
    public class Currency : IDisposable
    {
        private int _diamond;
        private int _coin;
        public int Diamond => _diamond;
        public int Coin => _coin;

        public void SetDiamond(int diamond)
        {
            _diamond = diamond;
        }

        public void SetCoin(int coin)
        {
            _coin = coin;
        }

        public void Dispose()
        {
        }
    }
}