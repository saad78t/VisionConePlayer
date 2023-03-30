using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PicUpTools : MonoBehaviour
{
    public GameObject objectWithPlayer,PicUpText;
    
    public RawImage objectRawImage;
    
    void Start()
    {
        objectWithPlayer.SetActive(false);
        objectRawImage.enabled = false;
        PicUpText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PicUpText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                gameObject.SetActive(false);
                objectWithPlayer.SetActive(true);
                objectRawImage.enabled = true;
                PicUpText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PicUpText.SetActive(false);
    }
}
