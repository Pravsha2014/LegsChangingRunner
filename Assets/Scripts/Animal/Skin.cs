using System;
using UnityEngine;

public class Skin : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed = false;

    private bool _isEquipped;

    public event Action<bool> OnEquipped;

    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBuyed => _isBuyed;
    public bool IsEquipped => _isEquipped;

    private void OnEnable()
    {
        _isEquipped = true;
        OnEquipped?.Invoke(_isEquipped);
    }

    private void OnDisable()
    {
        _isEquipped = false;
        OnEquipped?.Invoke(_isEquipped);
    }

    public void Buy()
    {
        _isBuyed = true;
    }
}
