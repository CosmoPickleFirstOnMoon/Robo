using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI healthValueUI;
    public TextMeshProUGUI energyValueUI;
    public GameObject itemPopupObject;
    public TextMeshProUGUI itemPopupText;       //displays item text such as name, price, description, etc.

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = Player.instance;

        //item popup UI is off by default, and only appears when mouse hovers over an item
        itemPopupObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //update player data
        healthValueUI.text = player.health.ToString();
        energyValueUI.text = player.energy.ToString();

        //check if mouse is pointing to something.
        Ray ray;
        RaycastHit hit;
         
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && hit.collider.GetComponent<Item>())
        {
            //display item data
            itemPopupObject.SetActive(true);
            Item item = hit.collider.GetComponent<Item>();
            itemPopupText.text = item.itemNameUI.text + "\n" + item.itemPriceUI.text + " Scrap\n" + item.itemDetailsUI.text;
        }
        else
        {
            itemPopupObject.SetActive(false);
        }
    }
}
