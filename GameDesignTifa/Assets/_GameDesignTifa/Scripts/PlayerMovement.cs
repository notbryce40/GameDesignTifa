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
    private CharacterController controller;
    private Animator anim;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveZ = Input.GetAxis("Vertical");

        moveDirections = new Vector3 (0, 0, moveZ);
        moveDirections = transform.TransformDirection(moveDirections);

        
        if(moveDirections != Vector3.zero && isHoldingBox == false )
        {
            Walk();
        }
        else if(moveDirections != Vector3.zero && isHoldingBox == false)
        {
            Idle();
        }
        else if(moveDirections == Vector3.zero && isHoldingBox == true)
        {
            holdbox();
        }
        else if(moveDirections != Vector3.zero && isHoldingBox == true )
        {
            walkbox();
        }

        moveDirections *= moveSpeed;

        controller.Move(moveDirections* Time.deltaTime);

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
