using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//chips add bonuses to stats
//[CreateAssetMenu(menuName = "Item Effect/Chip", fileName = "chip_")]
public class Chip : Item
{
    bool isEquipped;
    public float health;
    public float energy;
    public float moveSpeed;


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
