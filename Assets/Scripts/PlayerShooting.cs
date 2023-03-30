using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    //public GameObject bulletDestroyPrefab;
    public GameObject bulletPrefab;
    public Transform fireSpawnPoint;
    public float fireRate = 0.25f;
    public float bulletSpeed = 20;
    private float nextBullet;
    private Animator playerAnimator;

    public void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerAnimator.SetBool("Fire", true);
            if(Time.time > nextBullet)
            {
                nextBullet = Time.time + fireRate;
                GameObject bullet = Instantiate(bulletPrefab,fireSpawnPoint.position, Quaternion.identity);
                Destroy(bullet, 2f);
                //Instantiate(bulletDestroyPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            playerAnimator.SetBool("Fire", false);
        }
    }
}
