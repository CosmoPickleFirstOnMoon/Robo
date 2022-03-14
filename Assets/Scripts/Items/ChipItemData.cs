using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//chips add bonuses to stats
[CreateAssetMenu(menuName = "Item Data/Chip", fileName = "chip_")]
public class ChipItemData : ItemData
{
    bool isEquipped;
    public float health;
    public float energy;
    public float moveSpeed;
    //public ItemEffect passiveEffect;


    public override void Equip(Player player)
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
    }

}    
