using GamePlay;
using Infrastructure.Coins;
using Infrastructure.Level;
using Infrastructure.Sounds;
using UI;
using UnityEngine;

namespace Infrastructure
{
    public class EntryPoint: MonoBehaviour
    {
        [Header("Player Settings")]
        [SerializeField] private PlayerConfig _playerConfig;
        [Header("BackGround Settings")]
        [SerializeField] private BackGround _backGrounds;
        [SerializeField] private float _moveSpeed=1f;
        [Header("Ui Settings")]
        [SerializeField] private UIControl _uiPrefab;
        [Header("Level Settings")]
        [SerializeField] private SceneLoader _sceneLoader;
        [SerializeField] private float _waitTimeToLose=2f;
        [SerializeField] private float _waitTimeToWin=3f;
        [SerializeField] private LevelContainer _levelContainer;
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
            
            _levelState = new LevelState(_levelLoader,_waitTimeToLose, _waitTimeToWin);
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
            _levelLoader = new LevelLoader(_levelContainer);
            _currentLevel = _levelLoader.LoadValue();
            _maxValue = _levelLoader.GetMaxLevelValue();
            _currentLevelSettings = _levelContainer.TryGetLevelSettings(_currentLevel);

        }

        private void CreateAndInitUIWindow()
        {
            _ui = Instantiate(_uiPrefab);
            _ui.Init(_levelState, _levelState, _sceneLoader,
                     _economic,_levelLoader, _soundState,_currentLevel, _maxValue);
        }

        private void CreateAndInitPlayer()
        {
            _player = Instantiate(_playerConfig.Player, transform.position, Quaternion.identity);
            _player.Init(_levelState, _levelState, _ui, _economic,_playerConfig);
        }

        private void InitSoundSourceOnLevel()
        {
            _soundsSource.Init(_levelState, _economic, _ui, _ui, _soundState, _soundData);
        }

        private void InitBackground()
        {
            _backGrounds.Init(_levelState, _currentLevelSettings.Speed, _currentLevelSettings.BlocksCountOnScene);
        }
    }
}