using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallForce : MonoBehaviour
{
    public float shootForce;
    public float shootUpwardForce;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 forceDirection = transform.forward;
        Vector3 forceToAdd = forceDirection * shootForce + transform.up * shootUpwardForce;
        Debug.Log(forceDirection);
        Debug.Log(forceToAdd);
        rb.AddForce(forceToAdd, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
