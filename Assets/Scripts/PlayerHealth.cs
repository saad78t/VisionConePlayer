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


    private void Start()
    {
        Health = MAX_HEALTH;
        rd = GetComponent<Rigidbody>();
    }

    private void Update()
    {
            if (Input.GetKeyDown(KeyCode.H))
            {   
                 IncreaseHealth(10);              
            }
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
        //if (rd.gameObject.CompareTag("Health"))
        //{
            Health += amountOfHealth;
            health_Slider.value = Health;
        //}
    }
}
