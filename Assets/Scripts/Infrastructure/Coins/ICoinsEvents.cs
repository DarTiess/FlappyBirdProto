using System;

namespace Infrastructure
{
    public interface ICoinsEvents
    {
        event Action<int> ChangeCoins;
        int GetCoinsValue();
    }
}