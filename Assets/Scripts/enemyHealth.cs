using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float health;
    public TextMeshPro healthDisplay;

    private void Start()
    {
        healthDisplay.text = health.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
