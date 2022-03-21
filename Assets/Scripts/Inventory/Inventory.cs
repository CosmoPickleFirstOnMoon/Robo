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
    [HideInInspector]public bool isOpened;
    Vector3 initPos;                    //original position. Container is offscreen, and tab is visible.
    bool animateInventoryCoroutineOn;

    [SerializeField]ItemData[] items;
    [SerializeField]ItemSlot[] itemSlots;
    [SerializeField]Image[] itemIcons;
    int maxItems {get;} = 2;
    int currentEmptySlot;           //points to an available slot.

    public static Inventory instance;

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
        initPos = transform.position;
        //items = new Item[maxItems];
        //itemSlots = new Image[maxItems];
        currentEmptySlot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //when an item is clicked, perform an action based on the item type.
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

    public void AddItem(ItemData item)
    {
        if (currentEmptySlot >= items.Length)   //no more space
        {
            Debug.Log("No more space! Drop an item");
            return;
        }

        items[currentEmptySlot] = item;
        //itemSlots[currentEmptySlot].GetComponentInChildren<Image>().sprite = item.icon;
        itemIcons[currentEmptySlot].sprite = item.icon;
        currentEmptySlot++;
    }

    //use an item in the inventory when it's clicked. The result depends on the item type.
    public void UseItem()
    {
        //which slot was clicked?
        Debug.Log("Button clicked");
    
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
