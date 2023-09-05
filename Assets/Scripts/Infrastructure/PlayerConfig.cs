using GamePlay;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs", order = 51)]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private float _upForce=5f;
    [SerializeField] private float _maxZRotation=35f;
    [SerializeField] private float _minZRotation=-35f;
    [SerializeField] private float _rotationSpeed=5f;

    public Player Player => _playerPrefab;
    public float UpForce => _upForce;
    public float MaxZRotation => _maxZRotation;
    public float MinZRotation => _minZRotation;
    public float RotationSpeed => _rotationSpeed;

}