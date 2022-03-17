using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//all restoration of stats is done here. Scriptable objects will determine what actually gets restored.
[CreateAssetMenu(menuName = "Item Data/Healing", fileName = "heal_")]
public class HealingItemData : ItemData
{
    public float healthPercentAmount;
    public float energyPercentAmount;

    UI ui;      //need this to access the meters.
  
    public override void Activate(Player player)
    {
        ui = UI.instance;
        float healthAmount = player.maxHealth * (healthPercentAmount / 100);
        float energyAmount = player.maxEnergy * (energyPercentAmount / 100);

        if (healthAmount > 0)
        {
            player.health += healthAmount;
            ui.StartCoroutine(ui.AdjustMeter(ui.healthMeter, ui.healthSecondaryMeter, ui.healthSecondaryColor, player.health, player.maxHealth, true));
            if (player.health > player.maxHealth)
                player.health = player.maxHealth;
            Debug.Log(healthAmount + " health restored");
        }
        
        if (energyAmount > 0)
        {
            player.energy += energyAmount;
            ui.StartCoroutine(ui.AdjustMeter(ui.energyMeter, ui.energySecondaryMeter, ui.energySecondaryColor, player.energy, player.maxEnergy, true));
            if (player.energy > player.maxEnergy)
                player.energy = player.maxEnergy;
            Debug.Log(energyAmount + " energy restored");
        }

    }
}
