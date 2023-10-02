using UnityEngine.Events;

public class Player : Animal
{
    public UnityAction CoinTaken;

    public void CoinChanged()
    {
        CoinTaken?.Invoke();
    }
}
