using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//drop it to the player
public class PlayerScript : MonoBehaviour
{
    //private Dictionary<Item, int> itemDictionary = new Dictionary<Item, int>(); // Define dictionary like this
    private Dictionary<string, int> itemDictionary = new Dictionary<string, int>();

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E)) // First Check KEY cuz of optimization
        {
            if (other.gameObject.TryGetComponent(out Item item))
            {
                item.PickUp();
                if (itemDictionary.ContainsKey(item.type))
                {
                    itemDictionary[item.type]++;
                    Debug.Log($"{name} has {itemDictionary[item.type]} of {item.name}.");
                }
                else
                {
                    itemDictionary.Add(item.type, 1);
                }
                if (itemDictionary[item.type] == 2) // check count of picked item.
                {
                    Debug.Log($"Element: ({item.name}) have collected");
                }
            }

        }
    }
}
