using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Drop it into a game object to increase the player's health
public class OverLap : MonoBehaviour
{
    float timer = 0;
    float interval = 0;
    bool shouldHeal;

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

        if (Input.GetKeyDown(KeyCode.H))
        {
            timer = 0;
            shouldHeal = true;
        }

        if (Input.GetKey(KeyCode.H))
        {
            if (shouldHeal)
            {
                timer += Time.deltaTime;
                interval += Time.deltaTime;

                if (interval >= 0.1f)
                {
                    CheckArea();
                    interval = 0;
                }

                if (timer >= 3)
                    shouldHeal = false;
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
