using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This is the base class for all robots in the game. This includes the player avatar and enemy NPCs */

public class Robot : MonoBehaviour
{
    public float health;       //called TSP in game
    public float maxHealth;
    public float energy;       //basically stamina. Most actions use energy
    public float maxEnergy;
    public RobotMovement Movement { get; protected set; }
    public WeaponLoadout Loadout { get; protected set; }
    // Start is called before the first frame update
    void Start()
    {
        Movement = GetComponent<RobotMovement>();
        Loadout = GetComponent<WeaponLoadout>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    
}
