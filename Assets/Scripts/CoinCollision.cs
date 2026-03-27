using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    //public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Runs Coin Collect function in Game Manager Script
            GameManager.Instance.CoinCollect();
            Destroy(this.gameObject);
        }
    }
}
