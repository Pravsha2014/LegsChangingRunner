using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class Wallet : MonoBehaviour
{
    private Player _player;

    public event UnityAction<int> ValueChanged;

    public int Amount { get; private set; } = 0;

    private void Start()
    {
        ValueChanged?.Invoke(Amount);

        _player = GetComponent<Player>();

        _player.CoinTaken += AddCoin;
    }

    private void OnDisable()
    {
        _player.CoinTaken -= AddCoin;
    }

    public void BuyItem(Item item)
    {
        Amount -= item.Price;
    }

    private void AddCoin()
    {
        Amount++;
        ValueChanged?.Invoke(Amount);
    }
}
