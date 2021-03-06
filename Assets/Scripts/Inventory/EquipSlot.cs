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
            //must check if the item is a module
            if (inv.copiedItem.itemType == ItemData.ItemType.Module)
            {
                inv.copiedModule = (ModuleData)inv.copiedItem;

                //is the slot type arm or leg? TODO: re-write code to be cleaner
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
                        inv.copiedItem = null;

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
                        inv.copiedItem = item;
                        item = inv.copiedModule;
                        icon.sprite = inv.dragItem.sprite;
                        inv.copiedModule = oldModule;
                        inv.dragItem.sprite = oldModule.iconSprite;
                    }

                    //delete the item from the slot it was in before.
                    inv.copiedSlot = null;
                }
                else if (slotType == SlotType.Leg && 
                    (inv.copiedModule.moduleType == ModuleData.ModuleType.FastLeg || inv.copiedModule.moduleType == ModuleData.ModuleType.ScrappyLeg
                    || inv.copiedModule.moduleType == ModuleData.ModuleType.IndustrialLeg))  //item is a leg module
                {
                    if (item == null)
                    {
                        //drop module in slot and equip
                        item = inv.copiedModule;
                        icon.sprite = inv.dragItem.sprite;
                        icon.enabled = true;
                        inv.itemOnCursor = false;
                        inv.copiedModule = null;
                        inv.copiedItem = null;

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
                        inv.copiedItem = item;
                        item = inv.copiedModule;
                        icon.sprite = inv.dragItem.sprite;
                        inv.copiedModule = oldModule;
                        inv.dragItem.sprite = oldModule.iconSprite;
                    }

                    //delete the item from the slot it was in before.
                    inv.copiedSlot = null;
                }
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
            inv.copiedItem = item;
            inv.copiedModule = (ModuleData)item;
            inv.copiedSlot = this;
            inv.itemOnCursor = true;
            item = null;
        }
        
    }
}
