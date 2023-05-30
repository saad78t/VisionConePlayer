using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Drop it into a game object to increase the player's health
public class OverLap : MonoBehaviour
{
    float timer;
    float holdDur = 3f;
    
    float interval = 0;
    bool shouldHeal;

    public float radius;
    Collider[] Players;
    public PlayerHealth increase;
    public GameObject HealthText;

    int counter = 0;

    void Start()
    {
        HealthText.SetActive(false);
    }

    private void FixedUpdate()
    {
        //Increasing the player health within 3 seconds

        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    timer = 0;
        //    shouldHeal = true;
        //}

        //if (Input.GetKey(KeyCode.H))
        //{
        //    if (shouldHeal)
        //    {
        //        timer += Time.deltaTime;
        //        interval += Time.deltaTime;

        //        if (interval >= 0.1f)
        //        {
        //            CheckArea();
        //            interval = 0;
        //        }

        //        if (timer >= 3)
        //            shouldHeal = false;
        //    }
        //}

        //holding the button H for 3 seconds to increse the player's helth
        if (Input.GetButtonDown("Health"))
        {
            timer = Time.time;
        }
        else if (Input.GetButton("Health"))
        {
            if (Time.time - timer > holdDur)
            {
                timer = float.PositiveInfinity;
                CheckArea();
            }
        }
        else
        {
            timer = float.PositiveInfinity;
        }
    }

    private void CheckArea()
    {
        Players = Physics.OverlapSphere(transform.position, radius);
        
        foreach(var player in Players)
        {
            //counter is to allow the player get health just two times
            if (player.CompareTag("Player") && counter <= 2)
            {
               increase.IncreaseHealth(90);
                counter++;
                Debug.Log("CHECKING HEALTH COUNTER "+ counter);
            }
            //if(counter >= 2)
            //{
            //    increase.IncreaseHealth(0);
            //}
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
             HealthText.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthText.SetActive(false);
        }
            
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
