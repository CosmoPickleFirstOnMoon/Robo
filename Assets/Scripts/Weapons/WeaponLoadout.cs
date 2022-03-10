using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class WeaponLoadout : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Transform gunHolder;

    private List<Weapon> weapons = new List<Weapon>();
    [SerializeField]
    private Weapon currentWeapon;
    private int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        weapons = gunHolder.GetComponentsInChildren<Weapon>(true).ToList();
        if (weapons.Count > 0)
            currentWeapon = weapons[currentIndex];
        else
            Debug.Log("Weapons Are Missing");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            currentWeapon.gameObject.SetActive(!currentWeapon.gameObject.activeInHierarchy);

        }
    }

    public void OnMouseWheel(int dir)
    {
        Debug.Log("Change: " + weapons.Count);
        int newIndex = (currentIndex + dir) % weapons.Count;
        if (newIndex == currentIndex) return;

        currentWeapon.OnWeaponClose();
        currentWeapon.gameObject.SetActive(false);

        currentWeapon = weapons[newIndex];
        currentWeapon.gameObject.SetActive(true);
        currentWeapon.OnWeaponOpen();

        currentIndex = newIndex;
        SetStance();
    }
    public void OnLeftClickUp()
    {
        currentWeapon.OnFireReleased();
    }

    public void OnLeftClickDown()
    {
        currentWeapon.OnFireDown();
    }

    public void OnLeftClickHold()
    {
        currentWeapon.OnFireHold();
    }
    public void OnReload()
    {
        currentWeapon.OnReload();
    }

    private void SetStance()
    {
        if (currentWeapon.GetType() != typeof(Hands))
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
