using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Transform shootPoint;
    [SerializeField] public GameObject projectile;

    [Header("Shoot Variables")]
    [SerializeField] private KeyCode shootKey = KeyCode.Mouse0;
    [SerializeField] private float shootForce;
    [SerializeField] private float shootUpwardForce;
    [SerializeField] private int shotQuantity;
    [SerializeField] private float reloadCooldown;
    bool readyToShoot;
    // Start is called before the first frame update
    void Start()
    {
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(shootKey) && readyToShoot && shotQuantity > 0)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;
        GameObject projectileRef = Instantiate(projectile, shootPoint.position, Quaternion.identity);
        Rigidbody projectileRb = projectileRef.GetComponent<Rigidbody>();
        Vector3 forceDirection = shootPoint.transform.forward;
        Vector3 forceToAdd = forceDirection * shootForce + transform.up * shootUpwardForce;
        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);
        shotQuantity--;
        readyToShoot = true;

        if (shotQuantity <= 0)
        {
            Invoke(nameof(Reload), reloadCooldown);
        }
    }

    private void Reload()
    {
        shotQuantity = 10;
    }
}
