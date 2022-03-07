using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script manages all player animations. It will check for any player input, and then play the appropriate animation. */

public class AnimationController : MonoBehaviour
{
    Animator anim;
    Vector3 direction;  //used to get x and z values of player movement input.

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        //set animation
        if (direction.x < 0)
            anim.SetTrigger("WalkL");

        if (direction.x > 0)
            anim.SetTrigger("WalkR");

        //For forward and back movement, need to check which direction player is facing. For example, if player inputs up while looking in the
        //opposite direction, the walk forward animation will play when in reality it should be the walk backward animation.
        if (direction.z > 0)
        {
            Debug.Log("walking forward");
            anim.SetTrigger("WalkF");
        }

        if (direction.z < 0)
        {
            Debug.Log("Walking backwards");
            anim.SetTrigger("WalkB");
        }

        if (direction.x == 0)
            anim.SetTrigger("Idle");

    }
}
