using UnityEngine;
using UnityEngine.Serialization;

namespace Infrastructure.Level
{
    public class StartGame : MonoBehaviour
    {
        [FormerlySerializedAs("LevelLoader")]
        public SceneLoader _sceneLoader;

        private void Awake()
        {
            _sceneLoader.StartGame();    
        }
        
    }
}
