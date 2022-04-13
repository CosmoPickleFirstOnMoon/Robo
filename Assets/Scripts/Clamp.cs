using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This is used to attach UI elements on objects in world space. This will allow UI elements to follow an object.
public class Clamp : MonoBehaviour
{
    public Image mouseTarget;             //allows mouse actions to occur when mouse hovers over it.

    // Start is called before the first frame update
    void Start()
    {       
        Vector3 screenPos = Camera.main.ScreenToWorldPoint(transform.position);   //attach to an object in world space
        //SpriteRenderer sr = GetComponent<SpriteRenderer>();
        //textUI.transform.position = new Vector3(textPos.x + xOffset, textPos.y + yOffset, 0);
        //place UI underneath the sprite
        //textUI.transform.position = new Vector3(textPos.x, textPos.y - (sr.bounds.extents.y * 65), 0);

        //image must be enabled for mouse hover to work but alpha is reduced to 0
        mouseTarget.transform.position = screenPos;
        //mouseTarget.SetNativeSize();
        mouseTarget.color = new Color(1, 1, 1, 0);
    }
}
