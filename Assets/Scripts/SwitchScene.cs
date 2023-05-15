using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SwitchScene : MonoBehaviour
{
    PlayerScript num;
    FadeInOut fade;
    public GameObject Collecting_TXT;


    private void Start()
    {
        Collecting_TXT.SetActive(false);
        fade = FindObjectOfType<FadeInOut>();
    }

    public IEnumerator ChangeScene()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }

    private void OnTriggerStay(Collider other)
    {
        num = other.GetComponent<PlayerScript>();
       
        Collecting_TXT.SetActive(true);
        if (other.gameObject.tag == "Player" && num.Hissi)
        {
            Collecting_TXT.SetActive(false);
            StartCoroutine(ChangeScene());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Collecting_TXT.SetActive(false);
    }

}
