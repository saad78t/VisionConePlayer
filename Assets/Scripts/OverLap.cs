using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverLap : MonoBehaviour
{
    float timer = 0;
    float timerB = 0;

    public float radius;
    Collider[] Players;
    public PlayerHealth increase;
    public GameObject HealthText;

    void Start()
    {
        HealthText.SetActive(false);
    }

    private void FixedUpdate()
    {
        HealthText.SetActive(true);
        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    CheckArea();
        //    HealthText.SetActive(false);
        //}


        if (Input.GetButtonDown("Health"))
        {
            timer = Time.time;
            CheckArea();
            Debug.Log(timer);
        }

        if (Input.GetButtonUp("Health"))
        {
            timerB = Time.time;
            Debug.Log(timerB + " SPACE " + timer);
            if (timerB - timer >= 3)
            {
                timer = 0;
                timerB = 0;
                Debug.Log("Stopped");
            }
        }
    }

    private void CheckArea()
    {
        Players = Physics.OverlapSphere(transform.position, radius);
        
        foreach(var player in Players)
        {
            
            if (player.CompareTag("Player"))
            {
               increase.IncreaseHealth(10);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        HealthText.SetActive(false);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
