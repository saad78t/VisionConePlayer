using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AmmoPicUp : MonoBehaviour
{
    public PlayerShootingWithReloading revolver;
    public int bulletInventory;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(revolver.currentAmmo < revolver.maxAmmo )
            {
                revolver.currentAmmo = revolver.currentAmmo + bulletInventory;
                Destroy(gameObject);
                if(revolver.currentAmmo >= revolver.maxAmmo)
                {
                    revolver.currentAmmo = revolver.maxAmmo;
                }
            }
        }
    }

}
