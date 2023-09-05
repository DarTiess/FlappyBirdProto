using System;
using Infrastructure.Coins;

namespace Infrastructure.Level
{
    public class LevelLoader : ISaveLevelData, ILevelChangeData
    {
        private LevelData _levelData;
        private ILevelContainer _levelContainer;
        private Level _currentLevelSettings;
       
        public event Action<Level> ChangeLevelData;

        public LevelLoader(ILevelContainer levelContainer)
        {
            _levelData = new LevelData();
            _levelContainer = levelContainer;
        }

        public void TrySaveValue(int value)
        {
            _levelData.NumLevel =value;
           _currentLevelSettings = _levelContainer.TryGetLevelSettings(_levelData.NumLevel);
           if (_currentLevelSettings != null)
           {
               ChangeLevelData?.Invoke(_currentLevelSettings);
           }
        }

        public int LoadValue()
        {
            return _levelData.NumLevel;
        }

        public int GetMaxLevelValue()
        {
            return _levelContainer.GetMaxLevelValue();
        }
    }
}