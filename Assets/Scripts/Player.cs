using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

/*This script contains the player's stats. */

public class Player : Robot
{
    //player stats
    public float health;       //called TSP in game
    public float maxHealth;
    public float energy;       //basically stamina. All actions use energy
    public float maxEnergy;

    float energyRegenRate;
    float energyRegenMod;   //controls how fast the energy is restored.


    public bool weaponPickedUp;
    [HideInInspector]public bool isHealing;
    //RobotMovement rm;
    public static Player instance;

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
        energy = 0; //maxEnergy;
    }

    // Start is called before the first frame update
    void Start()
    {

        /*maxHealth = 120;
        maxEnergy = 80;
        health = maxHealth;
        energy = maxEnergy;*/
        energyRegenMod = 0.18f;
        energyRegenRate = maxEnergy * energyRegenMod;    
    }

   
    void Update()
    {
        if (energy < maxEnergy)
        {
            energy += energyRegenRate * Time.deltaTime;
            if (energy > maxEnergy)
                energy = maxEnergy;
        }
    }

    #region Controls
    /*public void MoveForward(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            //move player forward
            Debug.Log("moved forward");
            //rb.AddForce(Vector3.forward * moveSpeed, ForceMode.Force);
            vz = moveSpeed;
        }
        else
        {
            vz = 0;
        }
    }

    public void MoveBackward(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            //move player back
           Debug.Log("moved back");
           vz = -moveSpeed;
        }
        else
        {
            vz = 0;
        }
        
    }

    public void MoveLeft(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            //move player left
            Debug.Log("moved left");
            vx = -moveSpeed;
        }
        else
        {
            vx = 0;
        }

    }

    public void MoveRight(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            //move player right
            Debug.Log("moved right");
            vx = moveSpeed;
        }
        else
        {
            vx = 0;
        }
       
    }

    public void FireWeapon(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            //shoot equipped weapon
            Debug.Log("fire!");
        }

    }*/

    #endregion
}
