using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionKill : MonoBehaviour
{
    public GameObject enemy;
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(enemy);
        }
    }
}
