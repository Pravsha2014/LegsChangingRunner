using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private Wallet _wallet;

    private TMP_Text _text;
    private bool _isBuyed = false;
    private bool _isUsed = false;

    public int Price { get; private set; }

    private void Start()
    {
        _text = GetComponentInChildren<TMP_Text>();

        if (_isBuyed == false)
            _text.text = _price.ToString();
    }
}
