using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong_Paddle : MonoBehaviour
{
    private float moveInput;
    private Vector2 moveDirection;
    [SerializeField] float moveSpeed;
    Vector2 currentPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        moveInput = Input.GetAxis("Vertical");
        moveDirection = new Vector2(0, moveInput * moveSpeed);
        transform.Translate(moveDirection);

        if(transform.position.y >= 5)
        {
            currentPosition.y = 5;
            transform.position = currentPosition;
        }

        if (transform.position.y <= -5)
        {
            currentPosition.y = -5;
            transform.position = currentPosition;
        }
    }
}
