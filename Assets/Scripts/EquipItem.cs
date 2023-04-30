using UnityEngine.UI;
using UnityEngine;

public class EquipItem : MonoBehaviour
{

    public GameObject Item;
    public GameObject PicUp_TXT, Drop_TXT;
    public Transform CollectedItem;

    public RawImage ItemImage;
    bool disabledItem = false;
    public bool ItemCllected;
    float Timer , MaxTimer = 15;

    void Start()
    {
        Item.GetComponent<Rigidbody>().isKinematic = true;
        PicUp_TXT.SetActive(false);
        Drop_TXT.SetActive(false);
        ItemImage.enabled = false;
        ItemCllected = false;
        Timer = 0;
    }

    
    void Update()
    {
        
    }

    void DropItem()
    {
        CollectedItem.DetachChildren();
        Item.transform.eulerAngles = new Vector3(Item.transform.position.x, Item.transform.position.z, Item.transform.position.y);
        Item.GetComponent<Rigidbody>().isKinematic = false;
        Item.GetComponent<MeshCollider>().enabled = true;
    }

    void EquipedItem()
    {
        Item.GetComponent<Rigidbody>().isKinematic = true;
        Item.transform.position = CollectedItem.transform.position;
        Item.transform.rotation = CollectedItem.transform.rotation;

        Item.GetComponent<MeshCollider>().enabled = false;
        Item.transform.SetParent(CollectedItem);
        ItemImage.enabled = true;
        ItemCllected = true;
    }

        

    private void OnTriggerStay(Collider other)
    {
        //Picup Item
        if (other.gameObject.tag == "Player")
        {
           if(Item) 
                PicUp_TXT.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                EquipedItem();
                disabledItem = true;
                Item.SetActive(false);

                //ItemCounter.PickedUpItems();
            }
            if (ItemCllected)
            {
                PicUp_TXT.SetActive(false);
                Drop_TXT.SetActive(true);
            }
        }

        //Drop Item
        Timer = Timer + Time.deltaTime;
        
        if (Timer >= MaxTimer)
        {
            Drop_TXT.SetActive(false);
        }
        

        if (Input.GetKey(KeyCode.F) && ItemCllected)
        {
            Item.SetActive(true);
            //Item.GetComponent<MeshCollider>().enabled = true;
            Debug.Log("DONE");
            DropItem();
        }
    }

    private void OnTriggerExit(Collider other)
    {
            PicUp_TXT.SetActive(false);
    }
}
