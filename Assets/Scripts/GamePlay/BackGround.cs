using Infrastructure.Level;
using UnityEngine;

namespace GamePlay
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(BlocksSpawner))]
    public class BackGround: MonoBehaviour
    {
        [SerializeField] private float yBlocksPosition=-2.94f;

        private Vector3 _startPosition;
        private float _repeatWidth;
        private float _speed;
        private bool _canMove;
        private BlocksSpawner _blocksSpawner;
        private ILevelEvents _levelEvents;

        private void Update()
        {
            if(!_canMove)
                return;
            
            transform.Translate(Vector3.left * _speed * Time.deltaTime, Space.World);
        }

        private void LateUpdate()
        {
            if (transform.position.x < _startPosition.x -_repeatWidth)
            {
                RepositionBackground();
            }
        }

        private void OnDisable()
        {
            _levelEvents.PlayGame -= StartingMove;
            _levelEvents.LevelLost -= StopMoving;
        }

        public void Init(ILevelEvents levelEvents,float speed)
        {
            _levelEvents = levelEvents;
            _levelEvents.PlayGame += StartingMove;
            _levelEvents.LevelLost += StopMoving;
            _speed = speed;
            _startPosition = transform.position;
            _blocksSpawner = GetComponent<BlocksSpawner>();
            _repeatWidth = GetComponent<BoxCollider2D>().size.x / 2;
            
            _blocksSpawner.CreateBlocks(transform.position+new Vector3(_repeatWidth,yBlocksPosition,0f), transform);
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