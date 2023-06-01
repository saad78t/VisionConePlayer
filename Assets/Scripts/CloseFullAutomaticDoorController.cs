using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseFullAutomaticDoorController : MonoBehaviour
{
    //public AutomaticDoor[] doors;

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        foreach (var door in doors)
    //        {
    //            if (door.GetComponent<AutomaticDoor>().opening)
    //            {
    //                door.GetComponent<AutomaticDoor>().opening = false;
    //            }
    //        }       
    //    }
    //}

    //IEnumerator DelayImplementation()
    //{
    //    yield return new WaitForSeconds(10);
    //    foreach (var door in doors)
    //    {
    //        door.GetComponent<AutomaticDoor>().moving = false;
    //        door.GetComponent<AutomaticDoor>().opening = true;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player" )
    //    {
    //        StartCoroutine(DelayImplementation());
    //    }
    //}

    //public Vector3 endPos;
    //public float speed = 1.0f;

    //public bool opening = true;
    //private Vector3 startPos;
    //private float delay = 0.0f;
    //public bool moving = false;

    //void Start()
    //{
    //    startPos = transform.position;
    //}


    //void MoveDoor(Vector3 goalPos)
    //{
    //    float dist = Vector3.Distance(transform.position, goalPos);
    //    if (dist < .1f)
    //    {
    //        transform.position = Vector3.Lerp(transform.position, goalPos, speed * Time.deltaTime);
    //    }
    //}

    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("closed", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.enabled = false;
        }
    }
}


