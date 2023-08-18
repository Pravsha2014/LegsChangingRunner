using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class Wallet : MonoBehaviour
{
    private Player _player;

    public event UnityAction<int> ValueChanged;

    public int Amount { get; private set; }

    private void Start()
    {
        Amount = 0;

        ValueChanged?.Invoke(Amount);

        _player = GetComponent<Player>();

        _player.CoinTaken += AddCoin;
    }

    private void OnDisable()
    {
        _player.CoinTaken -= AddCoin;
    }

    private void AddCoin()
    {
        Amount++;
        ValueChanged?.Invoke(Amount);
    }
}
