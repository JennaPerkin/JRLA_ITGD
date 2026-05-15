using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{

    [Header("Cam Shake")]
    public CamShake shakeScript;
    public float shakeDuration;
    public float shakeIntensity;
    [SerializeField] private ParticleSystem trail;
    [SerializeField] private ParticleSystem smoke;
    [SerializeField] private AudioSource src;

    [Header("Objects")]
    [SerializeField] private Transform shootPoint;
    [SerializeField] public GameObject projectile;
    [SerializeField] private LayerMask includeFields;

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
        //Debug.DrawRay(shootPoint.position, shootPoint.up*10f, Color.green);
        if (Input.GetKeyDown(shootKey) && readyToShoot && shotQuantity > 0)
        {
            RaycastShoot();
        }
    }

    private void InstantiateShoot()
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

    private void RaycastShoot()
    {
        readyToShoot = false;
        shakeScript.ShakeCamera(shakeDuration, shakeIntensity);
        src.Play();
        Instantiate(trail, shootPoint.position, Quaternion.identity);
        RaycastHit hit;
        if (Physics.Raycast(shootPoint.position, shootPoint.up, out hit, 500f, includeFields))
        {
            Vector3 hitPosition = hit.point;
            Debug.Log("Hit Enemy");
            enemyHealth enemyscript = hit.transform.GetComponent<enemyHealth>();
            enemyscript.health--;
            Instantiate(smoke, hitPosition, Quaternion.identity);
        }
        else
        {
            Debug.Log("Did Not Hit Enemy");
        }

        readyToShoot = true;
    }

    private void Reload()
    {
        shotQuantity = 10;
    }
}
