using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlus : MonoBehaviour
{
    [SerializeField] private GameObject spawnObj;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Instantiated"))
        {
            Instantiate(spawnObj, new Vector3(0, 15, 0), Quaternion.identity);
        }
    }
}
