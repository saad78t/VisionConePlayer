using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PicUpKey : MonoBehaviour
{
    public GameObject keyObject, PicUpTextKey ;
    
    public RawImage objectRawImageKey;

    public bool keyCollected;

    void Start()
    {
        keyObject.SetActive(false);
        objectRawImageKey.enabled = false;
        PicUpTextKey.SetActive(false);
        keyCollected= false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PicUpTextKey.SetActive(true);
            if (Input.GetKey(KeyCode.K))
            {
                gameObject.SetActive(false);
                keyObject.SetActive(true);
                objectRawImageKey.enabled = true;
                keyCollected = true;
                Destroy(keyObject);
                PicUpTextKey.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PicUpTextKey.SetActive(false);
    }

}
