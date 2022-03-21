using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//chips add bonuses to stats
//[CreateAssetMenu(menuName = "Item Effect/Chip", fileName = "chip_")]
public class Chip : Item
{
    protected bool isEquipped;
    public float energyMod;      //used to reduce energy spending
    public float moveSpeedMod;       //increases speed
    public float reloadSpeedMod;
    public float fireRateMod;
    public float bulletSpreadMod;
    public float gunDamageMod;
    public float meleeDamageMod;
    public float blockEfficiencyMod;   //reduces damage taken while blocking

    protected void Start()
    {
       
    }

    /*public override void Equip(Player player)
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
    }*/

}    
