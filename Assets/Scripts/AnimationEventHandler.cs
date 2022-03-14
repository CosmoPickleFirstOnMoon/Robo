using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    public delegate void WeaponSwitch();
    public event WeaponSwitch OnWeaponSwitchStart;
    public event WeaponSwitch OnWeaponSwitchEnd;
    public event WeaponSwitch OnWeaponClosedEnd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnWeaponSwitchStarted(float val)
    {
        OnWeaponSwitchStart?.Invoke();
    }
    public void OnWeaponSwitchEnded(float val)
    {
        OnWeaponSwitchEnd?.Invoke();
    }

    public void OnWeaponClosedEnded(float val)
    {
        OnWeaponClosedEnd?.Invoke();

    }

}
