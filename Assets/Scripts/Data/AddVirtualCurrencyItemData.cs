using System;

namespace Common.Data
{
    public class AddVirtualCurrencyItemData : IDisposable
    {
        public int price;
        public string vc;
        public string Name;

        public void Dispose()
        {
        }
    }
}