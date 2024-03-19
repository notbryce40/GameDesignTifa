using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    

    public bool ItemOnRegister(GameObject item)
    {

        if (currentItemIndex < ItemLocations.Length)
        {
            
            ItemLocations[currentItemIndex] = item;

            // Increment the index for the next item
            item.transform.SetParent(ItemLocations[currentItemIndex].transform);
            item.transform.localPosition = Vector3.zero;
            item.transform.localRotation = Quaternion.identity;
            
            currentItemIndex++;
            // Reset the local position and rotation of the item
            

            Debug.Log("Picked up item: " + (item != null ? item.name : "None"));

            return true;
        }
        else
        {
            Debug.LogWarning("Failed to pick up item: " + (item != null ? item.name : "None"));
            return false;
        }
    }
}
