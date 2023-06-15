using System;

namespace Infrastructure.Level
{
    public interface ILevelChangeData
    {
        public event Action<Level> ChangeLevelData;
    }
}