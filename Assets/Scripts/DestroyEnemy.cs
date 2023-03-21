using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public int hitPoints;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(collision.gameObject, 0.5f);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Bullet has hit the enemy!!");
            // Destory bullet
            Destroy(collision.gameObject);
            hitPoints--;
            if (hitPoints == 0)
            {
                // Destroy the enemy
                Destroy(gameObject);
            }
        }
        
    }
}
