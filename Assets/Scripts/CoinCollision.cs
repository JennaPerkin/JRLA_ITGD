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
            GameManager.Instance.CoinCollect();
            Destroy(this.gameObject);
        }
    }
}
