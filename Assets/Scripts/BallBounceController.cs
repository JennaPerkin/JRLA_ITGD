using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Burst;
using UnityEngine;

public class BallBounceController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource src;
    [SerializeField] private AudioClip animStart, animBounce;
    [SerializeField] private ParticleSystem burst;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            src.clip = animStart;
            src.Play();
            animator.SetBool("isSpaceHeld", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("isSpaceHeld", false);
        }
    }

    //Collision Sound Effect Method
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != null)
        {
            Debug.Log("Hit Ground");
            src.Play();
        }
        else
        {
            Debug.Log("Null Hit");
        }
    }*/

    //Animation Event Method
    private void PlaySound()
    {
        src.clip = animBounce;
        src.Play();
        burst.Play();
    }
}
