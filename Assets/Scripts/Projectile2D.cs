using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2D : MonoBehaviour
{
    [Header("Rotation")]
    public Transform target;
    public float damping;

    [Header("Shooting")]
    public GameObject projectile;
    public Transform shootPoint;
    public float force;

    void Start()
    {
        Shoot();
    }

    void Update()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

        /*if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }*/
    }

    void Shoot()
    {
        GameObject projectileRef = Instantiate(projectile, shootPoint.position, Quaternion.identity);
        Rigidbody2D projectileRB = projectileRef.GetComponent<Rigidbody2D>();
        Vector3 forceToAdd = shootPoint.transform.up * force;
        projectileRB.AddForce(forceToAdd);
        Invoke(nameof(Shoot), 2f);
    }
}
