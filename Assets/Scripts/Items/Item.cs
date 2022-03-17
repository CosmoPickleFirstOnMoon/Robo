using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/* Base class for all non-weapon consumable items. The items can be picked up in game. A separate script will handle the item effects */
public class Item : MonoBehaviour
{
    public string itemName;
    public int price;           //amount of scrap to purchase
    public string description;

    public TextMeshProUGUI itemNameUI;
    public TextMeshProUGUI itemDetailsUI;
    public TextMeshProUGUI itemPriceUI;

    //public ItemEffect effect;   //occurs when item is touched upon contact, or is equipped.
    //public ItemData itemEffect;
    public ItemData data;

    float rotation;

    protected void Start()
    {

    }

    void Update()
    {
        //items on the map spin in place.
        rotation += 100 * Time.deltaTime;
        if (rotation > 360)
            rotation = 0;
        
        transform.rotation = Quaternion.Euler(0, rotation, 0);
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Player"))
        {
            //item goes into inventory

            //itemEffect.Activate(target.GetComponent<Player>()); //this line has to go eventually
            Destroy(gameObject);    //TODO: need to instead hide gameobject and destroy it later.
        }
    }
}
