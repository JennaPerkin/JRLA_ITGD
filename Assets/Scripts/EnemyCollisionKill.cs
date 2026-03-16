using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionKill : MonoBehaviour
{
    public GameObject enemy;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(enemy);
        }
    }
}
