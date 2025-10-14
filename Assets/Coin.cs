
using UnityEngine;
public class Coin : MonoBehaviour
{
    [SerializeField] public int coinValue;

    private bool hasTriggered;

    private CoinManager coinManager;

    private void Start()
    {
        coinManager = CoinManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered )
        {
            hasTriggered = true; 
            coinManager.ChangeCoins(coinValue);
            Destroy(gameObject);
        }
    }
}
