using UnityEngine;

public class UiPanelService : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _finishPanel;

    private readonly float _timePause = 0f;
    private readonly float _timePlay = 1f;
    private GameObject _currentActivePanel;
    private GameObject _lastActivePanel;

    private void Start()
    {
        _currentActivePanel = _mainMenuPanel;
        _currentActivePanel.SetActive(true);
        SetTimeScale();
    }

    public void SwitchPanel(GameObject panel)
    {
        _lastActivePanel = _currentActivePanel;
        _currentActivePanel.SetActive(false);
        _currentActivePanel = panel;
        _currentActivePanel.SetActive(true);

        SetTimeScale();
    }

    public void SwitchToLastPanel()
    {
        SwitchPanel(_lastActivePanel);
    }

    private bool IsCurrentPanelNeedPause() => _currentActivePanel != _gamePanel && _currentActivePanel != _finishPanel;

    private void SetTimeScale()
    {
        Time.timeScale = IsCurrentPanelNeedPause() ? _timePause : _timePlay;
    }
}