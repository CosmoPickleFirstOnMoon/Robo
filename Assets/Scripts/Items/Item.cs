using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Base class for all non-weapon consumable items. The items can be picked up in game. A separate script will handle the item effects */
public abstract class Item : MonoBehaviour
{
    public string itemName;
    public int price;           //amount of scrap to purchase
    public string description;

    public ItemEffect effect;   //occurs when item is touched upon contact, or is equipped.

    float rotation;

    public enum ItemType
    {
        Module, Chip, Blueprint, Healing, Scrap, Ammo
    }

    public ItemType type;

    void Update()
    {
        //items on the map spin in place.
        rotation += 100 * Time.deltaTime;
        if (rotation > 360)
            rotation = 0;
        
        transform.rotation = Quaternion.Euler(0, rotation, 0);
    }
}
