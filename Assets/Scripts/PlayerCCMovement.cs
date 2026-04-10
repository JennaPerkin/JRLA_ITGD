using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCCMovement : MonoBehaviour
{
    [Header("References")]
    private CharacterController controller;
    [SerializeField] private Transform camera;
    [SerializeField] private Animator animator;

    [Header("Input")]
    private float moveInput;
    private float turnInput;

    [Header("Movement Setting")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float turnSpeed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = 9.81f;
    private float verticalVelocity;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        if(controller == null)
        {
            Debug.Log("Missing Character Controller Component");
        }
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
        Movement();
    }

    private void Movement()
    {
        //Turn and movement are the two forms of movement
        //turn rotates the player
        //GroundMovement moves the player to their next location
        Turn();
        GroundMovement();
    }

    private void InputManagement()
    {
        //Assigns Input Floats to Axes
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    private void GroundMovement()
    {
        //assigns move vector based on Vertical and Horizontal player inputs
        Vector3 move = new Vector3(turnInput, 0, moveInput);
        //transform directions from world to local space based on camera location
        move = camera.transform.TransformDirection(move);
        //move.y = 0;
        //Move.y is determined by our jump, in vertical force calculation
        move.y = VerticalForceCalculation();
        move *= moveSpeed;
        //multiply by time.deltatime since we're running in update
        controller.Move(move * Time.deltaTime);
    }

    private float VerticalForceCalculation()
    {
        //if controller is grounded, vertical velocity is zero, uncless the player jumps
        if(controller.isGrounded)
        {
            verticalVelocity = 0;
            if(Input.GetButtonDown("Jump"))
            {
                //is player jumps, jump is determined by jump height and gravity
                verticalVelocity = Mathf.Sqrt(jumpHeight * gravity * 2);
                animator.SetBool("isJumping", true);
            }
            else
            {
                animator.SetBool("isJumping", false);
            }
        }
        else
        {
            //falls based on gravity if player is not grounded
            verticalVelocity -= gravity * Time.deltaTime;
        }
        return verticalVelocity;
    }

    private void Turn()
    {
        //checks if any input is pressed
        if(Mathf.Abs(turnInput) > 0 || Mathf.Abs(moveInput) > 0)
        {
            animator.SetBool("isMoving", true);
            //gets current look direction based on current movement direction, y set to 0.
            Vector3 currentLookDirection = controller.velocity.normalized;
            currentLookDirection.y = 0;
            currentLookDirection.Normalize();

            //sets target rotation to current look direction, then slerps to that rotation
            Quaternion targetRotation = Quaternion.LookRotation(currentLookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}
