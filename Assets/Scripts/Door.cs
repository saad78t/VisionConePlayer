using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Drop this script to the object in front of the door
public class Door : MonoBehaviour
{
    public GameObject AnimeObject;
    public GameObject ThisTrigger;
    public PicUpKey key;//you shoul add collected item in the inspector of the unity

    private void Start()
    {
    }
    

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player" && key.keyCollected == true)
        {
            AnimeObject.GetComponent<Animator>().Play("Door");
            ThisTrigger.SetActive(false);
            Debug.Log("Done");
        }
    }
}