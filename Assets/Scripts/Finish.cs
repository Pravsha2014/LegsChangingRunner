using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    private bool _isReached = false;

    public UnityEvent Reached;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Animal>(out _))
        {
            if (_isReached == false)
            {
                Reached?.Invoke();
            }
        }
    }

    public void StopChecking()
    {
        _isReached = true;
    }
}
