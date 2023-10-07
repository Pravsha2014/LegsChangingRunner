using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(ToolChanger))]
public abstract class Animal : MonoBehaviour
{
    protected ToolChanger toolChanger;
    protected Skin currentSkin;
    private Rigidbody _rigidbody;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
        toolChanger = GetComponent<ToolChanger>();
        currentSkin = GetComponentInChildren<Skin>();

        toolChanger.Changed += SetMaxAngularDrag;
    }

    private void OnDisable()
    {
        toolChanger.Changed -= SetMaxAngularDrag;
    }

    private void SetMaxAngularDrag(float maxAngularVelocity)
    {
        _rigidbody.maxAngularVelocity = maxAngularVelocity;
    }
}
