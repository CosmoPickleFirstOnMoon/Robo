using UnityEngine;

//if health goes below 1/3, the target immediately gets 50% health back, and this skill goes into cooldown.
[CreateAssetMenu(menuName = "Skill/Emergency Heal", fileName = "skill_emergencyHeal")]
public class EmergencyHeal : Skill
{
    //float currentTime;
    public override void Activate(Robot target)
    {
        float lowHealth = Mathf.Round(target.maxHealth * 0.33f);
        if (target.health < lowHealth && Time.time > currentTime + cooldown)
        {
            float healAmount = Mathf.Round(target.maxHealth * 0.5f);

            //must check who is receiving the health so appropriate method is called.
            if (target.TryGetComponent(out Player player))
            {
                player.RestoreHealth(healAmount);
            }
            /*else if (target.TryGetComponent(out Enemy enemy))
            {

            }*/
            currentTime = Time.time;

            
            Debug.Log("Emergency Heal activated, " + healAmount + " TSP restored");
            
        }
    }
}
