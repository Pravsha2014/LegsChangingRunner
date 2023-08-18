using DG.Tweening;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private readonly float _relativeTorqueYZ = 0f;
    private readonly float _movespeedAfterFinish = 0.8f;
    private readonly float _verticalOffset = 0.2f;
    private readonly float _finishShakeTime = 0.2f;
    private Rigidbody _rigidbody;
    private bool _isReachedFinish;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.maxAngularVelocity = _rotationSpeed;
        _rigidbody.inertiaTensorRotation = Quaternion.identity;
        _isReachedFinish = false;
    }

    private void FixedUpdate()
    {
        if (_isReachedFinish == false)
        {
            _rigidbody.AddRelativeTorque(_rotationSpeed, _relativeTorqueYZ, _relativeTorqueYZ, ForceMode.Force);
        }
    }

    public void FinishRotate(Transform endPosition)
    {
        _isReachedFinish = true;
        _rigidbody.isKinematic = true;
        _rigidbody.constraints = RigidbodyConstraints.None;

        Vector3[] finishShakeWay =
            {
            new Vector3(endPosition.position.x ,endPosition.position.y + _verticalOffset, endPosition.position.z)
            };

        transform.DOMove(endPosition.position, _movespeedAfterFinish);
        transform.DORotateQuaternion(endPosition.rotation, _movespeedAfterFinish).OnComplete(() =>
        {
            transform.DOPath(finishShakeWay, _finishShakeTime)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Linear);
        });
    }
}
