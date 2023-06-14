using System;
using UnityEngine;

namespace Infrastructure
{
    public class Coins : IAddCoins, ICoinsEvents
    {
        public event Action<int> ChangeCoins;
        private const string MONEY = "Money";
        private int money
        {
            get { return PlayerPrefs.GetInt(MONEY); }
            set { PlayerPrefs.SetInt(MONEY, value); }
        }

        public void AddCoins()
        {
            money += 1;
            ChangeCoins?.Invoke(money);
        }

        public int GetCoinsValue()
        {
            return money;
        }
    }
}