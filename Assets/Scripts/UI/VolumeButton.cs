using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class VolumeButton : MonoBehaviour
{
    [SerializeField] private VolumeSlider _volumeSlider;
    [SerializeField] private Sprite _imageSoundOn;
    [SerializeField] private Sprite _imageSoundOff;

    private readonly float _soundOffValue = 0f;
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
    }

    public void ChangeImage(float volume) => _button.image.sprite = volume > _soundOffValue ? _imageSoundOn : _imageSoundOff;
}
