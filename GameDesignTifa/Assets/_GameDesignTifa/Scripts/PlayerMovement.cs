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

    private Vector3 moveDirections;

    //Refs
   
    private Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        
    }

    private void Update()
    {
        Move();
    }

    /*private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveDirections = new Vector3(horizontalInput, 0f,verticalInput).normalized;
        moveDirections = transform.TransformDirection(moveDirections);

        
        if(moveDirections != Vector3.zero && isHoldingBox == false )
        {
            transform.rotation = Quaternion.LookRotation(moveDirections);
            Walk();
        }
        else if(moveDirections == Vector3.zero && isHoldingBox == false)
        {
            Idle();
        }
        else if(moveDirections == Vector3.zero && isHoldingBox == true)
        {
            holdbox();
        }
        else if(moveDirections != Vector3.zero && isHoldingBox == true )
        {
            transform.rotation = Quaternion.LookRotation(moveDirections);
            walkbox();
        }

        moveDirections *= moveSpeed;

        transform.Translate(moveDirections * moveSpeed * Time.deltaTime, Space.World);

    }*/
    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveDirections = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (moveDirections != Vector3.zero)
        {
            // Rotate the player based on horizontal input
            float targetAngle = Mathf.Atan2(moveDirections.x, moveDirections.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            // Determine whether to walk or walk while holding a box
            if (!isHoldingBox)
                Walk();
            else
                walkbox();
        }
        else
        {
            if (isHoldingBox)
            {
                // If no movement input, stop walking
                holdbox();
            }
            else
            {
                Idle();
            }
            
        }

        moveDirections *= moveSpeed;
        transform.Translate(moveDirections * Time.deltaTime, Space.World);
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
}
