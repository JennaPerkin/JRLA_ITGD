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
    [SerializeField] private GameObject spawnObj;

    [Header("Cam Shake")]
    public CamShake shakeScript;
    public float shakeDuration;
    public float shakeIntensity;


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

    //Animation Event Method
    private void PlaySound()
    {
        src.clip = animBounce;
        src.Play();
        burst.Play();
        shakeScript.ShakeCamera(shakeDuration, shakeIntensity);
        Instantiate(spawnObj, new Vector3(0, 15, 0), Quaternion.identity);
    }
}
