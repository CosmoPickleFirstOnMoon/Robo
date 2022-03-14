using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Effect/Healing", fileName = "heal_repairKit")]
public class RepairKitEffect : ItemEffect
{
    public float amount;
    public override void Activate(Player player)
    {
        player.health += amount;
        if (player.health > player.maxHealth)
            player.health = player.maxHealth;

        Debug.Log(amount + " health restored");
    }
}
