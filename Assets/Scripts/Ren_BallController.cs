using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ren_BallController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isSpacePressed", true);
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("isSpacePressed", false);
        }
    }
}
