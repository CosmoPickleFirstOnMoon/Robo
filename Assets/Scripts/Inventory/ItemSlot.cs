using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//item slots hold items. These can be clicked, and the item contained can be used, equipped, or dropped.
//Mousing over the item should show its data.
public class ItemSlot : MonoBehaviour
{
    public bool isEmpty;
    public byte slotID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This method is called when the slot is clicked on.
    public void UseItem()
    {
        Debug.Log("Slot " + slotID + " clicked");
    }
}
