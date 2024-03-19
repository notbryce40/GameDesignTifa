using UnityEngine;
using UnityEngine.UI;

public class CoinCounterUI : MonoBehaviour
{
    public Text display; // Reference to the UI Text element that displays the coins
    
    public int totalCoins = 10; // Total coins count, initialized to 10

    // Start is called before the first frame update
    void Start()
    {
        display = GetComponent<Text>();
    }

    void Update()
    {
        display.text = "Coins: " + totalCoins;
    }

    // Update the display text
    private void UpdateDisplay()
    {
        display.text = "Coins: " + totalCoins;
    }

    // Method to update the total coins
    public void UpdateTotalCoins()
    {
        totalCoins += 10;
        UpdateDisplay();
    }

}
