/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;

public class Shelf : MonoBehaviour
{
    public GameObject[] itemsToPickUp; // Reference to the items to pick up
    public class ShelfItem
    {
        public GameObject itemObject;
        
        public bool isVisible = true; // Whether the item is visible on the shelf
    }
    
    [SerializeField] public List<ShelfItem> items = new List<ShelfItem>(); // List of items on the shelf
    public Transform playerHand; // Reference to the player's hand for item instantiation

    public GameObject PickUpItem(int index)
    {
        Debug.Log("Picking up item at index: " + index);

        if (index >= 0 && index < items.Count)
        {
            if (items[index].isVisible)
            {
                GameObject pickedUpItem = items[index].itemObject;
                items[index].isVisible = false;
                // Toggle visibility of the item on the shelf
                pickedUpItem.SetActive(false);
                // Inside PickUpItem method in Shelf script
                Debug.Log("Picked up item: " + (pickedUpItem != null ? pickedUpItem.name : "None"));
                return pickedUpItem;
            }
        }
        return null;
    }
}*/
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

