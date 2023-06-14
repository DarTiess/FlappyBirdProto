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
        [FormerlySerializedAs("levelLoader")]
        [Header("Level Settings")]
        [SerializeField] private SceneLoader _sceneLoader;
        [SerializeField] private float waitTimeToLose=2f;
        [SerializeField] private float waitTimeToWin=3f;
        [FormerlySerializedAs("sounds")]
        [Header("Sound Settings")]
        [SerializeField] private SoundsSource _soundsSource;

        private LevelState _levelState;
        private Player _player;
        private UIControl _ui;
        private CoinsData _coinsData;
        private SoundData _soundData;
        private bool _soundState;

        private void Awake()
        {
            _levelState = new LevelState(waitTimeToLose, waitTimeToWin);
            CreateCoinsData();
            CreateSoundData();
            CreateAndInitUIWindow();
            CreateAndInitPlayer();
            InitSoundSourceOnLevel();
            InitBackground();
        }

        private void CreateCoinsData()
        {
            _coinsData = new CoinsData();
        }

        private void CreateSoundData()
        {
            _soundData = new SoundData();
            _soundState = _soundData.GetSoundState();
        }

        private void CreateAndInitUIWindow()
        {
            _ui = Instantiate(uiPrefab);
            _ui.Init(_levelState, _levelState, _sceneLoader, _coinsData, _soundState);
        }

        private void CreateAndInitPlayer()
        {
            _player = Instantiate(playerPrefab, transform.position, Quaternion.identity);
            _player.Init(_levelState, _levelState, _ui, _coinsData, upForce);
        }

        private void InitSoundSourceOnLevel()
        {
            _soundsSource.Init(_levelState, _coinsData, _ui, _ui, _soundState, _soundData);
        }

        private void InitBackground()
        {
            backGrounds.Init(_levelState, moveSpeed);
        }
    }
}