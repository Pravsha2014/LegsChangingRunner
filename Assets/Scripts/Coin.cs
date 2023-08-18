using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool _isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_isCollected)
        {
            return;
        }

        if (other.TryGetComponent(out Player player))
        {
            _isCollected = true;
            player.CoinChanged();
            Destroy(gameObject);
        }
    }
}
