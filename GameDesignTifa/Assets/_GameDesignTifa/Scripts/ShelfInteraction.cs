using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfInteraction : MonoBehaviour
{
    public GameObject[] itemsToToggle; // Reference to the items to toggle visibility
    private bool[] isItemAvailable; // Array to keep track of availability of each item
    private int totalAvailableItems; // Total count of available items

    private bool isPlayerNearby = false;
    private int currentItemIndex = 0; // Index of the currently selected item

    private void Start()
    {
        // Initialize the availability array
        isItemAvailable = new bool[itemsToToggle.Length];
        for (int i = 0; i < itemsToToggle.Length; i++)
        {
            isItemAvailable[i] = true; // Initially, all items are available
        }
        totalAvailableItems = itemsToToggle.Length;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }

    private void Update()
    {
        // Check for input when the player is nearby
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ToggleNextItemVisibility();
        }
    }

    private void ToggleNextItemVisibility()
    {
        // Toggle visibility of the next available item
        while (totalAvailableItems > 0)
        {
            if (isItemAvailable[currentItemIndex])
            {
                itemsToToggle[currentItemIndex].SetActive(!itemsToToggle[currentItemIndex].activeSelf);

                // Update availability status
                isItemAvailable[currentItemIndex] = !itemsToToggle[currentItemIndex].activeSelf;
                totalAvailableItems--;

                // Move to the next item
                currentItemIndex = (currentItemIndex + 1) % itemsToToggle.Length;
                break;
            }
            else
            {
                // Move to the next item
                currentItemIndex = (currentItemIndex + 1) % itemsToToggle.Length;
            }
        }
    }
}
