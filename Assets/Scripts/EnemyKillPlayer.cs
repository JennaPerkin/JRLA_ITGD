using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyKillPlayer : MonoBehaviour
{
    //Make sure attached collider has IsTrigger Selected
    void OnTriggerEnter(Collider other)
    {
        //Make sure player has tag Player
        if (other.gameObject.tag == "Player")
        {
            //Make sure other scene is included in Build Setting and Spelled Properly
            SceneManager.LoadSceneAsync("MainMenu");
        }

    }
}
