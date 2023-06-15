using System;

namespace UI
{
    public interface ISoundUIEvent
    {
        event Action<bool> ChangeSoundState;
    }
}