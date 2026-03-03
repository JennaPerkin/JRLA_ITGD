using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRBMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public Vector3 InputKey;
    public float moveSpeed;
    public float jumpForce = 300;

    [Header("GroundDetection")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundRadius;
    [SerializeField] LayerMask jumpLayers;
    [SerializeField] bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        //Gets Rigidbody component, checks if Rigidbody is assigned
        rb = GetComponent<Rigidbody>();
        if (rb == null)
            Debug.Log("Rigidbody not assigned");
    }

    // Update is called once per frame
    void Update()
    {
        //Uses Unity's axis system to assign player move direction
        InputKey = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, jumpLayers);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(0, jumpForce, 0);
        }
    }
    //Fixed update to avoid issues of player moving faster or slower on different computers
    void FixedUpdate()
    {
        //Multiplies Unity's axis system value by our move speed variable
        rb.AddForce(InputKey * moveSpeed);
    }
}
