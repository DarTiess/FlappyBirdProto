using System;

namespace Infrastructure.Coins
{
    public class Economic : ISaveEconomic, IChangeEconomicEvents
    {
        private CoinData _coinData;
        public event Action<int> ChangeData;

        public Economic()
        {
            _coinData = new CoinData();
        }

        public void SaveValue()
        {
            _coinData.Money += 1;
            ChangeData?.Invoke(_coinData.Money);
        }

        public int LoadValue()
        {
            return _coinData.Money;
        }
    }
}