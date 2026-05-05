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
    bool readyToShoot;
    // Start is called before the first frame update
    void Start()
    {
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(shootKey) && readyToShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;
        GameObject projectileRef = Instantiate(projectile, shootPoint.position, Quaternion.identity);
        Rigidbody projectileRb = projectileRef.GetComponent<Rigidbody>();
        Vector3 forceDirection = shootPoint.transform.right;
        Vector3 forceToAdd = forceDirection * shootForce + transform.up * shootUpwardForce;
        Debug.Log(forceDirection);
        Debug.Log(forceToAdd);
        projectileRb.AddRelativeForce(forceToAdd, ForceMode.Impulse);
        readyToShoot = true;
    }
}
