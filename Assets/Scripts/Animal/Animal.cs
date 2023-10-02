using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(ToolChanger))]
public abstract class Animal : MonoBehaviour
{
    private Rigidbody _rigidbody;
    protected ToolChanger toolChanger;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        toolChanger = GetComponent<ToolChanger>();

        toolChanger.ToolChanged += SetMaxAngularDrag;
    }

    private void OnDisable()
    {
        toolChanger.ToolChanged -= SetMaxAngularDrag;
    }

    private void SetMaxAngularDrag(float maxAngularVelocity)
    {
        _rigidbody.maxAngularVelocity = maxAngularVelocity;
    }
}
