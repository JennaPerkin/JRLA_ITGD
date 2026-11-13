using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayerMovement : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] Rigidbody2D rb;
    private Vector2 InputKey;
    [SerializeField] float moveSpeed;

    [Header("Jump Variables")]
    [SerializeField] float jumpForce;
    private Vector2 jumpVector;
    private bool isGrounded = false;
    public LayerMask groundLayers;

    private void Start()
    {
        jumpVector = new Vector2(0, jumpForce);
    }
    void Update()
    {
        //Using Unity Axis to determine which direction to move
        InputKey = new Vector2(Input.GetAxis("Horizontal"), 0);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(jumpVector);
            isGrounded = false;
        }

        if(Physics2D.Raycast(transform.position, -transform.up, 0.51f, groundLayers))
        {
            isGrounded = true;
        }
    }

    private void FixedUpdate()
    {
        //Moving in that direction
        rb.AddForce(InputKey * moveSpeed);
    }
}
