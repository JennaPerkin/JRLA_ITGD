using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ren_BallController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource src;
    [SerializeField] private AudioClip animBounce, animStart;
    [SerializeField] private ParticleSystem burst;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            src.clip = animStart;
            src.Play();
            animator.SetBool("isSpacePressed", true);
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("isSpacePressed", false);
        }
    }

    void SoundPlay()
    {
        src.clip = animBounce;
        src.Play();
        burst.Play();
    }
}
