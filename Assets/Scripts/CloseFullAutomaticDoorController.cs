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
                if (door.GetComponent<AutomaticDoor>().Moving == false)
                {
                    door.GetComponent<AutomaticDoor>().Moving = true;
                }

                if (door.GetComponent<AutomaticDoor>().opening)
                {
                    door.GetComponent<AutomaticDoor>().opening = false;
                }
                else
                {
                    door.GetComponent<AutomaticDoor>().moving = false;
                    door.GetComponent<AutomaticDoor>().opening = true;
                }
            }       
        }
    }
}


