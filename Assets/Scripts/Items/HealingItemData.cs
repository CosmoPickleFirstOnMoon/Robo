using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Data/Healing", fileName = "heal_")]
public class HealingItemData : ItemData
{
    public float healthAmount;
    public float energyAmount;
    public override void Activate(Player player)
    {
        healthAmount = player.maxHealth * (healthAmount / 100);
        energyAmount = player.maxEnergy * (energyAmount / 100);

        player.health += healthAmount;
        if (player.health > player.maxHealth)
            player.health = player.maxHealth;
        
        player.energy += energyAmount;
        if (player.energy > player.maxEnergy)
            player.energy = player.maxEnergy;

        Debug.Log(healthAmount + " health restored");
    }
}
