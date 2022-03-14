using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Data/Healing", fileName = "heal_")]
public class HealingItemData : ItemData
{
    public float healthPercentAmount;
    public float energyPercentAmount;
    public override void Activate(Player player)
    {
        float healthAmount = player.maxHealth * (healthPercentAmount / 100);
        float energyAmount = player.maxEnergy * (energyPercentAmount / 100);

        player.health += healthAmount;
        if (player.health > player.maxHealth)
            player.health = player.maxHealth;
        
        player.energy += energyAmount;
        if (player.energy > player.maxEnergy)
            player.energy = player.maxEnergy;

        Debug.Log(healthAmount + " health restored");
        Debug.Log(energyAmount + " energy restored");
    }
}
