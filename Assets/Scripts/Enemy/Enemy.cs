using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Base class for all enemies in the game. All enemies should derive from this class */
public class Enemy : Robot
{
    Player player;

    public EnemyData data;          //enemy object must have this scriptable object attached
    public string enemyName;
    public string description;
    public float moveSpeed;
    public float attackPower;       //how much damage they deal to player. This is the base amount, as player can reduce the dmg they receive
    public float defensePower;      //resistance to player attacks
    public int scrapAmount;         //how much scrap is dropped when enemy dies
    public Item commonItem;
    public Item rareItem;
    public float commonItemDropRate;
    public float rareItemDropRate;      

    // Start is called before the first frame update
    protected void Start()
    {
        player = Player.instance;
        enemyName = data.enemyName;
        description = data.description;
        maxHealth = data.health;
        health = maxHealth;
        maxEnergy = data.energy;
        energy = maxEnergy;
        moveSpeed = data.moveSpeed;
        attackPower = data.attackPower;
        defensePower = data.defensePower;
        scrapAmount = data.scrapAmount;
        commonItem = data.commonItem;
        rareItem = data.rareItem;
        commonItemDropRate = data.commonItemDropRate;
        rareItemDropRate = data.rareItemDropRate;
    }

    /* enemies can drop items in addition to scrap. If an enemy has a rare item, that is rolled first, then common item. There's a chance that nothing
    may drop at all. */
    public void DropItem(Item commonItem, Item rareItem)
    {
        //roll for rare item
        float roll = Random.Range(0, 1);
        if (roll <= rareItemDropRate)
        {
            //instantiate rare item where the enemy died
        }
        else if (roll <= commonItemDropRate)
        {
            //instantiate common item where the enemy died
        }
    }

}
