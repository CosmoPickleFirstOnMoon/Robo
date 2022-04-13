using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

/* Base class for all non-weapon consumable items. The items can be picked up in game. A separate script will handle the item effects */
public abstract class Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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

    public void OnPointerEnter(PointerEventData pointer)
    {
        Debug.Log("Mouse over " + itemName);
        UI ui = UI.instance;
        ui.itemPopupObject.SetActive(true);
        ui.itemPopupText.text = itemNameUI.text + "\n" + itemPriceUI.text + " Scrap\n" + itemDetailsUI.text;
    }

    public void OnPointerExit(PointerEventData pointer)
    {
        UI ui = UI.instance;
        ui.itemPopupObject.SetActive(false);
        ui.itemPopupText.text = "";
    }

    protected virtual void OnTriggerEnter(Collider target) {}
   
    //public virtual void Activate(Player player){}   //this is for one-time effects, such as healing.
    //public virtual void Equip(Player player){}
    //public virtual void Unequip(Player player){}
    //public virtual void PassiveEffect(Player player){}
}
