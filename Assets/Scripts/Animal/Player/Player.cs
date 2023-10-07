using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Wallet))]
public class Player : Animal
{
    private Wallet _wallet;

    public UnityAction CoinTaken;

    private void Start()
    {
        _wallet = GetComponent<Wallet>();
    }

    public void CoinChanged()
    {
        CoinTaken?.Invoke();
    }

    public void EquipSkin(Skin skin)
    {
        currentSkin.gameObject.SetActive(false);
        currentSkin = skin;
        currentSkin.gameObject.SetActive(true);
    }

    public void BuySkin(Skin skin)
    {
        _wallet.TakeAwayCoins(skin.Price);
    }
}
