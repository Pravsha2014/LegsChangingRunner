using DG.Tweening;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _smoothSpeed;
    [SerializeField] private Vector3 _playinOffset;

    private readonly float _finishMovespeed = 0.5f;
    private readonly Vector3 _finishOffset = new(2, -0.4f, 0);
    private readonly Vector3 _finishRotation = new(0, -90, 0);
    private Vector3 _currentVelocity = Vector3.zero;
    private bool _isPlaying = true;

    private void Awake()
    {
        transform.position = _playerTransform.position + _playinOffset;
    }

    private void LateUpdate()
    {
        if (_isPlaying)
        {
            Vector3 targetPosition = _playerTransform.position + _playinOffset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, _smoothSpeed);
        }
    }

    public void AttachToPlayer(Transform finishPosition)
    {
        _isPlaying = false;
        transform.DORotate(_finishRotation, _finishMovespeed);
        Vector3 finishOffset = finishPosition.position + _finishOffset;
        transform.DOMove(finishOffset, _finishMovespeed);
    }
}
