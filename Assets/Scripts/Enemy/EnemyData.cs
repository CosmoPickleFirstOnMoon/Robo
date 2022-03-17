using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Data", fileName = "enemy_")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    [TextArea]public string description;
    public float health;            //max health
    public float energy;            //max energy
    public float moveSpeed;
    public float attackPower;       //how much damage they deal to player. This is the base amount, as player can reduce the dmg they receive
    public float defensePower;      //resistance to player attacks
    public int scrapAmount;         //how much scrap is dropped when enemy dies
    public Item commonItem;
    public Item rareItem;
    public float commonItemDropRate;
    public float rareItemDropRate;
}
