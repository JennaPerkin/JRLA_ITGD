using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefeatPlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 inputKey;
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        inputKey = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        rb.AddForce(inputKey * moveSpeed);
    }
}
