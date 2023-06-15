using System;

namespace Infrastructure.Coins
{
    public interface IChangeEconomicEvents
    {
        event Action<int> ChangeData;
        int LoadValue();
    }
}