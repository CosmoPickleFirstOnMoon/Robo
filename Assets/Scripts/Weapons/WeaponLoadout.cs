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
    private AnimationEventHandler eventHandler;
    [SerializeField]
    private Transform gunHolder;

    private List<Weapon> weapons = new List<Weapon>();
    [SerializeField]
    private Weapon currentWeapon;
    private int currentIndex = 0;
    private int lastIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        weapons = gunHolder.GetComponentsInChildren<Weapon>(true).ToList();
        if (weapons.Count > 0)
            currentWeapon = weapons[currentIndex];
        else
            Debug.Log("Weapons Are Missing");
        eventHandler.OnWeaponSwitchStart += EventHandler_OnWeaponSwitchStarted;
        eventHandler.OnWeaponSwitchEnd += EventHandler_OnWeaponSwitchEnded;
        eventHandler.OnWeaponClosedEnd += EventHandler_OnWeaponClosedEnded;
    }

    private void EventHandler_OnWeaponSwitchStarted()
    {
        currentWeapon.gameObject.SetActive(true);
        currentWeapon.OnWeaponOpen();

    }

    private void EventHandler_OnWeaponClosedEnded()
    {
        weapons[lastIndex].OnWeaponClose();
        weapons[lastIndex].gameObject.SetActive(false);

        animator.SetTrigger("Open Weapon");
    }

    private void EventHandler_OnWeaponSwitchEnded()
    {


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
        lastIndex = currentIndex;
        currentIndex = (currentIndex + dir + weapons.Count) % weapons.Count;
        if (lastIndex == currentIndex) return;

        currentWeapon = weapons[currentIndex];
        SetStance();
        animator.SetTrigger("Close Weapon");

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
        animator.SetTrigger("Reload");
        currentWeapon.OnReload();
    }

    private void SetStance()
    {
        if (currentWeapon.GetType() != typeof(Hands))
        {
            animator.SetLayerWeight(animator.GetLayerIndex("FrontalMovementWithGun"), 1);
            animator.SetLayerWeight(animator.GetLayerIndex("SideMovementWIthGun"), 1);
            animator.SetBool("HoldsGun", true);

        }
        else
        {
            animator.SetLayerWeight(animator.GetLayerIndex("FrontalMovementWithGun"), 0);
            animator.SetLayerWeight(animator.GetLayerIndex("SideMovementWIthGun"), 0);
            animator.SetBool("HoldsGun", false);

        }

    }

    public void OnSwitchWeaponEnded(float value)
    {
        Debug.Log("Changed");
    }

}
