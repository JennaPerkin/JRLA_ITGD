using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRBMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public Vector3 InputKey;
    public float moveSpeed;
    public float jumpForce = 300;
    public float rotationSpeed;
    public float yVelocity;

    [Header("Camera Angle Movement")]
    private Vector3 horizontalMove;
    private Vector3 verticalMove;
    [SerializeField] Transform cam;

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
    void Update()
    {
        //Uses Unity's axis system to assign player move direction
        //calculates Movement Direction based on Camera Rotation/Position
        horizontalMove = Input.GetAxis("Horizontal") * cam.transform.right;
        verticalMove = Input.GetAxis("Vertical") * new Vector3(cam.transform.forward.x, 0f, cam.transform.forward.z);
        InputKey = horizontalMove + verticalMove;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, jumpLayers);
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(0, jumpForce, 0);
        }
    }
    void FixedUpdate()
    {
        //Multiplies Unity's axis system value by our move speed variable
        rb.MovePosition((Vector3)transform.position + InputKey * moveSpeed * Time.deltaTime);

        //Checks if player is pressing a movement button
        if (InputKey.magnitude > 0.1f)
        {
            //rotates the player to the direction they are moving
            float Angle = Mathf.Atan2(InputKey.x, InputKey.z) * Mathf.Rad2Deg;
            float Smooth = Mathf.SmoothDampAngle(transform.eulerAngles.y, Angle, ref yVelocity, rotationSpeed);
            transform.rotation = Quaternion.Euler(0, Smooth, 0);
        }
    }
}
