using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Obstacle : MonoBehaviour
{
    private readonly float _destroyDelay = 7f;
    private BoxCollider _boxCollider;
    private Rigidbody[] _rigidbodies;
    private Coroutine _coroutine;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Axe>(out _))
        {
            _boxCollider.enabled = false;
            
            foreach(var rigidbody in _rigidbodies)
            {
                rigidbody.constraints = RigidbodyConstraints.None;
            }

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(DestroyWithDelay());
        }
    }

    private IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds(_destroyDelay);

        Destroy(gameObject);
    }
}
