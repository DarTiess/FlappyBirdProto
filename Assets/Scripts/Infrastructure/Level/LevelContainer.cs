using System.Collections.Generic;
using System.Linq;
using Infrastructure.Coins;
using UnityEngine;

namespace Infrastructure.Level
{
    [CreateAssetMenu(fileName = "LevelContainer", menuName = "LevelSettings/LevelContainer", order = 51)]
    public class LevelContainer : ScriptableObject, ILevelContainer
    {
        public List<Level> Levels;

        public Level TryGetLevelSettings(int numberLevel)
        {
            foreach (Level level in Levels)
            {
                if (level.LevelNumber == numberLevel)
                {
                    return level;
                }
            }

            return null;
        }

        public int GetMaxLevelValue()
        {
            int maxLevel = Levels.Max(x => x.LevelNumber);
            return maxLevel;
        }
    }
}