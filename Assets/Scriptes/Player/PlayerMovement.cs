using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.maxAngularVelocity = _rotationSpeed;
        _rigidbody.inertiaTensorRotation = Quaternion.identity;
    }

    private void FixedUpdate()
    {
        _rigidbody.AddRelativeTorque(_rotationSpeed, 0, 0, ForceMode.Force);
    }
}
