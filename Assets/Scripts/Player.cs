using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

/*This script contains the player's stats. */

public class Player : Robot
{
    [Header("Player stats")]
    public float health;       //called TSP in game
    public float maxHealth;
    public float energy;       //basically stamina. Most actions use energy
    public float maxEnergy;

    float energyRegenRate;
    float energyRegenMod;           //controls how fast the energy is restored.
    float energyRegenDelayDuration; //time is in seconds
    float currentTime;


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

        /*maxHealth = 120;
        maxEnergy = 80;
        health = maxHealth;
        energy = maxEnergy;*/
        rm = RobotMovement.instance;
        energyRegenMod = 0.18f;
        energyRegenRate = maxEnergy * energyRegenMod;
        energyRegenDelayDuration = 1.5f;    
    }

    //Any actions that use up energy will cause the regeneration to be delayed until the action stops.
    public void ReduceEnergy(float amount)
    {
        energy -= amount;

        if (energy < 0)
            energy = 0;
        
        //start the delay
        currentTime = Time.time;
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
    }

}
