using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WeaponLoadout : MonoBehaviour
{
    private List<Weapon> weapons = new List<Weapon>();

    // Start is called before the first frame update
    void Start()
    {
        weapons = GetComponents<Weapon>().ToList();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
