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
    

    public bool ItemOnRegister(GameObject gameObject)
    {

        if (currentItemIndex < ItemLocations.Length)
        {
            
            ItemLocations[currentItemIndex] = gameObject;

            // Increment the index for the next item
            
            //gameObject.transform.SetParent(ItemLocations[currentItemIndex]);
            currentItemIndex++;
            //heldItem.transform.localPosition = Vector3.zero;
            //heldItem.transform.localRotation = Quaternion.identity;

            Debug.Log("Picked up item: " + (gameObject != null ? gameObject.name : "None"));

            return true;
        }
        return false;
    }
}
