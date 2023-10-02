using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    private readonly float _volumeOffValue = 0f;
    private float _volumeBeforeSoundOff;
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    public void SwitchValue()
    {
        if(IsSoundOn())
        {
            _volumeBeforeSoundOff = _slider.value;
            _slider.value = _volumeOffValue;
        }
        else
        {
            _slider.value = _volumeBeforeSoundOff;
        }
    }

    private bool IsSoundOn()
    {
        return _slider.value > _volumeOffValue;
    }
}
