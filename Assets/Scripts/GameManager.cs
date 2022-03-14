using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
<<<<<<< HEAD
=======
            itemManager.itemObjects[i].itemEffect = itemManager.itemData[i];    //this will call the script containing the item's effects.
            itemManager.itemObjects[i].itemNameUI.text = itemManager.itemData[i].itemName;
            itemManager.itemObjects[i].itemPriceUI.text = itemManager.itemData[i].price.ToString();
            itemManager.itemObjects[i].itemDetailsUI.text = itemManager.itemData[i].description;
        }
>>>>>>> parent of 7b80c7c (Added energy and durability sliders)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
