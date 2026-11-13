using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    [SerializeField] Animator anim;
    private bool isDoorOpen;

    private void Start()
    {
        isDoorOpen = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(!isDoorOpen)
            {
                Debug.Log("Door Opening");
                isDoorOpen = true;
                anim.SetBool("isOpen", true);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (isDoorOpen)
            {
                Debug.Log("Door Closing");
                isDoorOpen = false;
                anim.SetBool("isOpen", false);
            }
        }
    }
}
