using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileKillEnemy : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject);
        if (collision.gameObject.tag == "Enemy")
        {
            enemyHealth enemyScript = collision.gameObject.GetComponent<enemyHealth>();
            enemyScript.health--;
            Debug.Log("Enemy Health: " + enemyScript.health);
        }

        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
