using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Level
{
    [CreateAssetMenu(fileName = "LevelLoader", menuName = "LevelLoader", order = 51)]
    public class SceneLoader : ScriptableObject, ISceneLoader
    {
        public List<string> NameScene;

       
        private int NumScene
        {                    
            get { return PlayerPrefs.GetInt("NumScene"); }
            set { PlayerPrefs.SetInt("NumScene", value); }
        }

        public void StartGame()
        {
            if (NumScene == 0) NumScene = 1;
            LoadScene();    
        }

        public void LoadNextScene()
        {
            NumScene += 1;
            LoadScene();           
        }

        public void LoadScene()
        {
            int numLoadedScene = NumScene;
            if (numLoadedScene <= NameScene.Count){numLoadedScene -= 1;}
            if (numLoadedScene > NameScene.Count){numLoadedScene = (numLoadedScene - 1) % NameScene.Count;}
            Debug.Log("Load Scene Number " + numLoadedScene);

            SceneManager.LoadScene(NameScene[numLoadedScene]);
        }

        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
