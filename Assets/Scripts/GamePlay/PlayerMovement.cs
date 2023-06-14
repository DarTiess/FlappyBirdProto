using System;
using Infrastructure.Level;
using UI.Touch;
using UnityEngine;

namespace GamePlay
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private ITouchPad _touchPad;
        private IUpSound _sound;
        private float _upForce;
        
        private  Camera _camera;
        private  Vector3 _minPoint;
        private  Vector3 _maxPoint;
        private Rigidbody2D _rigidbody;

        public void Init(ITouchPad touchPad,IUpSound sound, float upForce)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _camera=Camera.main;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            _touchPad = touchPad;
            _sound = sound;
            _touchPad.ClickedTouch += MoveUpImpulse;
            _upForce = upForce;
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

        public void GameOver()
        {
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        private void SetCameraLimits()
        {
            _minPoint = _camera.ViewportToWorldPoint(new Vector2(0, 0));
            _maxPoint = _camera.ViewportToWorldPoint(new Vector2(1, 1));
        }
        private void MoveUpImpulse()
        {
            _rigidbody.AddForce(Vector3.up * _upForce, ForceMode2D.Impulse);
            _sound.PlayUpSound();
        }
    }
}