using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script is for all items that can be picked up. They can be collided with and they spin in place. */
public class ItemPickup : MonoBehaviour
{
    float rotation;     //used to spin the object in place

    // Update is called once per frame
    void Update()
    {
        rotation += 100 * Time.deltaTime;
        if (rotation > 360)
            rotation = 0;

        transform.rotation = Quaternion.Euler(0, rotation, 0);
    }
}
