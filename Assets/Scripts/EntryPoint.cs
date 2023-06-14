using GamePlay;
using Infrastructure;
using Infrastructure.Level;
using UI;
using UnityEngine;

public class EntryPoint: MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private float _upForce;
    [Header("BackGround Settings")]
    [SerializeField] private BackGround _backGrounds;
    [SerializeField] private float _moveSpeed;
    [Header("Ui Settings")]
    [SerializeField] private UIControl _uiPrefab;
    [Header("Level Settings")]
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private float _waitTimeToLose;
    [SerializeField] private float _waitTimeToWin;

    private LevelManager _levelManager;
    private Player _player;
    private UIControl _ui;
    private Coins _coins;

    private void Awake()
    {
        _levelManager = new LevelManager(_waitTimeToLose, _waitTimeToWin);

        _coins = new Coins();
        
        _ui = Instantiate(_uiPrefab);
        _ui.Init(_levelManager,_levelManager, _levelLoader, _coins);
          
        _player = Instantiate(_playerPrefab, transform.position, Quaternion.identity);
        _player.Init(_levelManager,_levelManager,_ui,_coins, _upForce);
          
        _backGrounds.Init(_levelManager,_moveSpeed);
                
    }
}