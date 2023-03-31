using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//drop it into player
public class PlayerTool : MonoBehaviour
{
    static int NumberOfItems = 0;

    public static void ItemPickedUp()
    {
        NumberOfItems++;
        if (NumberOfItems == 2)
        {
            Debug.Log("WELL DONE");
        }
 }
}
