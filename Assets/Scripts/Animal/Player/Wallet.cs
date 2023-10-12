using System;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class Wallet : MonoBehaviour
{
    private readonly string _coinsKey = "Coin";
    private Player _player;

    public event Action ValueChanged;

    public int Amount { get; private set; } = 0;

    private void Awake()
    {
        if(PlayerPrefs.HasKey(_coinsKey) == false)
            PlayerPrefs.SetInt(_coinsKey, 0);
    }

    private void Start()
    {
        _player = GetComponent<Player>();
        Amount = PlayerPrefs.GetInt(_coinsKey);
        ValueChanged?.Invoke();

        _player.CoinTaken += AddCoin;
    }

    private void OnDisable()
    {
        _player.CoinTaken -= AddCoin;

    }

    public void TakeAwayCoins(int price)
    {
        Amount -= price;
        ValueChanged?.Invoke();
    }

    public void SaveMoney()
    {
        PlayerPrefs.SetInt(_coinsKey, Amount);
    }

    private void AddCoin()
    {
        Amount++;
        ValueChanged?.Invoke();
    }
}
