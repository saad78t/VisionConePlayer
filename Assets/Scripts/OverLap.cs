using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverLap : MonoBehaviour
{
    public float radius;
    Collider[] Players;
    //public LayerMask m_LayerMask;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        CheckArea();
    }

    private void CheckArea()
    {
        Players = Physics.OverlapSphere(transform.position, radius);
        
        foreach(var player in Players)
        {
            if (player.CompareTag("Player"))
            {
                Debug.Log("The player entered the zone");
            }
            else
            {
                Debug.Log("the player out of the zone");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
