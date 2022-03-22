using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//if health goes below 1/3, the target immediately gets 50% health back, and this skill goes into cooldown.
[CreateAssetMenu(menuName = "Skill/Emergency Heal", fileName = "skill_emergencyHeal")]
public class EmergencyHeal : Skill
{
    float cooldown = 10;
    //float currentTime;
    public override void Activate(Robot target)
    {
        float lowHealth = Mathf.Round(target.maxHealth * 0.33f);
        if (target.health < lowHealth && Time.time > target.currentTime + cooldown)
        {
            float healAmount = Mathf.Round(target.maxHealth * 0.5f);

            //must check who is receiving the health so appropriate method is called.
            if (target.TryGetComponent(out Player player))
            {
                player.RestoreHealth(healAmount);
                player.currentTime = Time.time;
            }
            
            Debug.Log("Emergency Heal activated, " + healAmount + " TSP restored");
            
        }
    }
}
