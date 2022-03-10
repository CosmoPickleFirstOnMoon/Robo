using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI healthValueUI;
    public TextMeshProUGUI energyValueUI;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = Player.instance;

    }

    // Update is called once per frame
    void Update()
    {
        healthValueUI.text = player.health.ToString();
        energyValueUI.text = player.energy.ToString();
    }
}
