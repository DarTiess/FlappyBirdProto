using UI.Touch;
using UnityEngine;

namespace GamePlay
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerEffects))]
    public class PlayerMovement : MonoBehaviour
    {
        private ITouchPad _touchPad;
        private float _upForce;
        
        private  Camera _camera;
        private  Vector3 _minPoint;
        private  Vector3 _maxPoint;
        private Rigidbody2D _rigidbody;
        private Quaternion _maxRotation;
        private Quaternion _minRotation;
        private float _rotationSpeed;
        private IMoveAnimation _playerAnimator;
        private PlayerEffects _playerEffects;

        public void Init(ITouchPad touchPad,  PlayerConfig config, IMoveAnimation playerAnimator)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _playerEffects = GetComponent<PlayerEffects>();
            _camera=Camera.main;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            _touchPad = touchPad;
            _touchPad.ClickedTouch += MoveUpImpulse;
            _upForce = config.UpForce;
            _playerAnimator = playerAnimator;

            _maxRotation = Quaternion.Euler(0, 0, config.MaxZRotation);
            _minRotation = Quaternion.Euler(0, 0, config.MinZRotation);
            _rotationSpeed = config.RotationSpeed;
            SetCameraLimits();
        }

        private void Update()
        {
            Vector2 clampedPosition = _rigidbody.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, _minPoint.x, _maxPoint.x);
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, _minPoint.y, _maxPoint.y);
            _rigidbody.position = clampedPosition;
        }

        private void OnDisable()
        {
            _touchPad.ClickedTouch -= MoveUpImpulse;
        }

        public void OnStartingPlayGame()
        {
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        public void GameStop()
        {
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            _playerEffects.StopEffects();
        }

        private void SetCameraLimits()
        {
            _minPoint = _camera.ViewportToWorldPoint(new Vector2(0, 0));
            _maxPoint = _camera.ViewportToWorldPoint(new Vector2(1, 1));
        }
        private void MoveUpImpulse()
        {
            _playerEffects.FlyEffect();
            _playerAnimator.MoveAnimation();
            _rigidbody.AddForce(Vector3.up * _upForce, ForceMode2D.Impulse);
        }
    }
}