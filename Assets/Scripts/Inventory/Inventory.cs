using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script controls the inventory behaviour, including opening and closing the inventory, using items, and equipping gear.
public class Inventory : MonoBehaviour
{
    [SerializeField]Button tabButton;   //open/close the inventory
    [SerializeField]Image container;    //holds all acquired items
    [SerializeField]Transform restPosition; //when inventory is opened, the game object travels to this transform.
    bool isOpened;
    Vector3 initPos;                    //original position. Container is offscreen, and tab is visible.
    bool animateInventoryCoroutineOn;
    

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    //This method is triggered when tab button is clicked.
    public void ToggleInventory()
    {
        isOpened = !isOpened;

        if (!animateInventoryCoroutineOn)
        {
            StartCoroutine(AnimateInventory());
        }
    }

    //coroutine functions differently depending on inventory state
    IEnumerator AnimateInventory()
    {
        animateInventoryCoroutineOn = true;

        if (isOpened)
        {
            while(transform.position.x > restPosition.position.x)
            {
                float xPos = 1000 * Time.deltaTime;
                transform.position = new Vector3(transform.position.x - xPos, transform.position.y, transform.position.z);
                yield return null;
            }

            transform.position = restPosition.position;
        }
        else
        {
            while(transform.position.x < initPos.x)
            {
                float xPos = 1000 * Time.deltaTime;
                transform.position = new Vector3(transform.position.x + xPos, transform.position.y, transform.position.z);
                yield return null;
            }

            transform.position = initPos;
        }
        
        animateInventoryCoroutineOn = false;
    }
}
