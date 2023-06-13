using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class BackGround: MonoBehaviour
    {
        private Vector3 _startPosition;
        private float _repeatWidth;
        private float _speed;
        private bool _canMove;

        public void Init(float speed)
        {
            _speed = speed;
            _startPosition = transform.position;
            _repeatWidth = GetComponent<BoxCollider2D>().size.x / 2;
            _canMove = true;
        }

        void Update()
        {
            if(!_canMove)
                return;
            
            transform.Translate(Vector3.left * _speed * Time.deltaTime, Space.World);
            if (transform.position.x < _startPosition.x -_repeatWidth)
            {
                transform.position = _startPosition;
            }
        }
    }
}