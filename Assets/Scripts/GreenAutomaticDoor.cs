using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenAutomaticDoor : MonoBehaviour
{
    public Animator doorAnim;
    //public GameObject objectMaterial;
    //public Material material, defaultMaterial;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnim.ResetTrigger("close");
            doorAnim.SetTrigger("open");
            //objectMaterial.GetComponent<MeshRenderer>().material = material;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnim.ResetTrigger("open");
            doorAnim.SetTrigger("close");
            //objectMaterial.GetComponent<MeshRenderer>().material =  defaultMaterial;
        }
    }
}
