using System;
using UnityEngine;

public class ToolChanger : MonoBehaviour
{
    private ParticleSystem _fogParticle;
    private Tool _currentTool;

    public event Action<float> ToolChanged;

    private void Start()
    {
        _fogParticle = GetComponentInChildren<ParticleSystem>();
        _currentTool = GetComponentInChildren<Tool>();
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

    private void DisableCurrentTool()
    {
        _fogParticle.Play();
        _currentTool.gameObject.SetActive(false);
    }
}
