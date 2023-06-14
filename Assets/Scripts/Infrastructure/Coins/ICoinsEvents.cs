using System;

namespace Infrastructure.Coins
{
    public interface ICoinsEvents
    {
        event Action<int> ChangeCoins;
        int GetCoinsValue();
    }
}