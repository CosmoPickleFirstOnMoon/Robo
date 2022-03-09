using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WeaponLoadout : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    private List<Weapon> weapons = new List<Weapon>();
    [SerializeField]
    private GameObject currentGun;
    // Start is called before the first frame update
    void Start()
    {
        weapons = GetComponents<Weapon>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            currentGun.SetActive(!currentGun.activeInHierarchy);

        }
        if (currentGun.activeInHierarchy)
        {
            animator.SetLayerWeight(animator.GetLayerIndex("FrontalMovementWithGun"), 1);
            animator.SetLayerWeight(animator.GetLayerIndex("SideMovementWIthGun"), 1);

        }
        else
        {
            animator.SetLayerWeight(animator.GetLayerIndex("FrontalMovementWithGun"), 0);
            animator.SetLayerWeight(animator.GetLayerIndex("SideMovementWIthGun"), 0);

        }
    }
}
