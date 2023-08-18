using UnityEngine;

public class UiPanelService : MonoBehaviour
{
    [SerializeField] private GameObject _uILayerHUD;
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private Finish _finish;

    public void SwitchGamePanelToFinishPanel()
    {
        _uILayerHUD.SetActive(false);
        _finishPanel.SetActive(true);
    }
}
