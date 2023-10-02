using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class WalletText : MonoBehaviour
{
    [SerializeField] private GameObject _playerSpawner;

    private TMP_Text _text;
    private Wallet _wallet;

    private void Start()
    {
        _wallet = _playerSpawner.GetComponentInChildren<Wallet>();
        _text = GetComponent<TMP_Text>();
        _wallet.ValueChanged += ShowCurrentValue;
    }

    private void OnDisable()
    {
        _wallet.ValueChanged -= ShowCurrentValue;
    }

    private void ShowCurrentValue(int value)
    {
        _text.text = value.ToString();
    }
}
