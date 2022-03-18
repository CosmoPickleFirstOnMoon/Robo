using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Data/Module", fileName = "module_")]
public class ModuleData : ItemData
{
    //protected bool isEquipped;
    public float health;
    public float energy;
    public float moveSpeed;
    public Skill passiveSkill;   //must run in Player.cs update loop

    /*public override void Equip(Player player)
    {
       if (!isEquipped)
       { 
            player.maxHealth += health;
            player.maxEnergy += energy;

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
            isEquipped = false;
       }
    }*/
}
