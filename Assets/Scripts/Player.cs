using DefaultNamespace;
using Infrastructure;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private ITouchPad _touchPad;
    private Rigidbody2D _rigidbody;
    private float _upForce;
    private bool _canMove;

    public void Init(ITouchPad touchPad, float upForce)
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _touchPad = touchPad;
        _touchPad.ClickedTouch += MoveUpImpulse;
        _upForce = upForce;
    }

    private void MoveUpImpulse()
    {
        _rigidbody.AddForce(Vector3.up * _upForce, ForceMode2D.Impulse);
    }
}
