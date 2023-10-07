using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    private readonly string _volumeString = "Volume";

    private AudioSource _volume;

    private void Start()
    {
        _volume = GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey(_volumeString) == false)
            PlayerPrefs.SetFloat(_volumeString, _volume.volume);

        _volume.volume = PlayerPrefs.GetFloat(_volumeString);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeString, _volume.volume);
    }
}
