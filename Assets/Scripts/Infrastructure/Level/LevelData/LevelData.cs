using UnityEngine;

namespace Infrastructure.Level
{
    public class LevelData
    {
        private const string NUMLEVEL = "NumLevel";
        public int NumLevel
        {
            get { return PlayerPrefs.GetInt(NUMLEVEL); }
            set { PlayerPrefs.SetInt(NUMLEVEL, value); }
        }
    }
}