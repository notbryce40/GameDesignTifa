using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Register : MonoBehaviour
{
    //put item on register
    //remove items from register
    //4 empty childs for items 
    //check if in order
    //
    public GameObject[] ItemLocations;

    private int currentItemIndex = 0; // Index of the currently selected item


    // Start is called before the first frame update

    // Update is called once per frame
    //add item to child
    

    bool ItemOnRegister()
    {

        if (currentItemIndex < ItemLocations.Length)
        {
            
            GameObject pickedUpItem = ItemLocations[currentItemIndex];

            // Increment the index for the next item
            currentItemIndex++;

            Debug.Log("Picked up item: " + (pickedUpItem != null ? pickedUpItem.name : "None"));

            return pickedUpItem;
        }
        return true;
    }
}
