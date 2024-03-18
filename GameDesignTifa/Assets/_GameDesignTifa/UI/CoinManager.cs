using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int totalCoins;

    // Start is called before the first frame update
    void Start()
    {
        totalCoins = 10; // Initialize total coins to zero
    }

    // Call this method when a purchase is made
    public void AddCoins(int coinsToAdd)
    {
        totalCoins += coinsToAdd;
        Debug.Log("Coins added: " + coinsToAdd + ". Total coins: " + totalCoins);
    }

    // Call this method to get the current coin count
    public int GetTotalCoins()
    {
        return totalCoins;
    }

    // Update is called once per frame
    void Update()
    {
        // Here you can handle any updates related to coins
    }
}
