using System;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class Wallet : MonoBehaviour
{
    private readonly string _coins = "Coin";
    private Player _player;

    public event Action ValueChanged;

    public int Amount { get; private set; } = 0;

    private void Awake()
    {
        if(PlayerPrefs.HasKey(_coins) == false)
            PlayerPrefs.SetInt(_coins, 0);
    }

    private void Start()
    {
        _player = GetComponent<Player>();
        Amount = PlayerPrefs.GetInt(_coins);
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
        PlayerPrefs.SetInt(_coins, Amount);
    }

    private void AddCoin()
    {
        Amount++;
        ValueChanged?.Invoke();
    }
}
