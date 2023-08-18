using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(ToolChanger))]
public class Player : MonoBehaviour
{
    public UnityAction CoinTaken;

    private Rigidbody _rigidbody;
    private ToolChanger _toolChanger;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _toolChanger = GetComponent<ToolChanger>();

        _toolChanger.ToolChanged += SetMaxAngularDrag;
    }

    private void OnDisable()
    {
        _toolChanger.ToolChanged -= SetMaxAngularDrag;
    }

    public void CoinChanged()
    {
        CoinTaken?.Invoke();
    }

    private void SetMaxAngularDrag(float maxAngularVelocity)
    {
        _rigidbody.maxAngularVelocity = maxAngularVelocity;
    }
}
