using UnityEngine;
using UnityEngine.Events;

public class ToolChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] _tools;
    [SerializeField] private ParticleSystem _fogParticle;

    private Tool _currentTool;

    public event UnityAction<float> ToolChanged;

    private void Start()
    {
        _currentTool = GetComponentInChildren<Tool>();
    }

    private void DisableCurrentTool()
    {
        _fogParticle.Play();
        _currentTool.gameObject.SetActive(false);
    }

    public void EnableChoosenTool(Tool tool)
    {
        if (tool != _currentTool)
        {
            DisableCurrentTool();

            tool.gameObject.SetActive(true);

            _currentTool = tool;

            ToolChanged?.Invoke(_currentTool.MaxAngularVelocity);
        }
    }
}
