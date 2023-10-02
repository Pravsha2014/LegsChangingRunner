using DG.Tweening;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private GameObject _playerSpawner;
    [SerializeField] private float _smoothSpeed;
    [SerializeField] private Vector3 _gameOffset = new(4f, 1.5f, -2);

    private readonly float _finishMovespeed = 0.5f;
    private readonly Vector3 _finishOffset = new(2, -0.4f, 0);
    private readonly Vector3 _finishRotation = new(0, -90, 0);
    private Transform _playerTransform;
    private bool _isPlaying = true;

    private void Awake()
    {
        _playerTransform = _playerSpawner.GetComponentInChildren<Player>().transform;
        transform.position = _playerTransform.position + _gameOffset;
    }

    private void FixedUpdate()
    {
        if (_isPlaying)
            Move();
    }

    private void Move()
    {
        var nextPosition = Vector3.Lerp(transform.position, _playerTransform.position + _gameOffset, _smoothSpeed * Time.fixedDeltaTime);
        transform.position = nextPosition;
    }

    public void AttachToPlayer(Transform finishPosition)
    {
        _isPlaying = false;
        transform.DORotate(_finishRotation, _finishMovespeed);
        Vector3 finishOffset = finishPosition.position + _finishOffset;
        transform.DOMove(finishOffset, _finishMovespeed);
    }
}
