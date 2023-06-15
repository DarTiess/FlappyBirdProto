using UnityEngine;

namespace Infrastructure.Coins
{
    public class CoinData
    {
        private const string MONEY = "Money";
        public int Money
        {
            get { return PlayerPrefs.GetInt(MONEY); }
            set { PlayerPrefs.SetInt(MONEY, value); }
        }
    }
}