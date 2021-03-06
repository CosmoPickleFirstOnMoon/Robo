using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/* Base class for all non-weapon consumable items. The items can be picked up in game. A separate script will handle the item effects */
public abstract class Item : MonoBehaviour
{
    public string itemName;
    public int price;           //amount of scrap to purchase
    public string description;
    public Sprite icon;
    //public ItemData data;

    public TextMeshProUGUI itemNameUI;
    public TextMeshProUGUI itemDetailsUI;
    public TextMeshProUGUI itemPriceUI;

    //public ItemEffect effect;   //occurs when item is touched upon contact, or is equipped.
    //public ItemData itemEffect;
    //public ItemData data;

    float rotation;

    void Update()
    {
        //items on the map spin in place.
        rotation += 100 * Time.deltaTime;
        if (rotation > 360)
            rotation = 0;
        
        transform.rotation = Quaternion.Euler(0, rotation, 0);
    }

    protected virtual void OnTriggerEnter(Collider target) {}
   
    //public virtual void Activate(Player player){}   //this is for one-time effects, such as healing.
    //public virtual void Equip(Player player){}
    //public virtual void Unequip(Player player){}
    //public virtual void PassiveEffect(Player player){}
}
