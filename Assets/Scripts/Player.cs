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


    public bool weaponPickedUp;
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
    }

    // Start is called before the first frame update
    void Start()
    {

        maxHealth = 120;
        maxEnergy = 80;
        health = maxHealth;
        energy = maxEnergy;
    }

   
    void Update()
    {
       
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
