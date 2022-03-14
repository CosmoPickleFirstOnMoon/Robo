using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This is the base class for all robots in the game. This includes the player avatar and enemy NPCs */

public abstract class Robot : MonoBehaviour
{
    public float health;       //called TSP in game
    public float maxHealth;
    public float energy;       //basically stamina. All actions use energy
    public float maxEnergy;

}
