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
        /*RaycastHit hit;

        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hit, 1f, jumpLayers))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }*/

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(0, jumpForce, 0);
        }
    }
    //Fixed update to avoid issues of player moving faster or slower on different computers
    void FixedUpdate()
    {
        //Multiplies Unity's axis system value by our move speed variable
        rb.AddForce(InputKey * moveSpeed);

        if (InputKey.magnitude > 0.1f)
        {
            float Angle = Mathf.Atan2(InputKey.x, InputKey.z) * Mathf.Rad2Deg;
            float Smooth = Mathf.SmoothDampAngle(transform.eulerAngles.y, Angle, ref yVelocity, rotationSpeed);
            transform.rotation = Quaternion.Euler(0, Smooth, 0);
        }
    }
}
