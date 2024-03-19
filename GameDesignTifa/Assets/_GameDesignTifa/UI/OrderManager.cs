using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public Text display; // Reference to the UI Text component
    private NPCMovement npcMovement; // Reference to the NPCMovement script

    // Start is called before the first frame update
    void Start()
    {
        display = GetComponent<Text>();
        npcMovement = FindObjectOfType<NPCMovement>(); // Find and assign the NPCMovement script
    }

    // Update is called once per frame
    void Update()
    {
        if (npcMovement != null && npcMovement.currentOrder != null)
        {
            // Access the currentOrder array from NPCMovement
            NPCMovement.OrderItem[] currentOrder = npcMovement.currentOrder;

            // Update the UI Text with the current order
            display.text = "Current Order: " + string.Join(", ", currentOrder);
        }
        else
        {
            display.text = "No order available"; // Display a message if currentOrder is null or npcMovement is not found
        }
    }
}
