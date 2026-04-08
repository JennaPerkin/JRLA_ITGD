using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounceController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("isSpaceHeld", true);
        }
        else
        {
            animator.SetBool("isSpaceHeld", false);
        }
    }
}
