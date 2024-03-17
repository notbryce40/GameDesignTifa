using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounterUI : MonoBehaviour
{
    public Text display; // Reference to the UI Text element that displays the coins
    private CoinManager coinManager; // Reference to the CoinManager script

    void Start()
    {
        // Find the CoinManager component in the scene
        coinManager = FindObjectOfType<CoinManager>();
        display = GetComponent<Text>();
    }

    void Update()
    {
        // Update the UI Text to display the current number of coins
        display.text = "Coins: " + coinManager.GetTotalCoins().ToString();
    }
}
