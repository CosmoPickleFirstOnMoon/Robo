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
    //Color healColor;
 //   Color damageColor;
//    Color durabilityDamageColor;
    [HideInInspector]public Image healthSecondaryColor;
    Image durabilitySecondaryColor;
    [HideInInspector]public Image energySecondaryColor;

    //coroutine checks
    bool adjustMeterCoroutineOn;
    bool reduceHealthCoroutineOn;
    bool restoreHealthCoroutineOn;
    bool healingCoroutineOn;

    Player player;
    public static UI instance;

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
        player = Player.instance;
        
        //item popup UI is off by default, and only appears when mouse hovers over an item
        itemPopupObject.SetActive(false);

        //slider setup
        Debug.Log(player.health + "/" + player.maxHealth);
        healthMeter.value = player.health / player.maxHealth;
        healthSecondaryMeter.value = healthMeter.value;
        energyMeter.value = player.energy / player.maxEnergy;
        energySecondaryMeter.value = energyMeter.value;
        
        //healColor = new Color(0.3f, 0.9f, 1);               //light blue
        //damageColor = new Color(1, 0.76f, 0.05f);           //gold
        //durabilityDamageColor = new Color(0.7f, 0.06f, 0);  //dark red
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
        energyValueUI.text = Mathf.Round(player.energy) + "/" + player.maxEnergy;

        //update meters     
        //healthMeter.value = player.health / player.maxHealth;
        //if (player.EnergyRegenerating())
        //{
            energyMeter.value = player.energy / player.maxEnergy;

            if (!adjustMeterCoroutineOn)
                energySecondaryMeter.value = energyMeter.value;
        //}

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

            StartCoroutine(ReduceHealthMeter());

            player.ReduceEnergy(20);
            StartCoroutine(AdjustMeter(energyMeter, energySecondaryMeter, energySecondaryColor, player.energy, player.maxEnergy));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            player.health += 20;
            if (player.health > player.maxHealth)
                player.health = player.maxHealth;
            
            StartCoroutine(RestoreHealthMeter());

            player.energy += 20;
            if (player.energy > player.maxEnergy)
                player.energy = player.maxEnergy;
            StartCoroutine(AdjustMeter(energyMeter, energySecondaryMeter, energySecondaryColor, player.energy, player.maxEnergy, true));
        }

        //coroutine checks
        /*if (!adjustMeterCoroutineOn)
        {
            StartCoroutine(AdjustMeter(healthMeter, healthSecondaryMeter));
        }*/
    }

    public void ChangeHealthMeter(bool healing = false)
    {
        if (!healing)
        {
            StartCoroutine(ReduceHealthMeter());
        }
        else
        {
            StartCoroutine(RestoreHealthMeter());
        }
    }

    public void ChangeEnergyMeter(bool healing = false)
    {
        if (!healing)
            StartCoroutine(AdjustMeter(energyMeter, energySecondaryMeter, energySecondaryColor, player.energy, player.maxEnergy));
        else
            StartCoroutine(AdjustMeter(energyMeter, energySecondaryMeter, energySecondaryColor, player.energy, player.maxEnergy, isRecovering: true));
    }

    //this is used for when sliders need to be updated after equipping/removing items
    public void UpdateMeters()
    {
        healthMeter.value = player.health / player.maxHealth;
        healthSecondaryMeter.value = healthMeter.value;
        energyMeter.value = player.energy / player.maxEnergy;
        energySecondaryMeter.value = energyMeter.value;
        //TODO: add update for durability meter
    }



    #region Coroutines

    //this coroutine will be used for all sliders.
    public IEnumerator ReduceHealthMeter()
    {
        Color damageColor = new Color(1, 0.76f, 0.05f);           //gold

        if (!healingCoroutineOn)   //if damaged while healing, we don't run this part of the routine
        {
            reduceHealthCoroutineOn = true;
            healthMeter.value = player.health / player.maxHealth;              //show the portion that is being removed
            healthSecondaryColor.color = damageColor;            
            yield return new WaitForSeconds(0.5f);             //a slight delay is added to give player time to see what is happening

            while (healthSecondaryMeter.value > healthMeter.value)
            {
                healthSecondaryMeter.value -= meterRate * Time.unscaledDeltaTime; //I use unscaled time so the rate is consistent
                healthMeter.value = player.health / player.maxHealth;   //health is continuously checked in case player heals while secondary slider is updating
                yield return null;
            }

            healthSecondaryMeter.value = healthMeter.value;
            reduceHealthCoroutineOn = false;

        }
    }

    IEnumerator RestoreHealthMeter()
    {
        Color healColor = new Color(0.3f, 0.9f, 1);               //light blue

        if (!reduceHealthCoroutineOn)
        {
            healingCoroutineOn = true;
            healthSecondaryMeter.value = player.health / player.maxHealth; //show the portion that is being recovered
            healthSecondaryColor.color = healColor;
            yield return new WaitForSeconds(0.5f);

            while (healthMeter.value < healthSecondaryMeter.value)
            {
                healthMeter.value += meterRate * Time.unscaledDeltaTime;
                healthSecondaryMeter.value = player.health / player.maxHealth;  //if player is damaged while UI updating, we only update secondary meter
                yield return null;
            }

            healthMeter.value = healthSecondaryMeter.value;
            healingCoroutineOn = false;
        }
    }

    //TODO: This coroutine to be removed
    public IEnumerator AdjustMeter(Slider meter, Slider secondaryMeter, Image secondaryMeterColor, float currentValue, float maxValue, bool isRecovering = false)
    {
        adjustMeterCoroutineOn = true;
        Color healColor = new Color(0.3f, 0.9f, 1);               //light blue
        Color damageColor = new Color(1, 0.76f, 0.05f);           //gold
        Color durabilityDamageColor = new Color(0.7f, 0.06f, 0);  //dark red

        if (!isRecovering)
        {
            secondaryMeter.value = meter.value;
            meter.value = currentValue / maxValue;              //show the portion that is being removed
            secondaryMeterColor.color = damageColor;            
            yield return new WaitForSeconds(0.5f);             //a slight delay is added to give player time to see what is happening

            while (secondaryMeter.value > meter.value)
            {
                secondaryMeter.value -= meterRate * Time.unscaledDeltaTime; //I use unscaled time so the rate is consistent
                yield return null;
            }

            secondaryMeter.value = meter.value;

        }
        else    //player is recovering
        {
            meter.value = secondaryMeter.value;
            secondaryMeter.value = currentValue / maxValue; //show the portion that is being recovered
            secondaryMeterColor.color = healColor;
            yield return new WaitForSeconds(0.5f);

            while (meter.value < secondaryMeter.value)
            {
                meter.value += meterRate * Time.unscaledDeltaTime;
                secondaryMeter.value = player.health / player.maxHealth;
                yield return null;
            }

            meter.value = secondaryMeter.value;
        }

        adjustMeterCoroutineOn = false;
    }

    #endregion
}
