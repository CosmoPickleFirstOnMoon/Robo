using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//item slots hold items. These can be clicked, and the item contained can be used, equipped, or dropped.
//Mousing over the item should show its data.
public class ItemSlot : MonoBehaviour
{
    public bool isEmpty;
    public int slotID;
    public ItemData item;
    public Image icon;

    // Start is called before the first frame update
    void Start()
    {
        isEmpty = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This method is called when the slot is clicked on.
    public void UseItem()
    {
        Debug.Log("Slot " + slotID + " contains " + item.itemName);
    }
}
