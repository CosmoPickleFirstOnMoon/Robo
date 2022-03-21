using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Item/Module", fileName = "mod_")]
public class Module : Item
{
    public ModuleData data;
    protected bool isEquipped;
    public float health;
    public float energy;
    public Skill passiveSkill;

    void Start()
    {
        itemName = data.itemName;
        price = data.price;
        description = data.description;
        icon = data.icon;
        itemNameUI.text = itemName;
        itemDetailsUI.text = description;
        itemPriceUI.text = price.ToString();
        health = data.health;
        energy = data.energy;
        passiveSkill = data.passiveSkill;
    }

    /*public override void Equip(Player player)
    {
       if (!isEquipped)
       { 
            player.maxHealth += health;
            player.maxEnergy += energy;
            player.energyRegenRate = player.maxEnergy * player.energyRegenMod;

            //update UI
            UI ui = UI.instance;
            ui.UpdateMeters();

            //additional effects would apply
            player.passiveSkill = passiveSkill;

            isEquipped = true;
       }
    }

    public override void Unequip(Player player)
    {
       if (isEquipped)
       { 
            player.maxHealth -= health;
            player.maxEnergy -= energy;
            player.energyRegenRate = player.maxEnergy * player.energyRegenMod;
            player.passiveSkill = null;
            UI ui = UI.instance;
            ui.UpdateMeters();
            isEquipped = false;
       }
    }*/

    protected override void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Player"))
        {
            //copy module data and add to inventory
            Inventory inventory = Inventory.instance;
            
            inventory.AddItem(data);            //TODO: Need to make a separate copy of the item

            Player player = Player.instance;
            //Equip(player);
            //gameObject.SetActive(false);
            Destroy(gameObject);    //TODO: need to instead hide gameobject and destroy it later.
        }
    }
}
