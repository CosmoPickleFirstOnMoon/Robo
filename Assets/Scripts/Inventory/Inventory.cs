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

    //[SerializeField]ItemData[] items;
    [SerializeField]ItemSlot[] itemSlots;
    [SerializeField]EquipSlot[] equipSlots;     //3 slots total

    public Image dragItem;    //the item that will follow mouse cursor when an item is clicked on.
    public ModuleData copiedItem;
    [HideInInspector]public bool itemOnCursor;  //if true, item follows mouse cursor.
    
    //[SerializeField]Image[] itemIcons;
    int maxItems {get;} = 2;
    //int currentEmptySlot;           //points to an available slot.
    public int availableSlotID;

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
        //currentEmptySlot = 0;
        availableSlotID = -1;
        dragItem.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //when an item is clicked, perform an action based on the item type.
        if (itemOnCursor)
        {
            dragItem.transform.position = Input.mousePosition;
        }
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

    public bool SpaceAvailable()
    {
        int i = 0;
        bool emptySlotFound = false;
        while (!emptySlotFound && i < itemSlots.Length)
        {
            if (itemSlots[i].isEmpty)
            {
                emptySlotFound = true;
                availableSlotID = i;
            }
            else
            {
                i++;
                availableSlotID = -1;
            }
        }

        return emptySlotFound;

    }

    public void AddItem(ItemData item, int slotID)
    {
         if (slotID < 0 || slotID >= itemSlots.Length)
         {
            Debug.Log("Slot ID not valid");
            return;
         }

         itemSlots[slotID].item = item;
         itemSlots[slotID].isEmpty = false;
         itemSlots[slotID].icon.sprite = item.iconSprite;
         itemSlots[slotID].icon.enabled = true;       
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
