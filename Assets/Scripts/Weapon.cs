using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public float damage = 10f;
    public float range = 5f;
    public float impactForce = 30f ;
    public float fireRate = 15f ;
    public float nextTimetoFire = 0f ;
    public ParticleSystem muzzleFlash;     
    public GameObject impactEffect;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    //public Animator animator;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void OnEnable()
    {
        isReloading = false;
        //animator.SetBool("Reloading", false);
    }

    void Update()
    {
        if (isReloading)
            return;

        if (currentAmmo <= -1)
        {
            StartCoroutine(Reload());
            return;
        }

        if(Input.GetButton("Fire1") && Time.time >= nextTimetoFire)
        {
            nextTimetoFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }


    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        //animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime -.25f);
        //animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot()
    {
            muzzleFlash.Play();
        currentAmmo--;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.takeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject bullet=  Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(bullet,0.5f);
        }
    }

}
