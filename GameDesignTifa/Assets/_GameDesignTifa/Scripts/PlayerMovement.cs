using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Vars
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private bool isHoldingBox;
    [SerializeField] private bool isWalking;

    public Shelf currentShelf; // Reference to the currently interacted shelf
    public Register currentRegister;
    public Transform playerHand; // Reference to the player's hand for item instantiation

    private Vector3 moveDirections;
    private CharacterController CharCC;

    //Refs
    private GameObject heldItem; // Reference to the item currently held by the player
    private GameObject deparent;
    private Animator anim;

    private void Start()
    {
        CharCC = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        
    }

    private void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Ensure there is a valid shelf reference
            if (currentShelf != null)
            {
                if(heldItem == null)
                {
                    PickUpItemFromShelf();
                }
            }
            else if(currentRegister!= null){
                PlaceOnRegister();
            }
        }
    }
    
    private void Move()
    {
        moveDirections = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (moveDirections != Vector3.zero)
        {
            // Rotate the player based on horizontal input
            float targetAngle = Mathf.Atan2(moveDirections.x, moveDirections.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            if (heldItem == null)
                Walk();
            else
                walkbox();
        }
        else
        {
            if (heldItem == null)
                Idle();
            else
                holdbox();
        }



        moveDirections *= moveSpeed;
        //transform.Translate(moveDirections * Time.deltaTime, Space.World);
        CharCC.Move(moveDirections * Time.deltaTime);
    }

    private void Idle()
    {
        anim.SetBool("isWalking", false); 
        anim.SetBool("isHoldingBox", false);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetBool("isWalking", true);
        anim.SetBool("isHoldingBox", false);
    }

    private void holdbox()
    {
        anim.SetBool("isWalking", false);
        anim.SetBool("isHoldingBox", true);
    }

    private void walkbox()
    {
        moveSpeed = walkSpeed;
        anim.SetBool("isWalking", true);
        anim.SetBool("isHoldingBox", true);
    }

    private void PickUpItemFromShelf()
    {
        if (heldItem != null)
        {
            DropItem();
        }

        GameObject pickedUpItem = currentShelf.PickUpNextItem();
        if (pickedUpItem != null)
        {
            heldItem = pickedUpItem;
            heldItem.transform.SetParent(playerHand);
            heldItem.transform.localPosition = Vector3.zero;
            heldItem.transform.localRotation = Quaternion.identity;
        }
    }
    private void DropItem()
    {

        Destroy(heldItem);
        heldItem = null;
    }

    /*private void PlaceOnRegister()
    {
        if (heldItem != null)
        {
            bool boolPlaceItem = currentRegister.ItemOnRegister(heldItem);
            if (boolPlaceItem == true){
                Destroy(heldItem);
            }
        }
    }
    if (heldItem != null && currentRegister != null)
    {
        bool isPlaced = currentRegister.ItemOnRegister(heldItem);
        if (isPlaced)
        {
            // Instantiate a copy of the held item on the register
            GameObject registerItem = Instantiate(heldItem, currentRegister.transform);
            registerItem.transform.localPosition = Vector3.zero;
            registerItem.transform.localRotation = Quaternion.identity;

            // Destroy the held item in the player's hand
            Destroy(heldItem);
            heldItem = null;
        }
    }*/
    private void PlaceOnRegister()
    {
    if (heldItem != null && currentRegister != null)
    {
        //heldItem.transform.SetParent(null);bool isPlaced = 
        currentRegister.ItemOnRegister(heldItem);
        /*if (isPlaced)
        {
            heldItem = null; // Don't destroy the item here if it's successfully placed
        }*/
    }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player entered the trigger of a shelf
        Shelf shelf = other.GetComponent<Shelf>();
        Register register = other.GetComponent<Register>();
        if (shelf != null)
        {
            currentShelf = shelf;
        }
        if(register != null)
        {
            currentRegister = register;
        }

    }

    // OnTriggerExit is called when the Collider other has stopped touching the trigger
    void OnTriggerExit(Collider other)
    {
        // Check if the player exited the trigger of a shelf
        if (other.GetComponent<Shelf>() == currentShelf)
        {
            currentShelf = null;
        }
        if (other.GetComponent<Register>() == currentRegister)
        {
            currentRegister = null;
        }


    }


}
