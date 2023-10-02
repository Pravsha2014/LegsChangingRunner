using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    private Skin _currentSkin;

    private void Start()
    {
        _currentSkin = GetComponentInChildren<Skin>();
    }

    public void ChangeSkin(Skin skin)
    {
        _currentSkin.gameObject.SetActive(false);
        _currentSkin = skin;
        _currentSkin.gameObject.SetActive(true);
    }
}
