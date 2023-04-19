using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingWithReloading : MonoBehaviour
{
    //public GameObject bulletDestroyPrefab;
    public GameObject bulletPrefab;
    public float range = 5f;
    public Transform fireSpawnPoint;
    public float fireRate = 0.25f;
    public float bulletSpeed = 20;
    private float nextBullet;
    public ParticleSystem muzzleFlash;
    private Animator playerAnimator;

    public int maxAmmo = 10;
    public int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    [Header("UI Elements")]
    public TMPro.TextMeshProUGUI ammoText;

    public void Awake()
    {
        //playerAnimator = GetComponent<Animator>();
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        //if (isReloading)
        //    return;

        //if (currentAmmo <= 0f)
        //{
        //    StartCoroutine(Reload());
        //    return;
        //}

        if (Input.GetButton("Fire1") && Time.time >= nextBullet)
        {
            nextBullet = Time.time + fireRate;
            Shoot();
        }

    }

    //IEnumerator Reload()
    //{
    //    isReloading = true;
    //    Debug.Log("Reloading...");
    //    //animator.SetBool("Reloading", true);
    //    yield return new WaitForSeconds(reloadTime - .25f);
    //    //animator.SetBool("Reloading", false);
    //    yield return new WaitForSeconds(.25f);
    //    currentAmmo = maxAmmo;
    //    isReloading = false;
    //}


    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentAmmo > 0)
            {
                muzzleFlash.Play();
                currentAmmo--;
            }
            else
            {
                return;
            }
            ammoText.SetText(currentAmmo.ToString()+ "/"+ maxAmmo.ToString());
            GameObject bullet = Instantiate(bulletPrefab, fireSpawnPoint.position, Quaternion.identity);
            Destroy(bullet, 2f);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
        }
        if (Input.GetMouseButtonDown(0))
        {
            //playerAnimator.SetBool("Fire", false);
        }

    }
}
