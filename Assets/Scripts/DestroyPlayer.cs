using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyPlayer : MonoBehaviour
{
    private PlayerHealth playerHealth;
    [SerializeField] private RawImage redSplaterImage;
    public Animator flash;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        //redSplaterImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //OnTriggerEnter: To avoid displacement of the player when the bullet hit him
    //private void OnTriggerEnter(Collider collision)
    //{
    //    if (collision.gameObject.CompareTag("EnemyBullet"))
    //    {
    //        // Destory bullet
    //        Destroy(collision.gameObject);
    //        playerHealth.DecreaseHealth(10);
    //        //flash.SetBool("flashEnabled", true);
    //        flash.SetTrigger("flashEnabled t");
    //        //    redSplaterImage.enabled = true;
    //    }
    //    //else
    //    //{
    //    //    flash.SetBool("flashEnabled", false);
    //    //}
    //}

}
