using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public Slider health_Slider;
    private int Health;
    private const int MAX_HEALTH = 100;
    public Rigidbody rd ;
    public Animator flash;

    private void Start()
    {
        Health = MAX_HEALTH;
        rd = GetComponent<Rigidbody>();
    }

    private void Update()
    {

    }


    public void DecreaseHealth(int amountOfHealth)
    {
        Health -= amountOfHealth;
        health_Slider.value = Health;

        if (Health <= 0)
        {
            //Player is dead
            Destroy(gameObject);
            Debug.Log("you are dead");

            //to do death animator and show gameover screen
            //animator.SetBool(IsDead, true);
        }
    }

    public void IncreaseHealth(int amountOfHealth)
    {
        if(Health > 0 && Health < 100)
        {
            Health += amountOfHealth;
            health_Slider.value = Health;
            Health = MAX_HEALTH;
        }
        else 
        {
            Debug.Log("Health if full");
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))  //في حالة الضرب بالرصاص
       /* if (collision.gameObject.CompareTag("Enemy"))  *///في حالة اصطدام جسم اللاعب بالعدو
        {
            // Destory bullet
            Destroy(collision.gameObject);
            DecreaseHealth(10);
            //flash.SetBool("flashEnabled", true);
            flash.SetTrigger("flashEnabled t");
            //    redSplaterImage.enabled = true;
        }
        //else
        //{
        //    flash.SetBool("flashEnabled", false);
        //}
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Health"))
    //    {
    //        IncreaseHealth(10);
    //    }
    //}

}
