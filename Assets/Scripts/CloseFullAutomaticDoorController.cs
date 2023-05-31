using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseFullAutomaticDoorController : MonoBehaviour
{
    public AutomaticDoor[] doors;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (var door in doors)
            {
                if (door.GetComponent<AutomaticDoor>().opening)
                {
                    door.GetComponent<AutomaticDoor>().opening = false;
                }
            }       
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (var door in doors)
        {
            door.GetComponent<AutomaticDoor>().moving = false;
            door.GetComponent<AutomaticDoor>().opening = true;
        }
    }
}


