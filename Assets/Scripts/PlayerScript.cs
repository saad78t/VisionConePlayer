using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//drop it into the player
public class PlayerScript : MonoBehaviour
{
    //private Dictionary<Item, int> itemDictionary = new Dictionary<Item, int>(); // Define dictionary like this
    private Dictionary<string, int> itemDictionary = new Dictionary<string, int>();
    public GameObject PicUpText;
    private bool checkitem;

    private void Start()
    {
        PicUpText.SetActive(false);
        checkitem = true;
    }

    //other.gameObject.layer == 10
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Tools") { 
            PicUpText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E)) // First Check KEY cuz of optimization
            {
                if (other.gameObject.TryGetComponent(out Item item))
                {
                    item.PickUp();
                         PicUpText.SetActive(false);
                    
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

    private void OnTriggerExit(Collider other)
    {
        PicUpText.SetActive(false);
    }

}
