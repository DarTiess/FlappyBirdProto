using UnityEngine;
using Infrastructure.Level;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private Text _textData;
    [SerializeField] private Button _continueButton;
  
    private void Start()
    {
      //  AppsFlyer.UnityCallBack += OnConversionDataReceived;
        _continueButton.onClick.AddListener(NextScene);
    }

    private void NextScene()
    {
        _sceneLoader.StartGame();
    }

    private void OnConversionDataReceived(string conversionData)
    {
        Debug.Log("ConversionData: " + conversionData);
        _textData.text = conversionData;
    }
}

