using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ExitButton : MonoBehaviour
{
    private Button _button;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ExitGame);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ExitGame);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
