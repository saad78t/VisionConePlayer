using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public GameObject objectWithPlayer;

    public RawImage objectRawImage;

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
        objectWithPlayer.name = "Saad";
        objectRawImage.enabled = true;
    }
}
