
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    public GameObject[] itemsToPickUp; // Reference to the items to pick up
    //public Transform playerHand; // Reference to the player's hand for item instantiation

    private int currentItemIndex = 0; // Index of the currently selected item

    public GameObject PickUpNextItem()
    {
        // Check if there are available items
        if (currentItemIndex < itemsToPickUp.Length)
        {
            
            GameObject pickedUpItem = itemsToPickUp[currentItemIndex];

            // Increment the index for the next item
            currentItemIndex++;

            Debug.Log("Picked up item: " + (pickedUpItem != null ? pickedUpItem.name : "None"));

            return pickedUpItem;
        }
        else
        {
            Debug.Log("No more items available on the shelf.");
            return null;
        }
    }
}

