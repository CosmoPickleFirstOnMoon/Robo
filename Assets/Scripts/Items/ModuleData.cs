using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Data/Module", fileName = "module_")]
public class ModuleData : ItemData
{
    //public bool isEquipped;
    public float health;
    public float energy;
    public float moveSpeed;
    public Skill passiveSkill;   //must run in Player.cs update loop

    public override void Equip(Player player)
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

            //correct the stats
            if (player.health > player.maxHealth)
               player.health = player.maxHealth;
            
            if (player.energy > player.maxEnergy)
               player.energy = player.maxEnergy;
            
            UI ui = UI.instance;
            ui.UpdateMeters();
            isEquipped = false;
       }
    }
}
