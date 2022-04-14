using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Doors allow the player to move between rooms. There can be different types of doors, including locked doors or 1-way doors. */
public class Door : MonoBehaviour
{
    bool isLocked;
    byte doorID;        //used to link doors with switches or keys. For example, door ID 12 is opened by triggering switch 12.
    public enum UnlockCondition { None, KeyRequired, SwitchRequired, AllEnemiesDefeated }
    public enum DoorDirection {North, East, South, West}
    public DoorDirection doorDirection;
    public UnlockCondition unlockCondition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        isLocked = false;
    }
}
