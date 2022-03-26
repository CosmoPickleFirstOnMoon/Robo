using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is similar to ItemSlot except only modules and chips can be assigned to these.
public class EquipSlot : ItemSlot
{
    public enum SlotType {Arm, Leg}
    public SlotType slotType;

    public void EquipItem()
    {
        Inventory inv = Inventory.instance;
        Player player = Player.instance;
        if (inv.itemOnCursor)
        {
            //is the slot type arm or leg?
            if (slotType == SlotType.Arm && 
                (inv.copiedModule.moduleType == ModuleData.ModuleType.FastArm || inv.copiedModule.moduleType == ModuleData.ModuleType.ScrappyArm
                || inv.copiedModule.moduleType == ModuleData.ModuleType.IndustrialArm))
            {
                if (item == null)
                {
                    //drop module in slot and equip
                    item = inv.copiedModule;
                    icon.sprite = inv.dragItem.sprite;
                    icon.enabled = true;
                    inv.itemOnCursor = false;
                    inv.copiedModule = null;

                    if (!item.IsEquipped())
                    {
                        item.Equip(player);
                        Debug.Log(item.itemName + " equipped to equip slot " + slotID);
                    }
                }
                else
                {
                    //drop module in slot and equip, and old module goes to cursor and its data is copied.
                    if (item.IsEquipped())
                    {
                        item.Unequip(player);
                        Debug.Log(item.itemName + " unequipped from equip slot " + slotID);
                    }
                    ModuleData oldModule = (ModuleData)item;
                    item = inv.copiedModule;
                    icon.sprite = inv.dragItem.sprite;
                    inv.copiedModule = oldModule;
                    inv.dragItem.sprite = oldModule.iconSprite;
                    //inv.dragItem.enabled = true;
                }

                //delete the item from the slot it was in before.
                inv.copiedSlot = null;
            }
            else    //item is a leg module
            {

            }
        }
        else    //picking up item and unequipping it
        {
            if (item.IsEquipped())
            {
                item.Unequip(player);
                Debug.Log(item.itemName + " unequipped from equip slot " + slotID);
            }
            inv.dragItem.sprite = icon.sprite;
            icon.enabled = false;

            //copy item data
            inv.copiedModule = (ModuleData)item;
            inv.copiedSlot = this;
            inv.itemOnCursor = true;
            item = null;
        }
        
        /*if (item != null)
        {
            Debug.Log("Equip Slot " + slotID + " contains " + item.itemName);

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
        }*/
    }
}
