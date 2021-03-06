using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* when an item is used, its corresponding effect is activated. */
public class ItemData : ScriptableObject
{
    public string itemName;
    public int price;           //amount of scrap to purchase
    public string description;
    [System.NonSerialized]protected bool isEquipped = false;    //this is non-serialized so that Unity doesn't save the variable state after the game is stopped.
    

    public enum ItemType
    {
        Module, Chip, Blueprint, Healing
    }

    public ItemType itemType;
    public Sprite iconSprite;     //this appears in UI and the inventory.

    public virtual void Activate(Player player){}   //this is for one-time effects, such as healing.
    public virtual void Equip(Player player){}
    public virtual void Unequip(Player player){}
    public virtual void PassiveEffect(Player player){}
    public bool IsEquipped() { return isEquipped; }
}
