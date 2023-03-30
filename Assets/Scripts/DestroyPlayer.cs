using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    //OnTriggerEnter: To avoid displacement of the player when the bullet hit him
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            // Destory bullet
            Destroy(collision.gameObject);

            playerHealth.DecreaseHealth(10);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Health"))
    //    {
    //        playerHealth.IncreaseHealth(10);
    //        Destroy(collision.gameObject);
    //    }
    //}

}
