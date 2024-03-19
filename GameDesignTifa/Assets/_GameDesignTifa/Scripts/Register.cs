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
    public Transform Item1;
    public Transform Item2;
    public Transform Item3;
    public Transform Item4;


    private int currentItemIndex = 0; // Index of the currently selected item


    // Start is called before the first frame update

    // Update is called once per frame
    //add item to child
    

    public bool ItemOnRegister(GameObject item)
    {

        if (currentItemIndex == 0)
        {

            // Increment the index for the next item
            
            item.transform.SetParent(Item1);
            item.transform.localPosition = Vector3.zero;
            //item.transform.localPosition = Vector3.zero;
            item.transform.localRotation = Quaternion.identity;
            
            currentItemIndex++;
            // Reset the local position and rotation of the item
            

            Debug.Log("Picked up item: " + (item != null ? item.name : "None"));

            return true;
        }if (currentItemIndex == 1)
        {

            // Increment the index for the next item
            
            item.transform.SetParent(Item2);
            item.transform.localPosition = Vector3.zero;
            //item.transform.localPosition = Vector3.zero;
            item.transform.localRotation = Quaternion.identity;
            
            currentItemIndex++;
            // Reset the local position and rotation of the item
            

            Debug.Log("Picked up item: " + (item != null ? item.name : "None"));

            return true;
        }if (currentItemIndex == 2)
        {

            // Increment the index for the next item
            
            item.transform.SetParent(Item3);
            item.transform.localPosition = Vector3.zero;
            //item.transform.localPosition = Vector3.zero;
            item.transform.localRotation = Quaternion.identity;
            
            currentItemIndex++;
            // Reset the local position and rotation of the item
            

            Debug.Log("Picked up item: " + (item != null ? item.name : "None"));

            return true;
        }
        if (currentItemIndex == 3)
        {

            // Increment the index for the next item
            
            item.transform.SetParent(Item4);
            item.transform.localPosition = Vector3.zero;
            //item.transform.localPosition = Vector3.zero;
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
