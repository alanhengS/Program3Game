/***************************************************************
* file: Coin.cs
* author: Alana Dubie
* class: CS 4700 – Game Development
* assignment: Program 3
* date last modified: 10/13/2025
*
* purpose: This script handles coin collection logic in the game.
* When the player collides with a coin, the coin value is added
* to the CoinManager, and the coin object is destroyed.
*
****************************************************************/

using UnityEngine;

// Detects player collision with a coin object and updates the coin count
public class Coin : MonoBehaviour
{
    [SerializeField] public int coinValue;

    private bool hasTriggered;

    private CoinManager coinManager;

    // Initializes the coinManager reference
    private void Start()
    {
        coinManager = CoinManager.instance;
    }

    // Detects collision with the player, updates coin count, and destroys the coin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            coinManager.ChangeCoins(coinValue);
            Destroy(gameObject);
        }
    }
}
