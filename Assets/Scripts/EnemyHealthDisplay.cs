using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealthDisplay : MonoBehaviour
{
    public enemyHealth healthScript;
    [SerializeField] TextMeshPro healthDisplay;
    //public Transform displayDirection;
    public Transform cam;
 
    // Update is called once per frame
    void Update()
    {
        transform.rotation = cam.rotation;
    }
}
