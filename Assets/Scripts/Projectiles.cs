using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    //[SerializeField] private Animator anim;

    [Header("Objects")]
    [SerializeField] private Transform shootPoint;
    [SerializeField] public GameObject projectile;
    [SerializeField] private LayerMask includeFields;
    //[SerializeField] private TextMeshPro healthDisplay;
    //public enemyHealth healthScript;
    [SerializeField] private TextMeshPro shotQuantityDisplay;

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
        //healthDisplay.text = healthScript.health.ToString();
        shotQuantityDisplay.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(shootPoint.position, shootPoint.forward*10f, Color.green);
        if (Input.GetKeyDown(shootKey) && readyToShoot && shotQuantity > 0)
        {
            RaycastShoot();
        }
        if (shotQuantity <= 0)
        {
            readyToShoot = false;
            ReloadTimer();
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
        //anim.SetTrigger("isFired");
        Instantiate(trail, shootPoint.position, Quaternion.identity);
        RaycastHit hit;
        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, 500f, includeFields))
        {
            Vector3 hitPosition = hit.point;
            Debug.Log("Hit Enemy");
            enemyHealth enemyscript = hit.transform.GetComponent<enemyHealth>();
            enemyscript.health--;
            hit.transform.GetChild(0).GetComponent<TextMeshPro>().text = enemyscript.health.ToString();
            Instantiate(smoke, hitPosition, Quaternion.identity);
            shotQuantity--;
        }
        else
        {
            Debug.Log("Did Not Hit Enemy");
        }

        readyToShoot = true;
    }

    private void ReloadTimer()
    {
        if(reloadCooldown > 0)
        {
            shotQuantityDisplay.enabled = true;
            reloadCooldown -= Time.deltaTime;
            shotQuantityDisplay.text = reloadCooldown.ToString("0.");
            Debug.Log(reloadCooldown.ToString());
        }
        else if(reloadCooldown <= 0)
        {
            shotQuantityDisplay.enabled = false;
            Reload();
        }
    }

    private void Reload()
    {
        reloadCooldown = 5;
        shotQuantity = 10;
        readyToShoot = true;
    }
}
