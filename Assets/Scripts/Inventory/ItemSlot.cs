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
    protected void Start()
    {
        isEmpty = true;
        icon.enabled = false;
    }

   
    //This method is called when the slot is clicked on.
    public virtual void UseItem()
    {
        
        if (item != null)
        {
            Debug.Log("Item Slot " + slotID + " contains " + item.itemName);

            //check the item type so we know which method to execute
            switch(item.itemType)
            {
                case ItemData.ItemType.Module:
                    Player player = Player.instance;
                    if (!item.IsEquipped())
                    {
                        item.Equip(player);
                        Debug.Log(item.itemName + " equipped");
                    }
                    else
                    {
                        item.Unequip(player);
                        Debug.Log(item.itemName + " removed");
                    }
                    break;
                case ItemData.ItemType.Chip:
                    break;
                case ItemData.ItemType.Blueprint:
                    break;
                case ItemData.ItemType.Healing:
                    break;
            }
        }
    }
}
