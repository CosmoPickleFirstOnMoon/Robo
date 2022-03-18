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
        itemNameUI.text = itemName;
        itemDetailsUI.text = description;
        itemPriceUI.text = price.ToString();
        health = data.health;
        energy = data.energy;
        passiveSkill = data.passiveSkill;
    }

    public override void Equip(Player player)
    {
       if (!isEquipped)
       { 
            player.maxHealth += health;
            player.maxEnergy += energy;

            //update UI
            UI ui = UI.instance;
            ui.UpdateMeters();

            //additional effects would apply

            isEquipped = true;
       }
    }

    public override void Unequip(Player player)
    {
       if (isEquipped)
       { 
            player.maxHealth -= health;
            player.maxEnergy -= energy;
            //passiveSkill = null;
            UI ui = UI.instance;
            ui.UpdateMeters();
            isEquipped = false;
       }
    }

    protected override void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Player"))
        {
            Player player = Player.instance;
            Equip(player);
            Destroy(gameObject);    //TODO: need to instead hide gameobject and destroy it later.
        }
    }
}
