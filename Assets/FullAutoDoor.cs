using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullAutoDoor : MonoBehaviour
{
    //public AutomaticDoor door;
    //public AutomaticDoor door1;
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
    //    {
    //        if (door1.GetComponent<AutomaticDoor>().Moving == false && door.GetComponent<AutomaticDoor>().Moving == false)
    //        {
    //            door.GetComponent<AutomaticDoor>().Moving = true;
    //            door1.GetComponent<AutomaticDoor>().Moving = true;
    //        }
    //    }
    //}

    public AutomaticDoor [] doors;
    CloseFullAutomaticDoorController refrence;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            foreach (var door in doors)
            {
               if( door.GetComponent<AutomaticDoor>().Moving == false)
               {
                    door.GetComponent<AutomaticDoor>().Moving = true;
               }
            }
        }
    }
}
