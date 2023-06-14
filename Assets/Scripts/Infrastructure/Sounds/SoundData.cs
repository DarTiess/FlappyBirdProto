using UnityEngine;

namespace Infrastructure.Sounds
{
    public class SoundData : ISoundData, ISoundDataChange
    {
    
        private bool SoundState
        {                    
            get { return PlayerPrefs.GetInt("SoundState") == 1 ? true : false; } 
            set { PlayerPrefs.SetInt("SoundState", value ? 1 : 0); }
        }

        public void ChangeSoundState(bool state)
        {
            SoundState = state;
        }

        public bool GetSoundState()
        {
            return SoundState;
        }
    }
}