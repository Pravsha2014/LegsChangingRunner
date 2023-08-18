using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class WalletText : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        _wallet.ValueChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _wallet.ValueChanged -= ChangeValue;
    }

    private void ChangeValue(int value)
    {
        _text.text = value.ToString();
    }
}
