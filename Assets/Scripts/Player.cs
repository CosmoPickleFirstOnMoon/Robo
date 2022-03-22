using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

/*This script contains the player's stats. */

public class Player : Robot
{
    [Header("Player stats")]
    //public float health;       //called TSP in game
    //public float maxHealth;
    //public float energy;       //basically stamina. Most actions use energy
    //public float maxEnergy;

    [Header("Energy")]
    public float energyRegenRate;
    public float energyRegenMod;           //controls how fast the energy is restored.
    float energyRegenDelayDuration; //time is in seconds
    [SerializeField]float sprintCost;       //how much energy is used per frame. The amount is scaled by delta time.
    //float currentTime;

    //mods affect both the player and their equipped weapon's performance. By default, they have no effect until modules/chips are equipped.
    [Header("Mods")]
    public float energyMod;          //used to reduce energy spending
    public float moveSpeedMod;       //increases walk speed
    public float reloadSpeedMod;
    public float fireRateMod;
    public float bulletSpreadMod;
    public float gunDamageMod;
    public float meleeDamageMod;
    public float blockEfficiencyMod;   //reduces damage taken while blocking

    [Header("Modules")]
    [SerializeField]Module[] modules;               //3 modules: 2 arm, 1 leg
    int maxModules {get;} = 3;

    public Skill passiveSkill;          //may turn this into a list so player can have more than 1 passive.


    public bool weaponPickedUp;
    [HideInInspector]public bool isHealing;

    //singletons
    public static Player instance;
    RobotMovement rm;

   void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        //I set up stats here so UI script has access to these values when needed
        maxHealth = 120;
        maxEnergy = 80;
        health = maxHealth;
        energy = maxEnergy;
    }

    // Start is called before the first frame update
    void Start()
    {
        rm = RobotMovement.instance;
        energyRegenMod = 0.18f;   
        energyRegenRate = maxEnergy * energyRegenMod;   //by default, 18% of energy is restored each second
        energyRegenDelayDuration = 1.5f;
        sprintCost = 15;
        modules = new Module[maxModules];    
    }

    //Any actions that use up energy will cause the regeneration to be delayed until the action stops.
    public void ReduceEnergy(float amount)
    {
        energy -= (amount - energyMod);

        if (energy < 0)
            energy = 0;
        
        //start the delay
        currentTime = Time.time;

        //update UI
        UI ui = UI.instance;
        ui.ChangeEnergyMeter();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health < 0)
            health = 0;
        
        //update UI
        UI ui = UI.instance;
        ui.ChangeHealthMeter();
    }

    public void RestoreHealth(float amount)
    {
        health += amount;
        if (health > maxHealth)
            health = maxHealth;
        
        //update UI
        UI ui = UI.instance;
        ui.ChangeHealthMeter(healing: true);
    }

    public bool EnergyRegenerating()
    {
        return Time.time > currentTime + energyRegenDelayDuration;
    }

   
    void Update()
    {
        if (energy < maxEnergy && EnergyRegenerating())
        {
            energy += energyRegenRate * Time.deltaTime;
            if (energy > maxEnergy)
                energy = maxEnergy;
        }

        if (rm.isSprinting)
        {
            ReduceEnergy((sprintCost - energyMod) * Time.deltaTime);
        }

        //passive skill check
        if (passiveSkill != null)
        {
            //Debug.Log("Checking passive skill");

            if (passiveSkill.targetType == Skill.TargetType.Self)
                passiveSkill.Activate(this);
        }
    }

    void OnCollisionEnter(Collision target)
    {
        //Enemy enemy = target.gameObject.GetComponent<Enemy>();
        //health -= enemy.attackPower;
    }

}
