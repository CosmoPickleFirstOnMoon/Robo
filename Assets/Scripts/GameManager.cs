using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[SerializeField]Item testItem;

    ItemManager itemManager;
    [SerializeField]Item itemPrefab;
    public bool gamePaused;             //game pauses when inventory is open. only the player cannot act.

    public static GameManager instance;
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
        /*itemManager = ItemManager.instance;
        itemManager.itemObjects = new Item[itemManager.itemData.Length];

        //item set up
        for (int i = 0; i < itemManager.itemObjects.Length; i++)
        {
            itemManager.itemObjects[i] = Instantiate(itemPrefab);
        
            itemManager.itemObjects[i].itemEffect = itemManager.itemData[i];    //this will call the script containing the item's effects.
            itemManager.itemObjects[i].itemNameUI.text = itemManager.itemData[i].itemName;
            itemManager.itemObjects[i].itemPriceUI.text = itemManager.itemData[i].price.ToString();
            itemManager.itemObjects[i].itemDetailsUI.text = itemManager.itemData[i].description;
        }

        Vector3 itemPos = itemManager.itemObjects[1].transform.position;
        itemManager.itemObjects[1].transform.position = new Vector3(itemPos.x - 3, itemPos.y, itemPos.z);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
