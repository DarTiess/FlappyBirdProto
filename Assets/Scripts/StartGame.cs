using UnityEngine;
using UnityEngine.Serialization;
using AppsFlyerSDK;
using Infrastructure.Level;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [FormerlySerializedAs("LevelLoader")]
    public SceneLoader _sceneLoader;
    [SerializeField]
    private Text TextData;
    [SerializeField] private Button continueButton;
  
    private void Start()
    {
        AppsFlyer.UnityCallBack += OnConversionDataReceived;
        continueButton.onClick.AddListener(NextScene);
    }

    private void NextScene()
    {
        _sceneLoader.StartGame();
    }

    private void OnConversionDataReceived(string conversionData)
    {
        Debug.Log("ConversionData: " + conversionData);
        TextData.text = conversionData;
    }
}

