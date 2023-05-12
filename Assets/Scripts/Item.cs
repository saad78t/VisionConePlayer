using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Drop it onto items to be collected
public class Item : MonoBehaviour
{
    public GameObject objectWithPlayer;

    public RawImage objectRawImage;

    
    public string type = "Wrench"; // Assign Type String for items.

    void Start()
    {
            objectWithPlayer.SetActive(false);
            objectRawImage.enabled = false;
        //PicUpText.SetActive(false);
    }


    public void PickUp()
    {
        gameObject.SetActive(false);
        objectWithPlayer.SetActive(true);
        //Destroy(objectWithPlayer);
        objectWithPlayer.SetActive(false);
        objectRawImage.enabled = true;
    }
    
}
