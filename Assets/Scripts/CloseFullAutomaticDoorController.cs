using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseFullAutomaticDoorController : MonoBehaviour
{
    public AutomaticDoor[] doors;

    private void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            
            foreach (var door in doors)
            {
                if (door.GetComponent<AutomaticDoor>().opening)
                {
                    Debug.Log("PLAYER CAME HERE");
                    //door.GetComponent<AutomaticDoor>().delay += Time.deltaTime;
                    //if (door.GetComponent<AutomaticDoor>().delay > 5f)
                    //{
                        door.GetComponent<AutomaticDoor>().opening = false;

                    //door.GetComponent<AutomaticDoor>().delay= 0f;
                    //}
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


