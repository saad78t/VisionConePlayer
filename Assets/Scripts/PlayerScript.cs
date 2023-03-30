using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Dictionary<Item, int> itemDictionary = new Dictionary<Item, int>(); // Define dictionary like this

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E)) // First Check KEY cuz of optimization
        {
            if (other.gameObject.TryGetComponent(out Item item))
            {
                item.PickUp();
                if (itemDictionary.ContainsKey(item))
                {
                    itemDictionary[item]++;
                    Debug.Log($"{name} has {itemDictionary[item]} of {item}.");
                }
                else
                {
                    itemDictionary.Add(item, 1);
                }
            }

            if (itemDictionary[item] == 2) // check count of picked item.
            {
                Debug.Log($"Element: ({item.name}) have collected");
            }
        }
    }
}
