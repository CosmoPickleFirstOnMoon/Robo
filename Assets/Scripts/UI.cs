using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [Header("Player UI")]
    public TextMeshProUGUI healthValueUI;
    public TextMeshProUGUI energyValueUI;

    [Header("Popup UI")]
    public GameObject itemPopupObject;
    public TextMeshProUGUI itemPopupText;       //displays item text such as name, price, description, etc.

    [Header("Sliders")]
    public Slider healthMeter;              //red colour
    public Slider healthSecondaryMeter;        //yellow colour when damaged, light blue when healing
    public Slider energyMeter;              //green colour
    public Slider energySecondaryMeter;        //yellow colour when damaged, light blue when healing
    public Slider durabilityMeter;          //yellow colour
    public Slider durabilitySecondaryMeter;    //red colour when damaged, light blue when healing
    [SerializeField]float meterRate;  //used to control the speed of the meter gain/loss
    Color healColor;
    Color damageColor;
    Color durabilityDamageColor;
    Image healthSecondaryColor;
    Image durabilitySecondaryColor;
    Image energySecondaryColor;

    //coroutine checks
    bool adjustMeterCoroutineOn;
    bool test;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = Player.instance;
        
        //item popup UI is off by default, and only appears when mouse hovers over an item
        itemPopupObject.SetActive(false);

        //slider setup
        Debug.Log(player.health + "/" + player.maxHealth);
        healthMeter.value = player.health / player.maxHealth;
        healthSecondaryMeter.value = healthMeter.value;
        energyMeter.value = player.energy / player.maxEnergy;
        energySecondaryMeter.value = energyMeter.value;
        
        healColor = new Color(0.3f, 0.9f, 1);               //light blue
        damageColor = new Color(1, 0.76f, 0.05f);           //gold
        durabilityDamageColor = new Color(0.7f, 0.06f, 0);  //dark red
        meterRate = 0.3f;
        healthSecondaryColor = healthSecondaryMeter.fillRect.GetComponent<Image>();
        energySecondaryColor = energySecondaryMeter.fillRect.GetComponent<Image>();
        durabilitySecondaryColor = durabilitySecondaryMeter.fillRect.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //update player data
        healthValueUI.text = player.health + "/" + player.maxHealth;
        energyValueUI.text = player.energy + "/" + player.maxEnergy;

        //update meters
        //healthMeter.value = player.health / player.maxHealth;
        //energyMeter.value = player.energy / player.maxEnergy;

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

        /*******FOR TESTING ONLY*******/
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player.health -= 20;
            if (player.health < 0)
                player.health = 0;

            healthMeter.value = player.health / player.maxHealth;
            healthSecondaryColor.color = damageColor;
            StartCoroutine(AdjustMeter(healthMeter, healthSecondaryMeter));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            player.health += 20;
            if (player.health > player.maxHealth)
                player.health = player.maxHealth;
            
            healthSecondaryMeter.value = player.health / player.maxHealth;
            healthSecondaryColor.color = healColor;
            StartCoroutine(AdjustMeter(healthMeter, healthSecondaryMeter, true));
        }

        //coroutine checks
        /*if (!adjustMeterCoroutineOn)
        {
            StartCoroutine(AdjustMeter(healthMeter, healthSecondaryMeter));
        }*/
    }

    #region Coroutines

    //this coroutine will be used for all sliders.
    IEnumerator AdjustMeter(Slider meter, Slider secondaryMeter, bool isRecovering = false)
    {
        adjustMeterCoroutineOn = true;
        //a slight delay is added to give player time to see what is happening
        yield return new WaitForSeconds(1);

        if (!isRecovering)
        {            
            while (secondaryMeter.value > meter.value)
            {
                secondaryMeter.value -= meterRate * Time.unscaledDeltaTime; //I use unscaled time so the rate is consistent
                yield return null;
            }

            secondaryMeter.value = meter.value;

        }
        else    //player is recovering
        {
            while (meter.value < secondaryMeter.value)
            {
                meter.value += meterRate * Time.unscaledDeltaTime;
                yield return null;
            }

            meter.value = secondaryMeter.value;
        }

        adjustMeterCoroutineOn = false;
    }

    #endregion
}
