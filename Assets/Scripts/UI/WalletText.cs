using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class WalletText : MonoBehaviour
{
    [SerializeField] private GameObject _playerSpawner;

    private TMP_Text _text;
    private Wallet _wallet;

    private void OnEnable()
    {
        _wallet = _playerSpawner.GetComponentInChildren<Wallet>();
        _text = GetComponent<TMP_Text>();
        _wallet.ValueChanged += ShowCurrentValue;
        ShowCurrentValue();
    }

    private void OnDisable()
    {
        _wallet.ValueChanged -= ShowCurrentValue;
    }

    private void ShowCurrentValue()
    {
        _text.text = _wallet.Amount.ToString();
    }
}