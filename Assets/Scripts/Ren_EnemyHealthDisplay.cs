using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ren_EnemyHealthDisplay : MonoBehaviour
{
    public enemyHealth healthScript;
    [SerializeField] TextMeshPro healthDisplay;
    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = healthScript.health.ToString();
    }
}
