using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    //public GameObject movingDoor;

    //    public float maximumOpening = -6.25f;
    //    public float maximumClosing = 0f;
    //    public float movementSpeed = 5f;

    //    bool playerIsHere;
    //    public PicUpKey key;
    //    // Start is called before the first frame update
    //    void Start()
    //    {
    //        playerIsHere = false;
    //    }

    //    // Update is called once per frame
    //    void Update()
    //    {
    //        if (playerIsHere)
    //        {
    //            if (movingDoor.transform.position.z < maximumOpening)
    //            {
    //                movingDoor.transform.Translate(0f, 0f, -movementSpeed * Time.deltaTime);
    //                if (movingDoor.transform.position.z <= -10f)
    //                {
    //                    maximumOpening = movingDoor.transform.position.z;
    //                } 
    //            }

    //        }
    //        else
    //        {
    //            if (movingDoor.transform.position.z == maximumOpening)
    //            {
    //                movingDoor.transform.Translate(0f, 0f, movementSpeed * Time.deltaTime);
    //                if (movingDoor.transform.position.z <= -4.14f)
    //                {
    //                    maximumOpening = movingDoor.transform.position.z;
    //                } 
    //            }
    //        }
    //    }

    //    private void OnTriggerEnter(Collider col){
    //        if(col.gameObject.tag == "Player" )
    //        {
    //            playerIsHere = true;
    //        }
    //    }

    //    private void OnTriggerExit(Collider col){
    //        if(col.gameObject.tag == "Player"){
    //            playerIsHere = false;
    //        }
    //    }

    public Vector3 endPos;
    public float speed = 1.0f;

    private bool opening = true;
    private Vector3 startPos;
    private float delay = 0.0f;
    private bool moving = false;
    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (moving)
        {
            if (opening)
            {
                MoveDoor(endPos);
            }
            else
            {
                MoveDoor(startPos);
            }
        }
    }

    void MoveDoor(Vector3 goalPos)
    {
        float dist = Vector3.Distance(transform.position, goalPos);
        if (dist > .1f)
        {
            transform.position = Vector3.Lerp(transform.position, goalPos, speed * Time.deltaTime);
        }
        //else
        //{
        //    if (opening)
        //    {
        //        delay += Time.deltaTime;
        //        if (delay > 1.5f)
        //        {
        //            opening = false;
        //        }
        //    }
        //    else
        //    {
        //        moving = false;
        //        opening = true;
        //    }
        //}
    }

    public bool Moving
    {
        get { return moving; }
        set { moving = value; }
    }
}
