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
        OnEquipped?.Invoke(true);
    }

    private void OnDisable()
    {
        OnEquipped?.Invoke(false);
    }

    public void Buy()
    {
        _isBuyed = true;
    }
}
