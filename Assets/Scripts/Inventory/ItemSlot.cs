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
    public virtual void UseItem()
    {
        Inventory inventory = Inventory.instance;
        if (item != null)
        {
            Debug.Log("Item Slot " + slotID + " contains " + item.itemName);

            //check the item type so we know which method to execute
            switch(item.itemType)
            {
                case ItemData.ItemType.Module: /*case ItemData.ItemType.Chip:*/
                    //inventory.dragItem.sprite = item.iconSprite;
                    inventory.itemOnCursor = !inventory.itemOnCursor;
                    if (inventory.itemOnCursor == true)
                    {
                        //pick up item
                        inventory.dragItem.sprite = icon.sprite;
                        icon.enabled = false;
                        //inventory.dragItem.enabled = true;

                        //copy item data
                        inventory.copiedModule = (ModuleData)item;
                        inventory.copiedSlot = this;
                        item = null;
                    }
                    else
                    {
                        //drop item

                        icon.enabled = true;
                        icon.sprite = inventory.dragItem.sprite;
                        //inventory.dragItem.sprite = null;
                        //inventory.dragItem.enabled = false;
                    }                  
                    //inventory.dragItem.sprite = (inventory.itemOnCursor == true) ? item.iconSprite : null;
                    
                    /*Player player = Player.instance;
                    if (!item.IsEquipped())
                    {
                        item.Equip(player);
                        Debug.Log(item.itemName + " equipped");
                    }
                    else
                    {
                        item.Unequip(player);
                        Debug.Log(item.itemName + " removed");
                    }*/
                    break;
                //case ItemData.ItemType.Chip:
                    //break;
                case ItemData.ItemType.Blueprint:
                    break;
                case ItemData.ItemType.Healing:
                    break;
            }
        }
        else
        {
            //check if item is on cursor, and drop item into slot.
        }
    }
}
