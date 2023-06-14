using System;

namespace Infrastructure.Level
{
    public interface ILevelEvents
    {
        event Action LevelStart;
        event Action LevelWin;
        event Action LateWin;
        event Action LevelLost;
        event Action LateLost;
        event Action PlayGame;
        event Action StopGame;
    }
}