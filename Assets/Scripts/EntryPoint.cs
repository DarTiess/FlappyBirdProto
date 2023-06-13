using Infrastructure;
using UnityEngine;

namespace DefaultNamespace
{
    public class EntryPoint: MonoBehaviour
    {
        [Header("Player Settings")]
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private float _upForce;
        [SerializeField] private TouchPad _touchPad;
        [Header("BackGround Settings")]
        [SerializeField] private BackGround _backGrounds;
        [SerializeField] private float _moveSpeed;

        private Player _player;
      

        private void Awake()
        {
            _player = Instantiate(_playerPrefab, transform.position, Quaternion.identity);
            _player.Init(_touchPad, _upForce);
            _backGrounds.Init(_moveSpeed);
                
        }
    }
}