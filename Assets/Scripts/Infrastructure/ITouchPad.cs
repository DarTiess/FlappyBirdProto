using System;

namespace Infrastructure
{
    public interface ITouchPad
    {
        event Action ClickedTouch;
    }
}