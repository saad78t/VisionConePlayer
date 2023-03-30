using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttacking : MonoBehaviour
{
    
    public GameObject bulletPrefab;
    public Transform fireSpawnPoint;
    public float fireRate = 0.5f;
    public float bulletSpeed = 20;
    private float nextBullet;
    private Animator enemyAnimator;
    //private PlayerHealth playerHealth;
    
    private void Awake()
    {
        //playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public void Attack() {
        
        if (Time.time > nextBullet)
        {
            nextBullet = Time.time + fireRate;
            GameObject bullet = Instantiate(bulletPrefab, fireSpawnPoint.position, Quaternion.identity);
            Destroy(bullet, 2f);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
            //playerHealth.DecreaseHealth(10);
        }
    }
}
