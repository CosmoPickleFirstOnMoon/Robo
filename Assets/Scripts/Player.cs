using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

/*This script handles all controllable actions by the player. */

public class Player : Robot
{
    //public Rigidbody rb;

    //all weapons are hidden by default until player selects them. Only one weapon is visible at a time.
    //[SerializeField]Transform weaponTransform;  //used to position weapons in front of the robot. This transform follows the player.

    //player stats
    public float health;       //called TSP in game
    public float maxHealth;
    public float energy;       //basically stamina. All actions use energy
    public float maxEnergy;


    //public Shotgun shotgun;         
    Vector3 moveDirection;
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
        //rm = RobotMovement.instance;

        //Weapon placement. Each weapon is adjusted to rest in the robot's hands.
        /*shotgun.transform.localPosition = new Vector3(-0.412f,1.2f,-0.574f);
        shotgun.transform.localRotation = Quaternion.Euler(0,-10,0);
        shotgun.gameObject.SetActive(false);
        weaponPickedUp = false;*/
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
