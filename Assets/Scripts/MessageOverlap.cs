using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageOverlap : MonoBehaviour
{
    public GameObject sprintMesaage;
    float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        sprintMesaage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MyCollisions();
    }

    void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapBox(transform.position, transform.localScale);
        foreach(var hitCollider in hitColliders)
        {
            if (hitCollider.tag == "Player")
            {
                sprintMesaage.SetActive(true);
                timer += Time.deltaTime;
                if(timer >= 5)
                {
                    sprintMesaage.SetActive(false);
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
