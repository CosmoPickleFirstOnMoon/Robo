using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* when an item is used, its corresponding effect is activated. */
public abstract class ItemData : ScriptableObject
{
    public string itemName;
    public int price;           //amount of scrap to purchase
    public string description;

    public enum ItemType
    {
        Module, Chip, Blueprint, Healing, Scrap, Ammo
    }

    public ItemType type;
    public Sprite iconSprite;     //this appears in UI and the inventory.

    public virtual void Activate(Player player){}   //this is for one-time effects, such as healing.
    public virtual void Equip(Player player){}
    public virtual void Unequip(Player player){}
    public virtual void PassiveEffect(Player player){}
}
