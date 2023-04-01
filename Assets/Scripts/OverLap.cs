using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverLap : MonoBehaviour
{
    public float radius;
    Collider[] Players;
    public PlayerHealth increase;

    void Start()
    {
       
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            CheckArea();
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
