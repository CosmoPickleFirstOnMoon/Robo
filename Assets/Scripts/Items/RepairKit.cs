using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//restores 50% health
public class RepairKit : Item
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Player"))
        {
            effect.Activate(target.GetComponent<Player>());
            //target.GetComponent<Player>().health += 50;
            Destroy(gameObject);
        }
    }
}
