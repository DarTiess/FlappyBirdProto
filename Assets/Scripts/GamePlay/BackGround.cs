using System;
using Infrastructure.Coins;
using Infrastructure.Level;
using UnityEngine;
using UnityEngine.Serialization;

namespace GamePlay
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(BlocksSpawner))]
    public class BackGround: MonoBehaviour
    {
        [SerializeField] private float _yBlocksPosition=-2.94f;
       
        private Vector3 _startPosition;
        private float _halfSize;
        private float _speed;
        private bool _canMove;
        private BlocksSpawner _blocksSpawner;
        private ILevelEvents _levelEvents;
        private float _repeatWidth;
        private int _indexBack=0;
        private float _backGroundWidth;

        private void Update()
        {
            if(!_canMove)
                return;
            
            transform.Translate(Vector3.left * _speed * Time.deltaTime, Space.World);
        }

        private void LateUpdate()
        {
            if (transform.position.x < _startPosition.x - _repeatWidth)
            {
                RepositionBackground();
            }
        }

        private void OnDisable()
        {
            _levelEvents.PlayGame -= StartingMove;
            _levelEvents.LevelLost -= StopMoving;
        }

        public void Init(ILevelEvents levelEvents,float speed, int countBlocks)
        {
            _levelEvents = levelEvents;
            _speed = speed;
            _startPosition = transform.position;
            _blocksSpawner = GetComponent<BlocksSpawner>();
            _backGroundWidth = GetComponent<BoxCollider2D>().size.x;
            _halfSize = _backGroundWidth/ 2;
            _repeatWidth = _halfSize + (_halfSize / 2);
            
            _levelEvents.PlayGame += StartingMove;
            _levelEvents.LevelLost += StopMoving;
            _levelEvents.ChangeLevelSetting += ChangeSettings;

            _blocksSpawner.CreateBlocks(transform.position+new Vector3(_halfSize,_yBlocksPosition,0f),
                                        transform, countBlocks);
        }

        private void ChangeSettings(Level settings)
        {
            _speed = settings.Speed;
            _blocksSpawner.ChangeBlocksCountOnScene(settings.BlocksCountOnScene);
            
        }
        

        private void RepositionBackground()
        {
            transform.position = _startPosition;
        
            _blocksSpawner.SetBlocks();
        }

        private void StopMoving()
        {
            _canMove = false;
        }

        private void StartingMove()
        {
            _canMove = true; 
            _blocksSpawner.SetBlocks();
        }
    }
}