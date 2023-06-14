using UnityEngine;

namespace Infrastructure.Level
{
    public class LevelData
    {
        public int NumLevel
        {
            get { return PlayerPrefs.GetInt("NumLevel"); }
            set { PlayerPrefs.SetInt("NumLevel", value); }
        }
        
        public void LoadNextLevel()
        {
            NumLevel += 1;
        }
    }
}