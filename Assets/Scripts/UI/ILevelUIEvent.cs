using System;

namespace UI
{
    public interface ILevelUIEvent
    {
        event Action<int> ChangeLevelState;
    }
}