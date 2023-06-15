using GamePlay;
using Infrastructure.Coins;
using Infrastructure.Level;
using Infrastructure.Sounds;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Infrastructure
{
    public class EntryPoint: MonoBehaviour
    {
        [Header("Player Settings")]
        [SerializeField] private Player playerPrefab;
        [SerializeField] private float upForce=5f;
        [Header("BackGround Settings")]
        [SerializeField] private BackGround backGrounds;
        [SerializeField] private float moveSpeed=1f;
        [Header("Ui Settings")]
        [SerializeField] private UIControl uiPrefab;
        [FormerlySerializedAs("_sceneLoader")]
        [FormerlySerializedAs("levelLoader")]
        [Header("Level Settings")]
        [SerializeField] private SceneLoader sceneLoader;
        [SerializeField] private float waitTimeToLose=2f;
        [SerializeField] private float waitTimeToWin=3f;
        [SerializeField] private LevelContainer levelContainer;
        [FormerlySerializedAs("sounds")]
        [Header("Sound Settings")]
        [SerializeField] private SoundsSource _soundsSource;

        private LevelState _levelState;
        private Player _player;
        private UIControl _ui;
        private Economic _economic;
        private SoundData _soundData;
        private LevelLoader _levelLoader;
        private bool _soundState;
        private int _currentLevel;
        private int _maxValue;
        private Level.Level _currentLevelSettings;

        private void Awake()
        {
            CreateCoinsData();
            CreateSoundData();
            CreateLevelData();
            
            _levelState = new LevelState(_levelLoader,waitTimeToLose, waitTimeToWin);
            CreateAndInitUIWindow();
            CreateAndInitPlayer();
            InitSoundSourceOnLevel();
            InitBackground();
        }

        private void CreateCoinsData()
        {
            _economic = new Economic();
        }

        private void CreateSoundData()
        {
            _soundData = new SoundData();
            _soundState = _soundData.GetSoundState();
        }

        private void CreateLevelData()
        {
            _levelLoader = new LevelLoader(levelContainer);
            _currentLevel = _levelLoader.LoadValue();
            _maxValue = _levelLoader.GetMaxLevelValue();
            _currentLevelSettings = levelContainer.TryGetLevelSettings(_currentLevel);

        }

        private void CreateAndInitUIWindow()
        {
            _ui = Instantiate(uiPrefab);
            _ui.Init(_levelState, _levelState, sceneLoader,
                     _economic,_levelLoader, _soundState,_currentLevel, _maxValue);
        }

        private void CreateAndInitPlayer()
        {
            _player = Instantiate(playerPrefab, transform.position, Quaternion.identity);
            _player.Init(_levelState, _levelState, _ui, _economic, upForce);
        }

        private void InitSoundSourceOnLevel()
        {
            _soundsSource.Init(_levelState, _economic, _ui, _ui, _soundState, _soundData);
        }

        private void InitBackground()
        {
            backGrounds.Init(_levelState, _currentLevelSettings.Speed, _currentLevelSettings.BlocksCountOnScene);
        }
    }
}