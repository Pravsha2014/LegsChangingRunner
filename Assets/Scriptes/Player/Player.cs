using UnityEngine;

[RequireComponent (typeof(Rigidbody), typeof(ToolChanger))]
public class Player : MonoBehaviour 
{
    private Rigidbody _rb;
    private ToolChanger _toolChanger;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _toolChanger = GetComponent<ToolChanger>();

        _toolChanger.ToolChanged += SetMaxAngularDrag;
    }

    private void OnDisable()
    {
        _toolChanger.ToolChanged -= SetMaxAngularDrag;
    }

    private void SetMaxAngularDrag(float maxAngularVelocity)
    {
        _rb.maxAngularVelocity = maxAngularVelocity;
    }
}
