using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionKill : MonoBehaviour
{
    //Make sure attached collider has IsTrigger Selected
    void OnTriggerEnter(Collider other)
    {
        //Make sure player has tag Player
        if (other.gameObject.tag == "Player")
        {
            //Only works if killbox is attached as child of enemy
            Destroy(transform.parent.gameObject);
        }
    }
}
