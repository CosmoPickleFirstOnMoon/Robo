using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is similar to ItemSlot except only modules and chips can be assigned to these.
public class EquipSlot : ItemSlot
{

    public override void UseItem()
    {
        
        if (item != null)
        {
            Debug.Log("Slot " + slotID + " contains " + item.itemName);

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
                    //chips can only be equipped if a module is equipped
                    break;
            }
        }
    }
}
