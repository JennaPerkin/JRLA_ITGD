using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCCMovement : MonoBehaviour
{
    [Header("References")]
    private CharacterController controller;
    [SerializeField] private Transform camera;

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
        Vector3 move = new Vector3(turnInput, 0, moveInput);
        move = camera.transform.TransformDirection(move);
        //move.y = 0;
        move.y = VerticalForceCalculation();
        move *= moveSpeed;
        controller.Move(move * Time.deltaTime);
    }

    private float VerticalForceCalculation()
    {
        if(controller.isGrounded)
        {
            verticalVelocity = 0;
            if(Input.GetButtonDown("Jump"))
            {
                verticalVelocity = Mathf.Sqrt(jumpHeight * gravity * 2);
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        return verticalVelocity;
    }

    private void Turn()
    {
        if(Mathf.Abs(turnInput) > 0 || Mathf.Abs(moveInput) > 0)
        {
            Vector3 currentLookDirection = controller.velocity.normalized;
            currentLookDirection.y = 0;
            currentLookDirection.Normalize();

            Quaternion targetRotation = Quaternion.LookRotation(currentLookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
        }
    }
}
