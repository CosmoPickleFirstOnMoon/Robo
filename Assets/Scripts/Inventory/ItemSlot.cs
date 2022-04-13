using UnityEngine;
using UnityEngine.UI;

//item slots hold items. These can be clicked, and the item contained can be used, equipped, or dropped.
//Mousing over the item should show its data.
public class ItemSlot : MonoBehaviour
{
    //public bool isEmpty;
    public int slotID;
    public ItemData item;
    public Image icon;

    // Start is called before the first frame update
    protected void Start()
    {
        //isEmpty = true;
        icon.enabled = false;
    }

   
    //This method is called when the slot is clicked on.
    public void UseItem()
    {
        Inventory inv = Inventory.instance;
        Debug.Log("Item on cursor " + inv.itemOnCursor);
        if (inv.itemOnCursor)
        {
            if (item == null)
            {
                //drop item in slot
                item = inv.copiedItem;
                icon.sprite = inv.dragItem.sprite;
                icon.enabled = true;
                inv.itemOnCursor = false;
                inv.copiedItem = null;
                Debug.Log("Dropping Item");
            }
            else
            {
                //drop item in slot, and old item goes to cursor and its data is copied.
                ItemData oldItem = item;
                inv.copiedItem = item;
                icon.sprite = inv.dragItem.sprite;
                inv.copiedItem = oldItem;
                inv.dragItem.sprite = oldItem.iconSprite;
                Debug.Log("Swapping Item");
            }

            //delete the item from the slot it was in before.
            //inv.copiedSlot = null;

        }
        else    //picking up item
        {
            if (item != null)
            {
                inv.dragItem.sprite = icon.sprite;
                icon.enabled = false;

                //copy item data
                inv.copiedItem = item;
                //inv.copiedSlot = this;
                inv.itemOnCursor = true;
                item = null;
                Debug.Log("Picked up Item");
            }
        }
    }
}
