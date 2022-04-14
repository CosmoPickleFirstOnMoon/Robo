using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* A room consists of a rectangular room with up to 4 doors. There must be at least 1 door. */
public class Room : MonoBehaviour
{
    public Door[] doors;
     

    // Start is called before the first frame update
    void Start()
    {
        //every time a room is generated, select a random number of doors to generate. We only check 3 doors to guarantee at least
        //1 door is available
        for (int i = 0; i < 3; i++)
        {
            int randDoor = Random.Range(0, doors.Length);
            bool toggle = doors[randDoor].gameObject.activeSelf;
            doors[randDoor].gameObject.SetActive(!toggle);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
