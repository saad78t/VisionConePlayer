using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SwitchScene : MonoBehaviour
{
     PlayerScript num;

    public GameObject Collecting_TXT;
    

    private void Start()
    {
        Collecting_TXT.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        num = other.GetComponent<PlayerScript>();
       
        Collecting_TXT.SetActive(true);
        if (num.Hissi)
        {
            Collecting_TXT.SetActive(false);
            SceneManager.LoadScene(1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Collecting_TXT.SetActive(false);
    }

}
