using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenProjectileDamage : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            RenEnemyHealth enemyHealthScript = 
                collision.gameObject.GetComponent<RenEnemyHealth>();
            enemyHealthScript.health--;
            Debug.Log("Enemy Health: " +  enemyHealthScript.health);
        }
    }
}
