/***************************************************************
* file: CoinManager.cs
* author: Alana Dubie
* class: CS 4700 – Game Development
* assignment: Program 3
* date last modified: 10/13/2025
*
* purpose: This script manages the player's coin count. It updates
* the on-screen display and keeps track of total coins collected.
*
****************************************************************/


using UnityEngine;
using TMPro;
    
// Tracks and updates the player's total coin count and displays it on the UI
public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    private int coins;
    [SerializeField] private TMP_Text coinsDisplay;

    // Initializes the singleton instance
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    // Updates the coin display each frame
    private void OnGUI()
    {
        coinsDisplay.text = coins.ToString();
    }

    // Changes the coin count by the specified amount
    public void ChangeCoins(int amount)
    {
        coins += amount;
    }
}
