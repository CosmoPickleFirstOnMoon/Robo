using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//chips add bonuses to stats
[CreateAssetMenu(menuName = "Item Data/Chip", fileName = "chip_")]
public class ChipData : ItemData
{
    //protected bool isEquipped;
    //public float health;
    //public float energy;
    //public float moveSpeed;
    //public Skill passiveSkill;   //if a chip has a skill, it becomes active.

    public float energyMod;      //used to reduce energy spending
    public float moveSpeedMod;       //increases speed
    public float reloadSpeedMod;
    public float fireRateMod;
    public float bulletSpreadMod;
    public float gunDamageMod;
    public float meleeDamageMod;
    public float blockEfficiencyMod;   //reduces damage taken while blocking




    public override void Equip(Player player)
    {
       if (!isEquipped)
       { 
            player.energyMod += energyMod;
            player.moveSpeedMod += moveSpeedMod;
            player.reloadSpeedMod += reloadSpeedMod;
            player.fireRateMod += fireRateMod;
            player.bulletSpreadMod += bulletSpreadMod;
            player.gunDamageMod += gunDamageMod;
            player.meleeDamageMod += meleeDamageMod;
            player.blockEfficiencyMod += blockEfficiencyMod;

            isEquipped = true;
       }
    }

    public override void Unequip(Player player)
    {
       if (isEquipped)
       { 
            player.energyMod -= energyMod;
            player.moveSpeedMod -= moveSpeedMod;
            player.reloadSpeedMod -= reloadSpeedMod;
            player.fireRateMod -= fireRateMod;
            player.bulletSpreadMod -= bulletSpreadMod;
            player.gunDamageMod -= gunDamageMod;
            player.meleeDamageMod -= meleeDamageMod;
            player.blockEfficiencyMod -= blockEfficiencyMod;

            isEquipped = false;
       }
    }

}    
