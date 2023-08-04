using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _smoothSpeed;

    private void Start()
    {
        transform.position = new(transform.position.x, _playerTransform.position.y, _playerTransform.position.z);
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = new(transform.position.x, _playerTransform.position.y, _playerTransform.position.z);

        transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed); ;
    }
}
