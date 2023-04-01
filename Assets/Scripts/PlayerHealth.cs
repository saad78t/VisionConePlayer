using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    float timer;
    float timerB = 0;



    public Slider health_Slider;
    private int Health;
    private const int MAX_HEALTH = 100;
    public Rigidbody rd ;


    private void Start()
    {
        Health = MAX_HEALTH;
        rd = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //  IncreaseHealth(10);
        //}

        if (Input.GetButtonDown("Health"))
        {
            timer = Time.time;
            IncreaseHealth(10);
            Debug.Log(timer);
        }

        //if (Input.GetButtonUp("Health"))
        //{
        //    timerB = Time.time;
        //    Debug.Log(timerB + " ESPACIOSSS " + timer);
        //    if (timerB - timer >= 3)
        //    {
        //        timer = 0;
        //        timerB = 0;
        //        Debug.Log("CONSEGUIDOOOOOOOOOOOOOOOOOOOOOOOOOO");
        //    }
        //}
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
        }else
        {
            Debug.Log("Health if full");
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Health"))
    //    {
    //        IncreaseHealth(10);
    //    }
    //}

}
