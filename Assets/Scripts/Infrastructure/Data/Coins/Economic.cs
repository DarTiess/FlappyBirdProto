using System;

namespace Infrastructure.Coins
{
    public class Economic : ISaveEconomic, IChangeEconomicEvents
    {
        public event Action<int> ChangeData;
        private CoinData _coinData;

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