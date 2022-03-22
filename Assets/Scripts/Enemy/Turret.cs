using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//fires on the player if they enter its radius.
public class Turret : Enemy
{
    float cooldown = 1.5f;     //delay between shots
    //float currentTime;
    float minRange = 6;

    [SerializeField]Alarm alarmSkill;

    [SerializeField]EnemyBullet bulletPrefab;
    EnemyBullet bullet;
    // Update is called once per frame
    void Update()
    {
        //check if player is in range, and attack.
        float attackRange = Vector3.Distance(transform.position, player.transform.position);
        if (attackRange < minRange && CanFire())
        {
            Debug.Log("attacking");
            alarmSkill.Activate();
            bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.transform.parent = transform;    //need this step to acquire enemy data that can be passed on to bullet
            currentTime = Time.time;
        }
    }

    bool CanFire()
    {
        return Time.time > currentTime + cooldown;
    }
}
